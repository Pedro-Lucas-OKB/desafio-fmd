using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FMDLab.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participantes_Palestras_PalestraId",
                table: "Participantes");

            migrationBuilder.AddForeignKey(
                name: "FK_Participantes_Palestras_PalestraId",
                table: "Participantes",
                column: "PalestraId",
                principalTable: "Palestras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participantes_Palestras_PalestraId",
                table: "Participantes");

            migrationBuilder.AddForeignKey(
                name: "FK_Participantes_Palestras_PalestraId",
                table: "Participantes",
                column: "PalestraId",
                principalTable: "Palestras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
