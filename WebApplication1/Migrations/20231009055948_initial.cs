using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IsCrypto = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentSystems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentSystems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyPaymentSystem",
                columns: table => new
                {
                    CurrenciesId = table.Column<int>(type: "integer", nullable: false),
                    PaymentSystemsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyPaymentSystem", x => new { x.CurrenciesId, x.PaymentSystemsId });
                    table.ForeignKey(
                        name: "FK_CurrencyPaymentSystem_Currencies_CurrenciesId",
                        column: x => x.CurrenciesId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CurrencyPaymentSystem_PaymentSystems_PaymentSystemsId",
                        column: x => x.PaymentSystemsId,
                        principalTable: "PaymentSystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    CurrencyId = table.Column<int>(type: "integer", nullable: false),
                    PaymentSystemId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_PaymentSystems_PaymentSystemId",
                        column: x => x.PaymentSystemId,
                        principalTable: "PaymentSystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyPaymentSystem_PaymentSystemsId",
                table: "CurrencyPaymentSystem",
                column: "PaymentSystemsId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_CurrencyId",
                table: "Payments",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PaymentSystemId",
                table: "Payments",
                column: "PaymentSystemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrencyPaymentSystem");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "PaymentSystems");
        }
    }
}
