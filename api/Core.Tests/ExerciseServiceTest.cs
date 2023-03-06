//using AutoFixture;
//using AutoFixture.AutoMoq;
//using Core.Abstractions.Context;
//using Core.Abstractions.Entities;
//using Core.Entities;
//using Core.Services.WorkoutsServices;
//using FluentAssertions;
//using Moq;

//namespace Core.Tests
//{
//    public class ExerciseServiceTest
//    {
//        private readonly ExerciseService _service;
//        private readonly Mock<IUnitOfWork> _unitOfWork = new();
//        private readonly Mock<IExerciseRepository> _repositoryMock = new();
//        private readonly Fixture _fixture = new();

//        public ExerciseServiceTest()
//        {
//            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
//            _fixture.Customize(new AutoMoqCustomization());
//            _service = new ExerciseService(_unitOfWork.Object);
//            _unitOfWork.SetupGet(_ => _.Exercises).Returns(_repositoryMock.Object);
//        }

//        [Fact]
//        public async void GetExerciseAsync_ValidId_ReturnsExercise()
//        {
//            var id = _fixture.Create<int>();
//            var exercise = _fixture.Create<Exercise>();
//            _repositoryMock
//                .Setup(_ => _.GetAsync(id))
//                .ReturnsAsync(exercise)
//                .Verifiable();

//            var result = await _service.GetExerciseAsync(id);

//            result
//                .Should()
//                .BeEquivalentTo(exercise);

//            _repositoryMock.Verify();
//        }
//        [Fact]
//        public async void GetExerciseAsync_InvalidId_ReturnsNull()
//        {
//            var id = _fixture.Create<int>();
//            _repositoryMock
//                .Setup(_ => _.GetAsync(id))
//                .ReturnsAsync((IExercise?)null)
//                .Verifiable();

//            var result = await _service.GetExerciseAsync(id);

//            result
//                .Should()
//                .BeNull();

//            _repositoryMock.Verify();
//        }
//    }
//}