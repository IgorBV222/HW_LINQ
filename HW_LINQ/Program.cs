using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Приложение должно принимать имена 2-х сравниваемых файлов (или ввод пользователя или аргументы командной строки) и формировать третий,
//куда попадут слова, встречающиеся в обоих файлах. Предуспомотреть обработку знаков препинания и возможных разделителей (символов между словами).
//Рекомендации: использовать LINQ.

namespace HW_LINQ
{
    internal class Program
    {
        static void FileWrite(List<object> FilesWord, string _path)
        {
            try
            {
                StreamWriter sw = new StreamWriter((_path + "_word_parser.txt"), true);
                Console.WriteLine("\nData written to file " + (_path + "_word_parser.txt"));
                for (int i = 0; i < FilesWord.Count; i++)
                {
                    Console.WriteLine($"{FilesWord[i]} ");                    
                    sw.Write($"{FilesWord[i]} ");                    
                }
                FilesWord.Clear();
                sw.Close();
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("\nException: " + e.Message);
            }
        }
        static List<object> UnionFileWords(List<object> _filesWord1, List<object> _filesWord2)
        {
            var resault = _filesWord1.Intersect(_filesWord2);
            List<object> resFilesWord = new List<object>();
            foreach (var item in resault)
            {
                resFilesWord.Add(item);
            }
            return resFilesWord;
        }
        static void Main(string[] args)
        {
            string path1, path2, respath;
            try
            {
                if (args.Length == 2)
                {
                    path1 = args[0];
                    path2 = args[1];
                }
                else
                {
                    Console.WriteLine("Enter the path to the first file");
                    path1 = Console.ReadLine();
                    Console.WriteLine("Enter the path to the second file");
                    path2 = Console.ReadLine();
                }
                FileParser file1 = new FileParser(path1);
                FileParser file2 = new FileParser(path2);
                List<object> files1 = file1.FilesWord;
                List<object> files2 = file2.FilesWord;
                List<object> resFilesWord = UnionFileWords(files1, files2);                          
                respath = (path1.Remove(path1.Length - 4) + '_' + path2.Remove(path2.Length - 4));
                FileWrite(resFilesWord, respath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
