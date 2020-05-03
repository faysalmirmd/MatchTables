using System.Threading.Tasks;

namespace MatchTables
{
    public interface IController
    {
        Task RunAsync(Parameters parameters);

        Task<ValidationResponse> IsSchemaValidAsync(Parameters parameters);
    }
}
