# SubnettingInfo
> - This is a quick and dirty CLI Tool for displaying necessary information for subnetting, that i developed as a little school project.
> - This is not ready for any sort of commercial use

# How to get started?

> - Step 1: Clone the repository
> - Step 2: Open Powershell and Navigate to the repo Path
> - Step 3: Run the command ```dotnet package SubnettingInfo.sln``` => This will package the solution
> - Step 4: Run the command ```dotnet tool install --global --add-source ./nupkg SubnettingInfo``` => This will install the IpAddressAnalyzer as a CLI Tool globally


# How to use the Tool with Ipv4?

> In the CMD or PowerShell window run: ```SubnettingInfo <--ipv4> <Ip> <Subnet Mask>``` => For Ipv4 Information
> 
> Example usage: ```SubnettingInfo --ipv4 192.123.123.47 255.0.0.0```
>
> This will display the Wanted information:
> ```
>Ip: 192.123.123.47
>
> Subnet-Mask: 255.0.0.0
>
>Prefix: /24
>
>   1.Octet: 192
>
>   2.Octet: 123
>
>   3.Octet: 123
>
>   4.Octet: 47
>
> Network-Address: 192.0.0.0
>
> Broadcast-Address: 192.255.255.255
>
> Host-Amount: 16.777.214
> ```

# How to use the Tool with Ipv6?
> As of right now, Ipv6 is not yet supported but will be added in the future.

# How to unistall the Tool?
> In a PowerShell Window run the command ```dotnet tool uninstall subnettinginfo --global```
