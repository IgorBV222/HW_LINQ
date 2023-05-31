using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace HW_LINQ
{
    internal class FileParser
    {
        public FileParser(string _path)
        {
            FilesWord = new List<object>();
            FileRead(_path);
        }
        public List<object> FilesWord { get; set; }
        private static readonly Regex regexWord = new Regex(@"\w+(-||_)\w+");
        private void FileRead(string _path)
        {
            string strWord = "";
            try
            {                
                StreamReader sr = new StreamReader(_path);
                for (int i = 0; !sr.EndOfStream; i++)
                {
                    strWord += sr.ReadLine();
                }
                MatchCollection words = regexWord.Matches(strWord);
                foreach (Match match in words)
                {
                    if (match.Value == "")
                    {
                        continue;
                    }
                    else
                    {                       
                        FilesWord.Add(match.Value);  
                    }                      
                }
                sr.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }       
    }
}
