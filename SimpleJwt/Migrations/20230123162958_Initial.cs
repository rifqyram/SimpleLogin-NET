using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleJwt.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "m_role",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "m_user_credential",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    roleid = table.Column<Guid>(name: "role_id", type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_user_credential", x => x.id);
                    table.ForeignKey(
                        name: "FK_m_user_credential_m_role_role_id",
                        column: x => x.roleid,
                        principalTable: "m_role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "m_customer",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mobilephone = table.Column<string>(name: "mobile_phone", type: "nvarchar(max)", nullable: false),
                    usercredentialid = table.Column<Guid>(name: "user_credential_id", type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_customer", x => x.id);
                    table.ForeignKey(
                        name: "FK_m_customer_m_user_credential_user_credential_id",
                        column: x => x.usercredentialid,
                        principalTable: "m_user_credential",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_m_customer_user_credential_id",
                table: "m_customer",
                column: "user_credential_id");

            migrationBuilder.CreateIndex(
                name: "IX_m_user_credential_role_id",
                table: "m_user_credential",
                column: "role_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "m_customer");

            migrationBuilder.DropTable(
                name: "m_user_credential");

            migrationBuilder.DropTable(
                name: "m_role");
        }
    }
}
