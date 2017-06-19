using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DeltaImpuls2.Models
{
    /// <summary>
    /// Gets and sets the locations
    /// </summary>
    public class location
    {
        public int ID { get; set; }
        [Required, DisplayName("Plaats"), StringLength(25)]
        [RegularExpression(@"^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð-]+$",
            ErrorMessage = "Er is geen correcte plaats ingevoerd")]
        public string city { get; set; }
        [Required, DisplayName("Postcode")]
        [DataType(DataType.PostalCode), StringLength(7, MinimumLength = 4)]
        [RegularExpression(@"^[1-9][0-9]{3}\s?[a-zA-Z]{2}$", ErrorMessage = "Postcode is niet correct ingevuld")]
        public string postcode { get; set; }
        [Required, DisplayName("Adres"), StringLength(25)]
        public string adres { get; set; }

        public virtual ICollection<members> members { get; set; }
    }
}
