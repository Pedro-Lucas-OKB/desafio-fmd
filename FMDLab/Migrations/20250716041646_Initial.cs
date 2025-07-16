using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FMDLab.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Palestras",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Titulo = table.Column<string>(type: "NVARCHAR", maxLength: 150, nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR", maxLength: 2000, nullable: false),
                    DataHora = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Palestras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Participantes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "NVARCHAR", maxLength: 120, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR", maxLength: 160, nullable: false),
                    Telefone = table.Column<string>(type: "VARCHAR", maxLength: 20, nullable: false),
                    PalestraId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participantes_Palestras_PalestraId",
                        column: x => x.PalestraId,
                        principalTable: "Palestras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Participantes_PalestraId",
                table: "Participantes",
                column: "PalestraId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Participantes");

            migrationBuilder.DropTable(
                name: "Palestras");
        }
    }
}
