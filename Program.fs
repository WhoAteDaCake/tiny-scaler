open System.IO
open TinyScaler.Parsing

[<EntryPoint>]
let main args =
    let debugLocation = "/bin/Debug/net6.0"
    let baseDir = Directory.GetCurrentDirectory ()
    let myDir =
        if baseDir.Contains debugLocation then
            __SOURCE_DIRECTORY__
        else
            baseDir
    let config = Configuration.load(Path.Join(myDir, "examples/configuration.yml"))
    let compose = Compose.load(Path.Join(myDir, "examples/docker-compose.yml"))
    // Return 0. This indicates success.
    0