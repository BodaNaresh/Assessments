using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineBusBookingSystem.Migrations
{
    public partial class busbookings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusDetails",
                columns: table => new
                {
                    BusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusNo = table.Column<string>(nullable: true),
                    BusName = table.Column<string>(nullable: true),
                    BusType = table.Column<string>(nullable: true),
                    BookedSeats = table.Column<int>(nullable: false),
                    AvailableSeats = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<string>(nullable: true),
                    TotalSeats = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusDetails", x => x.BusId);
                });

            migrationBuilder.CreateTable(
                name: "LoginandSignUps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginandSignUps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    SeatNo = table.Column<string>(nullable: true),
                    BoardingPoint = table.Column<string>(nullable: true),
                    DropingPoint = table.Column<string>(nullable: true),
                    fare = table.Column<int>(nullable: false),
                    Busid = table.Column<int>(nullable: false),
                    userid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PNRDetails",
                columns: table => new
                {
                    PNRDetailsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PNRNo = table.Column<string>(nullable: true),
                    TotalAmount = table.Column<float>(nullable: false),
                    TotalTickets = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PNRDetails", x => x.PNRDetailsId);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleDetails",
                columns: table => new
                {
                    ScheduleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusId = table.Column<int>(nullable: false),
                    RouteID = table.Column<int>(nullable: false),
                    Fare = table.Column<float>(nullable: false),
                    DepatureTime = table.Column<string>(nullable: true),
                    EstimatedTime = table.Column<string>(nullable: true),
                    ArrivalTime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleDetails", x => x.ScheduleId);
                });

            migrationBuilder.CreateTable(
                name: "RouteDetails",
                columns: table => new
                {
                    RouteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Source = table.Column<string>(nullable: true),
                    Destination = table.Column<string>(nullable: true),
                    bus_date = table.Column<string>(nullable: true),
                    BusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteDetails", x => x.RouteID);
                    table.ForeignKey(
                        name: "FK_RouteDetails_BusDetails_BusId",
                        column: x => x.BusId,
                        principalTable: "BusDetails",
                        principalColumn: "BusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CardDetails",
                columns: table => new
                {
                    CardID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardType = table.Column<string>(nullable: true),
                    BankName = table.Column<string>(nullable: true),
                    CVVNo = table.Column<string>(nullable: true),
                    CardNo = table.Column<string>(nullable: true),
                    TotalAmount = table.Column<float>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardDetails", x => x.CardID);
                    table.ForeignKey(
                        name: "FK_CardDetails_LoginandSignUps_Id",
                        column: x => x.Id,
                        principalTable: "LoginandSignUps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BoardingPoints",
                columns: table => new
                {
                    StandID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoardingPoint = table.Column<string>(nullable: true),
                    DropingPoint = table.Column<string>(nullable: true),
                    RouteID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardingPoints", x => x.StandID);
                    table.ForeignKey(
                        name: "FK_BoardingPoints_RouteDetails_RouteID",
                        column: x => x.RouteID,
                        principalTable: "RouteDetails",
                        principalColumn: "RouteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoardingPoints_RouteID",
                table: "BoardingPoints",
                column: "RouteID");

            migrationBuilder.CreateIndex(
                name: "IX_CardDetails_Id",
                table: "CardDetails",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RouteDetails_BusId",
                table: "RouteDetails",
                column: "BusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoardingPoints");

            migrationBuilder.DropTable(
                name: "CardDetails");

            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropTable(
                name: "PNRDetails");

            migrationBuilder.DropTable(
                name: "ScheduleDetails");

            migrationBuilder.DropTable(
                name: "RouteDetails");

            migrationBuilder.DropTable(
                name: "LoginandSignUps");

            migrationBuilder.DropTable(
                name: "BusDetails");
        }
    }
}
