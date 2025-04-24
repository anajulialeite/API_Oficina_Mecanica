using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OficinaAPI.Migrations
{
    /// <inheritdoc />
    public partial class AtualizaClienteID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agendamentos",
                columns: table => new
                {
                    TempoMaoDeObraID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReparacaoID = table.Column<int>(type: "int", nullable: false),
                    FuncionarioID = table.Column<int>(type: "int", nullable: false),
                    TempoGastoEmHoras = table.Column<int>(type: "int", nullable: false),
                    ValorMaoDeObra = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamentos", x => x.TempoMaoDeObraID);
                });

            migrationBuilder.CreateTable(
                name: "categorias",
                columns: table => new
                {
                    IDCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteID = table.Column<int>(type: "int", nullable: false),
                    FuncionarioID = table.Column<int>(type: "int", nullable: false),
                    CustoHora = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categorias", x => x.IDCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoCivil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Observacao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteID);
                });

            migrationBuilder.CreateTable(
                name: "contatos",
                columns: table => new
                {
                    IDCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDFuncionario = table.Column<int>(type: "int", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Morada = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contatos", x => x.IDCliente);
                });

            migrationBuilder.CreateTable(
                name: "controleDePermissoes",
                columns: table => new
                {
                    IDFuncionario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeDoUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cargo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NivelDeAcesso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Departamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataEHoraDeAcesso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OperacoesRealizadas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResultadoDaOperacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IPDeAcesso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AcaoDeBloqueio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Observacoes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_controleDePermissoes", x => x.IDFuncionario);
                });

            migrationBuilder.CreateTable(
                name: "custoMaoDeObras",
                columns: table => new
                {
                    IDCustoMaoDeObra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataPagamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoDePagamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MetodoDePagamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroDaFatura = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fornecedor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Funcionario = table.Column<int>(type: "int", nullable: false),
                    Despesa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Observacoes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_custoMaoDeObras", x => x.IDCustoMaoDeObra);
                });

            migrationBuilder.CreateTable(
                name: "documentoImagens",
                columns: table => new
                {
                    IDDocumentoImagem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDVeiculo = table.Column<int>(type: "int", nullable: false),
                    NomeArquivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoDocumentoImagem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataEnvioCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Arquivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_documentoImagens", x => x.IDDocumentoImagem);
                });

            migrationBuilder.CreateTable(
                name: "feedbackClientes",
                columns: table => new
                {
                    IDFeedback = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDCliente = table.Column<int>(type: "int", nullable: false),
                    DataEHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Avaliacoes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServicoAvaliado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RespostaDaOficina = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusDoFeedback = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CanalDoFeedback = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AcaoTomada = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feedbackClientes", x => x.IDFeedback);
                });

            migrationBuilder.CreateTable(
                name: "funcionarios",
                columns: table => new
                {
                    FuncionarioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataContratacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ContatoEmergencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Qualificacoes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_funcionarios", x => x.FuncionarioID);
                });

            migrationBuilder.CreateTable(
                name: "pagamentos",
                columns: table => new
                {
                    IDPagamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDVeiculo = table.Column<int>(type: "int", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoDePagamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MetodoDePagamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroDaFatura = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fornecedor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Funcionario = table.Column<int>(type: "int", nullable: false),
                    Despesa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Observacoes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pagamentos", x => x.IDPagamento);
                });

            migrationBuilder.CreateTable(
                name: "pecaEmArmazems",
                columns: table => new
                {
                    PecaEmArmazemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoPeca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustoUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuantidadeAtual = table.Column<int>(type: "int", nullable: false),
                    PecaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pecaEmArmazems", x => x.PecaEmArmazemID);
                });

            migrationBuilder.CreateTable(
                name: "pecaUtilizadas",
                columns: table => new
                {
                    PecaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReparacaoID = table.Column<int>(type: "int", nullable: false),
                    CodigoPeca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Designacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrecoUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pecaUtilizadas", x => x.PecaID);
                });

            migrationBuilder.CreateTable(
                name: "relatorioEstatisticas",
                columns: table => new
                {
                    IDRegistro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDRelatorio = table.Column<int>(type: "int", nullable: false),
                    IDPagamento = table.Column<int>(type: "int", nullable: false),
                    TipoRegistro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Responsavel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Departamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DadosRegistro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResultadosAnalises = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Observacoes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArquivoAnexado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusRegistro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destinatario = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_relatorioEstatisticas", x => x.IDRegistro);
                });

            migrationBuilder.CreateTable(
                name: "reparaçãos",
                columns: table => new
                {
                    ReparacaoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VeiculoID = table.Column<int>(type: "int", nullable: false),
                    ClienteID = table.Column<int>(type: "int", nullable: false),
                    DataReparacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustoTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Observacoes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reparaçãos", x => x.ReparacaoID);
                });

            migrationBuilder.CreateTable(
                name: "tempoMaoDeObras",
                columns: table => new
                {
                    TempoMaoDeObraID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReparacaoID = table.Column<int>(type: "int", nullable: false),
                    FuncionarioID = table.Column<int>(type: "int", nullable: false),
                    TempoGasto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tempoMaoDeObras", x => x.TempoMaoDeObraID);
                });

            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    VeiculoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteID = table.Column<int>(type: "int", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnoFabricacao = table.Column<short>(type: "smallint", nullable: false),
                    Chassi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quilometragem = table.Column<int>(type: "int", nullable: false),
                    Placa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataAquisição = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculos", x => x.VeiculoID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendamentos");

            migrationBuilder.DropTable(
                name: "categorias");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "contatos");

            migrationBuilder.DropTable(
                name: "controleDePermissoes");

            migrationBuilder.DropTable(
                name: "custoMaoDeObras");

            migrationBuilder.DropTable(
                name: "documentoImagens");

            migrationBuilder.DropTable(
                name: "feedbackClientes");

            migrationBuilder.DropTable(
                name: "funcionarios");

            migrationBuilder.DropTable(
                name: "pagamentos");

            migrationBuilder.DropTable(
                name: "pecaEmArmazems");

            migrationBuilder.DropTable(
                name: "pecaUtilizadas");

            migrationBuilder.DropTable(
                name: "relatorioEstatisticas");

            migrationBuilder.DropTable(
                name: "reparaçãos");

            migrationBuilder.DropTable(
                name: "tempoMaoDeObras");

            migrationBuilder.DropTable(
                name: "Veiculos");
        }
    }
}
