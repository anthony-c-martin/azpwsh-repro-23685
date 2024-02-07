# azpwsh-repro-23685

1. Clone repo and cd to the repo directory.
1. Install .NET 7 SDK (if necessary): https://dotnet.microsoft.com/en-us/download/dotnet/7.0
1. Run the following to test the "current" logic:
    ```powershell
    dotnet run --project current <path_to_bicep_file>
    ```
1. Run the following to test the "proposed" logic:
    ```powershell
    dotnet run --project proposed <path_to_bicep_file>
    ```