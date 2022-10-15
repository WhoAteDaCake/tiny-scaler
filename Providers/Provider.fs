module TinyScaler.Providers.Provider

type Component = {
    name: string
    count: int
}

type State =
    abstract member Current: unit -> Result<Component[], 'a>

