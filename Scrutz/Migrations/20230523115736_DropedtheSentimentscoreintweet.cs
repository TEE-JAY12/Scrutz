using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Scrutz.Migrations
{
    /// <inheritdoc />
    public partial class DropedtheSentimentscoreintweet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SentimentScore",
                table: "Tweet");

            migrationBuilder.AddColumn<int>(
                name: "TweetMetricId",
                table: "Tweet",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tweet_TweetMetricId",
                table: "Tweet",
                column: "TweetMetricId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tweet_TweetMetrics_TweetMetricId",
                table: "Tweet",
                column: "TweetMetricId",
                principalTable: "TweetMetrics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tweet_TweetMetrics_TweetMetricId",
                table: "Tweet");

            migrationBuilder.DropIndex(
                name: "IX_Tweet_TweetMetricId",
                table: "Tweet");

            migrationBuilder.DropColumn(
                name: "TweetMetricId",
                table: "Tweet");

            migrationBuilder.AddColumn<decimal>(
                name: "SentimentScore",
                table: "Tweet",
                type: "decimal(18,2)",
                nullable: true);
        }
    }
}
