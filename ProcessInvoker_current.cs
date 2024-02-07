using System.Diagnostics;
using System.Text;

public class ProcessInvoker_current : IProcessInvoker
{
    public ProcessOutput Invoke(ProcessInput input)
    {
        var proc = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = input.Executable,
                Arguments = input.Arguments,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                StandardOutputEncoding = Encoding.UTF8,
                StandardErrorEncoding = Encoding.UTF8,
                CreateNoWindow = true,
            }
        };

        if (input.EnvVars != null)
        {
            foreach (var kvp in input.EnvVars)
            {
                proc.StartInfo.Environment[kvp.Key] = kvp.Value;
            }
        }

        proc.Start();
        var stdout = proc.StandardOutput.ReadToEnd();
        var stderr = proc.StandardError.ReadToEnd();
        proc.WaitForExit();

        return new ProcessOutput {
            Stdout = stdout,
            Stderr = stderr,
            ExitCode = proc.ExitCode
        };
    }
}