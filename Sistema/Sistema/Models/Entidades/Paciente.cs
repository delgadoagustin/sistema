using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Models.Entidades
{
    public class Paciente
    {
        int id;
        string nombre;
        string email;
        string telefono;
        string dni;
        char sexo;
        DateTime fechaNac;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Email { get => email; set => email = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Dni { get => dni; set => dni = value; }
        public char Sexo { get => sexo; set => sexo = value; }
        public DateTime FechaNac { get => fechaNac; set => fechaNac = value; }
    }
}
