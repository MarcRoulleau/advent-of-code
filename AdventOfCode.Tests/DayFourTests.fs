module AdventOfCode.Tests.DayFourTests

open AdventOfCode.DayFour
open Xunit

[<Fact>]
let ``Get input`` () =
    let result = getInput
    Assert.NotNull(result)


[<Fact>]
let ``Get correct count of winning numbers`` () =
    let result =
        getWinningNumbers "Card   1: 99 65 21  4 72 20 77 98 27 70 |  4 92 66 25 16 88 14 21 80 36 41 "

    Assert.Equal(10, Seq.length result)


[<Fact>]
let ``Get correct count of playing numbers`` () =
    let result =
        getPlayingNumbers "Card   1: 99 65 21  4 72 |  4 92 66 25 16 88 14 21 80 36 41 28 56 49 31 15 38 87 40 "

    Assert.Equal(19, Seq.length result)

[<Fact>]
let ``Playing numbers contain one winning number`` () =
    let winningNumbers = Set.ofList [ 77; 81; 46 ]
    let playingNumbers = Set.ofList [ 19; 46; 8 ]

    let result = getMatchCount winningNumbers playingNumbers

    Assert.Equal(1, Set.count result)

[<Fact>]
let ``Playing numbers contain two winning numbers`` () =
    let winningNumbers = Set.ofList [ 13; 32; 20; 16; 61 ]
    let playingNumbers = Set.ofList [ 61; 30; 68; 82; 17; 32; 24; 19 ]

    let result = getMatchCount winningNumbers playingNumbers

    Assert.Equal(2, Set.count result)

[<Fact>]
let ``Playing numbers contain four winning numbers`` () =
    let winningNumbers = Set.ofList [ 41; 48; 83; 86; 17 ]
    let playingNumbers = Set.ofList [ 83; 86; 6; 31; 17; 9; 48; 53 ]

    let result = getMatchCount winningNumbers playingNumbers

    Assert.Equal(4, Set.count result)


[<Fact>]
let ``Two winning numbers returns 2 points`` () =
    let result = countAll 2
    Assert.Equal(2, result)


[<Fact>]
let ``Four winning numbers returns 8 points`` () =
    let result = countAll 4 
    Assert.Equal(8, result)
    
[<Fact>]
let ``Five winning numbers returns 16 points`` () =
    let result = countAll 5
    Assert.Equal(16, result)