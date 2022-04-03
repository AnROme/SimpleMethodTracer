using System;
using System.Diagnostics;
using SimpleMethodTracer.Logging;

namespace SimpleMethodTracer
{
    public class MethodTracer : IDisposable
    {
        private readonly string _className;
        private readonly string _methodName;
        private readonly ILogger _logger;

        public MethodTracer(ILogger logger)
        {
            _logger = logger;
            (_className, _methodName) = GetCallerName();

            _logger.Info($"[{_className}::{_methodName}] -- enter");
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
            _logger.Info($"[{_className}::{_methodName}] -- exit");
        }

        static public void Log(in string message, ILogger logger)
        {
            var names = GetCallerName();
            logger.Info($"[{names.Item1}::{names.Item2}]: {message}");
        }
    }
}
