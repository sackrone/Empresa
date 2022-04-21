using System;
using System.ComponentModel.DataAnnotations;

namespace Empresa.Models.ViewModels
{
    public class EmpleadosViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(50)]
        public string Correo { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Nacimiento")]
        public DateTime FechaNacimiento { get; set; }
    }
}