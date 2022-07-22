﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SereApi.Models
{
    public partial class SereDbContext : DbContext
    {
        public SereDbContext()
        {
        }

        public SereDbContext(DbContextOptions<SereDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<EmailList> EmailLists { get; set; } = null!;
        public virtual DbSet<Event> Events { get; set; } = null!;
        public virtual DbSet<EventType> EventTypes { get; set; } = null!;
        public virtual DbSet<Objective> Objectives { get; set; } = null!;
        public virtual DbSet<Organization> Organizations { get; set; } = null!;
        public virtual DbSet<OrganizationObjective> OrganizationObjectives { get; set; } = null!;
        public virtual DbSet<OrganizationPerson> OrganizationPeople { get; set; } = null!;
        public virtual DbSet<OrganizationProject> OrganizationProjects { get; set; } = null!;
        public virtual DbSet<OrganizationStatus> OrganizationStatuses { get; set; } = null!;
        public virtual DbSet<OrganizationType> OrganizationTypes { get; set; } = null!;
        public virtual DbSet<Person> People { get; set; } = null!;
        public virtual DbSet<PersonEvent> PersonEvents { get; set; } = null!;
        public virtual DbSet<PersonObjective> PersonObjectives { get; set; } = null!;
        public virtual DbSet<PersonProject> PersonProjects { get; set; } = null!;
        public virtual DbSet<Project> Projects { get; set; } = null!;
        public virtual DbSet<ProjectObjective> ProjectObjectives { get; set; } = null!;
        public virtual DbSet<ProjectStatus> ProjectStatuses { get; set; } = null!;
        public virtual DbSet<WebProject> WebProjects { get; set; } = null!;
        public virtual DbSet<WebProjectPerson> WebProjectPeople { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=sereprototipo.mssql.somee.com; Initial Catalog=sereprototipo; user id=sereudec_SQLLogin_1; password=5q5foojbaq;;Trusted_Connection=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.IdCountry)
                    .HasName("PK__Country__F99F104D13CB7231");

                entity.ToTable("Country");

                entity.Property(e => e.NameCountry)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EmailList>(entity =>
            {
                entity.HasKey(e => e.IdEmail)
                    .HasName("PK__EmailLis__E80F8BD4BEBE366B");

                entity.ToTable("EmailList");

                entity.Property(e => e.Email).IsUnicode(false);
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasKey(e => e.IdEvent)
                    .HasName("PK__Event__E0B2AF39D6AB605D");

                entity.ToTable("Event");

                entity.Property(e => e.DateEvent).HasColumnType("date");

                entity.Property(e => e.DescriptionEvent)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ImagenEvento).IsUnicode(false);

                entity.Property(e => e.NameEvent)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEventTypeNavigation)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.IdEventType)
                    .HasConstraintName("FkEventEventType");

                entity.HasOne(d => d.IdOrganizationNavigation)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.IdOrganization)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FkEventOrganization");

                entity.HasOne(d => d.ObjectiveEventNavigation)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.ObjectiveEvent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FkEventObjective");
            });

            modelBuilder.Entity<EventType>(entity =>
            {
                entity.HasKey(e => e.IdEvent)
                    .HasName("PK__EventTyp__E0B2AF3953A08174");

                entity.ToTable("EventType");

                entity.Property(e => e.NameEventType)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Objective>(entity =>
            {
                entity.HasKey(e => e.IdObjective)
                    .HasName("PK__Objectiv__76514F97D47D83BA");

                entity.ToTable("Objective");

                entity.Property(e => e.IndicadorObjective).IsUnicode(false);

                entity.Property(e => e.MetasObjective).IsUnicode(false);

                entity.Property(e => e.NameObjective)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ObjectiveObjective).IsUnicode(false);
            });

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.HasKey(e => e.IdOrganization)
                    .HasName("PK__Organiza__C14A1C2735CA8AAC");

                entity.ToTable("Organization");

                entity.Property(e => e.DescriptionOrganization)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.EmailOrganization)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NameOrganization)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.CountryNavigation)
                    .WithMany(p => p.Organizations)
                    .HasForeignKey(d => d.Country)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FkOrganizationCountry");

                entity.HasOne(d => d.IdOrganizationStatusNavigation)
                    .WithMany(p => p.Organizations)
                    .HasForeignKey(d => d.IdOrganizationStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FkOrganizationOrganizationStatus");

                entity.HasOne(d => d.IdOrganizationTypeNavigation)
                    .WithMany(p => p.Organizations)
                    .HasForeignKey(d => d.IdOrganizationType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FkOrganizationOrganizationType");
            });

            modelBuilder.Entity<OrganizationObjective>(entity =>
            {
                entity.HasKey(e => e.IdOrganizationObjective)
                    .HasName("PK__Organiza__4D7C5147150D76DA");

                entity.ToTable("OrganizationObjective");

                entity.HasOne(d => d.IdObjectiveNavigation)
                    .WithMany(p => p.OrganizationObjectives)
                    .HasForeignKey(d => d.IdObjective)
                    .HasConstraintName("FkObjectiveOrganization");

                entity.HasOne(d => d.IdOrganizationNavigation)
                    .WithMany(p => p.OrganizationObjectives)
                    .HasForeignKey(d => d.IdOrganization)
                    .HasConstraintName("FkOrganizationObjective");
            });

            modelBuilder.Entity<OrganizationPerson>(entity =>
            {
                entity.HasKey(e => e.IdOrganizationPerson)
                    .HasName("PK__Organiza__573676C9D341927D");

                entity.ToTable("OrganizationPerson");

                entity.HasOne(d => d.IdOrganizationNavigation)
                    .WithMany(p => p.OrganizationPeople)
                    .HasForeignKey(d => d.IdOrganization)
                    .HasConstraintName("FkOrganizationPerson");

                entity.HasOne(d => d.IdPersonNavigation)
                    .WithMany(p => p.OrganizationPeople)
                    .HasForeignKey(d => d.IdPerson)
                    .HasConstraintName("FkPersonOrganization");
            });

            modelBuilder.Entity<OrganizationProject>(entity =>
            {
                entity.HasKey(e => e.IdOrganizationProject)
                    .HasName("PK__Organiza__171D148FDC60E45A");

                entity.ToTable("OrganizationProject");

                entity.HasOne(d => d.IdOrganizationNavigation)
                    .WithMany(p => p.OrganizationProjects)
                    .HasForeignKey(d => d.IdOrganization)
                    .HasConstraintName("FkOrganizationProject");

                entity.HasOne(d => d.IdProjectNavigation)
                    .WithMany(p => p.OrganizationProjects)
                    .HasForeignKey(d => d.IdProject)
                    .HasConstraintName("FkProjectOrganization");
            });

            modelBuilder.Entity<OrganizationStatus>(entity =>
            {
                entity.HasKey(e => e.IdOrganizationStatus)
                    .HasName("PK__Organiza__EF65CC7F35A6A4EF");

                entity.ToTable("OrganizationStatus");

                entity.Property(e => e.NameOrganizationStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OrganizationType>(entity =>
            {
                entity.HasKey(e => e.IdOrganizationType)
                    .HasName("PK__Organiza__4D4A4C69FCCBD449");

                entity.ToTable("OrganizationType");

                entity.Property(e => e.NameOrganizationType)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.IdPerson)
                    .HasName("PK__Person__A5D4E15BFDAFB55E");

                entity.ToTable("Person");

                entity.Property(e => e.EmailPerson)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.NamePerson)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.OrganizationName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordPerson).IsUnicode(false);

                entity.Property(e => e.PhonePerson)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.SurnamePerson)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.CountryPersonNavigation)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.CountryPerson)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Person__Country");
            });

            modelBuilder.Entity<PersonEvent>(entity =>
            {
                entity.HasKey(e => e.IdPersonEvent)
                    .HasName("PK__PersonEv__7E6E20355C783B4C");

                entity.ToTable("PersonEvent");

                entity.HasOne(d => d.IdEventNavigation)
                    .WithMany(p => p.PersonEvents)
                    .HasForeignKey(d => d.IdEvent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FkPersonEventEvent");

                entity.HasOne(d => d.IdPersonNavigation)
                    .WithMany(p => p.PersonEvents)
                    .HasForeignKey(d => d.IdPerson)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FkPersonEventPerson");
            });

            modelBuilder.Entity<PersonObjective>(entity =>
            {
                entity.HasKey(e => e.IdPersonObjective)
                    .HasName("PK__PersonOb__E2F376D772AB60BB");

                entity.ToTable("PersonObjective");

                entity.HasOne(d => d.IdObjectiveNavigation)
                    .WithMany(p => p.PersonObjectives)
                    .HasForeignKey(d => d.IdObjective)
                    .HasConstraintName("FkObjectivePerson");

                entity.HasOne(d => d.IdPersonNavigation)
                    .WithMany(p => p.PersonObjectives)
                    .HasForeignKey(d => d.IdPerson)
                    .HasConstraintName("FkPersonObjective");
            });

            modelBuilder.Entity<PersonProject>(entity =>
            {
                entity.HasKey(e => e.IdPersonProject)
                    .HasName("PK__PersonPr__8D705DB681A2B4E5");

                entity.ToTable("PersonProject");

                entity.HasOne(d => d.IdPersonNavigation)
                    .WithMany(p => p.PersonProjects)
                    .HasForeignKey(d => d.IdPerson)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FkPersonProject");

                entity.HasOne(d => d.IdProjectNavigation)
                    .WithMany(p => p.PersonProjects)
                    .HasForeignKey(d => d.IdProject)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FkProjectPerson");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(e => e.IdProject)
                    .HasName("PK__Project__B9E13D24C4A47ECB");

                entity.ToTable("Project");

                entity.Property(e => e.CreationDateProject).HasColumnType("date");

                entity.Property(e => e.DescriptionProject).IsUnicode(false);

                entity.Property(e => e.EndDateProject).HasColumnType("date");

                entity.Property(e => e.KeyWordsProject).IsUnicode(false);

                entity.Property(e => e.ObjectivesProject).IsUnicode(false);

                entity.Property(e => e.StartDateProject).HasColumnType("date");

                entity.HasOne(d => d.IdPersonResponsableNavigation)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.IdPersonResponsable)
                    .HasConstraintName("FkProjectPersonResponsable");

                entity.HasOne(d => d.IdProjectStatusNavigation)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.IdProjectStatus)
                    .HasConstraintName("FkProjectProjectStatus");
            });

            modelBuilder.Entity<ProjectObjective>(entity =>
            {
                entity.HasKey(e => e.IdProjectObjective)
                    .HasName("PK__ProjectO__A2C5D3BE5A6A788E");

                entity.ToTable("ProjectObjective");

                entity.HasOne(d => d.IdObjectiveNavigation)
                    .WithMany(p => p.ProjectObjectives)
                    .HasForeignKey(d => d.IdObjective)
                    .HasConstraintName("FkObjectiveProject");

                entity.HasOne(d => d.IdProjectNavigation)
                    .WithMany(p => p.ProjectObjectives)
                    .HasForeignKey(d => d.IdProject)
                    .HasConstraintName("FkProjectObjective");
            });

            modelBuilder.Entity<ProjectStatus>(entity =>
            {
                entity.HasKey(e => e.IdProjectStatus)
                    .HasName("PK__ProjectS__E0824C8734BC3882");

                entity.ToTable("ProjectStatus");

                entity.Property(e => e.NameProjectStatus)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WebProject>(entity =>
            {
                entity.HasKey(e => e.IdWebProject)
                    .HasName("PK__WebProje__1487D998829E0725");

                entity.ToTable("WebProject");

                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Img)
                    .IsUnicode(false)
                    .HasColumnName("img");

                entity.Property(e => e.Name)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Status)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.Title)
                    .IsUnicode(false)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<WebProjectPerson>(entity =>
            {
                entity.HasKey(e => e.IdWebProjectPerson)
                    .HasName("PK__WebProje__CD3180C0259A9529");

                entity.ToTable("WebProjectPerson");

                entity.HasOne(d => d.IdPersonNavigation)
                    .WithMany(p => p.WebProjectPeople)
                    .HasForeignKey(d => d.IdPerson)
                    .HasConstraintName("FkPersonWebProject");

                entity.HasOne(d => d.IdWebProjectNavigation)
                    .WithMany(p => p.WebProjectPeople)
                    .HasForeignKey(d => d.IdWebProject)
                    .HasConstraintName("FkWebProject");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
