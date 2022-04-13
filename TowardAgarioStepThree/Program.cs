// See https://aka.ms/new-console-template for more information
using AgarioModels;
using Communications;
using FileLogger;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using TowardAgarioStepThree;
using static AgarioModels.Protocols;

CustomFileLogger logger = new CustomFileLogger("custom");
Networking network = new Networking( logger, onConnect, onDisconnect, onMessage, '\n');
network.Connect("localhost",11000);
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
    foreach(AgarioModels.Food food in foodList)
    {
        Console.WriteLine(food);
    }
}

static string Command(string[] command)
{
    foreach(string s in command)
    {
        if(s.StartsWith("{Command Food}"))
        {
            return s.Substring(14);
        }
    }
    return "";

}