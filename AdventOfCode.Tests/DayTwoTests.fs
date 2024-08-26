module AdventOfCode.Tests.DayTwoTests

open AdventOfCode.DayTwo
open Xunit

[<Fact>]
let ``Get input`` () =
    let result = getInput
    Assert.NotNull(result)


[<Fact>]
let ``Get Game number one digit`` () =
    let result = parseGameNumber "Game 5"
    Assert.Equal(5, result)

[<Fact>]
let ``Get Game number two digits`` () =
    let result = parseGameNumber "Game 85"
    Assert.Equal(85, result)

[<Fact>]
let ``Get Game number three digits`` () =
    let result = parseGameNumber "Game 100"
    Assert.Equal(100, result)


let OneLineGame: Game =
    { Id = 61
      Sets =
        [ { Number = 1; Color = "green" }
          { Number = 3; Color = "blue" }
          { Number = 1; Color = "red" }
          { Number = 2; Color = "green" }
          { Number = 1; Color = "green" }
          { Number = 2; Color = "blue" }
          { Number = 2; Color = "red" } ] }


[<Fact>]
let ``parse one line`` () =
    let result =
        parseGame "Game 61: 1 green, 3 blue; 1 red, 2 green; 1 green, 2 blue, 2 red"

    Assert.Equal(OneLineGame, result)


[<Fact>]
let ``Red is inbound`` () =
    let result =
        redsAreInbound
            { Id = 14
              Sets = [ { Number = 8; Color = "red" } ] }

    Assert.Equal(true, result)

[<Fact>]
let ``Red is out of bound`` () =
    let result =
        redsAreInbound
            { Id = 14
              Sets = [ { Number = 17; Color = "red" } ] }

    Assert.Equal(false, result)

[<Fact>]
let ``Red is equal to limit`` () =
    let result =
        redsAreInbound
            { Id = 14
              Sets = [ { Number = 12; Color = "red" } ] }

    Assert.Equal(true, result)


[<Fact>]
let ``Green is inbound`` () =
    let result =
        greensAreInbound
            { Id = 14
              Sets = [ { Number = 8; Color = "green" } ; { Number = 18; Color = "blue" } ] }

    Assert.Equal(true, result)

[<Fact>]
let ``Green is not inbound`` () =
    let result =
        greensAreInbound
            { Id = 14
              Sets = [ { Number = 5; Color = "green" }; { Number = 144; Color = "green" } ] }

    Assert.Equal(false, result)

[<Fact>]
let ``Green is equal to limit`` () =
    let result =
        greensAreInbound
            { Id = 14
              Sets = [ { Number = 13; Color = "green" } ] }

    Assert.Equal(true, result)


[<Fact>]
let ``Blue is inbound`` () =
    let result =
        bluesAreInbound
            { Id = 14
              Sets = [ { Number = 8; Color = "blue" } ] }

    Assert.Equal(true, result)

[<Fact>]
let ``Blue is out of bound`` () =
    let result =
        bluesAreInbound
            { Id = 14
              Sets = [ { Number = 17; Color = "blue" } ] }

    Assert.Equal(false, result)

[<Fact>]
let ``Blue is equal to limit`` () =
    let result =
        bluesAreInbound
            { Id = 14
              Sets = [ { Number = 14; Color = "blue" } ] }

    Assert.Equal(true, result)

let Games: Game seq =
    [ { Id = 34
        Sets =
          [ { Number = 1; Color = "blue" }
            { Number = 1; Color = "red" }
            { Number = 9; Color = "green" }
            { Number = 144; Color = "red" }
            { Number = 1; Color = "blue" }
            { Number = 3; Color = "blue" }
            { Number = 7; Color = "green" } ] }
      { Id = 61
        Sets =
          [ { Number = 1; Color = "green" }
            { Number = 3; Color = "blue" }
            { Number = 1; Color = "red" }
            { Number = 2; Color = "green" }
            { Number = 1; Color = "green" }
            { Number = 2; Color = "blue" }
            { Number = 2; Color = "red" } ] } ]

let ExpectedGames: Game list =
    [ { Id = 61
        Sets =
          [ { Number = 1; Color = "green" }
            { Number = 3; Color = "blue" }
            { Number = 1; Color = "red" }
            { Number = 2; Color = "green" }
            { Number = 1; Color = "green" }
            { Number = 2; Color = "blue" }
            { Number = 2; Color = "red" } ] } ]

[<Fact>]
let ``List of games with one out of bound`` () =
    let result = onlySetInBounds Games 
    Assert.Equal(ExpectedGames, result)
