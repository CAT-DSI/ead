using EAD.Interfaces;

namespace EAD.Helpers
{
    /// <summary>
    /// Validation helper methods
    /// </summary>
    public static class ValidationHelper
    {
        /// <summary>
        /// Check if <paramref name="obj"/> is valud
        /// </summary>
        /// <param name="obj"><typeparamref name="T"/> object</param>
        public static bool Validate<T>(T obj) where T : IValidable
        {
            return obj != null && obj.IsValid();
        }
    }
}
