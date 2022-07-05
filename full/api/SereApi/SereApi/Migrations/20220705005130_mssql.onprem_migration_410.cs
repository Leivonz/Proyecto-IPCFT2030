using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SereApi.Migrations
{
    public partial class mssqlonprem_migration_410 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    IdArea = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameArea = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Area__2FC141AAEF044606", x => x.IdArea);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    IdCountry = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameCountry = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Country__F99F104DBB92DEC1", x => x.IdCountry);
                });

            migrationBuilder.CreateTable(
                name: "EventType",
                columns: table => new
                {
                    IdEvent = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEventType = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__EventTyp__E0B2AF3997755298", x => x.IdEvent);
                });

            migrationBuilder.CreateTable(
                name: "Objective",
                columns: table => new
                {
                    IdObjective = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameObjective = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    IndicadorObjective = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    MetasObjective = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    ObjectiveObjective = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Objectiv__76514F972A885A7E", x => x.IdObjective);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationStatus",
                columns: table => new
                {
                    IdOrganizationStatus = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOrganizationStatus = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Organiza__EF65CC7F6C80E7B8", x => x.IdOrganizationStatus);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationType",
                columns: table => new
                {
                    IdOrganizationType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOrganizationType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Organiza__4D4A4C69CDAE7A2A", x => x.IdOrganizationType);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    IdPerson = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamePerson = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    SurnamePerson = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    EmailPerson = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    PhonePerson = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Person__A5D4E15B84CD3DA8", x => x.IdPerson);
                });

            migrationBuilder.CreateTable(
                name: "ProjectStatus",
                columns: table => new
                {
                    IdProjectStatus = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameProjectStatus = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ProjectS__E0824C87AB6CACAD", x => x.IdProjectStatus);
                });

            migrationBuilder.CreateTable(
                name: "Organization",
                columns: table => new
                {
                    IdOrganization = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOrganization = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    DescriptionOrganization = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    EmailOrganization = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Country = table.Column<int>(type: "int", nullable: true),
                    Phone = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    IdOrganizationType = table.Column<int>(type: "int", nullable: true),
                    IdOrganizationStatus = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Organiza__C14A1C272D546BFB", x => x.IdOrganization);
                    table.ForeignKey(
                        name: "FkOrganizationCountry",
                        column: x => x.Country,
                        principalTable: "Country",
                        principalColumn: "IdCountry");
                    table.ForeignKey(
                        name: "FkOrganizationOrganizationStatus",
                        column: x => x.IdOrganizationStatus,
                        principalTable: "OrganizationStatus",
                        principalColumn: "IdOrganizationStatus");
                    table.ForeignKey(
                        name: "FkOrganizationOrganizationType",
                        column: x => x.IdOrganizationType,
                        principalTable: "OrganizationType",
                        principalColumn: "IdOrganizationType");
                });

            migrationBuilder.CreateTable(
                name: "PersonObjective",
                columns: table => new
                {
                    IdPersonObjective = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPerson = table.Column<int>(type: "int", nullable: true),
                    IdObjective = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PersonOb__E2F376D70A3142B9", x => x.IdPersonObjective);
                    table.ForeignKey(
                        name: "FkObjectivePerson",
                        column: x => x.IdObjective,
                        principalTable: "Objective",
                        principalColumn: "IdObjective");
                    table.ForeignKey(
                        name: "FkPersonObjective",
                        column: x => x.IdPerson,
                        principalTable: "Person",
                        principalColumn: "IdPerson");
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    IdProject = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MontoProject = table.Column<int>(type: "int", nullable: true),
                    CreationDateProject = table.Column<DateTime>(type: "date", nullable: true),
                    StartDateProject = table.Column<DateTime>(type: "date", nullable: true),
                    EndDateProject = table.Column<DateTime>(type: "date", nullable: true),
                    MonthsProject = table.Column<int>(type: "int", nullable: true),
                    DescriptionProject = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    KeyWordsProject = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    ObjectivesProject = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    IdArea = table.Column<int>(type: "int", nullable: true),
                    IdProjectStatus = table.Column<int>(type: "int", nullable: true),
                    IdObjectiveObjective = table.Column<int>(type: "int", nullable: true),
                    IdPersonResponsable = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Project__B9E13D24B9508CF8", x => x.IdProject);
                    table.ForeignKey(
                        name: "FkProjectArea",
                        column: x => x.IdArea,
                        principalTable: "Area",
                        principalColumn: "IdArea");
                    table.ForeignKey(
                        name: "FkProjectPersonResponsable",
                        column: x => x.IdPersonResponsable,
                        principalTable: "Person",
                        principalColumn: "IdPerson");
                    table.ForeignKey(
                        name: "FkProjectProjectStatus",
                        column: x => x.IdProjectStatus,
                        principalTable: "ProjectStatus",
                        principalColumn: "IdProjectStatus");
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    IdEvent = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEvent = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false),
                    DateEvent = table.Column<DateTime>(type: "date", nullable: false),
                    DescriptionEvent = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    ObjectiveEvent = table.Column<int>(type: "int", nullable: false),
                    IdEventType = table.Column<int>(type: "int", nullable: true),
                    SizeEvent = table.Column<int>(type: "int", nullable: true),
                    CostEvent = table.Column<decimal>(type: "money", nullable: false),
                    IdOrganization = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Event__E0B2AF39A124F1D6", x => x.IdEvent);
                    table.ForeignKey(
                        name: "FkEventEventType",
                        column: x => x.IdEventType,
                        principalTable: "EventType",
                        principalColumn: "IdEvent");
                    table.ForeignKey(
                        name: "FkEventObjective",
                        column: x => x.ObjectiveEvent,
                        principalTable: "Objective",
                        principalColumn: "IdObjective");
                    table.ForeignKey(
                        name: "FkEventOrganization",
                        column: x => x.IdOrganization,
                        principalTable: "Organization",
                        principalColumn: "IdOrganization");
                });

            migrationBuilder.CreateTable(
                name: "OrganizationObjective",
                columns: table => new
                {
                    IdOrganizationObjective = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdOrganization = table.Column<int>(type: "int", nullable: true),
                    IdObjective = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Organiza__4D7C5147A927FDCC", x => x.IdOrganizationObjective);
                    table.ForeignKey(
                        name: "FkObjectiveOrganization",
                        column: x => x.IdObjective,
                        principalTable: "Objective",
                        principalColumn: "IdObjective");
                    table.ForeignKey(
                        name: "FkOrganizationObjective",
                        column: x => x.IdOrganization,
                        principalTable: "Organization",
                        principalColumn: "IdOrganization");
                });

            migrationBuilder.CreateTable(
                name: "OrganizationPerson",
                columns: table => new
                {
                    IdOrganizationPerson = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPerson = table.Column<int>(type: "int", nullable: true),
                    IdOrganization = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Organiza__573676C95D1F2260", x => x.IdOrganizationPerson);
                    table.ForeignKey(
                        name: "FkOrganizationPerson",
                        column: x => x.IdOrganization,
                        principalTable: "Organization",
                        principalColumn: "IdOrganization");
                    table.ForeignKey(
                        name: "FkPersonOrganization",
                        column: x => x.IdPerson,
                        principalTable: "Person",
                        principalColumn: "IdPerson");
                });

            migrationBuilder.CreateTable(
                name: "OrganizationProject",
                columns: table => new
                {
                    IdOrganizationProject = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdOrganization = table.Column<int>(type: "int", nullable: true),
                    IdProject = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Organiza__171D148FD6B00AAF", x => x.IdOrganizationProject);
                    table.ForeignKey(
                        name: "FkOrganizationProject",
                        column: x => x.IdOrganization,
                        principalTable: "Organization",
                        principalColumn: "IdOrganization");
                    table.ForeignKey(
                        name: "FkProjectOrganization",
                        column: x => x.IdProject,
                        principalTable: "Project",
                        principalColumn: "IdProject");
                });

            migrationBuilder.CreateTable(
                name: "PersonProject",
                columns: table => new
                {
                    IdPersonProject = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPerson = table.Column<int>(type: "int", nullable: true),
                    IdProject = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PersonPr__8D705DB6991C390F", x => x.IdPersonProject);
                    table.ForeignKey(
                        name: "FkPersonProject",
                        column: x => x.IdPerson,
                        principalTable: "Person",
                        principalColumn: "IdPerson");
                    table.ForeignKey(
                        name: "FkProjectPerson",
                        column: x => x.IdProject,
                        principalTable: "Project",
                        principalColumn: "IdProject");
                });

            migrationBuilder.CreateTable(
                name: "ProjectObjective",
                columns: table => new
                {
                    IdProjectObjective = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProject = table.Column<int>(type: "int", nullable: true),
                    IdObjective = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ProjectO__A2C5D3BE860140F1", x => x.IdProjectObjective);
                    table.ForeignKey(
                        name: "FkObjectiveProject",
                        column: x => x.IdObjective,
                        principalTable: "Objective",
                        principalColumn: "IdObjective");
                    table.ForeignKey(
                        name: "FkProjectObjective",
                        column: x => x.IdProject,
                        principalTable: "Project",
                        principalColumn: "IdProject");
                });

            migrationBuilder.CreateTable(
                name: "PersonEvent",
                columns: table => new
                {
                    IdPersonEvent = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEvent = table.Column<int>(type: "int", nullable: true),
                    IdPerson = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PersonEv__7E6E2035A4F07BCC", x => x.IdPersonEvent);
                    table.ForeignKey(
                        name: "FkEventEventEvent",
                        column: x => x.IdEvent,
                        principalTable: "Event",
                        principalColumn: "IdEvent");
                    table.ForeignKey(
                        name: "FkPersonEventEvent",
                        column: x => x.IdPerson,
                        principalTable: "Person",
                        principalColumn: "IdPerson");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Event_IdEventType",
                table: "Event",
                column: "IdEventType");

            migrationBuilder.CreateIndex(
                name: "IX_Event_IdOrganization",
                table: "Event",
                column: "IdOrganization");

            migrationBuilder.CreateIndex(
                name: "IX_Event_ObjectiveEvent",
                table: "Event",
                column: "ObjectiveEvent");

            migrationBuilder.CreateIndex(
                name: "IX_Organization_Country",
                table: "Organization",
                column: "Country");

            migrationBuilder.CreateIndex(
                name: "IX_Organization_IdOrganizationStatus",
                table: "Organization",
                column: "IdOrganizationStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Organization_IdOrganizationType",
                table: "Organization",
                column: "IdOrganizationType");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationObjective_IdObjective",
                table: "OrganizationObjective",
                column: "IdObjective");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationObjective_IdOrganization",
                table: "OrganizationObjective",
                column: "IdOrganization");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationPerson_IdOrganization",
                table: "OrganizationPerson",
                column: "IdOrganization");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationPerson_IdPerson",
                table: "OrganizationPerson",
                column: "IdPerson");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationProject_IdOrganization",
                table: "OrganizationProject",
                column: "IdOrganization");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationProject_IdProject",
                table: "OrganizationProject",
                column: "IdProject");

            migrationBuilder.CreateIndex(
                name: "IX_PersonEvent_IdEvent",
                table: "PersonEvent",
                column: "IdEvent");

            migrationBuilder.CreateIndex(
                name: "IX_PersonEvent_IdPerson",
                table: "PersonEvent",
                column: "IdPerson");

            migrationBuilder.CreateIndex(
                name: "IX_PersonObjective_IdObjective",
                table: "PersonObjective",
                column: "IdObjective");

            migrationBuilder.CreateIndex(
                name: "IX_PersonObjective_IdPerson",
                table: "PersonObjective",
                column: "IdPerson");

            migrationBuilder.CreateIndex(
                name: "IX_PersonProject_IdPerson",
                table: "PersonProject",
                column: "IdPerson");

            migrationBuilder.CreateIndex(
                name: "IX_PersonProject_IdProject",
                table: "PersonProject",
                column: "IdProject");

            migrationBuilder.CreateIndex(
                name: "IX_Project_IdArea",
                table: "Project",
                column: "IdArea");

            migrationBuilder.CreateIndex(
                name: "IX_Project_IdPersonResponsable",
                table: "Project",
                column: "IdPersonResponsable");

            migrationBuilder.CreateIndex(
                name: "IX_Project_IdProjectStatus",
                table: "Project",
                column: "IdProjectStatus");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectObjective_IdObjective",
                table: "ProjectObjective",
                column: "IdObjective");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectObjective_IdProject",
                table: "ProjectObjective",
                column: "IdProject");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrganizationObjective");

            migrationBuilder.DropTable(
                name: "OrganizationPerson");

            migrationBuilder.DropTable(
                name: "OrganizationProject");

            migrationBuilder.DropTable(
                name: "PersonEvent");

            migrationBuilder.DropTable(
                name: "PersonObjective");

            migrationBuilder.DropTable(
                name: "PersonProject");

            migrationBuilder.DropTable(
                name: "ProjectObjective");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "EventType");

            migrationBuilder.DropTable(
                name: "Objective");

            migrationBuilder.DropTable(
                name: "Organization");

            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "ProjectStatus");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "OrganizationStatus");

            migrationBuilder.DropTable(
                name: "OrganizationType");
        }
    }
}
