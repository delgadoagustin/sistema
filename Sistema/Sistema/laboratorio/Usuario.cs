using System;
using System.Collections.Generic;

#nullable disable

namespace Sistema.laboratorio
{
    public partial class Usuario
    {
        public int UsuarioId { get; set; }
        public string UsuarioNombre { get; set; }
        public string UsuarioPass { get; set; }
        public string UsuarioNivel { get; set; }
    }
}
