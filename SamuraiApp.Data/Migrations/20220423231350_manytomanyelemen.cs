using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SamuraiApp.Data.Migrations
{
    public partial class manytomanyelemen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Elemens",
                columns: table => new
                {
                    ElemenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elemens", x => x.ElemenId);
                });

            migrationBuilder.CreateTable(
                name: "ElemenPedang",
                columns: table => new
                {
                    ElemensElemenId = table.Column<int>(type: "int", nullable: false),
                    PedangsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElemenPedang", x => new { x.ElemensElemenId, x.PedangsId });
                    table.ForeignKey(
                        name: "FK_ElemenPedang_Elemens_ElemensElemenId",
                        column: x => x.ElemensElemenId,
                        principalTable: "Elemens",
                        principalColumn: "ElemenId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElemenPedang_Pedangs_PedangsId",
                        column: x => x.PedangsId,
                        principalTable: "Pedangs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ElemenPedang_PedangsId",
                table: "ElemenPedang",
                column: "PedangsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElemenPedang");

            migrationBuilder.DropTable(
                name: "Elemens");
        }
    }
}
