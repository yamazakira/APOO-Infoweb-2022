using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;
using Modelos.Procedimentos;
using Modelos.Animal;
using Modelos.Users;
using Persistencias.Migrations;

namespace Persistencia.Contexts
{
    public class EFContext : DbContext
    {
        public EFContext() : base("Asp_Net_MVC_CS")
        {
            Database.SetInitializer<EFContext>(new
                MigrateDatabaseToLatestVersion<EFContext, Configuration>());
        }
        public DbSet<Exame> Exames { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Especie> Especies { get; set; }
        public DbSet<Pet> Pets{ get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Veterinario> Veterinarios { get; set; }
        public DbSet<Secretario> Secretarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }


    }
}