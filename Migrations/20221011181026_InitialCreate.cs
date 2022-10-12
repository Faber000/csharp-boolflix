using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace csharp_boolflix.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VisualCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TvSeries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeasonCount = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VisualCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvSeries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Episodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeasonNumber = table.Column<int>(type: "int", nullable: false),
                    TVSeriesId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VisualCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Episodes_TvSeries_TVSeriesId",
                        column: x => x.TVSeriesId,
                        principalTable: "TvSeries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MediaInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsNew = table.Column<bool>(type: "bit", nullable: false),
                    FilmId = table.Column<int>(type: "int", nullable: true),
                    TVSeriesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MediaInfos_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MediaInfos_TvSeries_TVSeriesId",
                        column: x => x.TVSeriesId,
                        principalTable: "TvSeries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ActorMediaInfo",
                columns: table => new
                {
                    CastId = table.Column<int>(type: "int", nullable: false),
                    MediaInfosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorMediaInfo", x => new { x.CastId, x.MediaInfosId });
                    table.ForeignKey(
                        name: "FK_ActorMediaInfo_Actors_CastId",
                        column: x => x.CastId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorMediaInfo_MediaInfos_MediaInfosId",
                        column: x => x.MediaInfosId,
                        principalTable: "MediaInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FeatureMediaInfo",
                columns: table => new
                {
                    FeaturesId = table.Column<int>(type: "int", nullable: false),
                    MediaInfosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureMediaInfo", x => new { x.FeaturesId, x.MediaInfosId });
                    table.ForeignKey(
                        name: "FK_FeatureMediaInfo_Features_FeaturesId",
                        column: x => x.FeaturesId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FeatureMediaInfo_MediaInfos_MediaInfosId",
                        column: x => x.MediaInfosId,
                        principalTable: "MediaInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenreMediaInfo",
                columns: table => new
                {
                    GeneresId = table.Column<int>(type: "int", nullable: false),
                    MediaInfosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreMediaInfo", x => new { x.GeneresId, x.MediaInfosId });
                    table.ForeignKey(
                        name: "FK_GenreMediaInfo_Genres_GeneresId",
                        column: x => x.GeneresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreMediaInfo_MediaInfos_MediaInfosId",
                        column: x => x.MediaInfosId,
                        principalTable: "MediaInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActorMediaInfo_MediaInfosId",
                table: "ActorMediaInfo",
                column: "MediaInfosId");

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_TVSeriesId",
                table: "Episodes",
                column: "TVSeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_FeatureMediaInfo_MediaInfosId",
                table: "FeatureMediaInfo",
                column: "MediaInfosId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreMediaInfo_MediaInfosId",
                table: "GenreMediaInfo",
                column: "MediaInfosId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaInfos_FilmId",
                table: "MediaInfos",
                column: "FilmId",
                unique: true,
                filter: "[FilmId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MediaInfos_TVSeriesId",
                table: "MediaInfos",
                column: "TVSeriesId",
                unique: true,
                filter: "[TVSeriesId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActorMediaInfo");

            migrationBuilder.DropTable(
                name: "Episodes");

            migrationBuilder.DropTable(
                name: "FeatureMediaInfo");

            migrationBuilder.DropTable(
                name: "GenreMediaInfo");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "MediaInfos");

            migrationBuilder.DropTable(
                name: "Films");

            migrationBuilder.DropTable(
                name: "TvSeries");
        }
    }
}
