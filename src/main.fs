module VSCodeFable

open Fable.Core
open Fable.Import
open Fable.Import.vscode

let activate (context : vscode.ExtensionContext) =
    vscode.commands.registerCommand("polyglott.sayHello", fun _ ->
        vscode.window.showInformationMessage "Hello world7!" |> unbox )
    |> context.subscriptions.Add
