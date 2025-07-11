using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace EAD.Extensions
{
    /// <summary>
    /// Extensions methods for <see cref="ITempDataDictionary"/>
    /// </summary>
    public static class TempDataExtensions
    {
        /// <summary>
        /// Setting notifications to display on frontend
        /// </summary>
        /// <param name="tempData"><see cref="ITempDataDictionary"/> object</param>
        /// <param name="toastType">Notification type</param>
        /// <param name="message">Notification content (message)</param>
        /// <param name="key"><see cref="ITempDataDictionary"/> key</param>
        public static void SetNotification(this ITempDataDictionary tempData, ToastType toastType, string message, string key = "Notification")
        {
            if (tempData != null && toastType != ToastType.Custom && !string.IsNullOrEmpty(message))
            {
                tempData[key] = $"{toastType.ToString().ToLower()}|{message.ToUnicode()}";
            }
        }
    }
}
