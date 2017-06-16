﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DeltaImpuls2.Models
{
    public class ls
    {
        public int ID { get; set; }
        [Required, DisplayName("Licentie"), StringLength(3, MinimumLength = 1, ErrorMessage = "Licentie is niet correct ingevoerd")]
        [RegularExpression(@"^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð-]+$",
            ErrorMessage = "Licentie is niet correct ingevoerd")]
        public string license { get; set; }

        public virtual ICollection<members> members { get; set; }
    }
}