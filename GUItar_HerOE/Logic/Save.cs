using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUItar_HerOE.Logic
{
    public class Save
    {      
        private string filePath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, @"GUItar_HerOE\Save\save.txt");
        public List<int> CompletedLevels;

        public Save()
        {
            CompletedLevels = new List<int>();
        }

        public List<int> Loading()
        {          
            string[] lines = System.IO.File.ReadAllLines(filePath);
            if (lines != null)
            {
                foreach (string line in lines)
                {
                    CompletedLevels.Add(int.Parse(line));
                }
            }
            return CompletedLevels;
        }

        public void Saveing(int levelID)
        {        
            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.WriteLine(levelID);
                sw.Close();
            }
            
        }

        public void Delete()
        {
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
                System.IO.File.Create(filePath).Close();
            }        
        }
    }
}
