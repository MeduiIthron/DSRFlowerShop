using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DSRFlowerProject.Db.Context.Migrations
{
    public partial class FlowerCounter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "flower_counters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlowerID = table.Column<int>(type: "int", nullable: false),
                    BouquetID = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_flower_counters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_flower_counters_bouquets_BouquetID",
                        column: x => x.BouquetID,
                        principalTable: "bouquets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_flower_counters_flowers_FlowerID",
                        column: x => x.FlowerID,
                        principalTable: "flowers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_flower_counters_BouquetID",
                table: "flower_counters",
                column: "BouquetID");

            migrationBuilder.CreateIndex(
                name: "IX_flower_counters_FlowerID",
                table: "flower_counters",
                column: "FlowerID");

            migrationBuilder.CreateIndex(
                name: "IX_flower_counters_Uid",
                table: "flower_counters",
                column: "Uid",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "flower_counters");
        }
    }
}
