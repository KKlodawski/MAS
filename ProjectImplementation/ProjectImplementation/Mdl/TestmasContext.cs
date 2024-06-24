using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ProjectImplementation.Mdl;

public partial class TestmasContext : DbContext
{
    public TestmasContext()
    {
    }

    public TestmasContext(DbContextOptions<TestmasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aktor> Aktors { get; set; }

    public virtual DbSet<Druzyna> Druzynas { get; set; }

    public virtual DbSet<Gra> Gras { get; set; }

    public virtual DbSet<Graaktor> Graaktors { get; set; }

    public virtual DbSet<Krytyk> Krytyks { get; set; }

    public virtual DbSet<Menadzer> Menadzers { get; set; }

    public virtual DbSet<Osoba> Osobas { get; set; }

    public virtual DbSet<Pracownik> Pracowniks { get; set; }

    public virtual DbSet<Przegladwydajnosci> Przegladwydajnoscis { get; set; }

    public virtual DbSet<Test> Tests { get; set; }

    public virtual DbSet<Tester> Testers { get; set; }

    public virtual DbSet<Druzyna.Zadanie> Zadanies { get; set; }
    
    public virtual DbSet<AktorPracownik> AktorPracowniks { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("server=localhost;database=mas2;uid=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.27-mariadb"));


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Aktor>(entity =>
        {
            entity.ToTable("aktor");
            entity.Property(e => e.IloscLinii).HasColumnType("int(11)");
            entity.Property(e => e.ZaplataZaLinie).HasPrecision(10, 2);
        });

        modelBuilder.Entity<Druzyna>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("druzyna");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.NazwaDruzyny).HasMaxLength(100);
            entity.Property(e => e.Rola).HasMaxLength(50);

            entity.HasMany(d => d.Gras).WithMany(p => p.Druzynas)
                .UsingEntity<Dictionary<string, object>>(
                    "Druzynagra",
                    r => r.HasOne<Gra>().WithMany()
                        .HasForeignKey("GraId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("druzynagra_ibfk_2"),
                    l => l.HasOne<Druzyna>().WithMany()
                        .HasForeignKey("DruzynaId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("druzynagra_ibfk_1"),
                    j =>
                    {
                        j.HasKey("DruzynaId", "GraId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("druzynagra");
                        j.HasIndex(new[] { "GraId" }, "GraID");
                        j.IndexerProperty<int>("DruzynaId")
                            .HasColumnType("int(11)")
                            .HasColumnName("DruzynaID");
                        j.IndexerProperty<int>("GraId")
                            .HasColumnType("int(11)")
                            .HasColumnName("GraID");
                    });

            entity
                .HasMany(d => d.Pracowniks)
                .WithOne(p => p.Druzyna)
                .HasForeignKey(p => p.DruzynaId);


            entity.HasMany(d => d.Zadanies)
                .WithOne()
                .IsRequired()
                .HasForeignKey("DruzynaId")
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Gra>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("gra");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.Tytul).HasMaxLength(100);
            entity.Property(e => e.DataWydania).HasColumnName("DataWydania");
            entity.Property(e => e.Gatunki)
                .HasConversion(
                    v => string.Join(',', v.Select(e => e.ToString())),
                    v => new HashSet<Gra.GATUNKI>(v.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(e => (Gra.GATUNKI)Enum.Parse(typeof(Gra.GATUNKI), e)))
                );
        });

        modelBuilder.Entity<Graaktor>(entity =>
        {
            entity.HasKey(e => new { e.GraId, e.AktorId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("graaktor");

            entity.HasIndex(e => e.AktorId, "AktorID");

            entity.Property(e => e.GraId)
                .HasColumnType("int(11)")
                .HasColumnName("GraID");
            entity.Property(e => e.AktorId)
                .HasColumnType("int(11)")
                .HasColumnName("AktorID");
            entity.Property(e => e.Postac).HasMaxLength(100);

            entity.HasOne(d => d.Aktor).WithMany(p => p.Graaktors)
                .HasForeignKey(d => d.AktorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("graaktor_ibfk_2");

            entity.HasOne(d => d.Gra).WithMany(p => p.Graaktors)
                .HasForeignKey(d => d.GraId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("graaktor_ibfk_1");
        });

        modelBuilder.Entity<Krytyk>(entity =>
        {
            entity.ToTable("krytyk");

            entity.HasIndex(e => e.OsobaId, "OsobaID");
            entity.Property(e => e.OsobaId)
                .HasColumnType("int(11)")
                .HasColumnName("OsobaID");
            entity.Property(e => e.Specjalizacja).HasMaxLength(100);
            entity.Property(e => e.WynagrodzenieZaOcene).HasPrecision(10, 2);

            entity.HasOne(d => d.Osoba).WithMany(p => p.Krytyks)
                .HasForeignKey(d => d.OsobaId)
                .HasConstraintName("krytyk_ibfk_1");
        });

        modelBuilder.Entity<Menadzer>(entity =>
        {
            entity.ToTable("menadzer");

            entity.HasIndex(e => e.PracownikId, "PracownikID");
            entity.Property(e => e.Bonus).HasPrecision(10, 2);
            entity.Property(e => e.PracownikId)
                .HasColumnType("int(11)")
                .HasColumnName("PracownikID");

            entity.HasOne(d => d.Pracownik)
                .WithOne(p => p.Menadzer)
                .HasForeignKey<Menadzer>(d => d.PracownikId)
                .HasConstraintName("menadzer_ibfk_1");
            

        });

        modelBuilder.Entity<Osoba>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("osoba");

            entity.HasIndex(e => e.Pesel, "Pesel").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Imie).HasMaxLength(50);
            entity.Property(e => e.Nazwisko).HasMaxLength(50);
            entity.Property(e => e.Pensja).HasPrecision(10, 2);
            entity.Property(e => e.Pesel).HasMaxLength(11);
            entity.Property(e => e.Telefon).HasMaxLength(15);
        });

        modelBuilder.Entity<Pracownik>(entity =>
        {
            entity.ToTable("pracownik");

            entity.OwnsOne(e => e.Adres, a =>
            {
                a.Property(adres => adres.miasto).HasColumnName("miasto");
                a.Property(adres => adres.ulica).HasColumnName("ulica");
                a.Property(adres => adres.nrDomu).HasColumnName("nrDomu");
                a.Property(adres => adres.kodPocztowy).HasColumnName("kodPocztowy");
            });
            entity.Property(e => e.CzasPracy).HasColumnType("int(11)");
            entity.Property(e => e.DruzynaId).IsRequired(false);
        });

        modelBuilder.Entity<Przegladwydajnosci>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("przegladwydajnosci");

            entity.HasIndex(e => e.KrytykId, "KrytykID");

            entity.HasIndex(e => e.PracownikId, "PracownikID");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.Komentarz).HasColumnType("text");
            entity.Property(e => e.KrytykId)
                .HasColumnType("int(11)")
                .HasColumnName("KrytykID");
            entity.Property(e => e.Ocena).HasColumnType("int(11)");
            entity.Property(e => e.PracownikId)
                .HasColumnType("int(11)")
                .HasColumnName("PracownikID");

            entity.HasOne(d => d.Krytyk).WithMany(p => p.Przegladwydajnoscis)
                .HasForeignKey(d => d.KrytykId)
                .HasConstraintName("przegladwydajnosci_ibfk_2");

            entity.HasOne(d => d.Pracownik).WithMany(p => p.Przegladwydajnoscis)
                .HasForeignKey(d => d.PracownikId)
                .HasConstraintName("przegladwydajnosci_ibfk_1");
        });

        modelBuilder.Entity<Test>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("test");

            entity.HasIndex(e => e.GraId, "GraID");

            entity.HasIndex(e => e.TesterId, "TesterID");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.GraId)
                .HasColumnType("int(11)")
                .HasColumnName("GraID");
            entity.Property(e => e.Komentarz).HasColumnType("text");
            entity.Property(e => e.TesterId)
                .HasColumnType("int(11)")
                .HasColumnName("TesterID");
            entity.Property(e => e.Wynik).HasColumnType("enum('zaliczony','niezaliczony')");

            entity.HasOne(d => d.Gra).WithMany(p => p.Tests)
                .HasForeignKey(d => d.GraId)
                .HasConstraintName("test_ibfk_1");

            entity.HasOne(d => d.Tester).WithMany(p => p.Tests)
                .HasForeignKey(d => d.TesterId)
                .HasConstraintName("test_ibfk_2");
        });

        modelBuilder.Entity<Tester>(entity =>
        {
            entity.ToTable("tester");

            entity.HasIndex(e => e.OsobaId, "OsobaID");
            entity.Property(e => e.Doswiadczenie).HasMaxLength(100);
            entity.Property(e => e.OsobaId)
                .HasColumnType("int(11)")
                .HasColumnName("OsobaID");
            entity.Property(e => e.WynagrodzenieZaTest).HasPrecision(10, 2);

            entity.HasOne(d => d.Osoba).WithMany(p => p.Testers)
                .HasForeignKey(d => d.OsobaId)
                .HasConstraintName("tester_ibfk_1");
        });

        modelBuilder.Entity<Druzyna.Zadanie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("zadanie");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.NazwaZadania).HasMaxLength(100);
            entity.Property(e => e.Opis).HasColumnType("text");
            entity.Property(e => e.Status).HasColumnType("enum('wtrakcie','zakonczone','przerwane')");
        });

        modelBuilder.Entity<AktorPracownik>(entity =>
        {
            entity.ToTable("AktorPracownik");
            entity.HasIndex(e => e.AktorId);
            entity.Property(e => e.DataZatrudnienia).HasColumnType("date");
            entity.Property(e => e.CzasPracy).HasColumnType("int");
            entity.Property((e => e.AktorId))
                .HasColumnType("int(11)")
                .HasColumnName("AktorID");

            entity.HasOne(d => d.Aktor)
                .WithOne(p => p.AktorPracownik)
                .HasForeignKey<AktorPracownik>(e => e.AktorId)
                .HasConstraintName("aktorpracownik_ibfk_1")
                .OnDelete(DeleteBehavior.Cascade);
            
            
            entity.OwnsOne(e => e.Adres, a =>
            {
                a.Property(adres => adres.miasto).HasColumnName("miasto");
                a.Property(adres => adres.ulica).HasColumnName("ulica");
                a.Property(adres => adres.nrDomu).HasColumnName("nrDomu");
                a.Property(adres => adres.kodPocztowy).HasColumnName("kodPocztowy");
            });

        });
            

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
