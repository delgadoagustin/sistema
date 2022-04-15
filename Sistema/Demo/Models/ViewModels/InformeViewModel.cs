using Demo.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Models.ViewModels
{
    public class InformeViewModel
    {
        public Informe informe;
        public List<Usuario> usuarios { get; set; }
        public List<Paciente> pacientes { get; set; }
        public InformeViewModel(List<Usuario> usuarios,List<Paciente> pacientes)
        {
            this.pacientes = pacientes;
            this.usuarios = usuarios;
        }
    }
}
