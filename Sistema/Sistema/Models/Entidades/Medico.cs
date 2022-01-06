using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Models.Entidades
{
    public class Medico
    {
        int id;
        string nombre;
        string matricula;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Matricula { get => matricula; set => matricula = value; }
    }
}
