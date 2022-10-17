module TinyScaler.Providers.Docker

open System
open TinyScaler.Utilities
open Legivel.Customization
open TinyScaler.Providers
open FsToolkit.ErrorHandling

//          Name                 Command        State   Ports
// ----------------------------------------------------------
// examples_hello_world2_1   /bin/sleep 20000   Up           
// examples_hello_world_1    /bin/sleep 20000   Up 

let composePs directory () =
    Execute.command directory "docker-compose" ["ps"]

let componentOfRow (row: string) =
    let name = row.Substring(row.IndexOf("-"), row.LastIndexOf("-"))
    let count = Int32.Parse(row.Substring(row.LastIndexOf("-")))
    (name, count)

let state (executor: unit -> Async<Execute.CommandResult>) =
    let raw = asyncResult {
        let! raw = executor ()
        return raw
    }
    state
