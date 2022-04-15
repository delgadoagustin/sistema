using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Models.Entidades
{
    public class Informe
    {
        [Display(Name = "ID")]
        public int InformeId { get; set; }

        [Display(Name = "Paciente")]
        [Required(ErrorMessage ="Este campo es obligatorio")]
        public int InformePacienteId { get; set; }

        [Display(Name = "Medico")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int InformeUsuarioId { get; set; }

        [Display(Name = "Detalle")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string InformeDetalle { get; set; }
    }
}
