namespace Polyglott
open Fable.Core
open Fable.Import
open vscode.Vscode
open Ionide.VSCode.Helpers
module Main=
    let activate (context : ExtensionContext) =
        Play.activate context
        
        // let disposable = commands.registerCommand("polyglott.hello", sayHello |> unbox )
        // context.subscriptions.Add(disposable)
        
