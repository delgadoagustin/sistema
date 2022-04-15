using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Models.Entidades
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string UsuarioNombre { get; set; }
        public string UsuarioPass { get; set; }
        public string UsuarioNivel { get; set; }
    }
}
