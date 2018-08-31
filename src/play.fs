namespace Polyglott
module Play  =
  open System
  open Fable.Core
  open Fable.Core.JsInterop
  open Fable.Import
  open vscode
  open Ionide.VSCode.Helpers
  
  let choose () =
  
    promise {
      let items = new  ResizeArray<string>()
      items.Add "a"
      items.Add "b"
      let! a= Vscode.window.showInformationMessage("Choose",items) |> Promise.fromThenable
      printfn "chosen %A" a
    } |> ignore

  let hello () =
    let items = new  ResizeArray<string>()
    Vscode.window.showInformationMessage("Hello1",items)
    |> ignore

  let quickPick () = 
    promise {
      let ra = ["essen";"trinken"] |>ResizeArray 
      let opts = createEmpty<Vscode.QuickPickOptions>
      let! r = Vscode.window.showQuickPick( ra |> U2.Case1, opts) |> Promise.fromThenable
      printfn "selected  %A" r 
    } |> ignore

  let activate (context : Vscode.ExtensionContext) = 
    [ 
      "polyglott.choose", choose
      "polyglott.hello", hello
      "polyglott.quickPick", quickPick
    ]
    |> List.iter (fun (name, f) -> 
          printfn "regsterCommand %s" name
          Vscode.commands.registerCommand(name, f |> unbox<Func<obj,obj>> )
          |> context.subscriptions.Add
       )

