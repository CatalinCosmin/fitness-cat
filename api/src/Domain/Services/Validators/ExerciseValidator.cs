using FluentValidation;

namespace Core.Services.Validators
{ 
    internal class ExerciseValidator : AbstractValidator<IExercise>
    {
        private readonly IExerciseService _exerciseService;
        public ExerciseValidator(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }
    }
}
