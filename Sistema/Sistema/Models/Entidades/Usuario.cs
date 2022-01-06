using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Models.Entidades
{
    public class Usuario
    {
        int id;
        string nombre;
        string pass;
        char nivel;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Pass { get => pass; set => pass = value; }
        public char Nivel { get => nivel; set => nivel = value; }
    }
}
