using AzureNaPratica.Serverless.Application.DataTransferObject.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureNaPratica.Serverless.Application.Base.Interfaces.Service
{
    public interface IBaseAppService<TEntity, Tid>
        where TEntity : BaseDtoId<Tid>
    {
        Task<IList<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(Tid id);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(Tid id);

        Task InsertAsync(TEntity entity);

        //TODO: Paged
    }
}