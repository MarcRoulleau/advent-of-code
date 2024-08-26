module AdventOfCode.DayOne

open System



let parseDigits input =
    input |> Seq.where (fun x -> Char.IsDigit x)

let getFirstAndLastDigit input =
    let numbers = parseDigits input |> Seq.toList

    let pair =
        match numbers with
        | [] -> []
        | [ x ] -> [ x; x ]
        | x :: tail -> [ x; List.last tail ]

    pair |> List.toSeq

let concatenate first last = String [| first; last |]

let getInput = System.IO.File.ReadLines("Day01\input.txt")


let execute =
    let result =
        getInput
             |> Seq.map (fun x -> getFirstAndLastDigit x |> String.Concat |> int)
             |> Seq.sum
             
    printfn $"the result is %i{result}"
