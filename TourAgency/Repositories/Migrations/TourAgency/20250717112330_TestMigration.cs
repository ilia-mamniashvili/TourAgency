using System.Reflection;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations.TourAgency
{
    /// <inheritdoc />
    public partial class TestMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            foreach (var path in Directory.GetFiles(@"..\Database\dbo\StoredProcedures", "*.sql"))
            {
                string sql = File.ReadAllText(path);
                migrationBuilder.Sql(sql);
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            foreach (var path in Directory.GetFiles(@"..\Database\dbo\StoredProcedures", "*.sql"))
            {
                var procName = Path.GetFileNameWithoutExtension(path);
                migrationBuilder.Sql($"DROP PROCEDURE IF EXISTS [dbo].[{procName}]");
            }
        }
    }
}
