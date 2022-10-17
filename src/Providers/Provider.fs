module TinyScaler.Providers.Provider

type Component = {
    name: string
    count: int
}

[<AbstractClass>]
type State() =
    abstract member Current: unit -> Async<Result<Component[], 'a>>

