using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoIntegradorTelas.Models;
using System.Data.Entity;

namespace ProjetoIntegradorTelas.Context
{
    public class EFContext : DbContext
    {
        public EFContext() : base("connection_integrador") { }
        public DbSet<paciente> Cadastros { get; set; }
        public DbSet<medico> Medicos { get; set; }
    }
}