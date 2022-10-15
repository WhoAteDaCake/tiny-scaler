module TinyScaler.Providers.Docker

open TinyScaler.Utilities
open Legivel.Customization
open TinyScaler.Providers

//          Name                 Command        State   Ports
// ----------------------------------------------------------
// examples_hello_world2_1   /bin/sleep 20000   Up           
// examples_hello_world_1    /bin/sleep 20000   Up 

[<AbstractClass>]
type DockerStateProvider(directory: string) =
    abstract member Read: unit -> Async<Execute.CommandResult> 

type DockerCommand(directory: string) =
       inherit DockerStateProvider(directory)
       override this.Read () =
              Execute.command directory "docker-compose" ["ps"]

    

// type DockerProvider =
//     
//     interface Provider.State with
//         