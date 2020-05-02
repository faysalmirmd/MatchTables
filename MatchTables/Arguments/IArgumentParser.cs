namespace MatchTables
{
    public interface IArgumentParser
    {
        bool IsValid(string[] args);
        Parameters Parse(string[] args);
    }
}
