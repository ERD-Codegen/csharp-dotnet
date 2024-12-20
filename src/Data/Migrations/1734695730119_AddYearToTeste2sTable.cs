using Microsoft.EntityFrameworkCore.Migrations;

public partial class AddYearToTeste2sTable : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<int>(
            name: "year",
            table: "teste2s",
            nullable: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "year",
            table: "teste2s");
    }
}