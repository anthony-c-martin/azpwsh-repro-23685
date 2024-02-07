IProcessInvoker invoker = args[0] switch {
    "current" => new ProcessInvoker_current(),
    "proposed" => new ProcessInvoker_proposed(),
    _ => throw new ArgumentException($"Invalid input {args[0]}"),
};

var filePath = args[1];

var result = invoker.Invoke(new ProcessInput
{
    Executable = "bicep",
    Arguments = $"build \"{filePath}\" --stdout",
});

Console.WriteLine($"STDOUT: {result.Stdout}");
Console.WriteLine($"STDERR: {result.Stderr}");
Console.WriteLine($"EXIT CODE: {result.ExitCode}");