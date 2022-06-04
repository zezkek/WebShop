using Microsoft.EntityFrameworkCore.Migrations;

namespace WebShop.Migrations
{
    public partial class BitChangesToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cpu_Type",
                table: "PowerSupply");

            migrationBuilder.RenameColumn(
                name: "Power_usage",
                table: "PowerSupply",
                newName: "Power_output");

            migrationBuilder.RenameColumn(
                name: "Cpu_Type",
                table: "Motherboard",
                newName: "CPU_Type");

            migrationBuilder.AddColumn<int>(
                name: "RAM_Type",
                table: "CPU",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CPU_RAM",
                columns: table => new
                {
                    CPU_Id = table.Column<int>(type: "int", nullable: false),
                    RAM_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPU_RAM", x => new { x.CPU_Id, x.RAM_Id });
                    table.ForeignKey(
                        name: "FK_CPU_RAM_CPU_CPU_Id",
                        column: x => x.CPU_Id,
                        principalTable: "CPU",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CPU_RAM_RAM_RAM_Id",
                        column: x => x.RAM_Id,
                        principalTable: "RAM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CPU_RAM_RAM_Id",
                table: "CPU_RAM",
                column: "RAM_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CPU_RAM");

            migrationBuilder.DropColumn(
                name: "RAM_Type",
                table: "CPU");

            migrationBuilder.RenameColumn(
                name: "Power_output",
                table: "PowerSupply",
                newName: "Power_usage");

            migrationBuilder.RenameColumn(
                name: "CPU_Type",
                table: "Motherboard",
                newName: "Cpu_Type");

            migrationBuilder.AddColumn<int>(
                name: "Cpu_Type",
                table: "PowerSupply",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
