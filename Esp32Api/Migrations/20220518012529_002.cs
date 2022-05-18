using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Esp32Api.Migrations
{
    public partial class _002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "TempDatas",
                newName: "Value");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Value",
                table: "TempDatas",
                newName: "Name");
        }
    }
}
