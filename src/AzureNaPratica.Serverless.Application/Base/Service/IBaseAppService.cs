using AzureNaPratica.Serverless.Application.DataTransferObject.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AzureNaPratica.Serverless.Application.Base.Interfaces.Service
{
    public interface IBaseAppService<TEntity, Tid>
        where TEntity : BaseDtoId<Tid>
    {
        Task<IList<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(Tid id);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task DeleteAsync(Tid id);

        Task<TEntity> InsertAsync(TEntity entity);

        Task<IList<TEntity>> FindByPredicateAsync(Expression<Func<TEntity,bool>> entity);
    }
}