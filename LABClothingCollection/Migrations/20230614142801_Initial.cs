using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LABClothingCollection.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeCompleto = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CpfOuCnpj = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colecoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeColecao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Orcamento = table.Column<double>(type: "float", nullable: false),
                    DataLancamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estacao = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colecoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Colecoes_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Modelos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeModelo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IdColecao = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Layout = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modelos_Colecoes_IdColecao",
                        column: x => x.IdColecao,
                        principalTable: "Colecoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "CpfOuCnpj", "DataNascimento", "Email", "Genero", "NomeCompleto", "Status", "Telefone", "TipoUsuario" },
                values: new object[,]
                {
                    { 1, "58080200343", new DateTime(1968, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "pedro.henrique.monteiro@serteccontabil.com.br", "Masculino", "Pedro Henrique Danilo Monteiro", "ATIVO", "48985460199", "ADMINISTRADOR" },
                    { 2, "84052854233", new DateTime(1981, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "lunalaviniaramos@comercialrafael.com.br", null, "Luna Lavínia Ramos", "INATIVO", null, "CRIADOR" },
                    { 3, "81456627000153", new DateTime(1990, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "vicente.tiago.depaula@multmed.com.br", null, "Vicente Tiago de Paula", "ATIVO", "86992875039", "OUTRO" },
                    { 4, "61869109000154", new DateTime(2000, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "kevin_mateus_bernardes@genesyslab.com", null, "Kevin Mateus Samuel Bernardes", "INATIVO", "83982174816", "OUTRO" },
                    { 5, "30554862000", new DateTime(1986, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "priscila_dacunha@hormail.com", "Feminino", "Priscila Rayssa Alice da Cunha", "ATIVO", "51986585903", "GERENTE" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Colecoes_IdUsuario",
                table: "Colecoes",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Modelos_IdColecao",
                table: "Modelos",
                column: "IdColecao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Modelos");

            migrationBuilder.DropTable(
                name: "Colecoes");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
