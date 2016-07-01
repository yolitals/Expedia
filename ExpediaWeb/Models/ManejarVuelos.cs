using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace ExpediaWeb.Models
{
    public class ManejarVuelos
    {
        public int ID { get; set; }

        [Required]
        public string Desde { get; set; }

        [Required]
        public string Hacia { get; set; }

        [DataType(DataType.Date)]
        public DateTime fechaIda { get; set; }

        [DataType(DataType.Date)]
        public DateTime fechaRegreso { get; set; }        

        [Required]
        public int numAdulto { get; set; }

        [Required]
        public int numNinos { get; set; }
    }
}