using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSectorCommunity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jadwa_Sector",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "Jadwa_Sector")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Historical")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom"),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "Jadwa_Sector")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Historical")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom"),
                    ModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "Jadwa_Sector")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Historical")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "Jadwa_Sector")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Historical")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom"),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "Jadwa_Sector")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Historical")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom"),
                    NameA = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "Jadwa_Sector")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Historical")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom"),
                    NameE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "Jadwa_Sector")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Historical")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom"),
                    Code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "Jadwa_Sector")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Historical")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom"),
                    Latitude = table.Column<double>(type: "float", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "Jadwa_Sector")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Historical")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom"),
                    Longitude = table.Column<double>(type: "float", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "Jadwa_Sector")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Historical")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom"),
                    Factor = table.Column<double>(type: "float", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "Jadwa_Sector")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Historical")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom"),
                    FactorBrief = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "Jadwa_Sector")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Historical")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom"),
                    SortIndex = table.Column<int>(type: "int", nullable: false)
    .Annotation("SqlServer:IsTemporal", true)
    .Annotation("SqlServer:TemporalHistoryTableName", "Jadwa_Sector")
    .Annotation("SqlServer:TemporalHistoryTableSchema", "Historical")
    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
    .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom"),
                    Focus = table.Column<bool>(type: "bit", nullable: false)
    .Annotation("SqlServer:IsTemporal", true)
    .Annotation("SqlServer:TemporalHistoryTableName", "Jadwa_Sector")
    .Annotation("SqlServer:TemporalHistoryTableSchema", "Historical")
    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
    .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom"),
                    Active = table.Column<bool>(type: "bit", nullable: false)
    .Annotation("SqlServer:IsTemporal", true)
    .Annotation("SqlServer:TemporalHistoryTableName", "Jadwa_Sector")
    .Annotation("SqlServer:TemporalHistoryTableSchema", "Historical")
    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
    .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom"),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "Jadwa_Sector")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Historical")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom"),
                    ValidTo = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "Jadwa_Sector")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Historical")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom"),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jadwa_Sector", x => x.Id);
                })
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "Jadwa_Sector")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Historical")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom");

            migrationBuilder.CreateTable(
                name: "Jadwa_User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NameE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NormalizedName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Organization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoginCount = table.Column<int>(type: "int", nullable: false),
                    LastLoginDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastLogoutDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Admin = table.Column<bool>(type: "bit", nullable: false),
                    IsCitizen = table.Column<bool>(type: "bit", nullable: false),
                    SortIndex = table.Column<int>(type: "int", nullable: false),
                    NewsLetterSubscribe = table.Column<bool>(type: "bit", nullable: false),
                    NewsLetterSubscribeDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Locked = table.Column<bool>(type: "bit", nullable: false),
                    Focus = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserTypeId = table.Column<int>(type: "int", nullable: true),
                    NsdbCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jadwa_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jadwa_User_Jadwa_User_ModifierId",
                        column: x => x.ModifierId,
                        principalTable: "Jadwa_User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Jadwa_User_Jadwa_User_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Jadwa_User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Jadwa_Community",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "Jadwa_Community")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Historical")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom"),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "Jadwa_Community")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Historical")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom"),
                    ModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "Jadwa_Community")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Historical")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "Jadwa_Community")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Historical")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom"),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "Jadwa_Community")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Historical")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom"),
                    NameA = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "Jadwa_Community")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Historical")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom"),
                    NameE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "Jadwa_Community")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Historical")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom"),
                    Code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "Jadwa_Community")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Historical")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom"),
                    Latitude = table.Column<double>(type: "float", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "Jadwa_Community")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Historical")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom"),
                    Longitude = table.Column<double>(type: "float", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "Jadwa_Community")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Historical")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom"),
                    SectorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "Jadwa_Community")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Historical")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom"),
                    SortIndex = table.Column<int>(type: "int", nullable: false)
    .Annotation("SqlServer:IsTemporal", true)
    .Annotation("SqlServer:TemporalHistoryTableName", "Jadwa_Community")
    .Annotation("SqlServer:TemporalHistoryTableSchema", "Historical")
    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
    .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom"),
                    Focus = table.Column<bool>(type: "bit", nullable: false)
    .Annotation("SqlServer:IsTemporal", true)
    .Annotation("SqlServer:TemporalHistoryTableName", "Jadwa_Community")
    .Annotation("SqlServer:TemporalHistoryTableSchema", "Historical")
    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
    .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom"),
                    Active = table.Column<bool>(type: "bit", nullable: false)
    .Annotation("SqlServer:IsTemporal", true)
    .Annotation("SqlServer:TemporalHistoryTableName", "Jadwa_Community")
    .Annotation("SqlServer:TemporalHistoryTableSchema", "Historical")
    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
    .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom"),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "Jadwa_Community")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Historical")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom"),
                    ValidTo = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "Jadwa_Community")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Historical")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom"),
                    
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jadwa_Community", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jadwa_Community_Jadwa_Sector_SectorId",
                        column: x => x.SectorId,
                        principalTable: "Jadwa_Sector",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "Jadwa_Community")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Historical")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom");

            migrationBuilder.CreateTable(
                name: "Jadwa_Role",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SortIndex = table.Column<int>(type: "int", nullable: false),
                    Focus = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jadwa_Role", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jadwa_Role_Jadwa_User_ModifierId",
                        column: x => x.ModifierId,
                        principalTable: "Jadwa_User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Jadwa_Role_Jadwa_User_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Jadwa_User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Jadwa_UserClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jadwa_UserClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jadwa_UserClaim_Jadwa_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Jadwa_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Jadwa_UserLogin",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jadwa_UserLogin", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_Jadwa_UserLogin_Jadwa_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Jadwa_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Jadwa_UserToken",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jadwa_UserToken", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_Jadwa_UserToken_Jadwa_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Jadwa_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Jadwa_RoleClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jadwa_RoleClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jadwa_RoleClaim_Jadwa_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Jadwa_Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Jadwa_UserRole",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(34)", maxLength: 34, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jadwa_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_Jadwa_UserRole_Jadwa_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Jadwa_Role",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Jadwa_UserRole_Jadwa_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Jadwa_User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jadwa_Community_SectorId",
                table: "Jadwa_Community",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Jadwa_Role_ModifierId",
                table: "Jadwa_Role",
                column: "ModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_Jadwa_Role_OwnerId",
                table: "Jadwa_Role",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Jadwa_Role",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Jadwa_RoleClaim_RoleId",
                table: "Jadwa_RoleClaim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Jadwa_User",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Jadwa_User_ModifierId",
                table: "Jadwa_User",
                column: "ModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_Jadwa_User_OwnerId",
                table: "Jadwa_User",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Jadwa_User",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Jadwa_UserClaim_UserId",
                table: "Jadwa_UserClaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Jadwa_UserLogin_UserId",
                table: "Jadwa_UserLogin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Jadwa_UserRole_RoleId",
                table: "Jadwa_UserRole",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jadwa_Community")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "Jadwa_Community")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Historical")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom");

            migrationBuilder.DropTable(
                name: "Jadwa_RoleClaim");

            migrationBuilder.DropTable(
                name: "Jadwa_UserClaim");

            migrationBuilder.DropTable(
                name: "Jadwa_UserLogin");

            migrationBuilder.DropTable(
                name: "Jadwa_UserRole");

            migrationBuilder.DropTable(
                name: "Jadwa_UserToken");

            migrationBuilder.DropTable(
                name: "Jadwa_Sector")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "Jadwa_Sector")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Historical")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom");

            migrationBuilder.DropTable(
                name: "Jadwa_Role");

            migrationBuilder.DropTable(
                name: "Jadwa_User");
        }
    }
}
