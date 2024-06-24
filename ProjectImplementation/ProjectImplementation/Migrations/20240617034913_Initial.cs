using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectImplementation.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "druzyna",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NazwaDruzyny = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Rola = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "gra",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Tytul = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Gatunki = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataWydania = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "osoba",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Pesel = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Imie = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nazwisko = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataUrodzenia = table.Column<DateOnly>(type: "date", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefon = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Pensja = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "zadanie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NazwaZadania = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Opis = table.Column<string>(type: "text", nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Termin = table.Column<DateOnly>(type: "date", nullable: false),
                    Status = table.Column<string>(type: "enum('wtrakcie','zakonczone','przerwane')", nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DruzynaId = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.ID);
                    table.ForeignKey(
                        name: "FK_zadanie_druzyna_DruzynaId",
                        column: x => x.DruzynaId,
                        principalTable: "druzyna",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "druzynagra",
                columns: table => new
                {
                    DruzynaID = table.Column<int>(type: "int(11)", nullable: false),
                    GraID = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.DruzynaID, x.GraID })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                    table.ForeignKey(
                        name: "druzynagra_ibfk_1",
                        column: x => x.DruzynaID,
                        principalTable: "druzyna",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "druzynagra_ibfk_2",
                        column: x => x.GraID,
                        principalTable: "gra",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "aktor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false),
                    ZaplataZaLinie = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    IloscLinii = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.ID);
                    table.ForeignKey(
                        name: "FK_aktor_osoba_ID",
                        column: x => x.ID,
                        principalTable: "osoba",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "krytyk",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false),
                    OsobaID = table.Column<int>(type: "int(11)", nullable: true),
                    WynagrodzenieZaOcene = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Specjalizacja = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.ID);
                    table.ForeignKey(
                        name: "FK_krytyk_osoba_ID",
                        column: x => x.ID,
                        principalTable: "osoba",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "krytyk_ibfk_1",
                        column: x => x.OsobaID,
                        principalTable: "osoba",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "pracownik",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false),
                    OsobaId = table.Column<int>(type: "int", nullable: true),
                    DataZatrudnienia = table.Column<DateOnly>(type: "date", nullable: false),
                    miasto = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ulica = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nrDomu = table.Column<int>(type: "int", nullable: false),
                    kodPocztowy = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CzasPracy = table.Column<int>(type: "int(11)", nullable: false),
                    DruzynaId = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.ID);
                    table.ForeignKey(
                        name: "FK_pracownik_druzyna_DruzynaId",
                        column: x => x.DruzynaId,
                        principalTable: "druzyna",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_pracownik_osoba_ID",
                        column: x => x.ID,
                        principalTable: "osoba",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "tester",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false),
                    OsobaID = table.Column<int>(type: "int(11)", nullable: true),
                    WynagrodzenieZaTest = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Doswiadczenie = table.Column<int>(type: "int", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tester_osoba_ID",
                        column: x => x.ID,
                        principalTable: "osoba",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "tester_ibfk_1",
                        column: x => x.OsobaID,
                        principalTable: "osoba",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "AktorPracownik",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false),
                    DataZatrudnienia = table.Column<DateOnly>(type: "date", nullable: false),
                    miasto = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ulica = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nrDomu = table.Column<int>(type: "int", nullable: false),
                    kodPocztowy = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CzasPracy = table.Column<int>(type: "int", nullable: false),
                    AktorID = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AktorPracownik_aktor_ID",
                        column: x => x.ID,
                        principalTable: "aktor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "aktorpracownik_ibfk_1",
                        column: x => x.AktorID,
                        principalTable: "aktor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "graaktor",
                columns: table => new
                {
                    GraID = table.Column<int>(type: "int(11)", nullable: false),
                    AktorID = table.Column<int>(type: "int(11)", nullable: false),
                    Postac = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.GraID, x.AktorID })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                    table.ForeignKey(
                        name: "graaktor_ibfk_1",
                        column: x => x.GraID,
                        principalTable: "gra",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "graaktor_ibfk_2",
                        column: x => x.AktorID,
                        principalTable: "aktor",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "menadzer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false),
                    PracownikID = table.Column<int>(type: "int(11)", nullable: true),
                    Bonus = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.ID);
                    table.ForeignKey(
                        name: "FK_menadzer_pracownik_ID",
                        column: x => x.ID,
                        principalTable: "pracownik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "menadzer_ibfk_1",
                        column: x => x.PracownikID,
                        principalTable: "pracownik",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "przegladwydajnosci",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DataPrzegladu = table.Column<DateOnly>(type: "date", nullable: false),
                    Komentarz = table.Column<string>(type: "text", nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ocena = table.Column<int>(type: "int(11)", nullable: false),
                    PracownikID = table.Column<int>(type: "int(11)", nullable: true),
                    KrytykID = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.ID);
                    table.ForeignKey(
                        name: "przegladwydajnosci_ibfk_1",
                        column: x => x.PracownikID,
                        principalTable: "pracownik",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "przegladwydajnosci_ibfk_2",
                        column: x => x.KrytykID,
                        principalTable: "krytyk",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "test",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    GraID = table.Column<int>(type: "int(11)", nullable: true),
                    TesterID = table.Column<int>(type: "int(11)", nullable: true),
                    DataTestowania = table.Column<DateOnly>(type: "date", nullable: false),
                    Komentarz = table.Column<string>(type: "text", nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Wynik = table.Column<string>(type: "enum('zaliczony','niezaliczony')", nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.ID);
                    table.ForeignKey(
                        name: "test_ibfk_1",
                        column: x => x.GraID,
                        principalTable: "gra",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "test_ibfk_2",
                        column: x => x.TesterID,
                        principalTable: "tester",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_AktorPracownik_AktorID",
                table: "AktorPracownik",
                column: "AktorID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "GraID",
                table: "druzynagra",
                column: "GraID");

            migrationBuilder.CreateIndex(
                name: "AktorID",
                table: "graaktor",
                column: "AktorID");

            migrationBuilder.CreateIndex(
                name: "OsobaID",
                table: "krytyk",
                column: "OsobaID");

            migrationBuilder.CreateIndex(
                name: "IX_menadzer_PracownikID",
                table: "menadzer",
                column: "PracownikID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PracownikID",
                table: "menadzer",
                column: "PracownikID");

            migrationBuilder.CreateIndex(
                name: "Pesel",
                table: "osoba",
                column: "Pesel",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_pracownik_DruzynaId",
                table: "pracownik",
                column: "DruzynaId");

            migrationBuilder.CreateIndex(
                name: "KrytykID",
                table: "przegladwydajnosci",
                column: "KrytykID");

            migrationBuilder.CreateIndex(
                name: "PracownikID1",
                table: "przegladwydajnosci",
                column: "PracownikID");

            migrationBuilder.CreateIndex(
                name: "GraID1",
                table: "test",
                column: "GraID");

            migrationBuilder.CreateIndex(
                name: "TesterID",
                table: "test",
                column: "TesterID");

            migrationBuilder.CreateIndex(
                name: "OsobaID1",
                table: "tester",
                column: "OsobaID");

            migrationBuilder.CreateIndex(
                name: "IX_zadanie_DruzynaId",
                table: "zadanie",
                column: "DruzynaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AktorPracownik");

            migrationBuilder.DropTable(
                name: "druzynagra");

            migrationBuilder.DropTable(
                name: "graaktor");

            migrationBuilder.DropTable(
                name: "menadzer");

            migrationBuilder.DropTable(
                name: "przegladwydajnosci");

            migrationBuilder.DropTable(
                name: "test");

            migrationBuilder.DropTable(
                name: "zadanie");

            migrationBuilder.DropTable(
                name: "aktor");

            migrationBuilder.DropTable(
                name: "pracownik");

            migrationBuilder.DropTable(
                name: "krytyk");

            migrationBuilder.DropTable(
                name: "gra");

            migrationBuilder.DropTable(
                name: "tester");

            migrationBuilder.DropTable(
                name: "druzyna");

            migrationBuilder.DropTable(
                name: "osoba");
        }
    }
}
