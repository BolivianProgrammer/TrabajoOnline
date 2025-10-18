using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetIdentity.Data.Migrations
{
    public partial class CreateIdentitySchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Baseline migration: no-op because Identity tables already exist in the database.
            // This avoids errors like "There is already an object named 'AspNetRoles' in the database".
            // Future migrations will adjust the existing schema (e.g., add custom columns).
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // No-op baseline; do not drop existing Identity tables.
        }
    }
}
