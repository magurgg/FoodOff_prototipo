using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pusher_realtime_table.Models
{
    public class RealtimeTable
    {
        [Key]
        public int id { get; set; }
        [Required]
        [MaxLength(100)]
        public string title { get; set; }
        [Required]
        [MaxLength(100)]
        public string Nombre_Foodtruck { get; set;  }
        [Required]
        public int year { get; set; }
        [Required]
        [MaxLength(2000)]
        public string Desc_Orden { get; set; }
        [Required]
        [MaxLength(100)]
        public string Metodo_Pago { get; set; }
    }
}
