using HTTPUtils;
using System.Text.Json;
using AnsiTools;
using Colors = AnsiTools.ANSICodes.Colors;

Console.Clear();
Console.WriteLine("Starting Assignment 2");

// SETUP 
const string myPersonalID = "83593b863072c7c1ccb7e7f712d285758643b2c401501531c1777013eba6d04d"; // GET YOUR PERSONAL ID FROM THE ASSIGNMENT PAGE https://mm-203-module-2-server.onrender.com/
const string baseURL = "https://mm-203-module-2-server.onrender.com/";
const string startEndpoint = "start/"; // baseURl + startEndpoint + myPersonalID
const string taskEndpoint = "task/";   // baseURl + taskEndpoint + myPersonalID + "/" + taskID

// Creating a variable for the HttpUtils so that we dont have to type HttpUtils.instance every time we want to use it
HttpUtils httpUtils = HttpUtils.instance;

//#### REGISTRATION
// We start by registering and getting the first task
Response startRespons = await httpUtils.Get(baseURL + startEndpoint + myPersonalID);
Console.WriteLine($"Start:\n{Colors.Magenta}{startRespons}{ANSICodes.Reset}\n\n"); // Print the response from the server to the console
string taskID = "aAaa23"; // We get the taskID from the previous response and use it to get the task (look at the console output to find the taskID)

//#### FIRST TASK 

Response task1Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + taskID);
Task task1 = JsonSerializer.Deserialize<Task>(task1Response.content);
Console.WriteLine($"TASK: {ANSICodes.Effects.Bold}{task1?.title}{ANSICodes.Reset}\n{task1?.description}\nParameters: {Colors.Yellow}{task1?.parameters}{ANSICodes.Reset}");

string tempInFahrenheitAsString = task1?.parameters;
Console.WriteLine("This is just checking " + tempInFahrenheitAsString);

int tempFahrenheitAsInt = int.Parse(tempInFahrenheitAsString);
Console.WriteLine("This is just checking the int " + tempFahrenheitAsInt);

double tempCelsiusAsInt = (((tempFahrenheitAsInt) - 32) * 5) / 9.0;
double answer = Math.Round(tempCelsiusAsInt, 2);
Console.WriteLine("This is just checking the int as celsius " + answer);

Response task1AnswerResponse = await httpUtils.Post(baseURL + taskEndpoint + myPersonalID + "/" + taskID, answer.ToString());
Console.WriteLine($"Answer: {Colors.Green}{task1AnswerResponse}{ANSICodes.Reset}");

taskID = "otYK2";

//#### SECOND TASK

Response task2Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + taskID); 
Task task2 = JsonSerializer.Deserialize<Task>(task2Response.content);
Console.WriteLine($"TASK: {ANSICodes.Effects.Bold}{task2?.title}{ANSICodes.Reset}\n{task2?.description}\nParameters: {Colors.Yellow}{task2?.parameters}{ANSICodes.Reset}");

string wordList = task2?.parameters;

string[] splitWords = wordList.Split(',').Select(word => word.Trim()).ToArray();
string[] uniqueAndSortedWords = splitWords.Distinct().OrderBy(word => word).ToArray();

string answerTask2 = String.Join(",", uniqueAndSortedWords);
Console.WriteLine("Sorted unique words: " + answerTask2);

Response task2AnswerResponse = await httpUtils.Post(baseURL + taskEndpoint + myPersonalID + "/" + taskID, answerTask2.ToString());
Console.WriteLine($"Answer: {Colors.Green}{task2AnswerResponse}{ANSICodes.Reset}");

taskID = "kuTw53L";










class Task
{
    public string? title { get; set; }
    public string? description { get; set; }
    public string? taskID { get; set; }
    public string? usierID { get; set; }
    public string? parameters { get; set; }
}
