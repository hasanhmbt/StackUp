using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StackUp.Infrastructure.Migrations.AppIdentityDb
{
    /// <inheritdoc />
    public partial class useredit2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 19, 16, 10, 5, 473, DateTimeKind.Utc).AddTicks(4412),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 19, 16, 9, 16, 989, DateTimeKind.Utc).AddTicks(3712));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "624bf462-2feb-49b7-b618-167b0c06702d", new DateTime(2024, 10, 19, 20, 10, 5, 478, DateTimeKind.Local).AddTicks(7985), "AQAAAAIAAYagAAAAEB36Mxw5tDo588hnW3ID0ZMNBaxcebDnutG0WRUX1e8erjNzWUYLt6PPIRFc+MPmpA==", "96b33acd-9c6f-4b75-aa6f-b142ab2b344e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 19, 16, 9, 16, 989, DateTimeKind.Utc).AddTicks(3712),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 19, 16, 10, 5, 473, DateTimeKind.Utc).AddTicks(4412));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "239ba07c-edd8-4c1c-b01b-514a3d88db13", new DateTime(2024, 10, 19, 20, 9, 16, 994, DateTimeKind.Local).AddTicks(7631), "AQAAAAIAAYagAAAAEMQQf67EVlW/AAp2sgffihNxycboO7+D7JYeCXjZa4g89aNjnq8G+SJuVDu/a5SIEg==", "4e10fc15-101b-4ef1-98ae-43d2e601e56d" });
        }
    }
}
