using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetIdentity.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            // Add FechaNacimiento only if it doesn't exist already
            migrationBuilder.Sql(@"
IF COL_LENGTH('dbo.AspNetUsers', 'FechaNacimiento') IS NULL
BEGIN
    ALTER TABLE [dbo].[AspNetUsers]
        ADD [FechaNacimiento] [datetime2] NOT NULL CONSTRAINT [DF_AspNetUsers_FechaNacimiento] DEFAULT ('0001-01-01T00:00:00.0000000');
END");

            // Add NombreCompleto only if it doesn't exist already
            migrationBuilder.Sql(@"
IF COL_LENGTH('dbo.AspNetUsers', 'NombreCompleto') IS NULL
BEGIN
    ALTER TABLE [dbo].[AspNetUsers]
        ADD [NombreCompleto] [nvarchar](max) NULL;
END");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Drop FechaNacimiento if it exists
            migrationBuilder.Sql(@"
IF COL_LENGTH('dbo.AspNetUsers', 'FechaNacimiento') IS NOT NULL
BEGIN
    ALTER TABLE [dbo].[AspNetUsers] DROP COLUMN [FechaNacimiento];
END");

            // Drop NombreCompleto if it exists
            migrationBuilder.Sql(@"
IF COL_LENGTH('dbo.AspNetUsers', 'NombreCompleto') IS NOT NULL
BEGIN
    ALTER TABLE [dbo].[AspNetUsers] DROP COLUMN [NombreCompleto];
END");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
