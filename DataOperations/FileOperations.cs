using DataModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace DataOperations
{
    public class FileOperations : IDataOperations
    {
        public IDataFile inputFile { get; set; }
        /// <summary>
        /// Tell fileoperations that how to draw graphic outside of class(from main)
        /// </summary>
        public event DrawGraphicEventHandler DrawGraphic;
        private FileSystemWatcher _watcher;

        public FileOperations(IDataFile inputFileAsParameter)
        {
            inputFile = inputFileAsParameter;

            _watcher = new FileSystemWatcher();

            _watcher.Path = inputFile.FileDirectory;
            _watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.Size;

            _watcher.Filter = inputFile.FileName;

            _watcher.EnableRaisingEvents = true;
            _watcher.Changed += new FileSystemEventHandler(onChanged);
            _watcher.Deleted += new FileSystemEventHandler(onDeleted);
        }

        public void PopulateValues()
        {
            Thread.Sleep(500); //this is for known bug of FileSystemWatcher(fires twice) to avoid "file is being used by another process error"
            var lines = File.ReadLines(inputFile.FullPath);
            inputFile.Graph = new List<IGraphItem>();
            foreach (var line in lines)
            {
                string[] temp = line.Split(':');
                IGraphItem item = new GraphItem(temp[0], temp[1], temp[2]);
                inputFile.Graph.Add(item);
            }
        }

        private void onChanged(object source, FileSystemEventArgs e)
        {
            PopulateValues();
            DrawGraphic();
        }

        private void onDeleted(object source, FileSystemEventArgs e)
        {
            Console.WriteLine("File Deleted!");
        }

    }
}
