﻿namespace RouterConfigurator.Writer
{
    using System;
    using System.IO;

    using RouterConfigurator.Contracts;

    public class FileWriter : IWriter
    {
        public void Write(string text, string destination)
        {
            File.WriteAllText(destination, text);
        }
    }
}
