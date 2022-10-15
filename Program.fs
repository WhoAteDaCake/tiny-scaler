open System
open System.IO
open FsToolkit.ErrorHandling
open TinyScaler.Configuration
open TinyScaler.Parsing
open TinyScaler.Providers

let findDirectory (file: string) =
    let fullFile =
        if Path.IsPathRooted(file) then
            file
        else
            Path.Join(Directory.GetCurrentDirectory(), file)
    let dir = Directory.GetParent(fullFile)
    if isNull dir then
        Result.Error $"Could not find parent"
    else if dir.Exists then
        Result.Ok (dir.ToString())
    else
        Result.Error $"Could not find directory: {dir}"

[<EntryPoint>]
let main args =
    let outcome = result {
        let! parsedState = Arguments.parse(args)
        let! config = Configuration.load(parsedState.configFile)
        // New to get the directory
        return! findDirectory(parsedState.composeFile)
    }
    match outcome with
    | Ok dir ->
        // Handle the directory
        let runner = Docker.DockerCommand dir
        let output = runner.Read() |> Async.RunSynchronously
        match output with
        | Ok data ->
            do Console.WriteLine("Success!")
            do Console.WriteLine(data)
            0
        | Error err ->
         do Console.WriteLine(err)
         1
    | Error err ->
         do Console.WriteLine(err)
         1