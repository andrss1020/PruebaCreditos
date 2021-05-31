using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PruebaCreditos.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaCreditos.AccesoDatos.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Credito> Credito { get; set; }
        public DbSet<Amortizacion> Amortizacion { get; set; }
    }
}
