using Microsoft.EntityFrameworkCore.Migrations;

namespace WebShop.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CPU",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Power_usage = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPU_Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPU", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GPU",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Power_usage = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GPU", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Motherboard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Cpu_Type = table.Column<int>(type: "int", nullable: false),
                    RAM_Type = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motherboard", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PowerSupply",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Power_usage = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cpu_Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PowerSupply", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RAM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RAM_Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RAM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CPU_Motherboard",
                columns: table => new
                {
                    CPU_Id = table.Column<int>(type: "int", nullable: false),
                    Motherboard_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPU_Motherboard", x => new { x.CPU_Id, x.Motherboard_Id });
                    table.ForeignKey(
                        name: "FK_CPU_Motherboard_CPU_CPU_Id",
                        column: x => x.CPU_Id,
                        principalTable: "CPU",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CPU_Motherboard_Motherboard_Motherboard_Id",
                        column: x => x.Motherboard_Id,
                        principalTable: "Motherboard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RAM_Motherboard",
                columns: table => new
                {
                    RAM_Id = table.Column<int>(type: "int", nullable: false),
                    Motherboard_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RAM_Motherboard", x => new { x.RAM_Id, x.Motherboard_Id });
                    table.ForeignKey(
                        name: "FK_RAM_Motherboard_Motherboard_Motherboard_Id",
                        column: x => x.Motherboard_Id,
                        principalTable: "Motherboard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RAM_Motherboard_RAM_RAM_Id",
                        column: x => x.RAM_Id,
                        principalTable: "RAM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CPU_Motherboard_Motherboard_Id",
                table: "CPU_Motherboard",
                column: "Motherboard_Id");

            migrationBuilder.CreateIndex(
                name: "IX_RAM_Motherboard_Motherboard_Id",
                table: "RAM_Motherboard",
                column: "Motherboard_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CPU_Motherboard");

            migrationBuilder.DropTable(
                name: "GPU");

            migrationBuilder.DropTable(
                name: "PowerSupply");

            migrationBuilder.DropTable(
                name: "RAM_Motherboard");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "CPU");

            migrationBuilder.DropTable(
                name: "Motherboard");

            migrationBuilder.DropTable(
                name: "RAM");
        }
    }
}
