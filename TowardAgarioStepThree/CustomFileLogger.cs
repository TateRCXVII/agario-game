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
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileLogger
{
    /// <summary>
    /// customFileLogger class loggs actions to the file
    /// </summary>
    public class CustomFileLogger : ILogger
    {
        private readonly string _file_name;
        private readonly string _category_name;


        /// <summary>
        /// constructor for the customFileLogger
        /// </summary>
        /// <param name="category_name">category name for the logger</param>
        public CustomFileLogger(string category_name)
        {
            _category_name = category_name;
            _file_name = "Log_CS3500_Assignment7";
        }

        IDisposable ILogger.BeginScope<TState>(TState state)
        {
            throw new NotImplementedException();
        }

        bool ILogger.IsEnabled(LogLevel logLevel)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// self explanatory
        /// </summary>
        /// <typeparam name="TState">self explanatory</typeparam>
        /// <param name="logLevel">self explanatory</param>
        /// <param name="eventId">self explanatory</param>
        /// <param name="state">self explanatory</param>
        /// <param name="exception">self explanatory</param>
        /// <param name="formatter">self explanatory</param>
        void ILogger.Log<TState>(LogLevel logLevel, EventId eventId, TState state,
            Exception? exception, Func<TState, Exception?, string> formatter)
        {
            string result = DateTime.Now.ToString() + $": {logLevel.ToString()} :" + formatter(state, exception) + Environment.NewLine;
            File.AppendAllText(_file_name, result);
        }
    }
}