using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ThePerfectBatch.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "RecipeType",
                columns: table => new
                {
                    RecipeTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeType", x => x.RecipeTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Recipe",
                columns: table => new
                {
                    RecipeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RecipeTypeId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipe", x => x.RecipeId);
                    table.ForeignKey(
                        name: "FK_Recipe_RecipeType_RecipeTypeId",
                        column: x => x.RecipeTypeId,
                        principalTable: "RecipeType",
                        principalColumn: "RecipeTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recipe_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    IngredientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RecipeId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Quantity = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.IngredientId);
                    table.ForeignKey(
                        name: "FK_Ingredients_Recipe_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipe",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "RecipeType",
                columns: new[] { "RecipeTypeId", "Name" },
                values: new object[,]
                {
                    { 1, "Breakfast" },
                    { 2, "Brunch" },
                    { 3, "Lunch" },
                    { 4, "Dinner" },
                    { 5, "Desert" }
                });

            migrationBuilder.InsertData(
                table: "Recipe",
                columns: new[] { "RecipeId", "DateCreated", "Image", "Name", "RecipeTypeId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 9, 7, 14, 39, 48, 354, DateTimeKind.Local), "images/FrenchToast.jpg", "French Toast", 1, "00000000-ffff-ffff-ffff-ffffffffffff" },
                    { 2, new DateTime(2019, 9, 7, 14, 39, 48, 359, DateTimeKind.Local), "images/ChickpeaCrepe.jpg", "Crepes", 2, "00000000-ffff-ffff-ffff-ffffffffffff" },
                    { 3, new DateTime(2019, 9, 7, 14, 39, 48, 359, DateTimeKind.Local), "images/GrilledCheese.jpg", "Grilled Cheese", 3, "00000000-ffff-ffff-ffff-ffffffffffff" },
                    { 4, new DateTime(2019, 9, 7, 14, 39, 48, 359, DateTimeKind.Local), "images/ChickenParm.jpg", "Chicken Parmesean", 4, "00000000-ffff-ffff-ffff-ffffffffffff" },
                    { 5, new DateTime(2019, 9, 7, 14, 39, 48, 359, DateTimeKind.Local), "images/ChocolateChipCookie.jpg", "Chocolate Chip Cookies", 5, "00000000-ffff-ffff-ffff-ffffffffffff" }
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


            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_RecipeId",
                table: "Ingredients",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_RecipeTypeId",
                table: "Recipe",
                column: "RecipeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_UserId",
                table: "Recipe",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropTable(
                name: "Ingredients");


            migrationBuilder.DropTable(
                name: "Recipe");

            migrationBuilder.DropTable(
                name: "RecipeType");

        }
    }
}
