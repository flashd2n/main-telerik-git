<img src="https://raw.githubusercontent.com/TelerikAcademy/Common/master/logos/telerik-header-logo.png"/>

#### _Telerik Academy Season 2016-2017 / C# Advanced Exam - 07 December 2016_
# Task 3: Sneaky the Snake

## Description
Sneaky the Snake loves to have snacks. He found a den that is full of eggs that he loves to eat so much, but there's a problem. The den is so dark that he has to be prepared in advance and know where to go once he is in. Use you Advanced C# skills to help Sneaky sneak and steal some eggs.

The den is represented by a two dimensional array of symbols. Possible symbols are:
- `-` - represents **free space**.
- `%` - represents a **rock**.
- `@` - represents **food**.
- `e` - represents the entrance of the den (starting point).
The first line will be filled with the symbol **%** (rocks) and **only one** symbol will be **e** (entrance)

_Example input:_
```
5x8
%%%%e%%%
----@---
--@-----
-----@--
--------
s,a,a,s,s,d,d,w,w,w
```

Then Sneaky will give you a rout to test separated with commas `,`. The directions are: **s** - down, **w** - up, **a** - left, **d** - right

There are a few other **IMPORTANT** things you should have in mind:
- Sneaky needs to **enter and exit from the same spot** (entrance) otherwise he will **remain in the den**.
- Sneaky enters the den with length `3` and for every `5` moves he makes he loses `1` of his length, but if he steals an egg `@` he gains `+1` length. If his length drops to `0` or below he will **starve in the den**.
  - _NOTE_: This is always calculated before the result of the move!
  - _NOTE_: An egg can be consumed only once (it is gone after the first time Sneaky moves to it)
- If he goes below the provided depth **R** he will lose sight of the entrance and will be **lost into the depths**.
- If Sneaky moves to the left or right and exceeds the width of the den **C**, he will go to the other side of the den.
  - If he is at the rightmost column and goes right (**d**) he will go to the leftmost column
  - If he is at the leftmost column and goes left (**a**) he will go to the rightmost column

The possible results of a path are:
- `Sneaky is going to get out with length L` - when Sneaky successfully exits the den.
- `Sneaky is going to hit a rock at [R,C]` - when Sneaky hits a rock (**#**) anywhere in the den.
- `Sneaky is going to be lost into the depths with length L` - when Sneaky moves below the provided depth **R**.
- `Sneaky is going to starve at [R,C]` - when Sneaky's length drops to `0` or lower.
- `Sneaky is going to be stuck in the den at [R,C]` - when Sneaky is stuck inside the den when the moves end.
  - _NOTE_: Substitute **R** and **C** with the row and column where Sneaky is.
  - _NOTE_: Substitute **L** with the length of Sneaky.

## Input
- On the **first line** you will receive the dimensions of the den in format **RxC**, where **R** is the depth of the den (number of rows) and **C** is the width (number of columns).
- On the next **R** lines you will receive the representation of the den (see example).
- On the last line you will receive the step directions you have to execute separated by a single comma `,`.

## Output
- Your output should always be a single line with content depending on the result of the path taken.

## Constraints
- **R** and **C** will be between **5** and **30**
- The number of moves will not be more than **120**
- Memory limit: **16 MB**
- Time limit: **0.10 sec**

## Sample tests 1
#### input
```
5x8
%%%%e%%%
----@---
--@-----
-----@--
--------
s,a,a,s,s,d,d,w,w,w
```

#### output
```
Sneaky is going to get out with length 3
```

#### explanation
- Sneaky enters from [0, 4] with length = 3
- **s** moves down to [1,4] and consumes the food, so he gains +1 to length (length = 4)
- **a** moves left to [1,3]
- **a** moves left to [1,2]
- **s** moves down to [2,2] and consumes the food, so he gains +1 to length (length = 5)
- **s** moves down to [3,2] and looses 1 from length because this is the 5th move (length = 4)
- **d** moves right to [1,4]
- **d** moves right to [3,4]
- **w** moves up to [2,4]
- **w** moves up to [1,4]
- **w** moves up to [0,4], looses 1 from length because this is the 10th move and gets out with length 3

## Sample tests 2
#### input
```
5x8
%%%%e%%%
----@---
--@-----
-----@--
--%%%---
s,a,a,s,s,d,d,d,w,w,w
```

#### output
```
Sneaky is going to hit a rock at [0,5]
```

#### explanation
- Similar to the first example, but taking one more step to the right, so Sneaky end up hitting the rocks at position [0,5]

## Sample tests 3
#### input
```
5x8
%%%%e%%%
----@---
--@-----
-----@--
--%%%---
s,a,a,s,s,d,d,w,w
```

#### output
```
Sneaky is going to be stuck in the den at [1,4]
```

#### explanation
- Similar to the first example, but this time Sneaky does one less move up, so he ends up in the den at position [1,4]


## Sample tests 4
#### input
```
5x8
%%%%e%%%
----@---
--@--%%-
-----@--
--%%%---
s,a,a,s,s,d,d,d,w,w,w
```

#### output
```
Sneaky is going to hit a rock at [2,5]
```

#### explanation
- Similar to the second example, but this time Sneaky hits the rock at position [2,5] when he does the first `u` (up) move


## Sample tests 5
#### input
```
5x8
%%%%e%%%
----@---
--@--%%-
-----@--
--%%%---
s,a,a,s,a,a,a,s,a,a,a,w,w,w
```

#### output
```
Sneaky is going to get out with length 4
```

#### explanation
- Sneaky enters from [0, 4] with length = 3
- **s** moves down to [1,4] and consumes the food, so he gains +1 to length (length = 4)
- **a** moves left to [1,3]
- **a** moves left to [1,2]
- **s** moves down to [2,2] and consumes the food, so he gains +1 to length
- **a** moves left to [2,1] and looses 1 from length because this is the 5th move (length = 4)
- **a** moves left to [2,0]
- **a** moves left to [2,7]
- **s** moves down to [3,7]
- **a** moves left to [3,6]
- **a** moves left to [3,5] and consumes the food, so he gains +1 to length (length = 5), but also looses 1 from length because this is the 10th move (length = 4)
- **a** moves left to [3,4]
- **w** moves up to [2,4]
- **w** moves up to [1,4]
- **w** moves up to [0,4] and gets out with length 4
