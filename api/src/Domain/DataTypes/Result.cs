namespace Core.DataTypes
{
    public abstract record Result<T, E>
    {
        public record Success(T data) : Result<T, E>;
        public record Error(E error) : Result<T, E>;
    }
}
