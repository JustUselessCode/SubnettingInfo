
using System.Text;

namespace IpAddressAnalyzer.Classes
{
    internal class AddressContext
    {
        public string IpAddress { get; set; }
        
        public string SubnetMask { get; set; }

        public string NetworkAddress { get; set; }

        public string BroadcastAddress { get; set; }

        public uint TotalPossibleHosts { get; set; }

        public string SubnetPrefix { get; set; }


        public AddressContext(string ip, string subnetMask)
        {
            IpAddress = ip;
            SubnetMask = subnetMask;
        }

        public override string ToString()
        {
            StringBuilder str = new();
            str.Append($"Ip: {IpAddress}");
            str.Append($"\n\nSubnet-Mask: {SubnetMask}");
            str.Append($"\n\nPrefix: {SubnetPrefix}");
            str.Append($"\n\nNetwork-Address: {NetworkAddress}");
            str.Append($"\n\nBroadcast-Address: {BroadcastAddress}");
            str.Append($"\n\nHost - Amount: {TotalPossibleHosts.ToString("N0")}");
            return str.ToString();
        }
    }
}
