// See https://aka.ms/new-console-template for more information
/// <summary> 
/// Author:    Tate Reynolds/Thatcher Geary
/// Partner:   each other
/// Date:      4/16/2022 
/// Course:    CS 3500, University of Utah, School of Computing 
/// Copyright: CS 3500 and Thatcher Geary - This work may not be copied for use in Academic Coursework. 
/// 
/// We, Thatcher Geary and Tate Reynolds, certify that I wrote this code from scratch and did not copy it in part or whole from  
/// another source.  All references used in the completion of the assignment are cited in my README file. 
/// 
/// File Contents 
/// This was an excercise for the class 
/// </summary>
using AgarioModels;
using Communications;
using FileLogger;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using TowardAgarioStepThree;
using static AgarioModels.Protocols;

CustomFileLogger logger = new CustomFileLogger("custom");
Networking network = new Networking(logger, onConnect, onDisconnect, onMessage, '\n');
network.Connect("localhost", 11000);
network.ClientAwaitMessagesAsync();
Console.ReadLine();

static void onConnect(Networking network)
{

}

static void onDisconnect(Networking network)
{

}

static void onMessage(Networking network, string message)
{
    string[] he = message.Split("\n");

    string stuff = Command(he);
    List<AgarioModels.Food> foodList = JsonSerializer.Deserialize<List<AgarioModels.Food>>(stuff);
    foreach (AgarioModels.Food food in foodList)
    {
        Console.WriteLine(food);
    }
}

static string Command(string[] command)
{
    foreach (string s in command)
    {
        if (s.StartsWith("{Command Food}"))
        {
            return s.Substring(14);
        }
    }
    return "";
}