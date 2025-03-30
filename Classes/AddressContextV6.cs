using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubnettingInfo.Classes;

internal class AddressContextV6
{
    public string IpV6Address { get; set; }

    public ushort Prefix { get; set; }

    public UInt128 TotatlPossibleAddresses { get; set; }

    public UInt64 TotalPossible64Subnets { get; set; }

    public AddressContextV6(string ipV6, string prefix)
    {
        IpV6Address = ipV6;
        var evaluatedPrefix = EvaluatePrefix(prefix);
        
        Prefix = EvaluatePrefix(prefix);

    }

    private ushort EvaluatePrefix(string pref)
    {
        if (pref.Contains("/"))
        {
            throw new ArgumentException("The Prefix is not allowed to contain a \"/\"");
        }
        var isValid = byte.TryParse(pref, out var result);
        return isValid ? result : throw new ArgumentException($"The provided prefix seems to be larger then 128. \n\nPrefix: {pref}");
    }

    public override string ToString()
    {
        StringBuilder str = new();
        str.Append($"IpV6: {IpV6Address}");
        str.Append($"\n\nPrefix: {Prefix}");
        throw new NotImplementedException("The ToString Method does not log all information");
        return str.ToString();
    }
}
