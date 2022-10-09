open System
open FsToolkit.ErrorHandling
open TinyScaler.Configuration
open TinyScaler.Parsing


[<EntryPoint>]
let main args =
    let outcome = result {
        let! parsedState = Arguments.parse(args)
        let! config = Configuration.load(parsedState.configFile)
        return 0
    }
    match outcome with
    | Ok _ -> 0
    | Error err ->
         do Console.WriteLine(err)
         1