using System;
using System.Collections;
using System.Text;

namespace SkalProj_Datastrukturer_Minne;

class Program
{
    /// <summary>
    /// The main method, vill handle the menues for the program
    /// </summary>
    /// <param name="args"></param>
    static void Main()
    {

        while (true)
        {
            Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                + "\n1. Examine a List"
                + "\n2. Examine a Queue"
                + "\n3. Examine a Stack"
                + "\n4. CheckParenthesis"
                + "\n0. Exit the application");
            char input = ' '; //Creates the character input to be used with the switch-case below.
            try
            {
                input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
            }
            catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
            {
                Console.Clear();
                Console.WriteLine("Please enter some input!");
            }
            switch (input)
            {
                case '1':
                    ExamineList();
                    break;
                case '2':
                    ExamineQueue();
                    break;
                case '3':
                    ExamineStack();
                    break;
                case '4':
                    CheckParanthesis();
                    break;
                /*
                 * Extend the menu to include the recursive 
                 * and iterative exercises.
                 */
                case '0':
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                    break;
            }
        }
    }

    /// <summary>
    /// Examines the datastructure List
    /// </summary>

    /*
         * Loop this method untill the user inputs something to exit to main menue.
         * Create a switch statement with cases '+' and '-'
         * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
         * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
         * In both cases, look at the count and capacity of the list
         * As a default case, tell them to use only + or -
         * Below you can see some inspirational code to begin working.
        */

    static void ExamineList()
    {
        Console.Write("Write a string starting with + to add to theList and starting with - to remove from theList: ");
        string input;
        List<string> theList = new List<string>();

        do
        {
            input = Console.ReadLine();
            char nav = input[0];
            string value = input.Substring(1);

            switch (nav)
            {
                case '+':
                    theList.Add(value);
                    Console.WriteLine($"Added {value}{Environment.NewLine}" +
                        $"Capacity: {theList.Capacity}{Environment.NewLine}" +
                        $"Count: {theList.Count}{Environment.NewLine}" +
                        $"-------------------------------------");

                    break;
                case '-':
                    theList.Remove(value);
                    Console.WriteLine($"Removed {value}{Environment.NewLine}" +
                       $"Capacity: {theList.Capacity}{Environment.NewLine}" +
                       $"Count: {theList.Count}{Environment.NewLine}" +
                       $"-------------------------------------");

                    break;
                default:
                    Console.WriteLine("You have to use - or + at the start of the input.");
                    break;
            }

        } while (input.ToUpper() != "Q");

    }

    /// <summary>
    /// Examines the datastructure Queue
    /// </summary>

    /*
        * Loop this method untill the user inputs something to exit to main menue.
        * Create a switch with cases to enqueue items or dequeue items
        * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
       */

    static void ExamineQueue()
    {
        Console.Write("Write a string starting with + to add to theQueue and starting with - to remove from theQueue: ");
        string input;
        Queue<string> theQueue = new Queue<string>();

        do
        {
            input = Console.ReadLine();
            char nav = input[0];
            string value = input.Substring(1);

            switch (nav)
            {
                case '+':
                    theQueue.Enqueue(value);
                    Console.WriteLine(string.Join(Environment.NewLine, theQueue));

                    break;
                case '-':
                    Console.WriteLine(string.Join(theQueue.Dequeue(), Environment.NewLine, theQueue));

                    break;
                default:
                    Console.WriteLine("You have to use - or + at the start of the input.");
                    break;
            }

        } while (input.ToUpper() != "Q");

    }

    /// <summary>
    /// Examines the datastructure Stack
    /// </summary>
    /// 

    /*
        * Loop this method until the user inputs something to exit to main menue.
        * Create a switch with cases to push or pop items
        * Make sure to look at the stack after pushing and and poping to see how it behaves
       */

    static void ExamineStack()
    {
        Console.Write("Write a string starting with + to add to theQueue and starting with - to remove from theQueue: ");
        string input;
        Stack<char> charStack = new Stack<char>();

        do
        {
            input = Console.ReadLine();
            char nav = input[0];
            string value = input.Substring(1);

            switch (nav)
            {
                case '+':
                    ReverseStringWithStack(charStack, value);

                    break;
                case '-':

                    Console.WriteLine();

                    break;
                default:
                    Console.WriteLine("You have to use - or + at the start of the input.");
                    break;
            }

        } while (input.ToUpper() != "Q");
    }

    private static void ReverseStringWithStack(Stack<char> charStack, string value)
    {
        foreach (char c in value)
            charStack.Push(c);

        StringBuilder sbReverse = new StringBuilder();

        foreach (char c in charStack)
            sbReverse.Append(charStack.Pop);

        Console.WriteLine(sbReverse.ToString());
    }

    /*
         * Use this method to check if the paranthesis in a string is Correct or incorrect.
         * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
         * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
        
                                                                                        (){}
     
     
     */
    static void CheckParanthesis()
    {
        Console.Write("Write a string with parenthesis and you will be informed if it is valid.");
        string input = Console.ReadLine();

        Stack<char> openP = new Stack<char>();

        if (input.IndexOfAny(new[] { '(', ')', '[', ']', '{', '}' }) >= 0)
        {
            foreach (char c in openP)
            {
                if (c == '(' || c == '{' || c == '[')
                    openP.Push(c);

                else if (c == ')' || c == '}' || c == ']')
                {
                    bool stackHasValue = openP.TryPop(out char pop);

                    if (c == ')' && pop != '(' ||
                        c == ']' && pop != '[' ||
                        c == '}' && pop != '{')
                    {
                        Console.WriteLine("The string you have given is not valid.");
                        return;
                    }
                }
            }
            if (openP.Count > 0)
                Console.WriteLine("Your string is valid!");
            else
                Console.WriteLine("The string you have given is not valid.");
        }
        else
            Console.WriteLine("Your string doesn't contain any parenthesis.");
    }
}

