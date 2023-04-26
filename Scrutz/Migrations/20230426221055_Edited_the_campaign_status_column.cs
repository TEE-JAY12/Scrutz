using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Scrutz.Migrations
{
    /// <inheritdoc />
    public partial class Edited_the_campaign_status_column : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CampaignStatus",
                table: "Campaigns",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                defaultValue: "InActive",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldDefaultValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CampaignStatus",
                table: "Campaigns",
                type: "int",
                nullable: true,
                defaultValue: 1,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldDefaultValue: "InActive");
        }
    }
}
