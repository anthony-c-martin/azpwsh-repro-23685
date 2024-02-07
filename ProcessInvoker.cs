public class ProcessOutput
{
    public string Stdout { get; set; }

    public string Stderr { get; set; }

    public int ExitCode { get; set; }
}

public class ProcessInput
{
    public string Executable { get; set; }

    public string Arguments { get; set; }

    public Dictionary<string, string> EnvVars { get; set; }
}

public interface IProcessInvoker
{
    ProcessOutput Invoke(ProcessInput input);
}