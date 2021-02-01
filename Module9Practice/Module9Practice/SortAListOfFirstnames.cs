using System;
using System.Collections.Generic;
using System.Text;

namespace Module9Practice
{
    public delegate void Sort(List<string> firstName, int number);  // делегат   
    public class SortAListOfFirstnames
    {
        public event Sort Sorting; // событие



        public void StartSorting(List<string> firstName, int number)
        {
            Console.WriteLine("Давайте отсортируем список фамилий!");
            OnSortingProcess(firstName, number);
        }

        protected virtual void OnSortingProcess(List<string> firstName, int number) //protected virtual method
        {
            Sorting?.Invoke(firstName, number);
        }
    }
}
