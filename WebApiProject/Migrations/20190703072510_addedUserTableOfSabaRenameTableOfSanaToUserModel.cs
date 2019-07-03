using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiProject.Data.Migrations
{
    public partial class addedUserTableOfSabaRenameTableOfSanaToUserModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Choice",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "FileNames",
                table: "Users",
                newName: "File");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "Employe_Role");

            migrationBuilder.RenameColumn(
                name: "Comments",
                table: "Users",
                newName: "Address");

            migrationBuilder.CreateTable(
                name: "StudentRegisterations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Program = table.Column<string>(nullable: true),
                    Detail = table.Column<string>(nullable: true),
                    Filename = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentRegisterations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Comments = table.Column<string>(nullable: true),
                    Choice = table.Column<string>(nullable: true),
                    FileNames = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModels", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentRegisterations");

            migrationBuilder.DropTable(
                name: "UserModels");

            migrationBuilder.RenameColumn(
                name: "File",
                table: "Users",
                newName: "FileNames");

            migrationBuilder.RenameColumn(
                name: "Employe_Role",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Users",
                newName: "Comments");

            migrationBuilder.AddColumn<string>(
                name: "Choice",
                table: "Users",
                nullable: true);
        }
    }
}
