#r "paket: groupref build5 //"
open Fake.DotNet
#load "./.fake/build5.fsx/intellisense.fsx"

open Fake.Core
open Fake.IO
open Fake.JavaScript
open Fake.DotNet

Target.create "Clean" (fun _ ->
  Shell.cleanDir "./temp"
)

Target.description "Install javaScript dependencies"
Target.create "YarnInstall" <| fun _ ->
    Yarn.install id

Target.create "DotnetRestore" <| fun _ ->
    DotNet.restore (DotNet.Options.withWorkingDirectory("src")) ""

// let runFable additionalArgs =
//     let cmd = "fable webpack -- --config ./webpack.config.js " + additionalArgs
//     DotNetCli.RunCommand (fun p -> { p with WorkingDir = "src" } ) cmd


Target.create "Default" ignore

Target.runOrDefault "Default"
