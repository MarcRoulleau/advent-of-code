module AdventOfCode.Tests.DayOneTests

open AdventOfCode.DayOne
open Xunit

[<Fact>]
let ``Get one digits at the end`` () =
    let result = parseDigits "hello world 1"
    Assert.Equal([ '1' ], result)

[<Fact>]
let ``Get one digits at the beginning`` () =
    let result = parseDigits "1 hello world"
    Assert.Equal([ '1' ], result)

[<Fact>]
let ``Get two digits at the beginning and end`` () =
    let result = parseDigits "1abc2"
    Assert.Equal([ '1'; '2' ], result)

[<Fact>]
let ``Get three digits at the beginning, middle and end`` () =
    let result = parseDigits "1 hello w2orld 3"
    Assert.Equal([ '1'; '2'; '3' ], result)

[<Fact>]
let ``Get zero digit from input`` () =
    let result = parseDigits "abc"
    Assert.Equal([], result)



[<Fact>]
let ``Get first and last with two digits at beginning and end`` () =
    let result = getFirstAndLastDigit "1 hello world 2"
    Assert.Equal([ '1'; '2' ], result)

[<Fact>]
let ``Get first and last with two digits in the middle`` () =
    let result = getFirstAndLastDigit "hello w1o2rld"
    Assert.Equal([ '1'; '2' ], result)

[<Fact>]
let ``Get first and last with two digits in the middle side by side`` () =
    let result = getFirstAndLastDigit "hello wo12rld"
    Assert.Equal([ '1'; '2' ], result)

[<Fact>]
let ``Get first and last with one digits`` () =
    let result = getFirstAndLastDigit "hello wo2rld"
    Assert.Equal([ '2'; '2' ], result)

[<Fact>]
let ``Get three digits with a tricky two digit in the middle`` () =
    let result = getFirstAndLastDigit "hello w25orld 3"
    Assert.Equal([ '2'; '3' ], result)

[<Fact>]
let ``Get no digits from input`` () =
    let result = getFirstAndLastDigit "abc"
    Assert.Equal([], result)


[<Fact>]
let ``Concatenate`` () =
    let result = [ '2'; '3' ] |> System.String.Concat |> int
    Assert.Equal(23, result)


[<Fact>]
let ``no idea`` () =
    let lastline = getInput |> Seq.last
    let calibration = getFirstAndLastDigit lastline |> System.String.Concat |> int
    Assert.Equal(19, calibration)
