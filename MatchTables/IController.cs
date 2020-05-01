using System.Threading.Tasks;

namespace MatchTables
{
    public interface IController
    {
        Task Run(Parameters parameters);

        Task<bool> IsSchemaSame(Parameters parameters);
    }
}
