using DataModel;
using DataOperations;
using System;
using System.IO;

namespace GraphExercise
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string filePath = getFilePath();
            if (filePath != Constants.EXIT)
            {
                IDataFile dataFile = new DataFile(filePath);
                IDataOperations dataOperations = new FileOperations(dataFile);
                dataOperations.PopulateValues();

                IGraphOperations graphOperations = new GraphOperations(dataFile);
                string graphPath = graphOperations.DrawGraphAsImage();
                Console.WriteLine(Constants.IMAGEPATH, graphPath);
                graphOperations.VisualizeChart(graphPath);

                dataOperations.DrawGraphic += new DrawGraphicEventHandler(() =>
                    graphOperations.VisualizeChart(graphOperations.DrawGraphAsImage()));
            }
            else
            {
                Console.WriteLine(Constants.MAX_TRY_COUNT);
            }
            Console.WriteLine(Constants.TO_QUIT);
            Console.ReadLine(); //Keep the program open to detect file changes
        }

        private static string getFilePath() 
        {
            string filePath = string.Empty;
            int i = 0;
            while (!File.Exists(filePath))
            {
                if(i == 0)
                    Console.Write(Constants.INPUT_FILE_PATH);
                else
                    Console.Write(Constants.INVALID_FILE);
                filePath = Console.ReadLine();
                if (i == 5) //Prevent infinite loop
                {
                    return Constants.EXIT;
                }
                i++;
            }
            return filePath;
        }
    }
}
