using System.Threading.Tasks;

namespace MatchTables
{
    public interface IController
    {
        Task RunAsync(Parameters parameters);

        Task<bool> IsSchemaValidAsync(Parameters parameters);
    }
}
