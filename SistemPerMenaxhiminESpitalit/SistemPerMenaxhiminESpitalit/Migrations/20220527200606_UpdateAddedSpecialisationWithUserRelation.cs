using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemPerMenaxhiminESpitalit.Migrations
{
    public partial class UpdateAddedSpecialisationWithUserRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_specialisations_SpecialisationId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "SpecialisationId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_specialisations_SpecialisationId",
                table: "AspNetUsers",
                column: "SpecialisationId",
                principalTable: "specialisations",
                principalColumn: "SpecialisationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_specialisations_SpecialisationId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "SpecialisationId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_specialisations_SpecialisationId",
                table: "AspNetUsers",
                column: "SpecialisationId",
                principalTable: "specialisations",
                principalColumn: "SpecialisationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
