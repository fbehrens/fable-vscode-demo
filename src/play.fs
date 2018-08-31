namespace Polyglott
module Play  =
  open System
  open Fable.Core
  open Fable.Core.JsInterop
  open Fable.Import
  open vscode.Vscode
  open Ionide.VSCode.Helpers
  
  let choose (a:ResizeArray<obj option>) = 
    let r = promise {
      let ra = [|"a";"b"|] |> ResizeArray
      let! r =window.showInformationMessage("Hello 1", ra ) |> Promise.fromThenable
      return r
    } 
    printfn "r=%A" r
    box r
     
  let hello (a:ResizeArray<obj option>) =
    let items = new  ResizeArray<string>()
    window.showInformationMessage("Hello2",items)
    |> box

  let quickPick (a:ResizeArray<obj option>) = 
    promise {
      let ra = ["essen";"trinken"] |> ResizeArray 
      let opts = createEmpty<QuickPickOptions>
      let! r = window.showQuickPick( ra |> U2.Case1, opts) |> Promise.fromThenable
      printfn "selected  %A" r 
    } |> box

  let activate (context : ExtensionContext) = 
    [ 
      "polyglott.choose", choose
      "polyglott.hello", hello
      "polyglott.quickPick", quickPick
    ]
    |> List.iter (fun (name, f) -> 
          printfn "regsterCommand %s" name
          commands.registerCommand(name, f |> unbox )
          |> context.subscriptions.Add
       )

