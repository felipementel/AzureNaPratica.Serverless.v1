using AzureNaPratica.Serverless.Domain.Aggregates.Course.Interfaces.Repositories;
using AzureNaPratica.Serverless.Domain.Aggregates.Course.Interfaces.Services;
using AzureNaPratica.Serverless.Domain.Aggregates.Course.Services;
using AzureNaPratica.Serverless.Domain.Tests.Fixtures;
using FluentAssertions;
using FluentValidation;
using Moq;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AzureNaPratica.Serverless.Domain.Tests
{
    public class CourseServiceTest
    {
        private readonly ICourseService _courseService;

        private readonly Mock<ICourseRepository> _courseRepositoryMock;

        private readonly Mock<IValidator<Domain.Aggregates.Course.Entities.Course>> _validator;

        public CourseServiceTest()
        {
            _courseRepositoryMock = new Mock<ICourseRepository>();
            _validator = new Mock<IValidator<Domain.Aggregates.Course.Entities.Course>>();

            _courseService = new CourseService(
                _courseRepositoryMock.Object,
                _validator.Object);
        }

        [Fact]
        public async Task InsertCourseAsync_WhenCourseIsValid_ShallRequestInsertCourseAsync()
        {
            //Arrange
            var items = CourseFixture.CreateValidCourse(3, "en");

            //_courseRepositoryMock.Setup(c => c.InsertAsync(items.First()))
            //    .ReturnsAsync(items);

            //Act
            var itemNew = await _courseService.InsertAsync(items[0]);

            //Assert
            itemNew.Id.Should().NotBeEmpty();

            _courseRepositoryMock.Verify(c => c.FindAllAsync(), Times.Once);
        }

        [Fact]
        public async Task FindAllAsync_ShallRequestFindAllAsync()
        {
            //Arrange
            var items = CourseFixture.CreateValidCourse(3, "en");

            _courseRepositoryMock.Setup(c => c.FindAllAsync())
                .ReturnsAsync(items);

            //Act
            var itemNew = await _courseService.InsertAsync(items[0]);

            //Assert
            itemNew.Id.Should().NotBeEmpty();

            _courseRepositoryMock.Verify(c => c.FindAllAsync(), Times.Once);            
        }
    }
}