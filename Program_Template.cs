using HTTPUtils;
using System.Text.Json;
using AnsiTools;
using Colors = AnsiTools.ANSICodes.Colors;

Console.Clear();
Console.WriteLine("Starting Exam_unit_2");

// SETUP

const string myPersonalID = "83593b863072c7c1ccb7e7f712d285758643b2c401501531c1777013eba6d04d"; 
const string baseURL = "https://mm-203-module-2-server.onrender.com/";
const string startEndpoint = "start/"; 
const string taskEndpoint = "task/";   
const string userID = "Alan";

HttpUtils httpUtils = HttpUtils.instance;

//#### REGISTRATION

Response startRespons = await httpUtils.Get(baseURL + startEndpoint + myPersonalID);
Console.WriteLine($"Start:\n{Colors.Magenta}{startRespons}{ANSICodes.Reset}\n\n"); 
string taskID = "aAaa23"; 

//#### FIRST TASK 

Response task1Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + taskID);
Task task1 = JsonSerializer.Deserialize<Task>(task1Response.content);
task1.userID = userID;
Console.WriteLine($"TASK: {ANSICodes.Effects.Bold}{task1?.title}{ANSICodes.Reset}\n{task1?.description}\nParameters: {Colors.Red}{task1?.parameters}{ANSICodes.Reset}\nUser: {userID}");

string tempInFahrenheitAsString = task1?.parameters;

int tempFahrenheitAsInt = int.Parse(tempInFahrenheitAsString);

int Offsetvalue = 32;
var conversionFactor = 5 / 9.0;

double tempCelsiusAsDouble = ((tempFahrenheitAsInt) - Offsetvalue) * conversionFactor;
string answerTask1 = tempCelsiusAsDouble.ToString("0.00"); 
Console.WriteLine("Temperature in Celsius: " + answerTask1);

var response = await httpUtils.Post($"{baseURL}{taskEndpoint}{myPersonalID}/{taskID}", answerTask1.ToString());
Console.WriteLine($"Answer: {Colors.Green}{response}{ANSICodes.Reset}");

taskID = "otYK2";

//#### SECOND TASK

Response task2Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + taskID); 
Task task2 = JsonSerializer.Deserialize<Task>(task2Response.content);
task2.userID = userID;
Console.WriteLine($"TASK: {ANSICodes.Effects.Bold}{task2?.title}{ANSICodes.Reset}\n{task2?.description}\nParameters: {Colors.Yellow}{task2?.parameters}{ANSICodes.Reset}\nUser: {userID}");

string wordList = task2?.parameters;

string[] splitWords = wordList.Split(',').Select(word => word.Trim()).ToArray();
string[] uniqueAndSortedWords = splitWords.Distinct().OrderBy(word => word).ToArray();

string answerTask2 = String.Join(",", uniqueAndSortedWords);
Console.WriteLine("Sorted unique words: " + answerTask2);

var response2 = await httpUtils.Post($"{baseURL}{taskEndpoint}{myPersonalID}/{taskID}", answerTask2.ToString());
Console.WriteLine($"Answer: {Colors.Green}{response2}{ANSICodes.Reset}");

taskID = "kuTw53L";

//#### THIRD TASK

Response task3Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + taskID); 
Task task3 = JsonSerializer.Deserialize<Task>(task3Response.content);
task3.userID = userID;
Console.WriteLine($"TASK: {ANSICodes.Effects.Bold}{task3?.title}{ANSICodes.Reset}\n{task3?.description}\nParameters: {Colors.Red}{task3?.parameters}{ANSICodes.Reset}\nUser: {userID}");

string numberSequence = task3?.parameters;

int[] numbers = numberSequence.Split(',').Select(int.Parse).ToArray();
Array.Sort(numbers);

string answerTask3 = String.Join(",", numbers.Where(IsPrime));

bool IsPrime(int number)
{
    if (number <= 1) return false;
    if (number == 2) return true;
    if (number % 2 == 0) return false;

    var boundary = (int)Math.Floor(Math.Sqrt(number));
          
    for (int i = 3; i <= boundary; i += 2)
        if (number % i == 0)
            return false;
    
    return true;        
}

Console.WriteLine($"Prime numbers: {answerTask3}");

var response3 = await httpUtils.Post($"{baseURL}{taskEndpoint}{myPersonalID}/{taskID}", answerTask3.ToString());
Console.WriteLine($"Answer: {Colors.Green}{response3}{ANSICodes.Reset}");

taskID = "aLp96";

//#### FOURTH TASK

Response task4Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + taskID); 
Task task4 = JsonSerializer.Deserialize<Task>(task4Response.content);
task4.userID = userID;
Console.WriteLine($"TASK: {ANSICodes.Effects.Bold}{task4?.title}{ANSICodes.Reset}\n{task4?.description}\nParameters: {Colors.Red}{task4?.parameters}{ANSICodes.Reset}\nUser: {userID}");

string enigmaticNumber = task4?.parameters;

int number = int.Parse(enigmaticNumber);

string answerTask4 = (number % 2 == 0) ? "even" : "odd";

Console.WriteLine($"The number {number} is {answerTask4}.");

var response4 = await httpUtils.Post($"{baseURL}{taskEndpoint}{myPersonalID}/{taskID}", answerTask4.ToString());
Console.WriteLine($"Answer: {Colors.Green}{response4}{ANSICodes.Reset}");


class Task
{
    public string? title { get; set; }
    public string? description { get; set; }
    public string? taskID { get; set; }
    public string? userID { get; set; }
    public string? parameters { get; set; }
}
