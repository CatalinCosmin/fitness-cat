using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Difficulty = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MuscleGroups",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MuscleGroups", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Muscles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Muscles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    AccountCreationDate = table.Column<DateOnly>(type: "date", nullable: false),
                    LastAuthenticationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    isVerified = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ExercisesEquipments",
                columns: table => new
                {
                    EquipmentsID = table.Column<int>(type: "integer", nullable: false),
                    ExercisesID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExercisesEquipments", x => new { x.EquipmentsID, x.ExercisesID });
                    table.ForeignKey(
                        name: "FK_ExercisesEquipments_Equipments_EquipmentsID",
                        column: x => x.EquipmentsID,
                        principalTable: "Equipments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExercisesEquipments_Exercises_ExercisesID",
                        column: x => x.ExercisesID,
                        principalTable: "Exercises",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExercisesMuscleGroups",
                columns: table => new
                {
                    ExercisesID = table.Column<int>(type: "integer", nullable: false),
                    MuscleGroupsID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExercisesMuscleGroups", x => new { x.ExercisesID, x.MuscleGroupsID });
                    table.ForeignKey(
                        name: "FK_ExercisesMuscleGroups_Exercises_ExercisesID",
                        column: x => x.ExercisesID,
                        principalTable: "Exercises",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExercisesMuscleGroups_MuscleGroups_MuscleGroupsID",
                        column: x => x.MuscleGroupsID,
                        principalTable: "MuscleGroups",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseMuscle",
                columns: table => new
                {
                    ExercisesID = table.Column<int>(type: "integer", nullable: false),
                    MusclesID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseMuscle", x => new { x.ExercisesID, x.MusclesID });
                    table.ForeignKey(
                        name: "FK_ExerciseMuscle_Exercises_ExercisesID",
                        column: x => x.ExercisesID,
                        principalTable: "Exercises",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseMuscle_Muscles_MusclesID",
                        column: x => x.MusclesID,
                        principalTable: "Muscles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MusclesMuscleGroups",
                columns: table => new
                {
                    MuscleGroupsID = table.Column<int>(type: "integer", nullable: false),
                    MusclesID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusclesMuscleGroups", x => new { x.MuscleGroupsID, x.MusclesID });
                    table.ForeignKey(
                        name: "FK_MusclesMuscleGroups_MuscleGroups_MuscleGroupsID",
                        column: x => x.MuscleGroupsID,
                        principalTable: "MuscleGroups",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MusclesMuscleGroups_Muscles_MusclesID",
                        column: x => x.MusclesID,
                        principalTable: "Muscles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutRoutines",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    AccesibilityLevel = table.Column<int>(type: "integer", nullable: false),
                    workoutroutineowner = table.Column<Guid>(name: "workoutroutine_owner", type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutRoutines", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WorkoutRoutines_Users_workoutroutine_owner",
                        column: x => x.workoutroutineowner,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Workouts",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    CreationDate = table.Column<DateOnly>(type: "date", nullable: false),
                    AccesibilityLevel = table.Column<int>(type: "integer", nullable: false),
                    workoutowner = table.Column<Guid>(name: "workout_owner", type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workouts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Workouts_Users_workout_owner",
                        column: x => x.workoutowner,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutRoutinesWorkouts",
                columns: table => new
                {
                    WorkoutRoutineID = table.Column<Guid>(type: "uuid", nullable: false),
                    WorkoutsID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutRoutinesWorkouts", x => new { x.WorkoutRoutineID, x.WorkoutsID });
                    table.ForeignKey(
                        name: "FK_WorkoutRoutinesWorkouts_WorkoutRoutines_WorkoutRoutineID",
                        column: x => x.WorkoutRoutineID,
                        principalTable: "WorkoutRoutines",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkoutRoutinesWorkouts_Workouts_WorkoutsID",
                        column: x => x.WorkoutsID,
                        principalTable: "Workouts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutsExercises",
                columns: table => new
                {
                    ExercisesID = table.Column<int>(type: "integer", nullable: false),
                    WorkoutsID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutsExercises", x => new { x.ExercisesID, x.WorkoutsID });
                    table.ForeignKey(
                        name: "FK_WorkoutsExercises_Exercises_ExercisesID",
                        column: x => x.ExercisesID,
                        principalTable: "Exercises",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkoutsExercises_Workouts_WorkoutsID",
                        column: x => x.WorkoutsID,
                        principalTable: "Workouts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseMuscle_MusclesID",
                table: "ExerciseMuscle",
                column: "MusclesID");

            migrationBuilder.CreateIndex(
                name: "IX_ExercisesEquipments_ExercisesID",
                table: "ExercisesEquipments",
                column: "ExercisesID");

            migrationBuilder.CreateIndex(
                name: "IX_ExercisesMuscleGroups_MuscleGroupsID",
                table: "ExercisesMuscleGroups",
                column: "MuscleGroupsID");

            migrationBuilder.CreateIndex(
                name: "IX_MusclesMuscleGroups_MusclesID",
                table: "MusclesMuscleGroups",
                column: "MusclesID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutRoutines_workoutroutine_owner",
                table: "WorkoutRoutines",
                column: "workoutroutine_owner");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutRoutinesWorkouts_WorkoutsID",
                table: "WorkoutRoutinesWorkouts",
                column: "WorkoutsID");

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_workout_owner",
                table: "Workouts",
                column: "workout_owner");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutsExercises_WorkoutsID",
                table: "WorkoutsExercises",
                column: "WorkoutsID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseMuscle");

            migrationBuilder.DropTable(
                name: "ExercisesEquipments");

            migrationBuilder.DropTable(
                name: "ExercisesMuscleGroups");

            migrationBuilder.DropTable(
                name: "MusclesMuscleGroups");

            migrationBuilder.DropTable(
                name: "WorkoutRoutinesWorkouts");

            migrationBuilder.DropTable(
                name: "WorkoutsExercises");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "MuscleGroups");

            migrationBuilder.DropTable(
                name: "Muscles");

            migrationBuilder.DropTable(
                name: "WorkoutRoutines");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "Workouts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
