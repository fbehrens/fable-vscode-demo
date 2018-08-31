namespace Polyglott
open Fable.Core
open Fable.Import
open vscode.Vscode
module Main=
    let activate (context : ExtensionContext) =
        //Play.activate context
        let ra = new  ResizeArray<string>()
        let sayHello () = window.showInformationMessage("Hello 1", ra ) |> ignore

        let disposable = commands.registerCommand("polyglott.hello", sayHello |> unbox )
        context.subscriptions.Add(disposable)
        
  
        // Vscode.Context.subscriptions.Add(disposable)

