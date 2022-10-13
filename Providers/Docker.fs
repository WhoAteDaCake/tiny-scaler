module TinyScaler.Providers.Docker

open TinyScaler.Providers

//          Name                 Command        State   Ports
// ----------------------------------------------------------
// examples_hello_world2_1   /bin/sleep 20000   Up           
// examples_hello_world_1    /bin/sleep 20000   Up 

type DockerReader =
    private {
        mutable directory: string
    }
    

// type DockerProvider =
//     
//     interface Provider.State with
//         