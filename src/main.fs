namespace Polyglott
open Fable.Core
open Fable.Import
open Fable.Import.vscode
module Main=
    let activate (context : vscode.ExtensionContext) =
        Play.activate context

