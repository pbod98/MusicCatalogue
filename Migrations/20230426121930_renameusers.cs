using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicCatalogue.Migrations
{
    /// <inheritdoc />
    public partial class renameusers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Users_PublisherID",
                table: "Albums");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Publishers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Publishers",
                table: "Publishers",
                column: "PublisherID");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Publishers_PublisherID",
                table: "Albums",
                column: "PublisherID",
                principalTable: "Publishers",
                principalColumn: "PublisherID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Publishers_PublisherID",
                table: "Albums");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Publishers",
                table: "Publishers");

            migrationBuilder.RenameTable(
                name: "Publishers",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "PublisherID");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Users_PublisherID",
                table: "Albums",
                column: "PublisherID",
                principalTable: "Users",
                principalColumn: "PublisherID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
