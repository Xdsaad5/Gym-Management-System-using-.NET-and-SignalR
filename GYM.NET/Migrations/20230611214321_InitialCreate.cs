using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GYM.NET.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    cgpa = table.Column<double>(type: "float", nullable: true),
                    university = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__student__3214EC07E2125126", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trainer",
                columns: table => new
                {
                    email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    speciality = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    experience = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    participated_in_any_competition = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    consult_fee = table.Column<int>(type: "int", nullable: false),
                    mobile_number = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_trainer", x => x.email);
                });

            migrationBuilder.CreateTable(
                name: "trainee",
                columns: table => new
                {
                    username = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    age = table.Column<decimal>(type: "numeric(3,0)", nullable: false),
                    mobile_number = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: false),
                    assigned_trainer = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_trainee", x => x.username);
                    table.ForeignKey(
                        name: "fk_assgn_trainer",
                        column: x => x.assigned_trainer,
                        principalTable: "Trainer",
                        principalColumn: "email");
                });

            migrationBuilder.CreateTable(
                name: "trainerImages",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    image_url = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_trainerImages", x => x.id);
                    table.ForeignKey(
                        name: "fk_trainerImages",
                        column: x => x.email,
                        principalTable: "Trainer",
                        principalColumn: "email");
                });

            migrationBuilder.CreateTable(
                name: "trainerVideos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    video_url = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_trainerVideos", x => x.id);
                    table.ForeignKey(
                        name: "fk_trainerVideos",
                        column: x => x.email,
                        principalTable: "Trainer",
                        principalColumn: "email");
                });

            migrationBuilder.CreateIndex(
                name: "IX_trainee_assigned_trainer",
                table: "trainee",
                column: "assigned_trainer");

            migrationBuilder.CreateIndex(
                name: "UQ__trainee__AB6E6164CF1D79A3",
                table: "trainee",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__trainee__F3DBC572550176CF",
                table: "trainee",
                column: "username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Trainer__AB6E6164921DD469",
                table: "Trainer",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_trainerImages_email",
                table: "trainerImages",
                column: "email");

            migrationBuilder.CreateIndex(
                name: "IX_trainerVideos_email",
                table: "trainerVideos",
                column: "email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "student");

            migrationBuilder.DropTable(
                name: "trainee");

            migrationBuilder.DropTable(
                name: "trainerImages");

            migrationBuilder.DropTable(
                name: "trainerVideos");

            migrationBuilder.DropTable(
                name: "Trainer");
        }
    }
}
