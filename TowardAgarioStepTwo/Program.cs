using System.Text.Json;
using TowardAgarioStepTwo;

Student jim = new Student(2.3f, "Jimmy Boi");

string message = JsonSerializer.Serialize(jim);
Console.WriteLine(message);

Student? jimTheSecond = JsonSerializer.Deserialize<Student?>(message);
Console.WriteLine(jimTheSecond);