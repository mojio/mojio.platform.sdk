using System.Threading.Tasks;

namespace Mojio.Platform.SDK.Contracts.Entities
{
    public interface IAuthorizationManager
    {
        Task Logout();

        Task SaveAuthorization(IAuthorization authorization);

        Task<IAuthorization> LoadAuthorization();
    }
}