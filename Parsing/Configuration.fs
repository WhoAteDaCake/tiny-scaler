module TinyScaler.Parsing.Configuration
open FSharp.Configuration

let [<Literal>] ymlPath = "examples/configuration.yml"
type Configuration = YamlConfig<ymlPath>
let load (fname: string) =
    let config = Configuration()
    do config.Load(fname)
    config