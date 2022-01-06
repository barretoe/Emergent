using Microsoft.EntityFrameworkCore.Migrations;
using Emergent.DbContext;
using System.Collections.Generic;
using Emergent.Models;

namespace Emergent.Migrations
{
    public partial class CreateEmptyDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            IEnumerable<Software> enumerable = SoftwareManager.GetAllSoftware();
            List<Software> data = new List<Software>(enumerable);

            migrationBuilder.CreateTable(
                name: "software",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            for(int x = 0; x < data.Count; x++)
            {
                migrationBuilder.InsertData(
                    table: "software",
                    columns: new[] { "Name", "Version" },
                    values: new object[,]
                    {
                        { data[x].Name, data[x].Version },
                    });
            }
                
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "software");
        }
    }
}
