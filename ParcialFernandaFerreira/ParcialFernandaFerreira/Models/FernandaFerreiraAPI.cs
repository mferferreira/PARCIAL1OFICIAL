using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ParcialFernandaFerreira.Models
{
    public class FernandaFerreiraAPI
    {
        [Key]
        public int alpha3Code { get; set; }

        [Required]
        [DisplayName("Ingrese la región")]
        public Place region { get; set; }

        public string flag { get; set; }

        [Required]
        [DisplayName("Ingrese el país")]
        public string name { get; set; }

        [DisplayName("Ingrese el area")]
        public int area { get; set; }

        [Required]
  
        public int callingCodes { get; set; }

        [Required]
        [DisplayName("Ingrese el idioma")]
        public string languages { get; set; }

        public enum Place
        {
            SudAmerica,
            NorteAmerica,
            CentroAmerica,
            Asia,
            Oceania,
        }


    }

}