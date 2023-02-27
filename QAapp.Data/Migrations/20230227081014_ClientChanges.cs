using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QAapp.Data.Migrations
{
    /// <inheritdoc />
    public partial class ClientChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderAmount",
                table: "Clients");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "OrderAmount",
                table: "Clients",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
