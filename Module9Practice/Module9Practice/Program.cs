using System;
using System.Collections.Generic;
using System.Linq;

namespace Module9Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            Exception[] exception = new Exception[] {new ArgumentOutOfRangeException(), new ArgumentNullException(),
            new FormatException(), new TimeoutException(), new MyException("Введено число не 1 и не 2")};

            List<string> firstName = new List<string>();
            firstName.Add( "Сидоров" );
            firstName.Add( "Петров" );
            firstName.Add("Антонов" );
            firstName.Add("Козлов");
            firstName.Add("Иванов");

            Console.WriteLine("Выберите вариант сортировки. Введите 1 или 2 (1 - сортировка от А до Я, 2 - сортировка от Я до А");

            try
            {
                int number = Int32.Parse(Console.ReadLine());
                if (number != 1 & number != 2) throw new MyException();                   

                SortAListOfFirstnames srt = new SortAListOfFirstnames();
                srt.Sorting += srt_Sorting; // регистрируем событие
                srt.StartSorting(firstName, number);
            }
            catch (Exception ex)
            {
                foreach (var i in exception)
                {
                    if (ex.GetType() == i.GetType()) Console.WriteLine($"Словили исключение: {i.Message}");
                    //else Console.WriteLine("Какое-то непредвиденное исключение");
                }
            }
            finally
            {
                foreach (string str in firstName)
                    Console.WriteLine(str);
            }                                 
        }

        // перехватчик событий
        public static void srt_Sorting(List<string> firstName, int number)
        {
            if(number == 1)
            firstName.Sort();  
            
            if (number == 2)
            {
                firstName.Sort();
                firstName.Reverse();
            }
        }
    }
}
