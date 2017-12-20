using System.Threading.Tasks;

namespace MarcoGazzola.Identity.MongoDB
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
