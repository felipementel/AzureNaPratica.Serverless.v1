using AzureNaPratica.Serverless.Domain.Aggregates.Student.Entities;
using AzureNaPratica.Serverless.Domain.Aggregates.Student.Interfaces.Repositories;
using AzureNaPratica.Serverless.Domain.Base.Interfaces.Repository.MongoDB;
using AzureNaPratica.Serverless.Infra.Database.Repositories.Base;
using System;
using System.Threading.Tasks;

namespace AzureNaPratica.Serverless.Infra.Database.Repositories
{
    public class StudentRepository : BaseRepository<Student, string>, IStudentRepository
    {
        public StudentRepository(IMongoDbContext context) : base(context, "student") 
        {

        }

        public override Task InsertAsync(Student entity)
        {
            entity.CreatedAt = DateTime.Now;
            entity.ModifiedAt = DateTime.Now;

            return base.InsertAsync(entity);
        }

        public override Task UpdateAsync(Student entity)
        {
            entity.ModifiedAt = DateTime.Now;

            return base.UpdateAsync(entity);
        }
    }
}
