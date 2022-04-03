using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMethodTracer
{
    public class MethodTracer : IDisposable
    {
        private readonly string _className;
        private readonly string _methodName;

        public MethodTracer()
        {
            (_className, _methodName) = GetCallerName();

            Console.WriteLine($"{_className}::{_methodName} -- enter");
        }

        static private (string, string) GetCallerName()
        {
            StackTrace stackTrace = new StackTrace();

            var method = stackTrace.GetFrame(2).GetMethod();
            string className = method.ReflectedType.Name;
            string methodName = method.Name;
            return (className, methodName);
        }

        public void Dispose()
        {
            Console.WriteLine($"{_className}::{_methodName} -- exit");
        }

        static public void Log(in string message)
        {
            var names = GetCallerName();
            Console.WriteLine($"{names.Item1}::{names.Item2}: {message}");
        }
    }
}
