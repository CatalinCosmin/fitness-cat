using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class User : IUser
    {
        public Guid ID { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateOnly BirthDate { get; set; } // Format "YYYY-MM-DDThh:mm:ss"
        public DateOnly AccountCreationDate { get; set; }
        public DateTime? LastAuthenticationDate { get; set; } = null;
        public bool isVerified { get; set; } = false;

        public List<IWorkout> Workouts { get; set; } = new();
        public List<IWorkoutRoutine> WorkoutRoutines { get; set; } = new();


    }
}
