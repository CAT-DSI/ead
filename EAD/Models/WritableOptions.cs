using EAD.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace EAD.Models
{
    public class WritableOptions<T> : IWritableOptions<T> where T : class, new()
    {
        private readonly IWebHostEnvironment _environment;

        private readonly string _file;

        private readonly IOptionsMonitor<T> _options;

        private readonly string _section;

        public WritableOptions(IWebHostEnvironment environment, IOptionsMonitor<T> options, string section, string file)
        {
            _environment = environment;
            _options = options;
            _section = section;
            _file = file;
        }

        public T Value => _options.CurrentValue;

        public T Get(string name) => _options.Get(name);

        public void Update(Action<T> applyChanges)
        {
            IFileProvider fileProvider = _environment.ContentRootFileProvider;
            IFileInfo fileInfo = fileProvider.GetFileInfo(_file);
            string physicalPath = fileInfo.PhysicalPath;

            JObject jObject = JsonConvert.DeserializeObject<JObject>(File.ReadAllText(physicalPath));
            T sectionObject = jObject.TryGetValue(_section, out JToken section) ? JsonConvert.DeserializeObject<T>(section.ToString()) : (Value ?? new T());

            applyChanges(sectionObject);

            jObject[_section] = JObject.Parse(JsonConvert.SerializeObject(sectionObject));
            File.WriteAllText(physicalPath, JsonConvert.SerializeObject(jObject, Formatting.Indented));
        }
    }
}