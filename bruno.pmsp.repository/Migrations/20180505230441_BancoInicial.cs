using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace bruno.pmsp.repository.Migrations
{
    public partial class BancoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AtualizadoEm = table.Column<DateTime>(nullable: false),
                    AtualizadoPor = table.Column<string>(nullable: true),
                    CredenciaisAcesso = table.Column<string>(maxLength: 50, nullable: false),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    QtdAtualizacoes = table.Column<int>(nullable: false),
                    Senha = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servidores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AtualizadoEm = table.Column<DateTime>(nullable: false),
                    AtualizadoPor = table.Column<string>(nullable: true),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    EstadoCivil = table.Column<string>(maxLength: 50, nullable: false),
                    Genero = table.Column<string>(maxLength: 50, nullable: false),
                    IdLogin = table.Column<int>(nullable: false),
                    NomeCompleto = table.Column<string>(maxLength: 50, nullable: false),
                    PreferenciaContato = table.Column<string>(maxLength: 50, nullable: false),
                    QtdAtualizacoes = table.Column<int>(nullable: false),
                    RF = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servidores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Servidores_Logins_IdLogin",
                        column: x => x.IdLogin,
                        principalTable: "Logins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AtualizadoEm = table.Column<DateTime>(nullable: false),
                    AtualizadoPor = table.Column<string>(nullable: true),
                    Bairro = table.Column<string>(maxLength: 50, nullable: false),
                    CEP = table.Column<string>(maxLength: 50, nullable: false),
                    Cidade = table.Column<string>(maxLength: 50, nullable: false),
                    Complemento = table.Column<string>(maxLength: 50, nullable: true),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    Estado = table.Column<string>(maxLength: 50, nullable: false),
                    IdServidor = table.Column<int>(nullable: false),
                    Logradouro = table.Column<string>(maxLength: 50, nullable: false),
                    Numero = table.Column<int>(nullable: false),
                    QtdAtualizacoes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enderecos_Servidores_IdServidor",
                        column: x => x.IdServidor,
                        principalTable: "Servidores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Telefones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AtualizadoEm = table.Column<DateTime>(nullable: false),
                    AtualizadoPor = table.Column<string>(nullable: true),
                    Celular = table.Column<string>(maxLength: 50, nullable: true),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    IdServidor = table.Column<int>(nullable: false),
                    OutroTelefone = table.Column<string>(maxLength: 50, nullable: true),
                    QtdAtualizacoes = table.Column<int>(nullable: false),
                    Recado = table.Column<string>(maxLength: 50, nullable: true),
                    TelefoneResidencial = table.Column<string>(maxLength: 50, nullable: true),
                    WhatsApp = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Telefones_Servidores_IdServidor",
                        column: x => x.IdServidor,
                        principalTable: "Servidores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vinculos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AtualizadoEm = table.Column<DateTime>(nullable: false),
                    AtualizadoPor = table.Column<string>(nullable: true),
                    Cargo = table.Column<string>(maxLength: 50, nullable: false),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    DRE = table.Column<string>(maxLength: 50, nullable: false),
                    DataInicioVinculo = table.Column<DateTime>(nullable: false),
                    IdServidor = table.Column<int>(nullable: false),
                    Jornada = table.Column<string>(maxLength: 50, nullable: false),
                    QtdAtualizacoes = table.Column<int>(nullable: false),
                    Referencia = table.Column<string>(maxLength: 50, nullable: false),
                    StatusVinculo = table.Column<string>(maxLength: 50, nullable: false),
                    UnidadeExercicio = table.Column<string>(maxLength: 50, nullable: false),
                    UnidadeLotacao = table.Column<string>(maxLength: 50, nullable: false),
                    Vinc = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vinculos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vinculos_Servidores_IdServidor",
                        column: x => x.IdServidor,
                        principalTable: "Servidores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_IdServidor",
                table: "Enderecos",
                column: "IdServidor",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Logins_CredenciaisAcesso",
                table: "Logins",
                column: "CredenciaisAcesso",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Servidores_IdLogin",
                table: "Servidores",
                column: "IdLogin",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Servidores_RF",
                table: "Servidores",
                column: "RF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Telefones_IdServidor",
                table: "Telefones",
                column: "IdServidor",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vinculos_IdServidor",
                table: "Vinculos",
                column: "IdServidor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Telefones");

            migrationBuilder.DropTable(
                name: "Vinculos");

            migrationBuilder.DropTable(
                name: "Servidores");

            migrationBuilder.DropTable(
                name: "Logins");
        }
    }
}
