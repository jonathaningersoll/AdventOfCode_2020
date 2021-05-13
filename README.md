# AdventOfCode_2020
# Day01: Moved to Day03/Day01
# Day02: Moved to Day03/Day01
# Day03 contains the main projects
## Day 01

### Overview:
pt.1 - Given a list of numbers, find two which sum to the number 2020. The product of those two numbers is the answer to part one of the puzzle.

pt.2 - Given a list of numbers, find three which sum to the numnber 2020. The product of these three numbers is the answer to part two of the puzzle.

### Solution pt1:
1. Take the provided text file and enqueue each line, parsing the string of text into an int.
2. Evaluate if there is anything in the queue, then dequeue the first number. Add that number to each line and evaluate whether the sum is equal to 2020. If the sum equals 2020, multiply those two numbers and save the result. print the result to Day 03\bin\Debug\netcoreapp3.1\output.txt

### Solution pt2:
1. Take the provided text file and add each line to a list parsing each string of text into an int.
2. For each list item, take the number and add it to each number in the same list evaluating if the sum is less than 2020. If it is less than 2020, add it to another list.
3. For each list item that is less than 2020, add it to every number in the original list again evaluating if the sum is equal to 2020.
4. If the new sum is equal to 2020, save the result in \Day 03\bin\Debug\netcoreapp3.1\ThreeOutput.txt

## Day 02

### Overview:
pt.1 - suppose you have the following list:
> 1-3 a: abcde
>
> 1-3 b: cdefg
>
> 2-9 c: ccccccccc

Each line gives the password policy and then the password.The password policy indicates the lowest and highest number of times a given letter must appear for the password to be valid. For example, 1-3 a means that the password must contain a at least 1 time and at most 3 times.

In the above example, 2 passwords are valid. The middle password, cdefg, is not; it contains no instances of b, but needs at least 1. The first and third passwords are valid: they contain one a or nine c, both within the limits of their respective policies.

How many passwords are valid according to their policies?

pt.2 - Switcharoo: Each policy actually describes two positions in the password, where 1 means the first character, 2 means the second character, and so on. (Be careful; Toboggan Corporate Policies have no concept of "index zero"!) Exactly one of these positions must contain the given letter.Other occurrences of the letter are irrelevant for the purposes of policy enforcement.
Given the same example list from above:
> 1-3 a: abcde is valid: position 1 contains a and position 3 does not.
> 
> 1-3 b: cdefg is invalid: neither position 1 nor position 3 contains b.
> 
> 2-9 c: ccccccccc is invalid: both position 2 and position 9 contain c.
How many passwords are valid according to the new interpretation of the policies?

### Solution pt. 1:
1. Read all the lines of an input file into a string array. Set a variable to keep track of valid passwords.
2. 
3. For each line in the file, split the line at each space sending each newly-split string into its own position in an array.

> At phrase[0] is the requirements (1-3).
>
> At phrase[1] is the required character (a).
>
> At phrase[2] is the actual password (abcde).

3. Split the phrase into three sections: Requirements(reqs), Required Character(reqChar), and the Password (pass)

4. Validate each line based on the parameters provided. Validation process: 

 - Use GetParams() to turn the parameters of the password into two ints
 - Obtain the character required for the password to be valid as a char
 - Save the password to evaluate as a string
 - Using Validate() which checks if the password has the char at all, if this returns true, use WithinParams() to check if the password lies within the appropriate size and also (using numMatchingChars) if the password has the correct amount of the required character.

5. Once validated, increment the int counting the amount of valid passwords

### Solution pt. 2:
Not sure where the code went for this portion of the puzzle, but I got a correct answer.

## Day03 <== this one was really fun to do.
### Overview:
pt.1 - Given a file full of #s and .s, and given a slope, how many times would you cross a #?
Example file:
> ..##.......
> 
> #...#...#..
> 
> .#....#..#.
>
> ..#.#...#.#

pt.2 - Now determine the number of #s you would encounter if, for each of the following slopes, you start at the top-left corner and traverse the map all the way to the bottom:
> Right 1, down 1.
> 
> Right 3, down 1. (This is the slope you already checked.)
> 
> Right 5, down 1.
> 
> Right 7, down 1.
> 
> Right 1, down 2.

### pt.1 Solution:
1. Read the file into a list setting the amount of trees hit to 0, and the iterator to 1 since we already know what 1 is (our origin).
2. While iterator is less than the amount of rows in the document, 
  - Set the x position to i-1 to account for 0-indexing and use GetColumn to multiply row\*distance for the column.
  - Then multiply that by distance along x(3) (x=y3).
  - Get the current line as a string,
  - If the position on the line is less than the length of the line, evaulate the character at line\[char position\], if EvaluateChar() is true, increment the # count by 1
  - If the position on the line is greater than the length of the line, take the modulus of pos/line.length and use the remainder since the pattern simply repeats. Then add 1 to the tree count.
3. Increment the row iterator by one moving to the next row.
4. Report the amount of #s crossed.

### pt.2 Solution:
1. Query how far to the right and how many lines down the user will be traveling (essentially the slope)
2. Use the slope as the argument for TreeCalculator() which calculates the amount of #s hit for the given slope. This code is more modular and will work with pt.1 as well.

