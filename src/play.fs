namespace Polyglott
module Play  =
  open System
  open Fable.Core
  open Fable.Import.vscode
  open Ionide.VSCode.Helpers
  
  let choose () =
    promise {
      let! a= window.showInformationMessage("Choose", "a" ,"b")
      printfn "chosen %A" a
    } |> ignore

  // let showQuickPick () = 
  //   promise {
  //     let ra = ["essen";"trinken"] |>ResizeArray 
  //     let! r = window.showQuickPick( ra |> Case1)
  //     printfn "selected %s" r } 

  let activate (context : ExtensionContext) = 
    commands.registerCommand("polyglott.choose", choose |> unbox<Func<obj,obj>> )
    |> context.subscriptions.Add 

