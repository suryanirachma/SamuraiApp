using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SamuraiApp.Data.Migrations
{
    public partial class many2manyelemenpedang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ElemenPedang_Elemens_ElemensElemenId",
                table: "ElemenPedang");

            migrationBuilder.DropForeignKey(
                name: "FK_ElemenPedang_Pedangs_PedangsId",
                table: "ElemenPedang");

            migrationBuilder.RenameColumn(
                name: "PedangsId",
                table: "ElemenPedang",
                newName: "PedangId");

            migrationBuilder.RenameColumn(
                name: "ElemensElemenId",
                table: "ElemenPedang",
                newName: "ElemenId");

            migrationBuilder.RenameIndex(
                name: "IX_ElemenPedang_PedangsId",
                table: "ElemenPedang",
                newName: "IX_ElemenPedang_PedangId");

            migrationBuilder.AddForeignKey(
                name: "FK_ElemenPedang_Elemens_ElemenId",
                table: "ElemenPedang",
                column: "ElemenId",
                principalTable: "Elemens",
                principalColumn: "ElemenId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ElemenPedang_Pedangs_PedangId",
                table: "ElemenPedang",
                column: "PedangId",
                principalTable: "Pedangs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ElemenPedang_Elemens_ElemenId",
                table: "ElemenPedang");

            migrationBuilder.DropForeignKey(
                name: "FK_ElemenPedang_Pedangs_PedangId",
                table: "ElemenPedang");

            migrationBuilder.RenameColumn(
                name: "PedangId",
                table: "ElemenPedang",
                newName: "PedangsId");

            migrationBuilder.RenameColumn(
                name: "ElemenId",
                table: "ElemenPedang",
                newName: "ElemensElemenId");

            migrationBuilder.RenameIndex(
                name: "IX_ElemenPedang_PedangId",
                table: "ElemenPedang",
                newName: "IX_ElemenPedang_PedangsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ElemenPedang_Elemens_ElemensElemenId",
                table: "ElemenPedang",
                column: "ElemensElemenId",
                principalTable: "Elemens",
                principalColumn: "ElemenId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ElemenPedang_Pedangs_PedangsId",
                table: "ElemenPedang",
                column: "PedangsId",
                principalTable: "Pedangs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
