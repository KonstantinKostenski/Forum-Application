using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Topics_SectionId",
                table: "Topics",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Replies_TopicId",
                table: "Replies",
                column: "TopicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Replies_Topics_TopicId",
                table: "Replies",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_Sections_SectionId",
                table: "Topics",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Replies_Topics_TopicId",
                table: "Replies");

            migrationBuilder.DropForeignKey(
                name: "FK_Topics_Sections_SectionId",
                table: "Topics");

            migrationBuilder.DropIndex(
                name: "IX_Topics_SectionId",
                table: "Topics");

            migrationBuilder.DropIndex(
                name: "IX_Replies_TopicId",
                table: "Replies");
        }
    }
}
