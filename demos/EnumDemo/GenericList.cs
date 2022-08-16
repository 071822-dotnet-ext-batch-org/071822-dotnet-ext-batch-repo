using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnumDemo
{
    public class GenericList<T>
    {
        public GenericList()
        {
            MyList = new T[10];
            this.Size = 1;
            this.Capacity = 10;
        }

        //keep the List
        public T[] MyList { get; set; }// just keep the reference variable here.
        private int Capacity { get; set; }
        public int Size { get; set; }

        public void AddT(T newT)
        {
            if (Capacity >= Size + 1)
            {
                MyList[Size - 1] = newT;
                Size++;
            }
            else
            {
                //create a new array of T type, that is double the size and move all the references over to it.
                throw new IndexOutOfRangeException("There isn't an element available for that T.");
            }
        }

        public void PrintList()
        {
            for (int x1 = 0; x1 < this.Size; x1++)
            {
                if (typeof(T) is Person)
                {
                    Console.WriteLine($"The T is {MyList[x1]}");
                }
            }
        }



    }
}