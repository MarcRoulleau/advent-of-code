module AdventOfCode.Tests.DayThreeTests

open Xunit
open AdventOfCode.DayThree

[<Fact>]
let ``Get input`` () =
    let result = getInput
    Assert.NotNull(result)


[<Fact>]
let ``Get Symbol coordinates`` () =
    let result =
        getSymbols "...41............&...................+...136.....546.......$.920................." [] 0 0

    Assert.Equal(3, Seq.length result)
    Assert.Contains({ X = 0; Y = 17 }, result)
    Assert.Contains({ X = 0; Y = 37 }, result)
    Assert.Contains({ X = 0; Y = 59 }, result)

[<Fact>]
let ``Get matches`` () =
    let results =
        getNumbers "...41............&...................+...136.....546.......$.920................." 1

    Assert.Equal(4, Seq.length results)
    Assert.Contains({ X = 1; Y = 3; Value = 41; Length = 2 }, results)

    Assert.Contains(
        { X = 1
          Y = 41
          Value = 136
          Length = 3 },
        results
    )

    Assert.Contains(
        { X = 1
          Y = 49
          Value = 546
          Length = 3 },
        results
    )

    Assert.Contains(
        { X = 1
          Y = 61
          Value = 920
          Length = 3 },
        results
    )


[<Fact>]
let ``Is on the same line`` () =
    let result =
        isInLineProximity
            { X = 1
              Y = 61
              Value = 920
              Length = 3 }
            { X = 1; Y = 55 }

    Assert.True(result)


[<Fact>]
let ``Is one line above`` () =
    let result =
        isInLineProximity
            { X = 1
              Y = 61
              Value = 920
              Length = 3 }
            { X = 2; Y = 55 }

    Assert.True(result)

[<Fact>]
let ``Is one line below`` () =
    let result =
        isInLineProximity
            { X = 13
              Y = 61
              Value = 920
              Length = 3 }
            { X = 14; Y = 55 }

    Assert.True(result)


[<Fact>]
let ``Is out of reach below`` () =
    let result =
        isInLineProximity
            { X = 12
              Y = 61
              Value = 920
              Length = 3 }
            { X = 14; Y = 55 }

    Assert.False(result)
    
[<Fact>]
let ``Is out of reach above`` () =
    let result =
        isInLineProximity
            { X = 16
              Y = 61
              Value = 920
              Length = 3 }
            { X = 14; Y = 55 }

    Assert.False(result)

[<Fact>]
let ``Is on the same column`` () =
    let result =
        isInColumnProximity
            { X = 12
              Y = 61
              Value = 920
              Length = 3 }
            { X = 1; Y = 61 }

    Assert.True(result)


[<Fact>]
let ``Is one column on the right after the number`` () =
    let result =
        isInColumnProximity
            { X = 12
              Y = 61
              Value = 920
              Length = 3 }
            { X = 1; Y = 64 }

    Assert.True(result)

[<Fact>]
let ``Is one column on the left before the number`` () =
    let result =
        isInColumnProximity
            { X = 12
              Y = 61
              Value = 920
              Length = 3 }
            { X = 1; Y = 60 }

    Assert.True(result)


[<Fact>]
let ``Is out of reach from the right`` () =
    let result =
        isInColumnProximity
            { X = 12
              Y = 61
              Value = 920
              Length = 3 }
            { X = 1; Y = 65 }

    Assert.False(result)


[<Fact>]
let ``Is out of reach from the left`` () =
    let result =
        isInColumnProximity
            { X = 12
              Y = 61
              Value = 920
              Length = 3 }
            { X = 1; Y = 59 }

    Assert.False(result)


[<Fact>]
let ``Does not exist if symbols is empty`` () =
    let result =
        exists
            { X = 1
              Y = 61
              Value = 920
              Length = 3 }
            []

    Assert.False(result)


[<Fact>]
let ``Exists at the right`` () =
    let result =
        exists
            { X = 1
              Y = 61
              Value = 920
              Length = 3 }
            [ { X = 1; Y = 64 } ]

    Assert.True(result)


[<Fact>]
let ``Exists at the top right`` () =
    let result =
        exists
            { X = 8
              Y = 61
              Value = 920
              Length = 3 }
            [ { X = 7; Y = 64 } ]

    Assert.True(result)
    
[<Fact>]
let ``Exists at the bottom left`` () =
    let result =
        exists
            { X = 8
              Y = 61
              Value = 920
              Length = 3 }
            [ { X = 9; Y = 60 } ]

    Assert.True(result)