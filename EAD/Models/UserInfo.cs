using EAD.Attributes;
using EAD.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace EAD.Models
{
    public class UserInfo
    {
        [Display(Name = "ObjectSid")]
        [PropertyName("ObjectSid")]
        public string ObjectSid { get; set; }

        [Display(Name = "DistinguishedName")]
        [PropertyName("distinguishedName")]
        public string DistinguishedName { get; set; }

        [Display(Name = "UserPrincipalName")]
        [PropertyName("userPrincipalName")]
        public string UserPrincipalName { get; set; }

        [Display(Name = "UserLogin")]
        [PropertyName("sAMAccountName")]
        public string UserLogin { get; set; }

        [Display(Name = "FirstName")]
        [PropertyName("givenName")]
        public string FirstName { get; set; }

        [Display(Name = "LastName")]
        [PropertyName("sn")]
        public string LastName { get; set; }

        [Display(Name = "DisplayName")]
        [PropertyName("displayName")]
        public string DisplayName { get; set; }

        [Display(Name = "Company")]
        [PropertyName("company")]
        public string Company { get; set; }

        [Display(Name = "Department")]
        [PropertyName("department")]
        public string Department { get; set; }

        [Display(Name = "Title")]
        [PropertyName("title")]
        public string Title { get; set; }

        [Display(Name = "StreetAddress")]
        [MaxLength(100)]
        [PropertyName("streetAddress")]
        public string StreetAddress { get; set; }

        [Display(Name = "PostalCode")]
        [PropertyName("postalCode")]
        public string PostalCode { get; set; }

        [Display(Name = "City")]
        [PropertyName("l")]
        public string City { get; set; }

        [Display(Name = "Country")]
        [PropertyName("countryCode")]
        public Country Country { get; set; }

        [Display(Name = "Email")]
        [PropertyName("mail")]
        public string Email { get; set; }

        [Display(Name = "MobileNumber")]
        [PropertyName("mobile")]
        public string MobileNumber { get; set; }

        [Display(Name = "TelephoneNumber")]
        [PropertyName("telephoneNumber")]
        public string TelephoneNumber { get; set; }
    }
}