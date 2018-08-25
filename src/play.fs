namespace Polyglott
module Play  =
  open System
  open Fable.Core
  open Fable.Import
  open Ionide.VSCode.Helpers
  
  let choose () =
    promise {
      let! a= vscode.window.showInformationMessage("Choose", "a" ,"b")
      printfn "chosen %A" a
    } |> ignore

  let hello () =
    vscode.window.showInformationMessage "Hello" |> ignore

  // let quickPick () = 
  //   promise {
  //     let ra = ["essen";"trinken"] |>ResizeArray 
  //     let! r = window.showQuickPick( ra |> Case1)
  //     printfn "selected %s" r } 

  let activate (context : vscode.ExtensionContext) = 
    [ 
      "polyglott.choose", choose
      "polyglott.hello", hello
    ]
    |> List.iter (fun (name, f) -> 
          vscode.commands.registerCommand(name, f |> unbox<Func<obj,obj>> )
          |> context.subscriptions.Add
       )

