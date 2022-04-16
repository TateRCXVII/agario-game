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
using System.Text.Json;
using TowardAgarioStepTwo;

Student jim = new Student(2.3f, "Jimmy Boi");

string message = JsonSerializer.Serialize(jim);
Console.WriteLine(message);

Student? jimTheSecond = JsonSerializer.Deserialize<Student?>(message);
Console.WriteLine(jimTheSecond);