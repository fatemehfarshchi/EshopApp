using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EshopApp.Infrastructure.Migrations
{
    /// <summary>
    /// Migration for fixing invoice relation issues in the database schema.
    /// This migration currently contains no operations.
    /// </summary>
    public partial class FixedInvoiceRelation : Migration
    {
        /// <summary>
        /// Applies the migration. No operations are defined for this migration.
        /// </summary>
        /// <param name="migrationBuilder">The builder used to construct the migration operations.</param>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // No operations defined.
        }

        /// <summary>
        /// Reverts the migration. No operations are defined for this migration.
        /// </summary>
        /// <param name="migrationBuilder">The builder used to construct the migration operations.</param>
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // No operations defined.
        }
    }
}
