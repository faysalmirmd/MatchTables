using System;
using System.Linq;
using System.Reflection;

namespace MatchTables
{
    public class ArgumentParser : IArgumentParser
    {
        private readonly string[] _parameterNames = new[] { "table1", "table2", "primarykey" };
        public bool IsValid(string[] args)
        {
            if (args.Length < 6) return false;
            return _parameterNames.Contains(GetParameterName(args[0])) && _parameterNames.Contains(GetParameterName(args[2])) &&
                   _parameterNames.Contains(GetParameterName(args[4]));
        }

        public Parameters Parse(string[] args)
        {
            var parameters = new Parameters();
            SetProperty(parameters, GetParameterName(args[0]), GetParameterValue(args[1]));
            SetProperty(parameters, GetParameterName(args[2]), GetParameterValue(args[3]));
            SetProperty(parameters, GetParameterName(args[4]), GetParameterValue(args[5]));

            return parameters;
        }

        void SetProperty(Parameters obj, string propName, string value)
        {
            var prop = obj.GetType().GetProperty(propName, BindingFlags.Public | BindingFlags.Instance);
            if (null != prop && prop.CanWrite)
            {
                prop.SetValue(obj, value, null);
            }
        }

        string GetParameterName(string name)
        {
            return name.TrimStart('-').ToLower();
        }

        private string GetParameterValue(string val)
        {
            return val.TrimStart('[').TrimEnd(']');
        }
    }
}
