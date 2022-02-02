using System;
using System.Collections.Generic;
using System.Text;
using TestNinja.Mocking;

namespace TestNinja.Unit
{
    public class MockFileReader : IFileReader
    {
        public string Read(string path)
        {
            return "";
        }
    }
}
