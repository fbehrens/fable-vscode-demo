namespace Polyglott
module Play  =
  open System
  open Fable.Core
  open Fable.Core.JsInterop
  open Fable.Import
  open Ionide.VSCode.Helpers
  
  let choose () =
    promise {
      let! a= vscode.window.showInformationMessage("Choose", "a" ,"b")
      printfn "chosen %A" a
    } |> ignore

  let hello () =
    vscode.window.showInformationMessage "Hello1" |> ignore

  let quickPick () = 
    promise {
      let ra = ["essen";"trinken"] |>ResizeArray 
      let opts = createEmpty<vscode.QuickPickOptions>
      let! r = vscode.window.showQuickPick( ra |> U2.Case1, opts)
      printfn "selected  %s" r 
    } |> ignore

  let activate (context : vscode.ExtensionContext) = 
    [ 
      "polyglott.choose", choose
      "polyglott.hello", hello
      "polyglott.quickPick", quickPick
    ]
    |> List.iter (fun (name, f) -> 
          printfn "regsterCommand %s" name
          vscode.commands.registerCommand(name, f |> unbox<Func<obj,obj>> )
          |> context.subscriptions.Add
       )

