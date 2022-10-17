module TinyScaler.Configuration.State

type ParsedState = {
    composeFile: string
    configFile: string
    connString: string
    confirm: bool
    Detach: bool
}