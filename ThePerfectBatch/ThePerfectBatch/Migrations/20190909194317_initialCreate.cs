using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ThePerfectBatch.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    DateCreated = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
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
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "00000000-ffff-ffff-ffff-ffffffffffff", 0, "f0625022-bc02-4422-86d7-7fadd2155b74", "mr.mcconnell@internet.com", true, "Ricky", "McConnell", false, null, "MR.MCCONNELL@INTERNET.COM", null, "AQAAAAEAACcQAAAAEBsSgkvqcGmMf9gPqTVU+qvdfd8O4n3mV4Nt6V7yJ7g9K9V9xV15jln438gWhi7aLQ==", null, false, "7f434309-a4d9-48e9-9ebb-8803db794577", false, null });

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
                    { 1, new DateTime(2019, 9, 9, 14, 43, 17, 406, DateTimeKind.Local), "images/FrenchToast.jpg", "French Toast", 1, "00000000-ffff-ffff-ffff-ffffffffffff" },
                    { 2, new DateTime(2019, 9, 9, 14, 43, 17, 409, DateTimeKind.Local), "images/ChickpeaCrepe.jpg", "Crepes", 2, "00000000-ffff-ffff-ffff-ffffffffffff" },
                    { 3, new DateTime(2019, 9, 9, 14, 43, 17, 409, DateTimeKind.Local), "images/GrilledCheese.jpg", "Grilled Cheese", 3, "00000000-ffff-ffff-ffff-ffffffffffff" },
                    { 4, new DateTime(2019, 9, 9, 14, 43, 17, 409, DateTimeKind.Local), "images/ChickenParm.jpg", "Chicken Parmesean", 4, "00000000-ffff-ffff-ffff-ffffffffffff" },
                    { 5, new DateTime(2019, 9, 9, 14, 43, 17, 409, DateTimeKind.Local), "images/ChocolateChipCookie.jpg", "Chocolate Chip Cookies", 5, "00000000-ffff-ffff-ffff-ffffffffffff" }
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
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Recipe");

            migrationBuilder.DropTable(
                name: "RecipeType");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
