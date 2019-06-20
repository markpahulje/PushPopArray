using System;
using System.Diagnostics; 

namespace InfiniteStackImplementationUsingStringArray
{
    internal class Stack
    {
        static int MAX = 3; //Max number of elements in string[] array
        static int idxMAX = MAX - 1; //Max number of elements in string[] array
        
        int count; 

        string[] stack = new string[MAX];

        public Stack() //constructor
        {
            count = 0;           //initialize stack with how many default values 
            //stack = new string[] { "x", "y", "z", "w" }; //w is ignored, no error given
            //MAX = 3; 
        }

        public Stack(string[] initArr, int initCount, int ArraySize ) //constructor with args
        {
            count = initCount;  //initialize stack with how many default values you want on stack
            MAX = ArraySize;    //initialize size of stack

            if (initArr.Length < MAX) //initialize remaining 
            {   
                Array.Resize<string>(ref initArr, MAX); //faster imp? 
            }

            stack = initArr;    //initialize stack with your array


        }

        public bool IsEmpty()
        {
            return (count == 0);
        }

        public bool IsFull()
        {
            return (count == MAX);
        }

        public int Length()
        {
            return MAX;
        }
        /// <summary>
        /// Number of current items on/in the stack array
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return count;
        }

        internal bool Push(string data)
        {
            if (count > 0)
            {
                for (int i = 0; i <= MAX - 2; i++) //inline copy fast
                    stack[i] = stack[i + 1];

                stack[MAX - 1] = data; //always same place at top, which in this case is last element of array!

                if (count < MAX) 
                    count++;
               // else
                    //Console.WriteLine("Max array size exceeded. Roll off the end.");
                
                //Console.WriteLine("count=" + count + ", Push = " + data);
                
                return true;
            }
            else
            {
                count++;
                stack[MAX - 1] = data;

                //Console.WriteLine("count=" + count + ", Push = " + data);
                return true;
            }

        }

        internal string Pop()
        {

            if (count > 0)
                count--;
            else
                return stack[MAX - 1]; 

            string popValue = stack[MAX - 1]; //pop value on top of array

            //Console.WriteLine("count = " + count + ", Pop = " + popValue);

            for (int i = MAX - 1; i >= 1; i--) //inline copy fast
            {
                stack[i] = stack[i - 1];
            }

            stack[0] = string.Empty; //initialize bottom of stack, gets empty string

            return popValue;

        }

        internal string Peek() //traditional definition of top
        {
            return stack[MAX - 1];
        }

        internal string Top() 
        {
            return stack[MAX - 1];
        }
        internal void PrintTop()
        {
            Console.WriteLine("The topmost element of Stack is : {0}", stack[MAX - 1]);
        }
        internal void PrintStack()
        {
            Console.WriteLine("Printing Stack with {0} items:", count);
            for (int i = MAX - 1; i >= 0; i--)
            {
                Console.Write("arr[" + i + "]=" + stack[i] + ",");
            }
            Console.WriteLine();
            Console.WriteLine();
        }

    }

    public static class Program
    {
        public static void Main()
        {
            Stopwatch sw = new Stopwatch(); 
            string popvalue = string.Empty; 

            string[] infiniteStackInitialize = new string[] { "x", "y", "z" }; //w is ignored, no error given
            int numberofelementstostartwith = 0;
            int maxnumberelementsforthestringarray = 1000;

            Stack s = new Stack(infiniteStackInitialize, numberofelementstostartwith, maxnumberelementsforthestringarray);

            Console.WriteLine("Pop/Push Array Test");
            Console.WriteLine("Arr Len = " + s.Length().ToString());
            Console.WriteLine("Top of stack is at index = " + (s.Length()-1).ToString());
            s.PrintTop();
            //s.PrintStack();
            

            s.Push("a");
            s.PrintTop();
            //s.PrintStack();
            s.Push("b");
            s.PrintTop();
            //s.PrintStack();
            s.Push("c");
            s.PrintTop();
            //s.PrintStack();

            //s.PrintStack();
            sw.Start();
            s.Push("d");
            sw.Stop();
            Console.WriteLine("### PUSH - Full stack internal copy took {0} ticks.", (sw.ElapsedTicks).ToString());

            s.PrintTop();
            //s.PrintStack();
            
            s.Push("e");
            //s.PrintStack();
            s.PrintTop();
            s.Push("f");
            //s.PrintStack();
            s.PrintTop();
            s.Push("g");
            //s.PrintStack();
            s.PrintTop();
            Console.WriteLine("Item popped from Stack : {0}", s.Pop());
            //s.PrintStack();

            sw.Restart();
            popvalue = s.Pop();
            sw.Stop();
            Console.WriteLine("### POP - Full stack internal copy took {0} ticks.", (sw.ElapsedTicks).ToString());
            Console.WriteLine("Item popped from Stack : {0}", popvalue);
            
            //s.PrintStack();
            Console.WriteLine("Item popped from Stack : {0}", s.Pop());
            //s.PrintStack();
            Console.WriteLine("Item popped from Stack : {0}", s.Pop());
            //s.PrintStack();

            Console.ReadKey(); 
        }
    }
}
