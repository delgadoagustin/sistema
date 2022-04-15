using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Models
{
    public interface IDB
    {
        IRepositorioInforme RepositorioInforme { get; set; }
        IRepositorioPaciente RepositorioPaciente { get; set; }
        IRepositorioUsuario RepositorioUsuario { get; set; }
    }
    public class SQLiteDB : IDB
    {
        public IRepositorioInforme RepositorioInforme { get; set; }
        public IRepositorioPaciente RepositorioPaciente { get; set; }
        public IRepositorioUsuario RepositorioUsuario { get; set; }

        public SQLiteDB(string cadena)
        {
            RepositorioInforme = new SQLiteRepositorioInforme(cadena);
            RepositorioPaciente = new SQLiteRepositorioPaciente(cadena);
            RepositorioUsuario = new SQLiteRepositorioUsuario(cadena);
        }
    }
}
