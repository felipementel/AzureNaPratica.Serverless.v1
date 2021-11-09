using AzureNaPratica.Serverless.Domain.Aggregates.Course.Entities;
using Bogus;
using System;
using System.Collections.Generic;

namespace AzureNaPratica.Serverless.Domain.Tests.Fixtures
{
    public class CourseFixture
    {
        public static List<Course> CreateValidCourse(int items, string language) =>
            new Faker<Course>()
            //.StrictMode(true)
            .RuleFor(c => c.Id, c => Guid.NewGuid().ToString())
            .RuleFor(c => c.Price, c => Decimal.Parse(c.Commerce.Price()))
            .FinishWith((f, u) =>
            {
                Console.WriteLine("Course Created! Id={0}", u.Id);
            })
            .Generate(items);
    }
}
