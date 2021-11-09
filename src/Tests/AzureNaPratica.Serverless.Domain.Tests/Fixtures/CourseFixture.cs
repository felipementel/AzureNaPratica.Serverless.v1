using AzureNaPratica.Serverless.Domain.Aggregates.Course.Entities;
using Bogus;
using System;
using System.Collections.Generic;
using static AzureNaPratica.Serverless.Domain.Aggregates.Course.ValueObjects.Enumerations;

namespace AzureNaPratica.Serverless.Domain.Tests.Fixtures
{
    public class CourseFixture
    {
        public static List<Course> CreateValidCourse(int items, string language) =>
            new Faker<Course>()
            //.StrictMode(true)
            .CustomInstantiator(c => new Course(
                c.Random.Guid().ToString(),
                c.Name.FirstName(Bogus.DataSets.Name.Gender.Male),
                c.Random.Bool(),
                c.Date.Future(),
                c.Date.Future(),
                Decimal.Parse(c.Commerce.Price()),
                c.Random.Enum<Shift>()))
            .FinishWith((f, u) =>
            {
                Console.WriteLine("Course Created! Id={0}", u.Id);
            })
            .Generate(items);
        
        /// <summary>
        /// Invalid = without Name and Id 
        /// </summary>
        /// <param name="items"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public static List<Course> CreateInValidCourse(int items, string language) =>
           new Faker<Course>()
           .CustomInstantiator(c => new Course(
                c.Name.FirstName(Bogus.DataSets.Name.Gender.Male),
                c.Random.Bool(),
                c.Date.Future(),
                c.Date.Future(),
                Decimal.Parse(c.Commerce.Price()),
                c.Random.Enum<Shift>()))
            .FinishWith((f, u) =>
            {
                Console.WriteLine("Invalid Course Created!");
            })
            .Generate(items);
    }
}
