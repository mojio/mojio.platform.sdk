using System;
using System.Collections.Generic;
using System.Text;

namespace Mojio.Platform.SDK.CLI
{
    internal class ConsoleSpinner
    {
        private int counter;
        private string[] sequence;

        private IList<string[]> sequences = new List<string[]>();

        public ConsoleSpinner(int sequenceIndex = 0)
        {
            counter = 0;

            sequences.Add(new string[] { "/", "-", "\\", "|" });
            sequences.Add(new string[] { ".", "o", "0", "o" });
            sequences.Add(new string[] { "+", "x" });
            sequences.Add(new string[] { "V", "<", "^", ">" });
            sequences.Add(new string[] { ".   ", "..  ", "... ", "....", "... ", "..  ", ".   " });
            sequences.Add(new string[] { ".   ", "..  ", "... ", "...." });

            if (sequenceIndex < 0) sequenceIndex = 0;
            if (sequenceIndex > sequences.Count) sequenceIndex = sequences.Count;

            sequence = sequences[sequenceIndex];
        }

        public void Turn()
        {
            counter++;

            if (counter >= sequence.Length)
                counter = 0;

            Console.Write(sequence[counter]);
            Console.SetCursorPosition(Console.CursorLeft - sequence[counter].Length, Console.CursorTop);
        }
    }
}