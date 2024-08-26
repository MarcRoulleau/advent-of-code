module AdventOfCode.DayTwo

type CubeDraw = { Number: int; Color: string }
type Game = { Id: int; Sets: CubeDraw list }

let parseGameNumber (game: string) = game.Replace("Game ", "") |> int

let parseSets (input: string) =
    input.Split [| ','; ';' |]
    |> Seq.map (fun x -> x.Trim())
    |> Seq.map (fun x -> x.Split [| ' ' |])
    |> Seq.map (fun x -> { Number = int x[0]; Color = x[1] })
    |> Seq.toList

let createGame game sets =
    let gameNumber = parseGameNumber game

    { Id = gameNumber
      Sets = parseSets sets }

let createEmptyGame =
    { Id = -1000000
      Sets = [ { Number = 0; Color = "None" } ] }


let parseGame (input: string) =
    let results = input.Split [| ':' |] |> Seq.map (fun x -> x.Trim()) |> Seq.toList

    match results with
    | [] -> createEmptyGame //create an Option instead
    | game :: draw -> createGame game draw[0]

let redsAreInbound game =
    not <| List.exists (fun x -> x.Color = "red" && x.Number > 12) game.Sets

let greensAreInbound game =
    not <| List.exists (fun x -> x.Color = "green" && x.Number > 13) game.Sets

let bluesAreInbound game =
    not <| List.exists (fun x -> x.Color = "blue" && x.Number > 14) game.Sets

let getInput = System.IO.File.ReadLines("Day02\input.txt")


let onlySetInBounds games =
    games
    |> Seq.where (fun x -> redsAreInbound x && greensAreInbound x && bluesAreInbound x)

let execute =
    let result =
        getInput
        |> Seq.map (fun x -> parseGame x)
        |> onlySetInBounds
        |> Seq.map (fun x -> x.Id)
        |> Seq.sum

    printfn $"the result is %i{result}"
