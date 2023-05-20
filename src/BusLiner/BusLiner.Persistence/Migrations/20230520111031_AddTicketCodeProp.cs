using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusLiner.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddTicketCodeProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TicketCode",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketCode",
                table: "Orders");
        }
    }
}
