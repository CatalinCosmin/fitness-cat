using AutoFixture;
using AutoFixture.AutoMoq;
using Core.Abstractions.Context;
using Core.Entities;
using Infrastructure.Context;
using Moq;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using Infrastructure.Entities;
using Exercise = Infrastructure.Entities.Exercise;
using Core.Abstractions.Entities;

namespace Infrastructure.Tests
{
    public class ExerciseRepositoryTest
    {
        private readonly ExerciseRepository _repository;
        private readonly Mock<IUnitOfWork> _unitOfWork = new();
        private readonly Mock<DataContext> _context;
        private readonly Mock<IExerciseRepository> _repositoryMock = new();
        private readonly Fixture _fixture = new();

        public ExerciseRepositoryTest()
        {
            var mockSet = new Mock<DbSet<Exercise>>();

            _context = new Mock<DataContext>();
            _context.SetupGet(m => m.Exercises).Returns(mockSet.Object);

            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            _fixture.Customize(new AutoMoqCustomization());
            _repository = new ExerciseRepository(_context.Object);
            _unitOfWork.SetupGet(_ => _.Exercises).Returns(_repositoryMock.Object);
        }

        [Fact]
        public void GetExercise_ValidId_ReturnsExercise()
        {
            var id = _fixture.Create<int>();
            var exercise = _fixture.Create<Exercise>();
            _repositoryMock
                .Setup(_ => _.GetExercise(id))
                .Returns((Core.Abstractions.Entities.IExercise)exercise)
                .Verifiable();

            var result = _repository.GetExercise(id);

            result
                .Should()
                .BeEquivalentTo(exercise);

            _repositoryMock.Verify();
        }
        [Fact]
        public void GetExercise_InvalidId_ReturnsNull()
        {
            var id = _fixture.Create<int>();
            _repositoryMock
                .Setup(_ => _.GetExercise(id))
                .Returns((IExercise?)null)
                .Verifiable();

            var result = _repository.GetExercise(id);

            result
                .Should()
                .BeNull();

            _repositoryMock.Verify();
        }
    }
}