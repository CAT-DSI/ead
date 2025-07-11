using EAD.Interfaces;

namespace EAD.Models
{
    public class Domain : IValidable
    {
        public string Name { get; set; }

        public string Path { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Name)
                && !string.IsNullOrEmpty(Path);
        }
    }
}