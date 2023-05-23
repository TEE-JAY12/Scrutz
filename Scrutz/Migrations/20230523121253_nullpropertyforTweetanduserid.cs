using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Scrutz.Migrations
{
    /// <inheritdoc />
    public partial class nullpropertyforTweetanduserid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tweet_TweetMetrics_TweetMetricId",
                table: "Tweet");

            migrationBuilder.DropForeignKey(
                name: "FK_Tweet_Users_UserID",
                table: "Tweet");

            migrationBuilder.DropForeignKey(
                name: "FK_TweetMetrics_Tweet_TweetID",
                table: "TweetMetrics");

            migrationBuilder.DropIndex(
                name: "IX_TweetMetrics_TweetID",
                table: "TweetMetrics");

            migrationBuilder.DropIndex(
                name: "IX_Tweet_TweetMetricId",
                table: "Tweet");

            migrationBuilder.DropColumn(
                name: "TweetMetricId",
                table: "Tweet");

            migrationBuilder.AlterColumn<string>(
                name: "TweetID",
                table: "TweetMetrics",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Tweet",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TweetMetrics_TweetID",
                table: "TweetMetrics",
                column: "TweetID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tweet_Users_UserID",
                table: "Tweet",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TweetMetrics_Tweet_TweetID",
                table: "TweetMetrics",
                column: "TweetID",
                principalTable: "Tweet",
                principalColumn: "TweetID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tweet_Users_UserID",
                table: "Tweet");

            migrationBuilder.DropForeignKey(
                name: "FK_TweetMetrics_Tweet_TweetID",
                table: "TweetMetrics");

            migrationBuilder.DropIndex(
                name: "IX_TweetMetrics_TweetID",
                table: "TweetMetrics");

            migrationBuilder.AlterColumn<string>(
                name: "TweetID",
                table: "TweetMetrics",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Tweet",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "TweetMetricId",
                table: "Tweet",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TweetMetrics_TweetID",
                table: "TweetMetrics",
                column: "TweetID",
                unique: true,
                filter: "[TweetID] IS NOT NULL");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Tweet_Users_UserID",
                table: "Tweet",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_TweetMetrics_Tweet_TweetID",
                table: "TweetMetrics",
                column: "TweetID",
                principalTable: "Tweet",
                principalColumn: "TweetID");
        }
    }
}
