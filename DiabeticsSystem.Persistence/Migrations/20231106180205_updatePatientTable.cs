using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiabeticsSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updatePatientTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CostomerId",
                table: "PatientMovements",
                newName: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMovements_CustomerId",
                table: "PatientMovements",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMovements_ProductId",
                table: "PatientMovements",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientMovements_Customers_CustomerId",
                table: "PatientMovements",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientMovements_Products_ProductId",
                table: "PatientMovements",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientMovements_Customers_CustomerId",
                table: "PatientMovements");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientMovements_Products_ProductId",
                table: "PatientMovements");

            migrationBuilder.DropIndex(
                name: "IX_PatientMovements_CustomerId",
                table: "PatientMovements");

            migrationBuilder.DropIndex(
                name: "IX_PatientMovements_ProductId",
                table: "PatientMovements");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "PatientMovements",
                newName: "CostomerId");
        }
    }
}
