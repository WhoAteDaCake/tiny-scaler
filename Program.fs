open System.IO
open TinyScaler.Parsing

[<EntryPoint>]
let main args =
    let debugLocation = "/bin/Debug/net6.0"
    let baseDir = Directory.GetCurrentDirectory ()
    let myDir =
        if baseDir.Contains debugLocation then
            baseDir.Replace(debugLocation, "")
        else
            baseDir
    let config = Configuration.load(Path.Join(myDir, "examples/configuration.yml"))
    // Return 0. This indicates success.
    0