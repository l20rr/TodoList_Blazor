using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoList_blazor.API.Migrations
{
    /// <inheritdoc />
    public partial class tododb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dos",
                columns: table => new
                {
                    DoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoString = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Completed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dos", x => x.DoId);
                });

            migrationBuilder.InsertData(
                table: "Dos",
                columns: new[] { "DoId", "Completed", "DoString" },
                values: new object[] { 1, false, "item 1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dos");
        }
    }
}
