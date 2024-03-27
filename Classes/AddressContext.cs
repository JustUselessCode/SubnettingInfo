
namespace IpAddressAnalyzer.Classes
{
    internal class AddressContext
    {
        public byte FirstOctet {  get; set; }
        
        public byte SecondOctet { get; set; }
        
        public byte ThirdOctet { get; set; }

        public byte FourthOctet { get; set; }

        public string SubnetMask { get; set; }

        public string NetworkAddress { get; set; }

        public string BroadcastAddress { get; set; }

        public uint TotalPossibleHosts { get; set; }

        public string SubnetPrefix { get; set; }

        public AddressContext(byte firstOctet, byte secondOctet, byte thirdOctet, byte fourthOctet)
        {
            FirstOctet = firstOctet;
            SecondOctet = secondOctet;
            ThirdOctet = thirdOctet;
            FourthOctet = fourthOctet;
        }

        public AddressContext()
        {

        }

        public override string ToString()
        {
            var indent = "   ";
            return $"\nGesammt: {FirstOctet}.{SecondOctet}.{ThirdOctet}.{FourthOctet}\n\nSubnet-Mask: {SubnetMask}\n\nPrefix: {SubnetPrefix}\n\n{indent}1.Oktet: {FirstOctet}\n\n{indent}2.Oktet: {SecondOctet}\n\n{indent}3.Oktet: {ThirdOctet}\n\n{indent}4.Oktet: {FourthOctet}\n\nNetwork-Address: {NetworkAddress}\n\nBroadcast-Address: {BroadcastAddress}\n\nHost-Amount: {TotalPossibleHosts.ToString("N0")}";
        }
    }
}
