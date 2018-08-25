module VSCodeFable

open Fable.Core
open Fable.Import
open Fable.Import.vscode

let activate (context : vscode.ExtensionContext) =
    vscode.commands.registerCommand("extension.sayHello", fun _ ->
        vscode.window.showInformationMessage "Hello world4!" |> unbox )
    |> context.subscriptions.Add
