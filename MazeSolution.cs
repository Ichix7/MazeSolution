using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mystack
{
    class Program
    {



        static void Main(string[] args)
        {
            

            do
            {

                MyStack.TopMap();
                MyStack.Checkpath();
                Console.ReadLine();
                Console.Clear();
                
            } while (MyStack.Maze[MyStack.posy, MyStack.posx] != "F");
        }


    }
    class MyStack
    {
        public static int posx = 1;
        public static int posy = 1;
        public static int savedx = 0;
        public static int savedy = 0;
        public static List<int> xCord = new List<int>();
        public static List<int> yCord = new List<int>();
        public static int Extra = 0;
        public static int Wrong = 0;

        public static string[,] Maze = new string[,]
        {

            // 0     1     2    3   4   5   6   7   8    9 
            { "0" , "0" , "0", "0","0","0","0","0","0" ,"0" },//Row 0
            { "0" , "S" , "0", "1","1","1","1","1","1" ,"0" },//Row 1
            { "0" , "1" , "0", "1","0","0","0","0","1" ,"0" },//Row 2
            { "0" , "1" , "0", "0","0","0","1","1","1" ,"0" },//Row 3
            { "0" , "1" , "1", "1","1","1","0","0","1" ,"0" },//Row 4
            { "0" , "1" , "0", "1","0","0","0","0","1" ,"0" },//Row 5
            { "0" , "1" , "0", "1","0","1","1","1","1" ,"0" },//Row 6
            { "0" , "1" , "0", "1","0","1","0","0","1" ,"0" },//Row 7
            { "0" , "0" , "0", "1","1","1","1","0","F" ,"0" },//Row 8
             { "0" , "0" , "0","0","0","0","0","0","0" ,"0" },//Row 9
        };
        public static void Checkpath()
        {
            if (Maze[posy + 1, posx] == "F")
            {

                Console.WriteLine("You Win!!!");
                Console.ReadLine();
                System.Environment.Exit(1);
            }

            if (posy <= 9 && Maze[posy + 1, posx] == "1")
            {
               // Console.WriteLine("1");
                Extra++;
            }
            else { Wrong++; }
            if (posy > 0 && Maze[posy - 1, posx] == "1" )//|| Maze[posy - 1, posx] == "F")
            {
                //Console.WriteLine("2");
                Extra++;
            }
            else { Wrong++; }
            if (posx > 0 && Maze[posy, posx-1] == "1")// || Maze[posy, posx -1] == "F")
            {
                //Console.WriteLine("3");
                Extra++;
            }
            else { Wrong++; }
            if (posx <= 9 && Maze[posy, posx + 1] == "1"  || Maze[posy, posx +1] == "F")
            {
                //Console.WriteLine("4");
                Extra++;
            }
            else { Wrong++; }
            if (Wrong <= 3 && Extra >= 2)
            {
                savedx = posx;
                savedy = posy-2;
                //Console.WriteLine("5");
                mult();
                Wrong = 0;
            }
            else { Wrong++; }
            if (Extra <= 1)
            {
               // Console.WriteLine("6");
                Wrong = 0;
                Pathchoice();
                
            }
            if (Wrong >= 4)
            {
                //Console.WriteLine("Hello");
                Pop();
            }
        }
        public static void mult()
        {

            if (posy <= 9 && Maze[posy + 1, posx] == "1" || Maze[posy + 1, posx] == "F")
            {
                //Console.WriteLine("Mult1");
                Push(posy+1, posx);
                posy++;
                MyStack.Maze[MyStack.posy, MyStack.posx] = "X";
            }
            else if(posy > 0 && Maze[posy - 1, posx] == "1")
            {
               // Console.WriteLine("Mult2");
                Push(posy-1, posx);
                posy--;
                MyStack.Maze[MyStack.posy, MyStack.posx] = "X";
            }
            else if(posx > 0 && Maze[posy, posx - 1] == "1")
            {
               // Console.WriteLine("Mult3");
                Push(posy, posx-1);
                posx--;
                MyStack.Maze[MyStack.posy, MyStack.posx] = "X";
            }
            else if(Maze[posy, posx+1] == "F" || posx <= 9 && Maze[posy, posx + 1] == "1")
            {
                //Console.WriteLine("Mult4");
                Push(posy, posx+1);
                posx++;
                MyStack.Maze[MyStack.posy, MyStack.posx] = "X";
            }
        }
        public static void Pathchoice()
        {
 
            if (posy <= 9 && Maze[posy + 1, posx] == "1" )// Maze[posy + 1, posx] == "F")
            {
                //Console.WriteLine("Path");
                posy++;
                Extra = 0;
                MyStack.Maze[MyStack.posy, MyStack.posx] = "C";
            }
            else if(posy > 0 && Maze[posy - 1, posx] == "1")
            {
                //Console.WriteLine("Path");
                posy--;
                Extra = 0;
                MyStack.Maze[MyStack.posy, MyStack.posx] = "C";
            }
            else if(posx > 0 && Maze[posy, posx -1] == "1")
            {
                //Console.WriteLine("Path");
                posx--;
                Extra = 0;
                MyStack.Maze[MyStack.posy, MyStack.posx] = "C";
            }
            else if(posx <= 9 && Maze[posy, posx + 1] == "1" )//|| Maze[posy, posx+1] == "F")
            {
                //Console.WriteLine("Path");
                posx++;
                Extra = 0;
                MyStack.Maze[MyStack.posy, MyStack.posx] = "C";
            }
        }

        public static void Push(int y, int x)
        {
            xCord.Add(x);
            yCord.Add(y);
        }

        public static void Pop()
        {

            if (yCord.Count() != 0 && !IsEmpty())
            {
                //Console.WriteLine("HI");

                Maze[yCord[yCord.Count()-1], xCord[xCord.Count()-1]] = "0";                
                xCord.RemoveAt(xCord.Count() - 1);
                yCord.RemoveAt(yCord.Count() - 1);
                posx = savedx;
                posy = savedy;
            }
            else Extra =0;
        }

        public static void TopMap()
        {

            
            Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9}", Maze[0, 0], Maze[0, 1], Maze[0, 2], Maze[0, 3], Maze[0, 4], Maze[0, 5], Maze[0, 6], Maze[0, 7], Maze[0, 8], Maze[0, 9]);
            Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9}", Maze[1, 0], Maze[1, 1], Maze[1, 2], Maze[1, 3], Maze[1, 4], Maze[1, 5], Maze[1, 6], Maze[1, 7], Maze[1, 8], Maze[1, 9]);
            Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9}", Maze[2, 0], Maze[2, 1], Maze[2, 2], Maze[2, 3], Maze[2, 4], Maze[2, 5], Maze[2, 6], Maze[2, 7], Maze[2, 8], Maze[2, 9]);
            Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9}", Maze[3, 0], Maze[3, 1], Maze[3, 2], Maze[3, 3], Maze[3, 4], Maze[3, 5], Maze[3, 6], Maze[3, 7], Maze[3, 8], Maze[3, 9]);
            Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9}", Maze[4, 0], Maze[4, 1], Maze[4, 2], Maze[4, 3], Maze[4, 4], Maze[4, 5], Maze[4, 6], Maze[4, 7], Maze[4, 8], Maze[4, 9]);
            Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9}", Maze[5, 0], Maze[5, 1], Maze[5, 2], Maze[5, 3], Maze[5, 4], Maze[5, 5], Maze[5, 6], Maze[5, 7], Maze[5, 8], Maze[5, 9]);
            Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9}", Maze[6, 0], Maze[6, 1], Maze[6, 2], Maze[6, 3], Maze[6, 4], Maze[6, 5], Maze[6, 6], Maze[6, 7], Maze[6, 8], Maze[6, 9]);
            Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9}", Maze[7, 0], Maze[7, 1], Maze[7, 2], Maze[7, 3], Maze[7, 4], Maze[7, 5], Maze[7, 6], Maze[7, 7], Maze[7, 8], Maze[7, 9]);
            Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9}", Maze[8, 0], Maze[8, 1], Maze[8, 2], Maze[8, 3], Maze[8, 4], Maze[8, 5], Maze[8, 6], Maze[8, 7], Maze[8, 8], Maze[8, 9]);
            Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9}", Maze[9, 0], Maze[9, 1], Maze[9, 2], Maze[9, 3], Maze[9, 4], Maze[9, 5], Maze[9, 6], Maze[9, 7], Maze[9, 8], Maze[9, 9]);

        }

        public static bool IsEmpty()
        {
            if (posx < 0 && posy < 0 ) { return true; }
            return false;
        }
        /*
        public static bool IsFull()
        {
            if (I > 25 && p > 25) { return true; }
            return false;
        }
        */
    }
}