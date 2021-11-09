using System.Threading.Tasks;

namespace AzureNaPratica.Serverless.Domain.Base.Interfaces.HttpService
{
    public interface ILuckyNumber
    {
        Task<int> GetLucyNumber();
    }
}