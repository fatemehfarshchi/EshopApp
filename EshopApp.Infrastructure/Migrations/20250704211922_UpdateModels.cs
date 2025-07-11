using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EshopApp.Infrastructure.Migrations
{
    /// <summary>
    /// Migration to update the foreign key constraint on InvoiceItems.InvoiceId to use Restrict delete behavior instead of Cascade.
    /// </summary>
    public partial class UpdateModels : Migration
    {
        /// <summary>
        /// Applies the migration by changing the delete behavior of the InvoiceItems-Invoices foreign key to Restrict.
        /// </summary>
        /// <param name="migrationBuilder">The builder used to construct the migration operations.</param>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Remove the existing foreign key with Cascade delete
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItems_Invoices_InvoiceId",
                table: "InvoiceItems");

            // Add a new foreign key with Restrict delete behavior
            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItems_Invoices_InvoiceId",
                table: "InvoiceItems",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <summary>
        /// Reverts the migration by restoring the Cascade delete behavior on the InvoiceItems-Invoices foreign key.
        /// </summary>
        /// <param name="migrationBuilder">The builder used to construct the migration operations.</param>
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove the foreign key with Restrict delete
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItems_Invoices_InvoiceId",
                table: "InvoiceItems");

            // Add the original foreign key with Cascade delete behavior
            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItems_Invoices_InvoiceId",
                table: "InvoiceItems",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
