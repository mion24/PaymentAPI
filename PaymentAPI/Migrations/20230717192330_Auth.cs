using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaymentAPI.Migrations
{
    /// <inheritdoc />
    public partial class Auth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastAcessed",
                table: "Autenticacao",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 17, 19, 23, 30, 85, DateTimeKind.Utc).AddTicks(6201),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2023, 7, 17, 18, 52, 13, 857, DateTimeKind.Utc).AddTicks(1475));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Autenticacao",
                type: "INT",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Autenticacao",
                table: "Autenticacao",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Autenticacao",
                table: "Autenticacao");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Autenticacao");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastAcessed",
                table: "Autenticacao",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 17, 18, 52, 13, 857, DateTimeKind.Utc).AddTicks(1475),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2023, 7, 17, 19, 23, 30, 85, DateTimeKind.Utc).AddTicks(6201));
        }
    }
}
