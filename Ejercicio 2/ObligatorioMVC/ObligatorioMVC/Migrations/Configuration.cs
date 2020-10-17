namespace ObligatorioMVC.Migrations
{
    using ObligatorioMVC.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ObligatorioMVC.Context.InstitutoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ObligatorioMVC.Context.InstitutoContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Carreras.AddOrUpdate(a => a.Codigo,
                new Carrera { Codigo = "AP", Nombre = "Analista Programador" },
                new Carrera { Codigo = "TECGER", Nombre = "T�cnico en Gerencia" },
                new Carrera { Codigo = "PER", Nombre = "Periodismo" });
            context.Asignaturas.AddOrUpdate(a => a.Codigo,
                new Asignatura { Codigo = "PROG", Nombre = "Programaci�n", NombreCarrera = "Analista Programador", Exonerable = false, GananciaCurso = true },
                new Asignatura { Codigo = "BD", Nombre = "Base de Datos", NombreCarrera = "Analista Programador", Exonerable = true, GananciaCurso = true },
                new Asignatura { Codigo = "ADM", Nombre = "Administraci�n", NombreCarrera = "T�cnico en Gerencia", Exonerable = false, GananciaCurso = true },
                new Asignatura { Codigo = "CONT", Nombre = "Contabilidad", NombreCarrera = "T�cnico en Gerencia", Exonerable = true, GananciaCurso = true },
                new Asignatura { Codigo = "LOC", Nombre = "Locuci�n", NombreCarrera = "Periodismo", Exonerable = false, GananciaCurso = true },
                new Asignatura { Codigo = "TINFO", Nombre = "Teor�a de la Informaci�n", NombreCarrera = "Periodismo", Exonerable = true, GananciaCurso = true });

        }
    }
}
