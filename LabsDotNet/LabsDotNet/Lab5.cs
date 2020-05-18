using System;
using System.Collections.Generic;
using System.IO;
using Xceed.Words.NET;

namespace LabsDotNet
{
    internal class Lab5
    {
        private const string InputFileName = "input.txt";
        private const string OutputFileName = "output.docx";

        public Lab5()
        { 
            var inputRows = new List<string>();
            
            using (var sr = new StreamReader(InputFileName))
            {
                var lineOfText = "";
                while ((lineOfText = sr.ReadLine()) != null)
                {
                    inputRows.Add(lineOfText);
                    Console.WriteLine(lineOfText);
                }
            }

            using var document = DocX.Create(OutputFileName);
            for (var rowIndex = 0; rowIndex < inputRows.Count; rowIndex++)
            {
                var inputRow = inputRows[rowIndex];
                if (rowIndex % 2 == 0 || rowIndex == inputRows.Count - 1)
                {
                    document.InsertParagraph(inputRow);
                }
                else
                {
                    var table = document.InsertTable(1, 5);
                    var split = inputRow.Split(';');
                    for (var cellIndex = 0; cellIndex < split.Length; cellIndex++)
                    {
                        table.Rows[0].Cells[cellIndex].InsertParagraph(split[cellIndex]);
                    }
                }
            }

            document.Save();
        }
    }
}