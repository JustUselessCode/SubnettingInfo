using System.Text;

namespace IpAddressAnalyzer.Classes
{
    internal class Helper
    {
        public static string ReverseString(string input)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = input.Length - 1; i >= 0; i--)
            {
                sb.Append(input[i]);
            }

            return sb.ToString();
        }

        public static string ConvertDezToBin(byte b)
        {
            StringBuilder binString = new StringBuilder();

            for (int i = 0; i < 8; i++)
            {
                bool BitSet = IsBitSet(b, i);

                if (!BitSet)
                {
                    binString.Append(0);
                }

                else if (BitSet)
                {
                    binString.Append(1);
                }
            }

            return Helper.ReverseString(binString.ToString());
        }

        public static string ConvertBinToDez(byte b)
        {
            return $"{b}";
        }

        public static bool IsBitSet(byte b, int pos)
        {
            return (b & (1 << pos)) != 0;
        }

        public static byte[] InvertSubnetMask(byte[] subnetMaskParts) 
        {

            if (subnetMaskParts.Length != 4)
            {
                throw new ArgumentException("Subnet Mask has invalid form!");
            }
            byte[] invertedSubnetBytes = new byte[4];

            for (int i = 0; i < subnetMaskParts.Length; i++)
            {
                if (subnetMaskParts[i] == 255)
                {
                    invertedSubnetBytes[i] = (byte) 0;
                }

                else
                {
                    invertedSubnetBytes[i] = (byte)~(subnetMaskParts[i]);
                }
            }

            return invertedSubnetBytes;
        }

        public static uint CalculateNumberOfHostBits(byte[] SubnetParts)
        {
            uint numberOfHostBits = 0;

            foreach (byte b in SubnetParts)
            {
                for (int i = 0; i < 8; i++)
                {
                    if (!IsBitSet(b, i))
                    {
                        numberOfHostBits++;
                    }
                }
            }

            return numberOfHostBits;
        }
    }
}
