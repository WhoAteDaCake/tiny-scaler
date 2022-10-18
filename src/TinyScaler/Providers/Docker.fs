module TinyScaler.Providers.Docker

open System
open System.Text.Json
open TinyScaler.Utilities
open FSharp.Json
open FsToolkit.ErrorHandling

type Container = {
    Service: string
    State: string 
}

let parseContainers (raw: string) = Json.deserialize<Container[]> raw 

let composePs directory () = asyncResult {
    let! raw = Execute.command directory "docker-compose" ["ps"; "a"; "--format"; "json"]
    return parseContainers raw
}

// let containersToComponents (ls: Container[]) =
    
    

let state (executor: unit -> Async<Execute.CommandResult>) =
    let raw = asyncResult {
        let! raw = executor ()
        return raw
    }
    raw
