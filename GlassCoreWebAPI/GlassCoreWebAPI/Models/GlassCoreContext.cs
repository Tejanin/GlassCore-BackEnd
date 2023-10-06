﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GlassCoreWebAPI.Models;

public partial class GlassCoreContext : DbContext
{
    public GlassCoreContext()
    {
    }

    public GlassCoreContext(DbContextOptions<GlassCoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Administrador> Administradors { get; set; }

    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<Asignatura> Asignaturas { get; set; }

    public virtual DbSet<Aula> Aulas { get; set; }

    public virtual DbSet<Carrera> Carreras { get; set; }

    public virtual DbSet<Ciclo> Ciclos { get; set; }

    public virtual DbSet<Dia> Dia { get; set; }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

    public virtual DbSet<Profesor> Profesors { get; set; }

    public virtual DbSet<TipoAsignatura> TipoAsignaturas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrador>(entity =>
        {
            entity.HasKey(e => e.IdAdministrador).HasName("PK__Administ__3704FCB13761EB24");

            entity.ToTable("Administrador");

            entity.HasIndex(e => e.IdUsuario, "UQ__Administ__63C76BE3DC8C8A21").IsUnique();

            entity.Property(e => e.IdAdministrador).HasColumnName("Id_Administrador");
            entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

            entity.HasOne(d => d.IdUsuarioNavigation).WithOne(p => p.Administrador)
                .HasForeignKey<Administrador>(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Administr__Id_Us__46E78A0C");
        });

        modelBuilder.Entity<Area>(entity =>
        {
            entity.HasKey(e => e.IdArea).HasName("PK__Area__9C42D7FE2532A7EC");

            entity.ToTable("Area");

            entity.Property(e => e.IdArea).HasColumnName("Id_Area");
            entity.Property(e => e.NombreArea)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Nombre_Area");
        });

        modelBuilder.Entity<Asignatura>(entity =>
        {
            entity.HasKey(e => e.IdAsignatura).HasName("PK__Asignatu__FAE056836767DBDE");

            entity.ToTable("Asignatura");

            entity.HasIndex(e => e.CodigoAsignatura, "UQ__Asignatu__D41994BB0624B2E5").IsUnique();

            entity.Property(e => e.IdAsignatura).HasColumnName("Id_Asignatura");
            entity.Property(e => e.CodigoAsignatura).HasColumnName("Codigo_Asignatura");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.NombreAsignatura)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Nombre_Asignatura");
            entity.Property(e => e.NumAsignatura).HasColumnName("Num_Asignatura");

            entity.HasOne(d => d.CodigoAsignaturaNavigation).WithOne(p => p.Asignatura)
                .HasForeignKey<Asignatura>(d => d.CodigoAsignatura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Asignatur__Codig__5AEE82B9");
        });

        modelBuilder.Entity<Aula>(entity =>
        {
            entity.HasKey(e => e.IdAula).HasName("PK__Aula__B4BE41D1C336B79E");

            entity.ToTable("Aula");

            entity.Property(e => e.IdAula).HasColumnName("Id_Aula");
            entity.Property(e => e.NombreAula)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("Nombre_Aula");
        });

        modelBuilder.Entity<Carrera>(entity =>
        {
            entity.HasKey(e => e.IdCarrera).HasName("PK__Carrera__45CC548840B787C4");

            entity.ToTable("Carrera");

            entity.Property(e => e.IdCarrera).HasColumnName("Id_Carrera");
            entity.Property(e => e.NombreCarrera)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Nombre_Carrera");
        });

        modelBuilder.Entity<Ciclo>(entity =>
        {
            entity.HasKey(e => e.IdCiclo).HasName("PK__Ciclo__936293296CA2C058");

            entity.ToTable("Ciclo");

            entity.Property(e => e.IdCiclo).HasColumnName("Id_Ciclo");
            entity.Property(e => e.DescCiclo)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("Desc_Ciclo");
        });

        modelBuilder.Entity<Dia>(entity =>
        {
            entity.HasKey(e => e.IdDia).HasName("PK__Dia__5EAC30D68759D6EC");

            entity.Property(e => e.IdDia).HasColumnName("Id_Dia");
            entity.Property(e => e.NombreDia)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("Nombre_Dia");
        });

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.HasKey(e => e.IdEstudiante).HasName("PK__Estudian__A85859D2AFEE0968");

            entity.ToTable("Estudiante");

            entity.HasIndex(e => e.IdUsuario, "UQ__Estudian__63C76BE36D284E49").IsUnique();

            entity.Property(e => e.IdEstudiante).HasColumnName("Id_Estudiante");
            entity.Property(e => e.Honor)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('Summa Cum Laude')");
            entity.Property(e => e.IdCarrera).HasColumnName("Id_Carrera");
            entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");
            entity.Property(e => e.IndiceGeneral)
                .HasDefaultValueSql("((4.00))")
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Indice_General");
            entity.Property(e => e.IndiceTrimestral)
                .HasDefaultValueSql("((4.00))")
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Indice_Trimestral");
            entity.Property(e => e.Trimestre).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.IdCarreraNavigation).WithMany(p => p.Estudiantes)
                .HasForeignKey(d => d.IdCarrera)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Estudiant__Id_Ca__6E01572D");

            entity.HasOne(d => d.IdUsuarioNavigation).WithOne(p => p.Estudiante)
                .HasForeignKey<Estudiante>(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Estudiant__Id_Us__6383C8BA");
        });

        modelBuilder.Entity<Profesor>(entity =>
        {
            entity.HasKey(e => e.IdProfesor).HasName("PK__Profesor__45D4152AF8F7A5A9");

            entity.ToTable("Profesor");

            entity.HasIndex(e => e.IdUsuario, "UQ__Profesor__63C76BE34B82DB1B").IsUnique();

            entity.Property(e => e.IdProfesor).HasColumnName("Id_Profesor");
            entity.Property(e => e.IdArea).HasColumnName("Id_Area");
            entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

            entity.HasOne(d => d.IdAreaNavigation).WithMany(p => p.Profesors)
                .HasForeignKey(d => d.IdArea)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Profesor__Id_Are__4BAC3F29");

            entity.HasOne(d => d.IdUsuarioNavigation).WithOne(p => p.Profesor)
                .HasForeignKey<Profesor>(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Profesor__Id_Usu__4AB81AF0");
        });

        modelBuilder.Entity<TipoAsignatura>(entity =>
        {
            entity.HasKey(e => e.CodigoAsignatura).HasName("PK__Tipo_Asi__D41994BA513BAD90");

            entity.ToTable("Tipo_Asignatura");

            entity.Property(e => e.CodigoAsignatura).HasColumnName("Codigo_Asignatura");
            entity.Property(e => e.Codigo)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.DescripcionAsignatura)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Descripcion_Asignatura");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__63C76BE279E2CFBF");

            entity.ToTable("Usuario", tb => tb.HasTrigger("TR_UserName_Increment"));

            entity.HasIndex(e => e.Email, "UQ__Usuario__A9D10534175F49F4").IsUnique();

            entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");
            entity.Property(e => e.ApellidoUsuario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Apellido_Usuario");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FechaIngreso)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date")
                .HasColumnName("Fecha_Ingreso");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Nombre_Usuario");
            entity.Property(e => e.Password)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Rol)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Salt)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.UserName).HasDefaultValueSql("(NEXT VALUE FOR [UserName_Sequence])");
        });
        modelBuilder.HasSequence("UserName_Sequence").StartsAt(100000L);

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
