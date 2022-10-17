module TinyScaler.Parsing.Configuration

open System.IO
open FsToolkit.ErrorHandling
open YamlDotNet.Serialization

// [<CLIMutable>] is required here to create constructors/setters and getters
// since the yaml parsing library uses them to set the values.
[<CLIMutable>]
type Shared = {
    poolWindow: int
}

[<CLIMutable>]
type Component = {
    name: string
    query: string
    min: int
    max: int
}

[<CLIMutable>]
type Configuration = {
    shared: Shared
    components: Component[]
}

let deserializer = (
    DeserializerBuilder()
        .Build()
)
let load (file: string) = result {
    let! file =
        if not (File.Exists file) then
            Result.Error $"File :{file} does not exist"
        else
            try
                File.ReadAllText(file)
                |> Result.Ok
            with e ->
                Result.Error $"Failed to read config file: ${e.Message}"
    let! parsed =
        try
            deserializer.Deserialize<Configuration> file
            |> Result.Ok
        with e ->
            Result.Error $"Invalid YAML: ${e.Message}"
    return parsed
}