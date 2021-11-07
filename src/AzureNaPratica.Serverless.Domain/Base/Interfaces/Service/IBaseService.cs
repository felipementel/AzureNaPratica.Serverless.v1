using AzureNaPratica.Serverless.Domain.Base.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureNaPratica.Serverless.Domain.Base.Interfaces.Service
{
    public interface IBaseService<TEntity, Tid>
        where TEntity : BaseEntityId<Tid>
    {
        Task<IList<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(Tid id);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<TEntity> DeleteAsync(Tid id);

        Task<TEntity> InsertAsync(TEntity entity);

        //TODO: Paged
    }
}