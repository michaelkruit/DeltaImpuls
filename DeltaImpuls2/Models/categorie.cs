﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DeltaImpuls2.Models
{
    public class categorie
    {
        public int ID { get; set; }
        [Required, DisplayName("Categorie")]
        [RegularExpression(@"^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð-]+$",
            ErrorMessage = "Er is geen correcte categorie ingevoerd")]
        public string name { get; set; }
        [Required, DisplayName("Leeftijd")]
        public Nullable<byte> age { get; set; }

        public virtual ICollection<members> members { get; set; }
    }
}