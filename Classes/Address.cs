using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpAddressAnalyzer.Classes
{
    internal class Address
    {
        public byte FirstOctet {  get; set; }
        
        public byte SecondOctet { get; set; }
        
        public byte ThirdOctet { get; set; }

        public byte FourthOctet { get; set; }

        public string SubnetMask { get; set; }

        public string NetworkAddress { get; set; }


        public Address(byte firstOctet, byte secondOctet, byte thirdOctet, byte fourthOctet)
        {
            FirstOctet = firstOctet;
            SecondOctet = secondOctet;
            ThirdOctet = thirdOctet;
            FourthOctet = fourthOctet;
        }

        public Address()
        {

        }

        public override string ToString()
        {
            return $"Gesammt: {FirstOctet}.{SecondOctet}.{ThirdOctet}.{FourthOctet}\n1.Oktet: {FirstOctet}, 2.Oktet: {SecondOctet}, 3.Oktet: {ThirdOctet}, 4.Oktet: {FourthOctet}";
        }
    }
}
