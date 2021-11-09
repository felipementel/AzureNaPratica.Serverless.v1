using AzureNaPratica.Serverless.Domain.Aggregates.Course.Entities;
using AzureNaPratica.Serverless.Domain.Aggregates.Course.Interfaces.Repositories;
using AzureNaPratica.Serverless.Domain.Aggregates.Course.Interfaces.Services;
using AzureNaPratica.Serverless.Domain.Aggregates.Course.Services;
using AzureNaPratica.Serverless.Domain.Aggregates.Course.Validations;
using AzureNaPratica.Serverless.Domain.Tests.Fixtures;
using FluentAssertions;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace AzureNaPratica.Serverless.Domain.Tests
{
    public class CourseServiceTest
    {
        private readonly ICourseService _courseService;

        private readonly Mock<ICourseRepository> _courseRepositoryMock;

        private readonly CourseValidator _validator;

        public CourseServiceTest()
        {
            _courseRepositoryMock = new Mock<ICourseRepository>();
            _validator = new CourseValidator();

            _courseService = new CourseService(
                _courseRepositoryMock.Object,
                _validator);
        }

        [Fact]
        public async Task InsertCourseAsync_WhenCourseIsValid_ShallRequestInsertCourseAsync()
        {
            //Arrange
            var items = CourseFixture.CreateValidCourse(1, "en");

            _courseRepositoryMock.Setup(c => c.InsertAsync(It.IsAny<Course>()))
                .Returns(Task.FromResult(items[0]));

            //Act
            var itemNew = await _courseService.InsertAsync(items[0]);

            //Assert
            itemNew.Id.Should().NotBeEmpty();

            _courseRepositoryMock.Verify(c => c.InsertAsync(It.IsAny<Course>()), Times.Once);
        }

        [Fact]
        public async Task FindAllAsync_ShallRequestFindAllAsync()
        {
            //Arrange
            var items = CourseFixture.CreateValidCourse(3, "en");

            _courseRepositoryMock.Setup(c => c.FindAllAsync())
                .ReturnsAsync(items);

            //Act
            var itemNew = await _courseService.GetAllAsync();

            //Assert

            _courseRepositoryMock.Verify(c => c.FindAllAsync(), Times.Once);
        }
    }
}