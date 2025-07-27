
namespace MyStack.KeepAlive.Service
{
    public interface IKeepAliveService
    {
        Task<string?> GetVersionAsync();
    }
}