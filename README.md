# azpwsh-repro-23685
Repro for https://github.com/Azure/azure-powershell/issues/23685

1. Clone repo and cd to the cloned folder.
1. Install .NET 7 SDK (if not already installed): https://dotnet.microsoft.com/en-us/download/dotnet/7.0
1. For `<path_to_bicep_file>` below, use a Bicep file which generates a large number of warning or error diagnostics (this is important to repro the problem).
1. Run the following to test the "current" logic (which contains the deadlock bug):
    ```powershell
    dotnet run --project current <path_to_bicep_file>
    ```
1. Run the following to test the "proposed" logic (which contains the fix):
    ```powershell
    dotnet run --project proposed <path_to_bicep_file>
    ```
