using AzureNaPratica.Serverless.Domain.Aggregates.Course.Interfaces.Repositories;
using FluentValidation;
using Moq;
using Xunit;

namespace AzureNaPratica.Serverless.Domain.Tests
{
    public class CourseServiceTest
    {
        private readonly Mock<ICourseRepository> _courseRepositoryMock;

        private readonly IValidator<Domain.Aggregates.Course.Entities.Course> _validator;

        [Fact]
        public void Test1()
        {

        }
    }
}