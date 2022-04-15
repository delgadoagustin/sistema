using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Models.Entidades
{
    public class Paciente
    {
        [Key]
        [Display(Name = "ID")]
        public int PacienteId { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(30)]
        [Display(Name = "Nombre")]
        public string PacienteNombre { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string PacienteEmail { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefono")]
        public string PacienteTelefono { get; set; }

        [Display(Name = "DNI")]
        public string PacienteDni { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime PacienteFechaNac { get; set; }

        [Display(Name = "Sexo")]
        public char PacienteSexo { get; set; }
    }
}
