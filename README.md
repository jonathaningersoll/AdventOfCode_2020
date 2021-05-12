# AdventOfCode_2020
# Day01: Nothing special
# Day02: Nothing special again. I initially had the days in different solutions, but decided to just make different project for each day starting in the Day03 folder
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

In the above example, 2 passwords are valid.The middle password, cdefg, is not; it contains no instances of b, but needs at least 1. The first and third passwords are valid: they contain one a or nine c, both within the limits of their respective policies.

How many passwords are valid according to their policies?

### Solution pt. 1:
1. Read all the lines of an input file into a string array. Set a variable to keep track of valid passwords.
2. For each line in the file, split the line at each space sending each newly-split string into its own position in an array.

> At phrase[0] is the requirements (1-3).
>
> At phrase[1] is the required character (a).
>
> At phrase[2] is the actual password (abcde).

3. Split the phrase into three sections: Requirements(reqs), Required Character(reqChar), and the Password (pass)

4. Validate each line based on the parameters provided. Validation process: 

To be continued...
