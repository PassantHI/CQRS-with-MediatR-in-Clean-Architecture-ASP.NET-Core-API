using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class genreedit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Genres_GerneId",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "GerneId",
                table: "Movies",
                newName: "GenreId");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_GerneId",
                table: "Movies",
                newName: "IX_Movies_GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Genres_GenreId",
                table: "Movies",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Genres_GenreId",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "GenreId",
                table: "Movies",
                newName: "GerneId");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_GenreId",
                table: "Movies",
                newName: "IX_Movies_GerneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Genres_GerneId",
                table: "Movies",
                column: "GerneId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
