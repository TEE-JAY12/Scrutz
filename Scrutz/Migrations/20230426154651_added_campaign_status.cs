using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Scrutz.Migrations
{
    /// <inheritdoc />
    public partial class added_campaign_status : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CampaignStatus",
                table: "Campaigns",
                type: "int",
                nullable: true,
                defaultValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CampaignStatus",
                table: "Campaigns");
        }
    }
}
