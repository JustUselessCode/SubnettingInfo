# SubnettingInfo
> - This is a quick and dirty CLI Tool for displaying necessary information for subnetting.
> - This is not ready for any sort of commercial use

# How to get started:

> - Step 1: Clone the repository
> - Step 2: Open Powershell and Navigate to the repo Path
> - Step 3: Run the command ```dotnet package SubnettingInfo.sln``` => This will package the solution
> - Step 4: Run the command ```dotnet tool install --global --add-source ./nupkg SubnettingInfo``` => This will install the IpAddressAnalyzer as a CLI Tool globally


# How to use the Tool
> In the CMD or PowerShell window run: ```SubnettingInfo <Ip> <Subnet Mask>```
> 
> Example usage: ```SubnettingInfo 192.123.123.47 255.0.0.0```
>
> This will display the Wanted information:
> ```
>Ip: 192.123.123.47
>
> Subnet-Mask: 255.0.0.0
>
>Prefix: /24
>
>   1.Oktet: 192
>
>   2.Oktet: 123
>
>   3.Oktet: 123
>
>   4.Oktet: 47
>
> Network-Address: 192.0.0.0
>
> Broadcast-Address: 192.255.255.255
>
> Host-Amount: 16.777.214
> ```
