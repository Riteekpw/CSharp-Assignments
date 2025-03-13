using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagementWebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddedControllers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MembersMapToBook_Books_BookId",
                table: "MembersMapToBook");

            migrationBuilder.DropForeignKey(
                name: "FK_MembersMapToBook_Librarian_LibrarianId",
                table: "MembersMapToBook");

            migrationBuilder.DropForeignKey(
                name: "FK_MembersMapToBook_Members_MemberId",
                table: "MembersMapToBook");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MembersMapToBook",
                table: "MembersMapToBook");

            migrationBuilder.RenameTable(
                name: "MembersMapToBook",
                newName: "MemberMapToBook");

            migrationBuilder.RenameColumn(
                name: "IsEbook",
                table: "Books",
                newName: "IsEBook");

            migrationBuilder.RenameIndex(
                name: "IX_MembersMapToBook_MemberId",
                table: "MemberMapToBook",
                newName: "IX_MemberMapToBook_MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_MembersMapToBook_LibrarianId",
                table: "MemberMapToBook",
                newName: "IX_MemberMapToBook_LibrarianId");

            migrationBuilder.RenameIndex(
                name: "IX_MembersMapToBook_BookId",
                table: "MemberMapToBook",
                newName: "IX_MemberMapToBook_BookId");

            migrationBuilder.AlterColumn<bool>(
                name: "IsEBook",
                table: "Books",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MemberMapToBook",
                table: "MemberMapToBook",
                column: "MappingId");

            migrationBuilder.AddForeignKey(
                name: "FK_MemberMapToBook_Books_BookId",
                table: "MemberMapToBook",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MemberMapToBook_Librarian_LibrarianId",
                table: "MemberMapToBook",
                column: "LibrarianId",
                principalTable: "Librarian",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MemberMapToBook_Members_MemberId",
                table: "MemberMapToBook",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MemberMapToBook_Books_BookId",
                table: "MemberMapToBook");

            migrationBuilder.DropForeignKey(
                name: "FK_MemberMapToBook_Librarian_LibrarianId",
                table: "MemberMapToBook");

            migrationBuilder.DropForeignKey(
                name: "FK_MemberMapToBook_Members_MemberId",
                table: "MemberMapToBook");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MemberMapToBook",
                table: "MemberMapToBook");

            migrationBuilder.RenameTable(
                name: "MemberMapToBook",
                newName: "MembersMapToBook");

            migrationBuilder.RenameColumn(
                name: "IsEBook",
                table: "Books",
                newName: "IsEbook");

            migrationBuilder.RenameIndex(
                name: "IX_MemberMapToBook_MemberId",
                table: "MembersMapToBook",
                newName: "IX_MembersMapToBook_MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_MemberMapToBook_LibrarianId",
                table: "MembersMapToBook",
                newName: "IX_MembersMapToBook_LibrarianId");

            migrationBuilder.RenameIndex(
                name: "IX_MemberMapToBook_BookId",
                table: "MembersMapToBook",
                newName: "IX_MembersMapToBook_BookId");

            migrationBuilder.AlterColumn<string>(
                name: "IsEbook",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MembersMapToBook",
                table: "MembersMapToBook",
                column: "MappingId");

            migrationBuilder.AddForeignKey(
                name: "FK_MembersMapToBook_Books_BookId",
                table: "MembersMapToBook",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MembersMapToBook_Librarian_LibrarianId",
                table: "MembersMapToBook",
                column: "LibrarianId",
                principalTable: "Librarian",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MembersMapToBook_Members_MemberId",
                table: "MembersMapToBook",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
