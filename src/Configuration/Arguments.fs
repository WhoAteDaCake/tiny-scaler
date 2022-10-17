module TinyScaler.Configuration.Arguments
open Argu

open TinyScaler.Configuration.State

type CliArgs =
    | [<Mandatory>] Config_File of string
    | [<Mandatory>] Conn_String of string
    | [<Mandatory>] Compose_File of string
    | Confirm
    | Detach
    interface IArgParserTemplate with
        member s.Usage =
            match s with
            | Config_File _ -> "configuration file for ration and scalability"
            | Conn_String _ -> "connection string for chosen database"
            | Compose_File _ -> "path to docker-compose.yml file"
            | Confirm -> "confirm pods to be scaled before it's enabled"
            | Detach -> "detach daemon from console."
    
let parser =  ArgumentParser.Create<CliArgs>(programName="tiny-scaler")

let parse_exn argv =
    let result = parser.ParseCommandLine(
        inputs = argv,
        raiseOnUsage = false
    )
    {
        composeFile = result.GetResult Compose_File;
        connString = result.GetResult Conn_String;
        configFile = result.GetResult Config_File;
        confirm = result.Contains Confirm;
        Detach = result.Contains Detach;
    }
    
let parse argv =
    try
        parse_exn(argv)
        |> Result.Ok
    with e ->
        Result.Error e.Message