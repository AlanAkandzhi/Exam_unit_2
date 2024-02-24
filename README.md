# Exam Unit 2 Overview 🎓

## 📝 Tasks and Solutions

### Task 1: Temperature Conversion 🌡️

#### Objective 🎯
To write a program that converts temperature from Fahrenheit to Celsius, with the result shown to two decimal places.

#### Solution 💡
The code utilizes a simple conversion formula. Precision is achieved with `Math.Round`, rounding the answer to the required two decimal places.

```csharp``` 💻🔷
double tempCelsiusAsDouble = ((tempFahrenheitAsInt - 32) * 5 / 9.0);

double answer = Math.Round(tempCelsiusAsDouble, 2);

### Task 2: Unique and Ordered Word List 📋🔍

#### Objective 🎯
Extract unique words from a string and list them in alphabetical order, ensuring no duplicates.

#### Solution 💡
The process involves obtaining the string of words, splitting them by commas, trimming spaces, removing duplicates, and sorting alphabetically before joining them back into a single string.

```csharp``` 💻🔷
string[] splitWords = wordList.Split(',').Select(word => word.Trim()).ToArray();

string[] uniqueAndSortedWords = splitWords.Distinct().OrderBy(word => word).ToArray();

string result = String.Join(",", uniqueAndSortedWords);

### Task 3: Prime Number Finder 🔢🔍

#### Objective 🎯
Develop code that identifies prime numbers within a list.

#### Solution 💡
The code parses the list of numbers, filters by prime numbers using a dedicated method, and generates a list of the prime numbers found.

```csharp``` 💻🔷
int[] numbers = numberSequence.Split(',').Select(int.Parse).ToArray();

var primes = numbers.Where(IsPrime); // Assuming IsPrime is a defined method

### Task 4: Odd or Even Number Identification ➗🔢✖️

#### Objective 🎯
Create a program that determines if a given number is odd or even.

#### Solution 💡
The solution employs a simple check using the modulo operator to determine the number's parity.

```csharp``` 💻🔷
string result = (number % 2 == 0) ? "even" : "odd";

