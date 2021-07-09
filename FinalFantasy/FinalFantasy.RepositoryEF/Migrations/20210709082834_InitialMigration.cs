using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalFantasy.RepositoryEF.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Level",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Level", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Nickname = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Nickname);
                });

            migrationBuilder.CreateTable(
                name: "Weapon",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapon", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Hero",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Life = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LevelID = table.Column<int>(type: "int", nullable: false),
                    WeaponID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hero", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Hero_Level_LevelID",
                        column: x => x.LevelID,
                        principalTable: "Level",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hero_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "Nickname",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hero_Weapon_WeaponID",
                        column: x => x.WeaponID,
                        principalTable: "Weapon",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Monster",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Life = table.Column<int>(type: "int", nullable: false),
                    LevelID = table.Column<int>(type: "int", nullable: false),
                    WeaponID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monster", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Monster_Level_LevelID",
                        column: x => x.LevelID,
                        principalTable: "Level",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Monster_Weapon_WeaponID",
                        column: x => x.WeaponID,
                        principalTable: "Weapon",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Level",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Level 1" },
                    { 2, "Level 2" },
                    { 3, "Level 3" },
                    { 4, "Level 4" },
                    { 5, "Level 5" }
                });

            migrationBuilder.InsertData(
                table: "Weapon",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 10, 9 },
                    { 9, 8 },
                    { 8, 7 },
                    { 7, 6 },
                    { 6, 5 },
                    { 4, 3 },
                    { 11, 10 },
                    { 3, 2 },
                    { 2, 1 },
                    { 1, 0 },
                    { 5, 4 },
                    { 12, 11 }
                });

            migrationBuilder.InsertData(
                table: "Monster",
                columns: new[] { "ID", "LevelID", "Life", "Name", "Type", "WeaponID" },
                values: new object[,]
                {
                    { 1, 1, 20, "Fantasma1", "Ghost", 1 },
                    { 3, 5, 100, "Lucifer1", "Lucifer", 1 },
                    { 2, 2, 40, "Fantasma2", "Ghost", 2 },
                    { 4, 3, 60, "Lucifer2", "Lucifer", 2 },
                    { 5, 4, 80, "Lucifer3", "Lucifer", 3 },
                    { 6, 5, 100, "Lucifer4", "Lucifer", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hero_LevelID",
                table: "Hero",
                column: "LevelID");

            migrationBuilder.CreateIndex(
                name: "IX_Hero_UserID",
                table: "Hero",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Hero_WeaponID",
                table: "Hero",
                column: "WeaponID");

            migrationBuilder.CreateIndex(
                name: "IX_Monster_LevelID",
                table: "Monster",
                column: "LevelID");

            migrationBuilder.CreateIndex(
                name: "IX_Monster_WeaponID",
                table: "Monster",
                column: "WeaponID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hero");

            migrationBuilder.DropTable(
                name: "Monster");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Level");

            migrationBuilder.DropTable(
                name: "Weapon");
        }
    }
}
