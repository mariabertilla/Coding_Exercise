using System.IO;
using System;
using System.Collections;

namespace Coding_Exercise
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string? file;
            string? path;
            string? filePath;

            // User input for File name 
            Console.Write("Enter the file name : ");
            file = Console.ReadLine();
            if (file == null || !file.EndsWith(".csv"))
                throw new Exception("Invalid file type");


            // Optional user input for entering a different filepath
            Console.Write("Enter the file path : ");
            path = Console.ReadLine();
            if (path != null && path.Trim().Length > 0)
                filePath = path + "\\" + file;
            else
                filePath = "D:\\" + file;

            String fileName = Path.GetFileNameWithoutExtension(filePath);
            String outputFilePath = filePath.Replace(fileName, fileName + "_transposed");

            try
            {
                // Fetching input data and storing them in a list
                List<String[]> input_row_list = new List<String[]>();
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        String[] split_value = line.Split(',');
                        input_row_list.Add(split_value);

                    }
                }

                List<String[]> transposedData = new List<String[]>();
                int input_row_count = input_row_list.Count();

                // Looping through the each row and column 
                for (int each_input_row = 0; each_input_row < input_row_count; each_input_row++)
                {
                    for (int each_input_column = 0; each_input_column < input_row_list[each_input_row].Count(); each_input_column++)
                    {
                        // Condition to add rows to the output
                        if (each_input_column >= transposedData.Count())
                        {
                            transposedData.Add(new String[input_row_count]);
                        }
                        transposedData[each_input_column][each_input_row] = input_row_list[each_input_row][each_input_column];

                    }

                }

                // Writing the transposed data list into the output file
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    foreach (var row in transposedData)
                    {
                        writer.WriteLine(string.Join(",", row));

                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }
    }


}

