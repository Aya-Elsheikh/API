using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddOtp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewsLetterSubscribe",
                table: "Jadwa_User");

            migrationBuilder.DropColumn(
                name: "UserTypeId",
                table: "Jadwa_User");

            migrationBuilder.RenameColumn(
                name: "NsdbCode",
                table: "Jadwa_User",
                newName: "Otp");

            migrationBuilder.RenameColumn(
                name: "NewsLetterSubscribeDate",
                table: "Jadwa_User",
                newName: "OtpExpiry");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OtpExpiry",
                table: "Jadwa_User",
                newName: "NewsLetterSubscribeDate");

            migrationBuilder.RenameColumn(
                name: "Otp",
                table: "Jadwa_User",
                newName: "NsdbCode");

            migrationBuilder.AddColumn<bool>(
                name: "NewsLetterSubscribe",
                table: "Jadwa_User",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UserTypeId",
                table: "Jadwa_User",
                type: "int",
                nullable: true);
        }
    }
}
