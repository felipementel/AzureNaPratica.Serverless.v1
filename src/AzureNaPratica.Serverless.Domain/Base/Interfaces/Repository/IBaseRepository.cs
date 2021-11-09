using AzureNaPratica.Serverless.Domain.Base.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureNaPratica.Serverless.Domain.Base.Interfaces.Repository
{
    public interface IBaseRepository<TEntity, Tid>
        where TEntity : BaseEntityId<Tid>
    {
        Task<IList<TEntity>> FindAllAsync();

        Task<TEntity> FindByIdAsync(Tid id);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(Tid id);

        Task InsertAsync(TEntity entity);

        //TODO: Paged
    }
}
