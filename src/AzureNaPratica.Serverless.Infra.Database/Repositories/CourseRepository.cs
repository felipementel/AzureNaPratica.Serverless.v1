using AzureNaPratica.Serverless.Domain.Aggregates.Course.Entities;
using AzureNaPratica.Serverless.Domain.Aggregates.Course.Interfaces.Repositories;
using AzureNaPratica.Serverless.Domain.Base.Interfaces.Repository.MongoDB;
using AzureNaPratica.Serverless.Infra.Database.Repositories.Base;
using System;
using System.Threading.Tasks;

namespace AzureNaPratica.Serverless.Infra.Database.Repositories
{
    public class CourseRepository : BaseRepository<Course, string>, ICourseRepository
    {
        public CourseRepository(IMongoDbContext context) : base(context, "course")
        {

        }

        public override Task InsertAsync(Course entity)
        {
            entity.CreatedAt = DateTime.Now;
            entity.ModifiedAt = DateTime.Now;

            return base.InsertAsync(entity);
        }

        public override Task UpdateAsync(Course entity)
        {
            entity.ModifiedAt = DateTime.Now;

            return base.UpdateAsync(entity);
        }
    }
}