using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkGuia.Server.Migrations
{
    public partial class Proveedor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {         
            migrationBuilder.CreateTable(
                name: "PROVEEDOR",
                columns: table => new
                {
                    ID_PROVEEDOR = table.Column<int>(nullable: false),
                    NOMBRE = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    APELLIDO = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROVEEDOR", x => x.ID_PROVEEDOR);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {            
            migrationBuilder.DropTable(
                name: "PROVEEDOR");
        }
    }
}
