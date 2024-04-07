using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevFreela.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DateTime", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "DateTime", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    StartedAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    FinishedAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    IdClient = table.Column<int>(type: "int", nullable: false),
                    IdFreelancer = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DateTime", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_User_IdClient",
                        column: x => x.IdClient,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Project_User_IdFreelancer",
                        column: x => x.IdFreelancer,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserSkill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    IdSkill = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DateTime", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSkill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSkill_Skill_IdSkill",
                        column: x => x.IdSkill,
                        principalTable: "Skill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserSkill_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectComment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IdProject = table.Column<int>(type: "int", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DateTime", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectComment_Project_IdProject",
                        column: x => x.IdProject,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectComment_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Project_IdClient",
                table: "Project",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_Project_IdFreelancer",
                table: "Project",
                column: "IdFreelancer");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectComment_IdProject",
                table: "ProjectComment",
                column: "IdProject");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectComment_IdUser",
                table: "ProjectComment",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_UserSkill_IdSkill",
                table: "UserSkill",
                column: "IdSkill");

            migrationBuilder.CreateIndex(
                name: "IX_UserSkill_IdUser_IdSkill",
                table: "UserSkill",
                columns: new[] { "IdUser", "IdSkill" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectComment");

            migrationBuilder.DropTable(
                name: "UserSkill");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
