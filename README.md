# Exam_unit_2

//Task 1

In this task, we needed to write a program that changes temperature from Fahrenheit to Celsius and shows the result with two numbers after the decimal point. The code I wrote uses a simple formula to do the conversion. Then, to make sure the temperature in Celsius has exactly two decimal places, I added "double answer = Math.Round(tempCelsiusAsInt, 2);" to the code. This line rounds the answer to the required precision.

//Task 2

In this task, the goal was to pick out different words from a string and list them in order, without any repeats. To do this, I first got the string of words using "string wordList = task2?.parameters;". Then, I broke it into pieces at each comma and cleaned up any spaces from the ends. This step makes sure that when we look at the words, we're not confused by extra spaces. Next, I used a special command to get rid of any repeating words and another to put them in A to Z order. Finally, I put the words back together in a neat line, ready to be shown or used somewhere else.

//Task 3

The task was to create code that finds prime numbers in a list. First, the code safely grabbed the list and didn't break if it was empty. It then took the list, which was a text of numbers separated by commas, and broke it into individual numbers. To pick out the prime numbers, the code used a simple filter that kept only the primes and made a new list out of them. This approach was direct and avoided unnecessary complexity.

//Task 4

 
