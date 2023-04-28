using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Delegate
{

    // объявили делегат
    delegate void output(params object[] values); //params - модификатор, который говорит что количество значений ////может  быть неопределено
    internal static class Program
    {

        static void NamesOfObj(object[] _arr)   //метод
        {
            string output = string.Empty; // строка нулевая 
            foreach (var item in _arr)
            {
                output += $"{item.GetType()}\n";
            }
            MessageBox.Show(output);
        }
        static void Main()
        {

            output myPrint = (object[] _arr) =>// переменная делегата
            {
                foreach (var item in _arr)
                {
                    Console.WriteLine(item);
                }
            };
            myPrint += NamesOfObj;    // передаем адрес метода ( NamesOfObj )
            myPrint += (object[] _arr) =>   // метод без названия
            {
                using (var sw = new StreamWriter("output.txt", true)) // запись в файл
                {   
                    foreach (var item in _arr)
                    {
                        sw.WriteLine(item.ToString(), true);  
                    }
                }
            };
            myPrint(1, "ldf", 3.5f, 'F'); // вызываем метод
            myPrint -= NamesOfObj;
            myPrint(1, 2d, (byte)25, true);


              Console.ReadLine();
        }
            
          
        }
    }

