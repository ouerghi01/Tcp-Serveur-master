using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Conversation_Chat_Serveur.DAL.Migrations
{
    /// <inheritdoc />
    public partial class serveurclientdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conversations",
                columns: table => new
                {
                    ConversationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IpServeurId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServeurPort = table.Column<int>(type: "int", nullable: false),
                    ServeurMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IpClient = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientMessage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversations", x => x.ConversationId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conversations");
        }
    }
}
