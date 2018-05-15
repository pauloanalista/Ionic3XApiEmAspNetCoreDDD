using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace YouLearn.Infra.Migrations
{
    public partial class Setup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Senha = table.Column<string>(maxLength: 36, nullable: false),
                    Email = table.Column<string>(maxLength: 200, nullable: false),
                    PrimeiroNome = table.Column<string>(maxLength: 50, nullable: false),
                    UltimoNome = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Canal",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdUsuario = table.Column<Guid>(nullable: true),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    UrlLogo = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Canal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Canal_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlayList",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdUsuario = table.Column<Guid>(nullable: true),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayList_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Video",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 255, nullable: false),
                    IdCanal = table.Column<Guid>(nullable: true),
                    IdPlayList = table.Column<Guid>(nullable: true),
                    IdUsuario = table.Column<Guid>(nullable: true),
                    IdVideoYoutube = table.Column<string>(maxLength: 50, nullable: false),
                    OrdemNaPlayList = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Tags = table.Column<string>(maxLength: 100, nullable: false),
                    Titulo = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Video", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Video_Canal_IdCanal",
                        column: x => x.IdCanal,
                        principalTable: "Canal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Video_PlayList_IdPlayList",
                        column: x => x.IdPlayList,
                        principalTable: "PlayList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Video_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Canal_IdUsuario",
                table: "Canal",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_PlayList_IdUsuario",
                table: "PlayList",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Video_IdCanal",
                table: "Video",
                column: "IdCanal");

            migrationBuilder.CreateIndex(
                name: "IX_Video_IdPlayList",
                table: "Video",
                column: "IdPlayList");

            migrationBuilder.CreateIndex(
                name: "IX_Video_IdUsuario",
                table: "Video",
                column: "IdUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Video");

            migrationBuilder.DropTable(
                name: "Canal");

            migrationBuilder.DropTable(
                name: "PlayList");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
