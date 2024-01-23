using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class PositionId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Positions_PositionID",
                table: "People");

            migrationBuilder.RenameColumn(
                name: "PositionID",
                table: "People",
                newName: "PositionId");

            migrationBuilder.RenameIndex(
                name: "IX_People_PositionID",
                table: "People",
                newName: "IX_People_PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Positions_PositionId",
                table: "People",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Positions_PositionId",
                table: "People");

            migrationBuilder.RenameColumn(
                name: "PositionId",
                table: "People",
                newName: "PositionID");

            migrationBuilder.RenameIndex(
                name: "IX_People_PositionId",
                table: "People",
                newName: "IX_People_PositionID");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Positions_PositionID",
                table: "People",
                column: "PositionID",
                principalTable: "Positions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
