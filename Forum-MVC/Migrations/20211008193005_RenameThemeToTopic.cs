using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum_MVC.Migrations
{
    public partial class RenameThemeToTopic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Themes_ThemeId",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "Themes");

            migrationBuilder.RenameColumn(
                name: "ThemeId",
                table: "Posts",
                newName: "TopicId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_ThemeId",
                table: "Posts",
                newName: "IX_Posts_TopicId");

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Topics_TopicId",
                table: "Posts",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Topics_TopicId",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.RenameColumn(
                name: "TopicId",
                table: "Posts",
                newName: "ThemeId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_TopicId",
                table: "Posts",
                newName: "IX_Posts_ThemeId");

            migrationBuilder.CreateTable(
                name: "Themes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Themes", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Themes_ThemeId",
                table: "Posts",
                column: "ThemeId",
                principalTable: "Themes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
