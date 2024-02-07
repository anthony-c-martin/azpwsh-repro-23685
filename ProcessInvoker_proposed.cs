using System.Diagnostics;
using System.Text;

public class ProcessInvoker_proposed : IProcessInvoker
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

        var stderr = new StringBuilder();
        proc.ErrorDataReceived += (sender, e) =>  stderr.AppendLine(e.Data);
        proc.Start();

        // To avoid deadlocks, use an asynchronous read operation on at least one of the streams.  
        proc.BeginErrorReadLine();
        var stdout = proc.StandardOutput.ReadToEnd();  
        proc.WaitForExit();

        return new ProcessOutput {
            Stdout = stdout,
            Stderr = stderr.ToString(),
            ExitCode = proc.ExitCode
        };
    }
}