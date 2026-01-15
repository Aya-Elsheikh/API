using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPenetrationinActitviy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Penetration",
                table: "Jadwa_Activity",
                type: "float",
                nullable: false,
                defaultValue: 0.0)
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "Jadwa_Activity")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Historical")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Penetration",
                table: "Jadwa_Activity")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "Jadwa_Activity")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Historical")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom");
        }
    }
}
