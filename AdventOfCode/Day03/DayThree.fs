module AdventOfCode.DayThree

open System.Text.RegularExpressions
open System

type Symbol = { X: int; Y: int }

type Number =
    { X: int
      Y: int
      Value: int
      Length: int }

let create acc x y = Seq.append acc [ { X = x; Y = y } ]

let (|IsNotSymbol|_|) a =
    if Char.IsDigit a || a = '.' then Some() else None

let getNumbers input lineNumber =
    Regex.Matches(input, "\d+")
    |> Seq.cast<Match>
    |> Seq.where (fun x -> x.Success)
    |> Seq.map (fun x ->
        { X = lineNumber
          Y = x.Index
          Value = int x.Value
          Length = x.Value.Length })

let rec getSymbols (input: char seq) acc x y =
    match Seq.toList input with
    | [] -> acc
    | head :: tail ->
        match head with
        | IsNotSymbol -> getSymbols tail acc x (y + 1)
        | _ ->
            let newAcc = create acc x y
            getSymbols tail newAcc x (y + 1)

let equalsTwo (symbol: Number) = Seq.exists (fun x -> symbol.Value = 0)

let getInput = seq { yield! System.IO.File.ReadLines "Day03\input.txt" }

let isInLineProximity number (symbol: Symbol) =
    number.X = symbol.X || number.X = symbol.X - 1 || number.X = symbol.X + 1

let isInColumnProximity number (symbol: Symbol) =
    number.Y - 1 <= symbol.Y && symbol.Y <= number.Y + number.Length

let exists (number: Number) (list: Symbol seq) =
    Seq.exists (fun (symbol: Symbol) -> isInLineProximity number symbol && isInColumnProximity number symbol) list

let execute =
    let input = getInput
    let numbers = input |> Seq.mapi (fun lineId number -> getNumbers number (lineId + 1)) |>  Seq.concat
    let symbols = input |> Seq.mapi (fun lineId symbol -> getSymbols symbol [] (lineId + 1) 0) |> Seq.concat

    let result =
        numbers
        |> Seq.where (fun number -> exists number symbols)
        |> Seq.map (fun x -> x.Value)
        |> Seq.sum

    printfn $"the result is %i{result}"
