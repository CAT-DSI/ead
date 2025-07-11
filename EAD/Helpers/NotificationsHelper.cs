using System.ComponentModel.DataAnnotations;

namespace EAD.Helpers
{
    /// <summary>
    /// Notification translation helper (translation keys)
    /// </summary>
    public class NotificationsHelper
    {
        [Display(Name = "BarcodeFileDeleteSuccess")]
        public const string BarcodeFileDeleteSuccess = "BarcodeFileDeleteSuccess";

        [Display(Name = "BarcodeFileDeleteWarning")]
        public const string BarcodeFileDeleteWarning = "BarcodeFileDeleteWarning";

        [Display(Name = "BarcodeFileNotFoundWarning")]
        public const string BarcodeFileNotFoundWarning = "BarcodeFileNotFoundWarning";

        [Display(Name = "BarcodeFileUpdateSuccess")]
        public const string BarcodeFileUpdateSuccess = "BarcodeFileUpdateSuccess";

        [Display(Name = "BarcodeFileUpdateWarning")]
        public const string BarcodeFileUpdateWarning = "BarcodeFileUpdateWarning";

        [Display(Name = "ImportFromFileSuccess")]
        public const string ImportFromFileSuccess = "ImportFromFileSuccess";

        [Display(Name = "ImportFromFileWarning")]
        public const string ImportFromFileWarning = "ImportFromFileWarning";

        [Display(Name = "InvalidModelWarning")]
        public const string InvalidModelWarning = "InvalidModelWarning";

        [Display(Name = "NoPermissionWarning")]
        public const string NoPermissionWarning = "NoPermissionWarning";

        [Display(Name = "OcrConfigurationAddSuccess")]
        public const string OcrConfigurationAddSuccess = "OcrConfigurationAddSuccess";

        [Display(Name = "OcrConfigurationAddWarning")]
        public const string OcrConfigurationAddWarning = "OcrConfigurationAddWarning";

        [Display(Name = "OcrConfigurationAlreadyExistsWarning")]
        public const string OcrConfigurationAlreadyExistsWarning = "OcrConfigurationAlreadyExistsWarning";

        [Display(Name = "OcrConfigurationDeleteSuccess")]
        public const string OcrConfigurationDeleteSuccess = "OcrConfigurationDeleteSuccess";

        [Display(Name = "OcrConfigurationDeleteWarning")]
        public const string OcrConfigurationDeleteWarning = "OcrConfigurationDeleteWarning";

        [Display(Name = "OcrConfigurationNotFoundWarning")]
        public const string OcrConfigurationNotFoundWarning = "OcrConfigurationNotFoundWarning";

        [Display(Name = "OcrConfigurationUpdateSuccess")]
        public const string OcrConfigurationUpdateSuccess = "OcrConfigurationUpdateSuccess";

        [Display(Name = "OcrConfigurationUpdateWarning")]
        public const string OcrConfigurationUpdateWarning = "OcrConfigurationUpdateWarning";
    }
}
