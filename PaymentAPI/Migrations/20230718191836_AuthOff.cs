using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaymentAPI.Migrations
{
    /// <inheritdoc />
    public partial class AuthOff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Usuarios_SenderId",
                table: "Payments");

            migrationBuilder.DropTable(
                name: "Autenticacao");

            migrationBuilder.DropIndex(
                name: "IX_Payments_SenderId",
                table: "Payments");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Payments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_UserId",
                table: "Payments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Usuarios_UserId",
                table: "Payments",
                column: "UserId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Usuarios_UserId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_UserId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Payments");

            migrationBuilder.CreateTable(
                name: "Autenticacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpirationDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    JwtToken = table.Column<string>(type: "VARCHAR", nullable: false),
                    LastAcessed = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValue: new DateTime(2023, 7, 17, 19, 23, 30, 85, DateTimeKind.Utc).AddTicks(6201)),
                    UserId = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autenticacao", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_SenderId",
                table: "Payments",
                column: "SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Usuarios_SenderId",
                table: "Payments",
                column: "SenderId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
