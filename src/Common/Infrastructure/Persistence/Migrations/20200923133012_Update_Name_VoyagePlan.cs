using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class Update_Name_VoyagePlan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VoyagePlan_Cities_CityFromId",
                table: "VoyagePlan");

            migrationBuilder.DropForeignKey(
                name: "FK_VoyagePlan_Cities_CityToId",
                table: "VoyagePlan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VoyagePlan",
                table: "VoyagePlan");

            migrationBuilder.RenameTable(
                name: "VoyagePlan",
                newName: "VoyagePlans");

            migrationBuilder.RenameIndex(
                name: "IX_VoyagePlan_CityToId",
                table: "VoyagePlans",
                newName: "IX_VoyagePlans_CityToId");

            migrationBuilder.RenameIndex(
                name: "IX_VoyagePlan_CityFromId",
                table: "VoyagePlans",
                newName: "IX_VoyagePlans_CityFromId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VoyagePlans",
                table: "VoyagePlans",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VoyagePlans_Cities_CityFromId",
                table: "VoyagePlans",
                column: "CityFromId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VoyagePlans_Cities_CityToId",
                table: "VoyagePlans",
                column: "CityToId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VoyagePlans_Cities_CityFromId",
                table: "VoyagePlans");

            migrationBuilder.DropForeignKey(
                name: "FK_VoyagePlans_Cities_CityToId",
                table: "VoyagePlans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VoyagePlans",
                table: "VoyagePlans");

            migrationBuilder.RenameTable(
                name: "VoyagePlans",
                newName: "VoyagePlan");

            migrationBuilder.RenameIndex(
                name: "IX_VoyagePlans_CityToId",
                table: "VoyagePlan",
                newName: "IX_VoyagePlan_CityToId");

            migrationBuilder.RenameIndex(
                name: "IX_VoyagePlans_CityFromId",
                table: "VoyagePlan",
                newName: "IX_VoyagePlan_CityFromId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VoyagePlan",
                table: "VoyagePlan",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VoyagePlan_Cities_CityFromId",
                table: "VoyagePlan",
                column: "CityFromId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VoyagePlan_Cities_CityToId",
                table: "VoyagePlan",
                column: "CityToId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
