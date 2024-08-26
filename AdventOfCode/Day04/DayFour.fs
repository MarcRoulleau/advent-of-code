module AdventOfCode.DayFour

open System.Text.RegularExpressions

let getInput = seq { yield! System.IO.File.ReadLines "Day04\input.txt" }

let readWinningNumbers (fromLine:string) =
    fromLine.Split([|':'; '|'|])[1]
    
let readPlayingNumber (fromLine:string) =
    fromLine.Split[|'|'|] |> Array.last
    
let getWinningNumbers fromLine =
    Regex.Matches(readWinningNumbers fromLine, "\d+")
    |> Seq.cast<Match>
    |> Seq.where (fun x -> x.Success)
    |> Seq.map (fun x -> int x.Value)
    |> Set.ofSeq

let getPlayingNumbers fromLine =
    Regex.Matches(readPlayingNumber fromLine, "\d+")
    |> Seq.cast<Match>
    |> Seq.where (_.Success)
    |> Seq.map (fun x -> int x.Value)
    |> Set.ofSeq
    
let getMatchCount winningNumbers playingNumbers  =
    Set.intersect winningNumbers playingNumbers
   
let countAll points =  int (2.0 ** (float points - 1.0))

let getPoints fromLine =
    let winningNumbers = getWinningNumbers fromLine
    let playingNumbers = getPlayingNumbers fromLine
    let count =  getMatchCount winningNumbers playingNumbers
    let points = Set.count count
    countAll points

let execute =
    let input = getInput
    let test = input |> Seq.map (fun fromLine -> getPoints fromLine)
    let result = test |> Seq.sum

    printfn $"the result is %i{result}"