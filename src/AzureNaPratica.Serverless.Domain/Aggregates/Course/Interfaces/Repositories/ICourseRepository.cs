﻿using AzureNaPratica.Serverless.Domain.Base.Interfaces.Repository;

namespace AzureNaPratica.Serverless.Domain.Aggregates.Course.Interfaces.Repositories
{
    public interface ICourseRepository : IBaseRepository<Course.Entities.Course, string>
    {
    }
}