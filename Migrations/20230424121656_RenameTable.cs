using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicCatalogue.Migrations
{
    /// <inheritdoc />
    public partial class RenameTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Users_UserID",
                table: "Albums");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Users",
                newName: "PublisherID");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Albums",
                newName: "PublisherID");

            migrationBuilder.RenameIndex(
                name: "IX_Albums_UserID",
                table: "Albums",
                newName: "IX_Albums_PublisherID");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Users_PublisherID",
                table: "Albums",
                column: "PublisherID",
                principalTable: "Users",
                principalColumn: "PublisherID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Users_PublisherID",
                table: "Albums");

            migrationBuilder.RenameColumn(
                name: "PublisherID",
                table: "Users",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "PublisherID",
                table: "Albums",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Albums_PublisherID",
                table: "Albums",
                newName: "IX_Albums_UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Users_UserID",
                table: "Albums",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
