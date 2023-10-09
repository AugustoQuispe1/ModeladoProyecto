using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModeladoProyecto.BData.Migrations
{
    /// <inheritdoc />
    public partial class inicio2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "stock",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodStock = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Producto = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Cantidad = table.Column<int>(type: "int", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stock", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "Id_UQ",
                table: "stock",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "stock");
        }
    }
}
