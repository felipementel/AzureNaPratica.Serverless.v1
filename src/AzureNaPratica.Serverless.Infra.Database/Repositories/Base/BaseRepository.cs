using AzureNaPratica.Serverless.Domain.Base.Entity;
using AzureNaPratica.Serverless.Domain.Base.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureNaPratica.Serverless.Infra.Database.Repositories.Base
{
    public abstract class BaseRepository<TEntity, Tid>
        : IBaseRepository<TEntity, Tid> where TEntity : BaseEntityId<Tid>
    {
        public Task<TEntity> DeleteAsync(Tid id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<TEntity>> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> FindByIdAsync(Tid id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> InsertAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
