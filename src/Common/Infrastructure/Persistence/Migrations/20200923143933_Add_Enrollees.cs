using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class Add_Enrollees : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentCapacity",
                table: "VoyagePlans");

            migrationBuilder.CreateTable(
                name: "Enrollees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Creator = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Modifier = table.Column<string>(nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    VoyagePlanId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enrollees_VoyagePlans_VoyagePlanId",
                        column: x => x.VoyagePlanId,
                        principalTable: "VoyagePlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enrollees_VoyagePlanId",
                table: "Enrollees",
                column: "VoyagePlanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrollees");

            migrationBuilder.AddColumn<int>(
                name: "CurrentCapacity",
                table: "VoyagePlans",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
