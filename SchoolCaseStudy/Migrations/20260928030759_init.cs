using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolCaseStudy.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassRooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GradeLevel = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassRooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClassRoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_ClassRooms_ClassRoomId",
                        column: x => x.ClassRoomId,
                        principalTable: "ClassRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MaxGrade = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subjects_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Grade = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enrollments_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ClassRooms",
                columns: new[] { "Id", "Capacity", "GradeLevel", "Name" },
                values: new object[,]
                {
                    { 1, 30, 10, "Class A" },
                    { 2, 25, 11, "Class B" },
                    { 3, 30, 12, "Class C" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Department of Computer Science", "Computer Science" },
                    { 2, "Department of Information Technology", "Information Technology" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ClassRoomId", "DateOfBirth", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2009, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "ali.mohamed@student.com", "Ali", "Mohamed", "01011111111" },
                    { 2, 1, new DateTime(2009, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "sara.ahmed@student.com", "Sara", "Ahmed", "01122222222" },
                    { 3, 2, new DateTime(2008, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "youssef.mahmoud@student.com", "Youssef", "Mahmoud", "01233333333" },
                    { 4, 2, new DateTime(2008, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "nour.khaled@student.com", "Nour", "Khaled", "01044444444" },
                    { 5, 3, new DateTime(2007, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "mariam.tarek@student.com", "Mariam", "Tarek", "01155555555" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "DepartmentId", "Email", "FirstName", "LastName", "PhoneNumber", "Salary" },
                values: new object[,]
                {
                    { 1, 1, "ahmed.hassan@school.com", "Ahmed", "Hassan", "01012345678", 15000m },
                    { 2, 1, "mona.ali@school.com", "Mona", "Ali", "01112345678", 14000m },
                    { 3, 2, "omar.ibrahim@school.com", "Omar", "Ibrahim", "01212345678", 13000m }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Description", "MaxGrade", "Name", "TeacherId" },
                values: new object[,]
                {
                    { 1, "Introduction to C# programming", 100, "C# Programming", 1 },
                    { 2, "Database concepts and SQL", 100, "Database", 2 },
                    { 3, "HTML, CSS and web development", 100, "Web Development", 3 }
                });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "Id", "EnrollmentDate", "Grade", "StudentId", "SubjectId" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 90m, 1, 1 },
                    { 2, new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 85m, 1, 2 },
                    { 3, new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 95m, 2, 1 },
                    { 4, new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 88m, 2, 3 },
                    { 5, new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 78m, 3, 2 },
                    { 6, new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 82m, 3, 3 },
                    { 7, new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 91m, 4, 1 },
                    { 8, new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 87m, 5, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_StudentId_SubjectId",
                table: "Enrollments",
                columns: new[] { "StudentId", "SubjectId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_SubjectId",
                table: "Enrollments",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassRoomId",
                table: "Students",
                column: "ClassRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_TeacherId",
                table: "Subjects",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_DepartmentId",
                table: "Teachers",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "ClassRooms");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
