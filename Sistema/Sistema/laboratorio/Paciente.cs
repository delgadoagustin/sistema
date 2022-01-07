using System;
using System.Collections.Generic;

#nullable disable

namespace Sistema.laboratorio
{
    public partial class Paciente
    {
        public int PacienteId { get; set; }
        public string PacienteNombre { get; set; }
        public string PacienteEmail { get; set; }
        public string PacienteTelefono { get; set; }
        public string PacienteDni { get; set; }
        public DateTime PacienteFechaNac { get; set; }
        public string PacienteSexo { get; set; }
    }
}
