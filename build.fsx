#r "paket: groupref build //"
#load "./.fake/build.fsx/intellisense.fsx"

open Fake.Core
open Fake.IO
open Fake.JavaScript
open Fake.DotNet

Target.create "Clean" <| fun _ ->
  Shell.cleanDir "./temp"
//   Shell.copy "release" ["README.md"; "LICENSE.md"]
//   Shell.copyFile "release/CHANGELOG.md" "RELEASE_NOTES.md"

Target.description "Install javaScript dependencies"
Target.create "YarnInstall" <| fun _ ->
    Yarn.install id

Target.create "DotnetRestore" <| fun _ ->
    DotNet.restore (DotNet.Options.withWorkingDirectory("src")) ""

let runFable additionalArgs =
    let cmd = "fable webpack -- --config ./webpack.config.js " 
    let r = DotNet.exec (DotNet.Options.withWorkingDirectory("src")) cmd additionalArgs
    printfn "result=%A" r

Target.create "RunScript" <| fun _ ->
    // Ideally we would want a production (minized) build but UglifyJS fail on PerMessageDeflate.js as it contains non-ES6 javascript.
    runFable ""

Target.create "Watch" <| fun _ ->
    runFable "--watch"

Target.create "Default" ignore

open Fake.Core.TargetOperators
"YarnInstall" ?=> "RunScript"
"DotNetRestore" ?=> "RunScript"

"Clean"
==> "RunScript"
==> "Default"

Target.runOrDefault "Default"
