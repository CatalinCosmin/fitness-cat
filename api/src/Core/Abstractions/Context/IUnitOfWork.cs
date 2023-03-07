namespace Core.Abstractions.Context
{
    public interface IUnitOfWork
    {
        public IExerciseRepository Exercises { get; set; }

        Task SaveAsync();

    }
}
