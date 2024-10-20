using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StackUp.Infrastructure.Migrations.AppIdentityDb
{
    /// <inheritdoc />
    public partial class useredit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 19, 16, 9, 16, 989, DateTimeKind.Utc).AddTicks(3712),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 19, 13, 6, 7, 170, DateTimeKind.Utc).AddTicks(7399));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "239ba07c-edd8-4c1c-b01b-514a3d88db13", new DateTime(2024, 10, 19, 20, 9, 16, 994, DateTimeKind.Local).AddTicks(7631), "AQAAAAIAAYagAAAAEMQQf67EVlW/AAp2sgffihNxycboO7+D7JYeCXjZa4g89aNjnq8G+SJuVDu/a5SIEg==", "4e10fc15-101b-4ef1-98ae-43d2e601e56d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 19, 13, 6, 7, 170, DateTimeKind.Utc).AddTicks(7399),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 19, 16, 9, 16, 989, DateTimeKind.Utc).AddTicks(3712));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "66673731-5584-4006-a583-4918303f9c46", new DateTime(2024, 10, 19, 17, 6, 7, 176, DateTimeKind.Local).AddTicks(3227), "AQAAAAIAAYagAAAAEBYcB6L1voM1HWJit3JI4DV+0hzI9Ba6K8CGuwQE/PQoDSzeZjhF9UzvpwfNa0bbcw==", "39db03e0-64ac-4fb2-80fe-67ac9008a5e8" });
        }
    }
}
