using System.ComponentModel.DataAnnotations;

namespace Core.Abstractions.Entities
{
    public interface IUser
    {
        [Key, Required]
        public Guid ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateOnly BirthDate { get; set; } // Format "YYYY-MM-DDThh:mm:ss"
        public DateOnly AccountCreationDate { get; set; }
        public DateTime? LastAuthenticationDate { get; set; }
        public bool isVerified { get; set; }

        public List<IWorkout> Workouts { get; set; }
        public List<IWorkoutRoutine> WorkoutRoutines { get; set; }


    }
}
