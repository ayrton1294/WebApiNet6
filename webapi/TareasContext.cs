using Microsoft.EntityFrameworkCore;
using webapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoEF
{
    public class TareasContext : DbContext
    {
        //protected readonly IConfiguration _configuration;

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Tarea> Tareas { get; set; }

        //public TareasContext(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(_configuration.GetConnectionString("cnTareas"));
        //}

        public TareasContext(DbContextOptions<TareasContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            List<Categoria> categoriasInit = new List<Categoria>();
            categoriasInit.Add(new Categoria{CategoriaId = Guid.Parse("c4e0d0e7-5f06-48c7-9246-11fe12f2c657"),Nombre = "Actividades pendientes",Peso = 20});
            categoriasInit.Add(new Categoria{CategoriaId = Guid.Parse("c4e0d0e7-5f06-48c7-9246-11fe12f2c602"),Nombre = "Actividades personales",Peso = 50});

            modelBuilder.Entity<Categoria>(categoria =>
            {
                categoria.ToTable("Categoria");
                categoria.HasKey(m => m.CategoriaId);

                categoria.Property(m => m.Nombre).IsRequired().HasMaxLength(150);

                categoria.Property(m => m.Descripcion).IsRequired(false);

                categoria.Property(m => m.Peso);

                categoria.HasData(categoriasInit);
            });

            List<Tarea> tareasInit = new List<Tarea>();
            tareasInit.Add(new Tarea() { TareaId = Guid.Parse("c4e0d0e7-5f06-48c7-9246-11fe12f2c610"),CategoriaId = Guid.Parse("c4e0d0e7-5f06-48c7-9246-11fe12f2c657"), PrioridadTarea = Prioridad.Media, Titulo = "Pago de servicios públicos", FechaCreacion = DateTime.Now , Tipo = "Fin de mes"});
            tareasInit.Add(new Tarea() { TareaId = Guid.Parse("c4e0d0e7-5f06-48c7-9246-11fe12f2c611"),CategoriaId = Guid.Parse("c4e0d0e7-5f06-48c7-9246-11fe12f2c602"), PrioridadTarea = Prioridad.Baja, Titulo = "Terminar de ver pelicula en Netflix", FechaCreacion = DateTime.Now , Tipo = "Rutinaria"});

            modelBuilder.Entity<Tarea>(tarea =>
            {
                tarea.ToTable("Tarea");
                tarea.HasKey(m => m.TareaId);

                tarea.Property(m => m.Titulo).IsRequired().HasMaxLength(200);

                tarea.Property(m => m.Tipo);

                tarea.Property(m => m.Descripcion).IsRequired(false);

                tarea.Property(m => m.PrioridadTarea);

                tarea.Property(m => m.FechaCreacion);

                tarea.HasOne(m => m.Categoria).WithMany(m => m.Tareas).HasForeignKey(m => m.CategoriaId);

                tarea.Ignore(m => m.Resumen);

                tarea.HasData(tareasInit);
            });

        }
    }
}
