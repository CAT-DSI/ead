using Newtonsoft.Json;

namespace EAD.Helpers
{
    /// <summary>
    /// JSON helper methods
    /// </summary>
    public static class JsonHelper
    {
        /// <summary>
        /// Converting <paramref name="json"/> into <typeparamref name="T"/> object
        /// </summary>
        /// <param name="json">JSON value</param>
        public static T FromJson<T>(this string json)
        {
            return !string.IsNullOrEmpty(json) ? JsonConvert.DeserializeObject<T>(json) : default;
        }

        /// <summary>
        /// Converting <paramref name="obj"/> into JSON
        /// </summary>
        /// <param name="obj">Object to convert</param>
        public static string ToJson(this object obj)
        {
            return obj == null ? null : JsonConvert.SerializeObject(obj);
        }
    }
}
