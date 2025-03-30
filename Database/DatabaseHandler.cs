using IpAddressAnalyzer.Classes;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubnettingInfo.Database;

internal class DatabaseHandler
{
    private const string _connectionString = "Data Source=IpAddressAnalyzer.db";

    public static void CreateDatabaseIpV4()
    {
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();
        using var command = new SqliteCommand()
        {
            Connection = connection
        };
        command.CommandText = "CREATE TABLE IF NOT EXISTS IpAddressesV4 (Id INTEGER PRIMARY KEY, IpAddress TEXT, SubnetMask TEXT, NetworkAddress TEXT, BroadcastAddress TEXT, TotalPossibleHosts INTEGER, SubnetPrefix TEXT)";
        command.ExecuteNonQuery();
    }

    public static void CreateDatabaseIpV6()
    {
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();
        using var command = new SqliteCommand()
        {
            Connection = connection
        };
        command.CommandText = "CREATE TABLE IF NOT EXISTS IpAddressesV6 (Id INTEGER PRIMARY KEY, IpAddress TEXT, Prefix INTEGER, TotalPossibleAddresses TEXT, TotalPossible64Subnets TEXT)";
        command.ExecuteNonQuery();
    }


    public static List<AddressContextV4> GetLastSubnettingIpV4Entries()
    {
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();
        using var command = new SqliteCommand()
        {
            Connection = connection
        };
        command.CommandText = "SELECT * FROM IpAddressesV4 ORDER BY Id DESC LIMIT 5";
        using var reader = command.ExecuteReader();
        List<AddressContextV4> entries = new();
        var totalPossibleHost = () =>
        {
            byte[] buffer = new byte[2];
            var _ = reader.GetBytes(0, 0, buffer, 0, 2);
            uint hosts = 0;
            foreach (byte b in buffer)
            {
                hosts += (uint)b;
            }

            return hosts;
        };
        while (reader.Read())
        {
            throw new NotImplementedException("Total Possible Host calculation is not fully implemented yet");
            entries.Add(new AddressContextV4(reader.GetString(1), reader.GetString(2))
            {
                NetworkAddress = reader.GetString(3),
                BroadcastAddress = reader.GetString(4),
                TotalPossibleHosts = (uint)totalPossibleHost(),
                SubnetPrefix = reader.GetString(6)
            });
        }
        return entries;
    }
}
