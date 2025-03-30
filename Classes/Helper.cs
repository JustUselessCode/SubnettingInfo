using Microsoft.Data.Sqlite;
using System.Text;

namespace IpAddressAnalyzer.Classes;

internal class Helper
{
    private static readonly string _ApplicationDataPath = $"{Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SubnettingInfo")}";
    private static readonly SqliteConnection _connectionForV4 = new($"Data Source={_ApplicationDataPath}/IpAddressV4.db");
    private static readonly SqliteConnection _connectionForV6 = new($"Data Source={_ApplicationDataPath}/IpAddressV6.db");

    internal class IPV4
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

            for (sbyte i = 0; i < 8; i++)
            {
                bool bitSet = IsBitSet(b, i);

                if (!bitSet)
                {
                    binString.Append(0);
                }

                else if (bitSet)
                {
                    binString.Append(1);
                }
            }

            return Helper.IPV4.ReverseString(binString.ToString());
        }

        public static string ConvertBinToDez(byte b)
        {
            return $"{b}";
        }

        public static bool IsBitSet(byte b, sbyte bitPosition)
        {
            return (b & (1 << bitPosition)) != 0;
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
                    invertedSubnetBytes[i] = (byte)0;
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
                for (sbyte i = 0; i < 8; i++)
                {
                    if (!Helper.IPV4.IsBitSet(b, i))
                    {
                        numberOfHostBits++;
                    }
                }
            }

            return numberOfHostBits;
        }
    }
    
    internal static class IPV6
    {
        public static string NormalizeShortnedIPV6Address(string address)
        {
            if (address.Length == 39)
            {
                return address;
            }

            string normalizedAddressString = "";
            for (int i = 0; i < address.Length; i++)
            {
                normalizedAddressString += address[i];

                if (address[i] == ':' && address[i + 1] == ':')
                {
                    normalizedAddressString = normalizedAddressString.Substring(0, normalizedAddressString.Length - 1);

                    int missingSegments = 39 - address.Length;
                    for (int j = 0; j < missingSegments; j++)
                    {
                        normalizedAddressString += (j % 5 == 0) ? ":" : "0";
                    }
                }
            }

            string[] strArr = normalizedAddressString.Split(':');
            string[] fixedArr = new string[strArr.Length];

            for (int i = 0; i < strArr.Length; i++)
            {
                if (strArr[i].Length < 4)
                {
                    string additionalZeros = new string('0', 4 - strArr[i].Length);
                    fixedArr[i] = additionalZeros + strArr[i];
                }
                else
                {
                    fixedArr[i] = strArr[i];
                }
            }

            var finishedComputation = string.Join(":", fixedArr);

            if (finishedComputation.Length != 39)
            {
                throw new Exception("Function not working properly");
            }

            return finishedComputation;
        }
    }
}
