using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace MvcCrud.Models
{
    public partial class ActaNota
    {
        [DisplayName("Id")]
        public int IdNotasE { get; set; }

        [DisplayName("No. Carnet")]
        [Required]
        public string? Carnet { get; set; }

        [DisplayName("Nombres")]
        [Required]
        public string? Nombre { get; set; }

        [DisplayName("Apellidos")]
        [Required]
        public string? Apellido { get; set; }

        [DisplayName("Primer Parcial")]
        [Required]
        [Range(0,35)]
        public short? Ipn { get; set; }

        [DisplayName("Segundo Parcial")]
        [Required]
        [Range(0,35)]
        public short? Iipn { get; set; }

        [DisplayName("Sistematicos")]
        [Required]
        [Range(0, 30)]
        public short? Siste { get; set; }

        [DisplayName("Proyecto")]
        [Required]
        [Range(0, 35)]
        public short? Proyect { get; set; }

        [DisplayName("Nota Final")]
        public short? Nf { get; set; }
    }
}
