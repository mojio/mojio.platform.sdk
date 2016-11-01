using System.Threading.Tasks;

namespace Mojio.Platform.SDK.Contracts.Extension
{
    public static class TaskExtensions
    {
        public static readonly Task CompletedTask = Task.FromResult(false);
    }
}