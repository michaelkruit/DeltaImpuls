using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DeltaImpuls2.Models
{
    /// <summary>
    /// Gets and sets the members
    /// </summary>
    public class members
    {
        public int ID { get; set; }
        [Required, DisplayName("Voornaam"), StringLength(25)]
        [RegularExpression(@"^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ,.'-]+$",
            ErrorMessage = "Er mogen geen correcte naam ingevoerd")]
        public string firstname { get; set; }
        [Required, DisplayName("Achternaam"), StringLength(25)]
        [RegularExpression(@"^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ,.'-]+$",
            ErrorMessage = "Er mogen geen correcte achternaam ingevoerd")]
        public string lastname { get; set; }
        [DisplayName("T.V."), StringLength(25)]
        [RegularExpression(@"^[A-Z- . a-z]+$", ErrorMessage = "Er mogen geen correcte tussenvoegsel ingevoerd")]
        public string insertion { get; set; }
        [Required, DisplayName("Bondsnmr")]
        public long bondsnr { get; set; }
        [DisplayName("CG")]
        public bool cg { get; set; }
        [DisplayName("Para-TT")]
        public bool paratt { get; set; }
        [Required, DisplayName("Geb. Datum")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime dateborn { get; set; }
        [DisplayName("M/V")]
        public bool gender { get; set; }
        [Required, DisplayName("Lid sinds")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime membersince { get; set; }
        [Required, DisplayName("Adres"), StringLength(25)]
        [RegularExpression(@"^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ,.'-]+$",
            ErrorMessage = "Er is geen correct adres ingevoerd")]
        public string adres { get; set; }
        [Required, DisplayName("Huisnummer")]
        public byte housenumber { get; set; }
        [DisplayName("Toevoeging"),StringLength(5)]
        [RegularExpression(@"^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ,.'-]+$",
            ErrorMessage = "Er is geen correcte toevoeging ingevoerd")]
        public string suffix { get; set; }
        [Required, DisplayName("Postcode")]
        [DataType(DataType.PostalCode), StringLength(7, MinimumLength = 4)]
        [RegularExpression(@"^[1-9][0-9]{3}\s?[a-zA-Z]{2}$", ErrorMessage = "Postcode is niet correct ingevuld")]
        public string postcode { get; set; }
        [Required, DisplayName("Woonplaats"), StringLength(25)]
        [RegularExpression(@"^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ,.'-]+$",
            ErrorMessage = "Er is geen correcte woonplaats ingevoerd")]
        public string city { get; set; }
        [DisplayName("Telefoonnummer")]
        [DataType(DataType.PhoneNumber), StringLength(12, MinimumLength = 6)]
        [RegularExpression(@"^[0-9+-]+$", ErrorMessage = "Niet een correct telefoonnummer")]
        public string phonennumber { get; set; }
        [DisplayName("Mobiel")]
        [RegularExpression(@"^[0-9+-]+$", ErrorMessage = "Niet een correct telefoonnummer")]
        [DataType(DataType.PhoneNumber), StringLength(12, MinimumLength = 10)]
        public string mobilenumber { get; set; }
        [Required, DisplayName("Email"), StringLength(50)]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        public int categorieID { get; set; }
        public int locationID { get; set; }
        public Nullable<int> ljID { get; set; }
        public Nullable<int> lsID { get; set; }

        public virtual categorie categorie { get; set; }
        public virtual location location { get; set; }
        public virtual lj lj { get; set; }        
        public virtual ls ls { get; set; }
    }
}