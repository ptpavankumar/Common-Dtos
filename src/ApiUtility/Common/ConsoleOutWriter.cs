using System;

namespace ApiUtility.Common
{
    public class ConsoleOutWriter : IOutWriter
    {
        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }
    }
}
