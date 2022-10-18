module ``Provider tests``

open TinyScaler.Providers
open Xunit
open FsUnit.Xunit

module ``Docker`` =
    module ``componentOfRow`` =
        [<Fact>]
        let ``should parse raw output`` () =
            let input = """[{"ID":"c1765c3ce514c6e3a34eca33dd3575f679b552bdedb3a034180fc7c199bb2951","Name":"examples-hello_world-1","Command":"/bin/sleep 20000","Project":"examples","Service":"hello_world","State":"running","Health":"","ExitCode":0,"Publishers":null},{"ID":"99ef2dbd1f9e7832fa9c5d3c78e73a438d3e9eac4e7fac439c0192ed2cd06139","Name":"examples-hello_world-2","Command":"/bin/sleep 20000","Project":"examples","Service":"hello_world","State":"running","Health":"","ExitCode":0,"Publishers":null},{"ID":"15178a450b5a3b6b47a7c9fe5eb03c1be74581daedb367991df9a8f872a1f52e","Name":"examples-hello_world2-1","Command":"/bin/sleep 20000","Project":"examples","Service":"hello_world2","State":"running","Health":"","ExitCode":0,"Publishers":[{"URL":"0.0.0.0","TargetPort":3002,"PublishedPort":3002,"Protocol":"tcp"},{"URL":"::","TargetPort":3002,"PublishedPort":3002,"Protocol":"tcp"}]}]"""
            Docker.parseContainers input |> should haveLength 3 