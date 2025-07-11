using System;
using System.ComponentModel.DataAnnotations;

namespace EAD.ViewModels
{
    public class BarcodeFileViewModel
    {
        [Display(Name = "Barcode")]
        public string Barcode { get; set; }

        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "OrgUnit")]
        public string OrgUnit { get; set; }

        [Display(Name = "Path")]
        public string Path { get; set; }

        [Display(Name = "RemotePath")]
        public string RemotePath { get; set; }
    }
}