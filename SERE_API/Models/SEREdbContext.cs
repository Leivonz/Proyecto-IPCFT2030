using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SERE_API.Models
{
    public partial class SEREdbContext : DbContext
    {
        public SEREdbContext()
        {
        }

        public SEREdbContext(DbContextOptions<SEREdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Area> Areas { get; set; } = null!;
        public virtual DbSet<Estadoorganizacion> Estadoorganizacions { get; set; } = null!;
        public virtual DbSet<Estadoproyecto> Estadoproyectos { get; set; } = null!;
        public virtual DbSet<Evento> Eventos { get; set; } = null!;
        public virtual DbSet<Od> Ods { get; set; } = null!;
        public virtual DbSet<Organizacion> Organizacions { get; set; } = null!;
        public virtual DbSet<OrganizacionOd> OrganizacionOds { get; set; } = null!;
        public virtual DbSet<OrganizacionPersona> OrganizacionPersonas { get; set; } = null!;
        public virtual DbSet<OrganizacionProyecto> OrganizacionProyectos { get; set; } = null!;
        public virtual DbSet<Pai> Pais { get; set; } = null!;
        public virtual DbSet<Persona> Personas { get; set; } = null!;
        public virtual DbSet<PersonaEvento> PersonaEventos { get; set; } = null!;
        public virtual DbSet<PersonaOd> PersonaOds { get; set; } = null!;
        public virtual DbSet<PersonaProyecto> PersonaProyectos { get; set; } = null!;
        public virtual DbSet<Proyecto> Proyectos { get; set; } = null!;
        public virtual DbSet<ProyectoOd> ProyectoOds { get; set; } = null!;
        public virtual DbSet<TipoEvento> TipoEventos { get; set; } = null!;
        public virtual DbSet<Tipoorganizacion> Tipoorganizacions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SEREdb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>(entity =>
            {
                entity.HasKey(e => e.IdArea)
                    .HasName("PK__area__8A8C837BBD2D9CFB");

                entity.ToTable("area");

                entity.Property(e => e.IdArea).HasColumnName("id_area");

                entity.Property(e => e.NombreArea)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("nombre_area");
            });

            modelBuilder.Entity<Estadoorganizacion>(entity =>
            {
                entity.HasKey(e => e.IdEstadoorganizacion)
                    .HasName("PK__estadoor__EE6B54D4778C1C57");

                entity.ToTable("estadoorganizacion");

                entity.Property(e => e.IdEstadoorganizacion).HasColumnName("id_estadoorganizacion");

                entity.Property(e => e.NombreEstado)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre_estado");
            });

            modelBuilder.Entity<Estadoproyecto>(entity =>
            {
                entity.HasKey(e => e.IdEstadoproyecto)
                    .HasName("PK__estadopr__A2F4B2F5CDD84AD1");

                entity.ToTable("estadoproyecto");

                entity.Property(e => e.IdEstadoproyecto).HasColumnName("id_estadoproyecto");

                entity.Property(e => e.NombreEstadoproyecto)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("nombre_estadoproyecto");
            });

            modelBuilder.Entity<Evento>(entity =>
            {
                entity.HasKey(e => e.IdEvento)
                    .HasName("PK__eventos__AF150CA54B4C46FF");

                entity.ToTable("eventos");

                entity.Property(e => e.IdEvento)
                    .ValueGeneratedNever()
                    .HasColumnName("id_evento");

                entity.Property(e => e.CantCupos).HasColumnName("cant_cupos");

                entity.Property(e => e.CostoEvento)
                    .HasColumnType("money")
                    .HasColumnName("costo_evento");

                entity.Property(e => e.DescEvento)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("desc_evento");

                entity.Property(e => e.FechaEvento)
                    .HasColumnType("date")
                    .HasColumnName("fecha_evento");

                entity.Property(e => e.IdOrganizacion).HasColumnName("id_organizacion");

                entity.Property(e => e.IdTipoEvento).HasColumnName("id_tipo_evento");

                entity.Property(e => e.NombreEvento)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("nombre_evento");

                entity.Property(e => e.OdsEvento).HasColumnName("ods_evento");

                entity.HasOne(d => d.IdOrganizacionNavigation)
                    .WithMany(p => p.Eventos)
                    .HasForeignKey(d => d.IdOrganizacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__eventos__id_orga__6754599E");

                entity.HasOne(d => d.IdTipoEventoNavigation)
                    .WithMany(p => p.Eventos)
                    .HasForeignKey(d => d.IdTipoEvento)
                    .HasConstraintName("FK__eventos__id_tipo__66603565");

                entity.HasOne(d => d.OdsEventoNavigation)
                    .WithMany(p => p.Eventos)
                    .HasForeignKey(d => d.OdsEvento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__eventos__ods_eve__68487DD7");
            });

            modelBuilder.Entity<Od>(entity =>
            {
                entity.HasKey(e => e.IdOds)
                    .HasName("PK__ods__6E0E20A47734A367");

                entity.ToTable("ods");

                entity.Property(e => e.IdOds).HasColumnName("id_ods");

                entity.Property(e => e.Indicador)
                    .IsUnicode(false)
                    .HasColumnName("indicador");

                entity.Property(e => e.MetasOds)
                    .IsUnicode(false)
                    .HasColumnName("metas_ods");

                entity.Property(e => e.NombreOds)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("nombre_ods");

                entity.Property(e => e.ObjetivosOds)
                    .IsUnicode(false)
                    .HasColumnName("objetivos_ods");
            });

            modelBuilder.Entity<Organizacion>(entity =>
            {
                entity.HasKey(e => e.IdOrganizacion)
                    .HasName("PK__organiza__B2D27FD1D1DE2A2E");

                entity.ToTable("organizacion");

                entity.Property(e => e.IdOrganizacion).HasColumnName("id_organizacion");

                entity.Property(e => e.CorreoOrganizacion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("correo_organizacion");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.IdEstadoorganizacion).HasColumnName("id_estadoorganizacion");

                entity.Property(e => e.IdTipoorganizacion).HasColumnName("id_tipoorganizacion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Pais).HasColumnName("pais");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("telefono");

                entity.HasOne(d => d.IdEstadoorganizacionNavigation)
                    .WithMany(p => p.Organizacions)
                    .HasForeignKey(d => d.IdEstadoorganizacion)
                    .HasConstraintName("FK_organizacion_estadoorganizacion");

                entity.HasOne(d => d.IdTipoorganizacionNavigation)
                    .WithMany(p => p.Organizacions)
                    .HasForeignKey(d => d.IdTipoorganizacion)
                    .HasConstraintName("FK_organizacion_tipoorganizacion");

                entity.HasOne(d => d.PaisNavigation)
                    .WithMany(p => p.Organizacions)
                    .HasForeignKey(d => d.Pais)
                    .HasConstraintName("FK_organizacion_pais");
            });

            modelBuilder.Entity<OrganizacionOd>(entity =>
            {
                entity.HasKey(e => e.IpOrganizacionOds)
                    .HasName("PK__organiza__0B7626B0C15EB509");

                entity.ToTable("organizacion_ods");

                entity.Property(e => e.IpOrganizacionOds).HasColumnName("ip_organizacion_ods");

                entity.Property(e => e.IdOds).HasColumnName("id_ods");

                entity.Property(e => e.IdOrganizacion).HasColumnName("id_organizacion");

                entity.HasOne(d => d.IdOdsNavigation)
                    .WithMany(p => p.OrganizacionOds)
                    .HasForeignKey(d => d.IdOds)
                    .HasConstraintName("FK_ods_organizacion");

                entity.HasOne(d => d.IdOrganizacionNavigation)
                    .WithMany(p => p.OrganizacionOds)
                    .HasForeignKey(d => d.IdOrganizacion)
                    .HasConstraintName("FK_organizacion_ods");
            });

            modelBuilder.Entity<OrganizacionPersona>(entity =>
            {
                entity.HasKey(e => e.IdOrganizacionPersona)
                    .HasName("PK__organiza__336A5FCE8D6AE01A");

                entity.ToTable("organizacion_persona");

                entity.Property(e => e.IdOrganizacionPersona).HasColumnName("id_organizacion_persona");

                entity.Property(e => e.IdOrganizacion).HasColumnName("id_organizacion");

                entity.Property(e => e.IdPersona).HasColumnName("id_persona");

                entity.HasOne(d => d.IdOrganizacionNavigation)
                    .WithMany(p => p.OrganizacionPersonas)
                    .HasForeignKey(d => d.IdOrganizacion)
                    .HasConstraintName("FK_organizacion_persona");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.OrganizacionPersonas)
                    .HasForeignKey(d => d.IdPersona)
                    .HasConstraintName("FK_persona_organizacion");
            });

            modelBuilder.Entity<OrganizacionProyecto>(entity =>
            {
                entity.HasKey(e => e.IdOrganizacionProyecto)
                    .HasName("PK__organiza__A55A992EC0DBC33F");

                entity.ToTable("organizacion_proyecto");

                entity.Property(e => e.IdOrganizacionProyecto).HasColumnName("id_organizacion_proyecto");

                entity.Property(e => e.IdOrganizacion).HasColumnName("id_organizacion");

                entity.Property(e => e.IdProyecto).HasColumnName("id_proyecto");

                entity.HasOne(d => d.IdOrganizacionNavigation)
                    .WithMany(p => p.OrganizacionProyectos)
                    .HasForeignKey(d => d.IdOrganizacion)
                    .HasConstraintName("FK_organizacion_proyecto");

                entity.HasOne(d => d.IdProyectoNavigation)
                    .WithMany(p => p.OrganizacionProyectos)
                    .HasForeignKey(d => d.IdProyecto)
                    .HasConstraintName("FK_proyecto_organizacion");
            });

            modelBuilder.Entity<Pai>(entity =>
            {
                entity.HasKey(e => e.IdPais)
                    .HasName("PK__pais__0941A3A7CE4175A6");

                entity.ToTable("pais");

                entity.Property(e => e.IdPais).HasColumnName("id_pais");

                entity.Property(e => e.NombrePais)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("nombre_pais");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.IdPersona)
                    .HasName("PK__persona__228148B031CF55C0");

                entity.ToTable("persona");

                entity.Property(e => e.IdPersona).HasColumnName("id_persona");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("apellido");

                entity.Property(e => e.Email)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Fono)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("fono");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<PersonaEvento>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Persona_eventos");

                entity.Property(e => e.IdEvento).HasColumnName("id_evento");

                entity.Property(e => e.IdPersona).HasColumnName("id_persona");

                entity.HasOne(d => d.IdEventoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdEvento)
                    .HasConstraintName("FK__Persona_e__id_ev__6A30C649");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdPersona)
                    .HasConstraintName("FK__Persona_e__id_pe__6B24EA82");
            });

            modelBuilder.Entity<PersonaOd>(entity =>
            {
                entity.HasKey(e => e.IdPersonaOds)
                    .HasName("PK__persona___C161B8B232C1260D");

                entity.ToTable("persona_ods");

                entity.Property(e => e.IdPersonaOds).HasColumnName("id_persona_ods");

                entity.Property(e => e.IdOds).HasColumnName("id_ods");

                entity.Property(e => e.IdPersona).HasColumnName("id_persona");

                entity.HasOne(d => d.IdOdsNavigation)
                    .WithMany(p => p.PersonaOds)
                    .HasForeignKey(d => d.IdOds)
                    .HasConstraintName("FK_ods_persona");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.PersonaOds)
                    .HasForeignKey(d => d.IdPersona)
                    .HasConstraintName("FK_persona_ods");
            });

            modelBuilder.Entity<PersonaProyecto>(entity =>
            {
                entity.HasKey(e => e.IdOrganizacionProyecto)
                    .HasName("PK__persona___A55A992ED23A5D02");

                entity.ToTable("persona_proyecto");

                entity.Property(e => e.IdOrganizacionProyecto).HasColumnName("id_organizacion_proyecto");

                entity.Property(e => e.IdPersona).HasColumnName("id_persona");

                entity.Property(e => e.IdProyecto).HasColumnName("id_proyecto");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.PersonaProyectos)
                    .HasForeignKey(d => d.IdPersona)
                    .HasConstraintName("FK_persona_proyecto");

                entity.HasOne(d => d.IdProyectoNavigation)
                    .WithMany(p => p.PersonaProyectos)
                    .HasForeignKey(d => d.IdProyecto)
                    .HasConstraintName("FK_proyecto_persona");
            });

            modelBuilder.Entity<Proyecto>(entity =>
            {
                entity.HasKey(e => e.IdProyecto)
                    .HasName("PK__proyecto__F38AD81D8FA9ABFD");

                entity.ToTable("proyecto");

                entity.Property(e => e.IdProyecto).HasColumnName("id_proyecto");

                entity.Property(e => e.Descripcion)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("date")
                    .HasColumnName("fecha_Creacion");

                entity.Property(e => e.FechaInico)
                    .HasColumnType("date")
                    .HasColumnName("fecha_inico");

                entity.Property(e => e.FechaTermino)
                    .HasColumnType("date")
                    .HasColumnName("fecha_termino");

                entity.Property(e => e.IdArea).HasColumnName("id_area");

                entity.Property(e => e.IdEstadoproyecto).HasColumnName("id_estadoproyecto");

                entity.Property(e => e.IdOds).HasColumnName("id_ods");

                entity.Property(e => e.IdPersonaresponsable).HasColumnName("id_personaresponsable");

                entity.Property(e => e.Meses).HasColumnName("meses");

                entity.Property(e => e.Monto).HasColumnName("monto");

                entity.Property(e => e.Objetivos)
                    .IsUnicode(false)
                    .HasColumnName("objetivos");

                entity.Property(e => e.PalabrasClave)
                    .IsUnicode(false)
                    .HasColumnName("palabras_clave");

                entity.HasOne(d => d.IdAreaNavigation)
                    .WithMany(p => p.Proyectos)
                    .HasForeignKey(d => d.IdArea)
                    .HasConstraintName("FK_proyecto_area");

                entity.HasOne(d => d.IdEstadoproyectoNavigation)
                    .WithMany(p => p.Proyectos)
                    .HasForeignKey(d => d.IdEstadoproyecto)
                    .HasConstraintName("FK_proyecto_estadoproyecto");

                entity.HasOne(d => d.IdPersonaresponsableNavigation)
                    .WithMany(p => p.Proyectos)
                    .HasForeignKey(d => d.IdPersonaresponsable)
                    .HasConstraintName("FK_proyecto_personaresponsabe");
            });

            modelBuilder.Entity<ProyectoOd>(entity =>
            {
                entity.HasKey(e => e.IdProyectoOds)
                    .HasName("PK__proyecto__E0CD62A1B10A07B4");

                entity.ToTable("proyecto_ods");

                entity.Property(e => e.IdProyectoOds).HasColumnName("id_proyecto_ods");

                entity.Property(e => e.IdOds).HasColumnName("id_ods");

                entity.Property(e => e.IdProyecto).HasColumnName("id_proyecto");

                entity.HasOne(d => d.IdOdsNavigation)
                    .WithMany(p => p.ProyectoOds)
                    .HasForeignKey(d => d.IdOds)
                    .HasConstraintName("FK_ods_proyecto");

                entity.HasOne(d => d.IdProyectoNavigation)
                    .WithMany(p => p.ProyectoOds)
                    .HasForeignKey(d => d.IdProyecto)
                    .HasConstraintName("FK_proyecto_ods");
            });

            modelBuilder.Entity<TipoEvento>(entity =>
            {
                entity.HasKey(e => e.IdEvento)
                    .HasName("PK__tipo_eve__AF150CA55D1403C4");

                entity.ToTable("tipo_evento");

                entity.Property(e => e.IdEvento)
                    .ValueGeneratedNever()
                    .HasColumnName("id_evento");

                entity.Property(e => e.NombreTipo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("nombre_tipo");
            });

            modelBuilder.Entity<Tipoorganizacion>(entity =>
            {
                entity.HasKey(e => e.IdTipoorganizacion)
                    .HasName("PK__tipoorga__059095B81ABF6C3D");

                entity.ToTable("tipoorganizacion");

                entity.Property(e => e.IdTipoorganizacion).HasColumnName("id_tipoorganizacion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
