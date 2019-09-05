using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ThePerfectBatch.Migrations
{
    public partial class addingRecipeImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Recipe",
                keyColumn: "RecipeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Recipe",
                keyColumn: "RecipeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Recipe",
                keyColumn: "RecipeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Recipe",
                keyColumn: "RecipeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Recipe",
                keyColumn: "RecipeId",
                keyValue: 5);

            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "Ingredients",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0069ea49-d02b-4003-b336-303b368c7b46", "AQAAAAEAACcQAAAAEH51QoBN65u8SjB7DpYI/4mpXnkaEt0r2WvNDL2Due2106fKugX8J888d9gqQoYMpg==" });

            migrationBuilder.InsertData(
                table: "Recipe",
                columns: new[] { "RecipeId", "DateCreated", "Image", "Name", "RecipeTypeId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 9, 5, 16, 31, 54, 993, DateTimeKind.Local), "images/FrenchToast.jpg", "French Toast", 1, "00000000-ffff-ffff-ffff-ffffffffffff" },
                    { 2, new DateTime(2019, 9, 5, 16, 31, 54, 997, DateTimeKind.Local), "images/ChickpeaCrepe.jpg", "Crepes", 2, "00000000-ffff-ffff-ffff-ffffffffffff" },
                    { 3, new DateTime(2019, 9, 5, 16, 31, 54, 997, DateTimeKind.Local), "images/GrilledCheese.jpg", "Grilled Cheese", 3, "00000000-ffff-ffff-ffff-ffffffffffff" },
                    { 4, new DateTime(2019, 9, 5, 16, 31, 54, 997, DateTimeKind.Local), "images/ChickenParm.jpg", "Chicken Parmesean", 4, "00000000-ffff-ffff-ffff-ffffffffffff" },
                    { 5, new DateTime(2019, 9, 5, 16, 31, 54, 997, DateTimeKind.Local), "images/ChocolateChipCookie.jpg", "Chocolate Chip Cookies", 5, "00000000-ffff-ffff-ffff-ffffffffffff" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_RecipeId",
                table: "Ingredients",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Recipe_RecipeId",
                table: "Ingredients",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Recipe_RecipeId",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_RecipeId",
                table: "Ingredients");

            migrationBuilder.DeleteData(
                table: "Recipe",
                keyColumn: "RecipeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Recipe",
                keyColumn: "RecipeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Recipe",
                keyColumn: "RecipeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Recipe",
                keyColumn: "RecipeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Recipe",
                keyColumn: "RecipeId",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "Ingredients");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ccbc9b8e-ebf0-417e-88c7-b6d62b5ec6a7", "AQAAAAEAACcQAAAAECCC0nKM3OlW9PjAfNI0LLn2GLLyKx7/efWPX/7yHjS0uiRPwZlr3CQqqGSC6QpcuA==" });

            migrationBuilder.InsertData(
                table: "Recipe",
                columns: new[] { "RecipeId", "DateCreated", "Image", "Name", "RecipeTypeId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 9, 5, 14, 3, 53, 318, DateTimeKind.Local), null, "French Toast", 1, "00000000-ffff-ffff-ffff-ffffffffffff" },
                    { 2, new DateTime(2019, 9, 5, 14, 3, 53, 321, DateTimeKind.Local), null, "Crepes", 2, "00000000-ffff-ffff-ffff-ffffffffffff" },
                    { 3, new DateTime(2019, 9, 5, 14, 3, 53, 321, DateTimeKind.Local), null, "Grilled Cheese", 3, "00000000-ffff-ffff-ffff-ffffffffffff" },
                    { 4, new DateTime(2019, 9, 5, 14, 3, 53, 321, DateTimeKind.Local), null, "Chicken Parmesean", 4, "00000000-ffff-ffff-ffff-ffffffffffff" },
                    { 5, new DateTime(2019, 9, 5, 14, 3, 53, 321, DateTimeKind.Local), "ThePerfectBatch/wwwroot/images/ChocolateChipCookie.jpg", "Chocolate Chip Cookies", 5, "00000000-ffff-ffff-ffff-ffffffffffff" }
                });
        }
    }
}
