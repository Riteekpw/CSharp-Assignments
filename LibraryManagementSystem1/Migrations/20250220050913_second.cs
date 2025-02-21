using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagementSystem1.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookRecords_Librarians_LibrarianId",
                table: "BookRecords");

            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LibrarianId",
                table: "BookRecords",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookRecords_Librarians_LibrarianId",
                table: "BookRecords",
                column: "LibrarianId",
                principalTable: "Librarians",
                principalColumn: "LibrarianId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookRecords_Librarians_LibrarianId",
                table: "BookRecords");

            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "Books",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LibrarianId",
                table: "BookRecords",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_BookRecords_Librarians_LibrarianId",
                table: "BookRecords",
                column: "LibrarianId",
                principalTable: "Librarians",
                principalColumn: "LibrarianId");
        }
    }
}
