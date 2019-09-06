using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ThePerfectBatch.Migrations
{
    public partial class ingredientsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Recipe_RecipeId",
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

            migrationBuilder.RenameColumn(
                name: "IngredientsId",
                table: "Ingredients",
                newName: "IngredientId");

            migrationBuilder.AlterColumn<int>(
                name: "RecipeId",
                table: "Ingredients",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "90fa8349-72c8-4b46-9ae8-687f8deefae3", "AQAAAAEAACcQAAAAEBE37eACdCMu5pv/wBPDH5Z3aj8rW8bhgtW+3ATwkw0ZRssctDnxRXlPKBLC8Sn5MA==" });

            migrationBuilder.InsertData(
                table: "Recipe",
                columns: new[] { "RecipeId", "DateCreated", "Image", "Name", "RecipeTypeId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 9, 6, 10, 23, 47, 376, DateTimeKind.Local), "images/FrenchToast.jpg", "French Toast", 1, "00000000-ffff-ffff-ffff-ffffffffffff" },
                    { 2, new DateTime(2019, 9, 6, 10, 23, 47, 380, DateTimeKind.Local), "images/ChickpeaCrepe.jpg", "Crepes", 2, "00000000-ffff-ffff-ffff-ffffffffffff" },
                    { 3, new DateTime(2019, 9, 6, 10, 23, 47, 380, DateTimeKind.Local), "images/GrilledCheese.jpg", "Grilled Cheese", 3, "00000000-ffff-ffff-ffff-ffffffffffff" },
                    { 4, new DateTime(2019, 9, 6, 10, 23, 47, 380, DateTimeKind.Local), "images/ChickenParm.jpg", "Chicken Parmesean", 4, "00000000-ffff-ffff-ffff-ffffffffffff" },
                    { 5, new DateTime(2019, 9, 6, 10, 23, 47, 380, DateTimeKind.Local), "images/ChocolateChipCookie.jpg", "Chocolate Chip Cookies", 5, "00000000-ffff-ffff-ffff-ffffffffffff" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "IngredientId", "Name", "Quantity", "RecipeId" },
                values: new object[,]
                {
                    { 1, "Egg", "1", 1 },
                    { 21, "Cubed Mozzarella", "1/4 Cup", 4 },
                    { 22, "Basil", "1/4 Cup", 4 },
                    { 23, "Provolone Cheese", "1/2 Cup", 4 },
                    { 24, "Grated Parmesean Cheese", "1/2 Cup", 4 },
                    { 25, "Olive Oil", "1 Tbsp", 4 },
                    { 26, "Butter", "1 Cup", 5 },
                    { 20, "Tomato Sauce", "1/2 Cup", 4 },
                    { 27, "White Sugar", "1 Cup", 5 },
                    { 29, "Egg", "2", 5 },
                    { 30, "Vanilla extract", "2 Tsp", 5 },
                    { 31, "Baking Soda", "1 Tsp", 5 },
                    { 32, "Hot Water", "1 Tsp", 5 },
                    { 33, "Salt", "1/2 Tsp", 5 },
                    { 34, "Flour", "3 Cups", 5 },
                    { 28, "Brown Sugar", "1 Cup", 5 },
                    { 19, "Olive Oil for Frying", "1 Cup", 4 },
                    { 18, "Flour", "2 Tbsp", 4 },
                    { 17, "Grated Parmesean Cheese", "1/2 Cup", 4 },
                    { 2, "Vanilla Extract", "1 Tsp", 1 },
                    { 3, "Cinnimon Grounds", "1/2 Tsp", 1 },
                    { 4, "Milk", "1/4 Cup of Milk", 1 },
                    { 5, "Bread", "4 Slices", 1 },
                    { 6, "Chickpea Flour", "1 Cup", 2 },
                    { 7, "Water", "1 and 1/4 Cups", 2 },
                    { 8, "Lemon Juice", "1 Tbsp", 2 },
                    { 9, "Salt", "1/2 Tsp", 2 },
                    { 10, "Bread", "2 Slices", 3 },
                    { 11, "Butter", "1 Tbsp", 3 },
                    { 12, "Cheese of Choice", "2 Slices", 3 },
                    { 13, "Skinless Chicken Breast", "4", 4 },
                    { 14, "Salt and Pepper", "To Taste", 4 },
                    { 15, "Eggs", "2", 4 },
                    { 16, "Bread Crumbs", "1 and 1/4 Cup", 4 },
                    { 35, "Chocolate Chips", "2 Cups", 5 },
                    { 36, "Chopped Walnuts", "1 Cup", 5 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Recipe_RecipeId",
                table: "Ingredients",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Recipe_RecipeId",
                table: "Ingredients");

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 36);

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

            migrationBuilder.RenameColumn(
                name: "IngredientId",
                table: "Ingredients",
                newName: "IngredientsId");

            migrationBuilder.AlterColumn<int>(
                name: "RecipeId",
                table: "Ingredients",
                nullable: true,
                oldClrType: typeof(int));

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

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Recipe_RecipeId",
                table: "Ingredients",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
