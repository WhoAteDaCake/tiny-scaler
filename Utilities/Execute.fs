module TinyScaler.Utilities.Execute

open System
open System.Diagnostics
open System.Threading.Tasks

type CommandResult = Result<string, int * string>

let command executable args : Async<CommandResult> =
  async {
    let startInfo = ProcessStartInfo()
    startInfo.FileName <- executable
    for a in args do
      startInfo.ArgumentList.Add(a)
    startInfo.RedirectStandardOutput <- true
    startInfo.RedirectStandardError <- true
    startInfo.UseShellExecute <- false
    startInfo.CreateNoWindow <- true
    use p = new Process()
    p.StartInfo <- startInfo
    p.Start() |> ignore

    let outTask = Task.WhenAll([|
      p.StandardOutput.ReadToEndAsync();
      p.StandardError.ReadToEndAsync()
    |])

    do! p.WaitForExitAsync() |> Async.AwaitTask
    let! out = outTask |> Async.AwaitTask
    return
      if p.ExitCode <> 0 then
        Result.Error (p.ExitCode, out.[1])
      else
        Result.Ok out.[0]
  }

let shellCommand cmd =
  command "/usr/bin/env" [ "-S"; "bash"; "-c"; cmd ]
