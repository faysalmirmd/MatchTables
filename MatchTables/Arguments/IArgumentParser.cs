using System;
using System.Collections.Generic;
using System.Text;

namespace MatchTables
{
    public interface IArgumentParser
    {
        bool IsValid(string[] args);
        Parameters Parse(string[] args);
    }
}
