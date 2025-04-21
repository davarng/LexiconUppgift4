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

        //Questions
        //1. The stack is LIFO(last in first out) which means that the deallocation order has to be the opposite of the allocation order.
        //   For example like a stack of books where the first book you place in a stack has to be picked up last. On the stack we have 
        //   value types, reference pointers and methods. The stack is also more efficient when it comes to performance.
        //
        //   The heap however contains the data that the pointers point to and does not have a specific order for allocation/deallocation.
        //   To handle this there is something called garbage collection which in C# automatically handles deallocation when it sees that 
        //   pointers are not able to be reached any more.
        //
        //   See picture "Stack and heap drawing" in Drawings folder.
        //
        //2. Value types are types that get stored on the stack, this includes: int, double , bool, char and struct. Most value types are
        //   primitive but for example struct is not primitive but still a value type. Value types can also not be null by default.
        //   Value types are always unique so for example if I create "int int2 = int1" then they will both be the same value but if I change
        //   int1 then int2 will not change.
        //
        //   Reference types however have their pointer stored on the stack but their actual value stored on the heap. Objects, strings, lists
        //   and arrays are examples of reference types. If you do the same operation as I showed above "Car car2 = car1" Then you will have 
        //   Two pointers which are stored on the stack pointing to the same object on the heap. This means that if you change color on car1
        //   then car2 will also change color since they are the same car. So instead of copying a car you could create a deep or shallow copy instead.
        //
        //3. The first method assigns x to 3 and never changes x.
        //
        //   The second method however creates two objects from the class MyInt which are reference types. This means that when you assign y
        //   to x that you have two pointers to the same object so when you change y you also change x.

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
            //To pause app and clear.
            Console.WriteLine(Environment.NewLine + "Hit enter to go back to the main menu.");
            Console.ReadLine();
            Console.Clear();
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
        /*  
            2. The list starts out with a capacity of 4 and increases when the count goes over the capacity.

            3. The list capacity increases in size by 100%.

            4. Because the list does not know how many items are supposed to be in the list so it attempts to do as few increases of capacity
               as possible while still keeping the list capacity reasonable.

            5. No the capacity does not decrease when items are removed. I think this is because the list doesn't want to take up performance 
               and expects the list to be used again.

            6. When you know how many items are going to be in an array. 
        
        */
        Console.Write($"Enter q to go back to the main menu{Environment.NewLine}Write a string starting with + to add to theList and starting with - to remove from theList: ");
        string input;
        List<string> theList = new();

        do
        {
            input = Console.ReadLine();
            char nav = input[0]; //First char for switch.
            string value = input.Substring(1);// Remove the first char from string.

            switch (nav)
            {
                case '+':
                    theList.Add(value);//Add to list
                    //CW write out the added value, capacity and count.
                    Console.WriteLine($"Added {value}{Environment.NewLine}" +
                        $"Capacity: {theList.Capacity}{Environment.NewLine}" +
                        $"Count: {theList.Count}{Environment.NewLine}" +
                        $"-------------------------------------");

                    break;
                case '-':
                    theList.Remove(value);//Remove from list.
                    //CW write out the removed value, capacity and count.
                    Console.WriteLine($"Removed {value}{Environment.NewLine}" +
                       $"Capacity: {theList.Capacity}{Environment.NewLine}" +
                       $"Count: {theList.Count}{Environment.NewLine}" +
                       $"-------------------------------------");

                    break;

                case 'Q':
                    break;
                default:
                    //Default message.
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
    {   /*
         1. "ICA queue" in drawings folder. 
         
         2. "ICA queue demo" in drawings folder.
         */

        Console.Write("Q to go back to menu." + Environment.NewLine + "Write a string starting with + to add to theQueue and - to remove from theQueue: ");
        string input;
        //Create queue.
        Queue<string> theQueue = new();

        do
        {
            input = Console.ReadLine();
            if (input.Length > 0) //Make sure input isn't empty to avoid exception.
            {
                char nav = input[0];//Gets first char of input.
                string value = input.Substring(1); //Removes first char.

                switch (nav)
                {
                    case '+':
                        //Adds input to the queue.
                        theQueue.Enqueue(value);
                        //CW that uses string.Join to make sure that theQueue is the correct format.
                        Console.WriteLine($"{value} has been added to the queue.{Environment.NewLine}" +
                            $"{Environment.NewLine}{string.Join(Environment.NewLine, theQueue)}");

                        break;
                    case '-':
                        //Make sure that Count is greater than zero to avoid exception trying to dequeue empty queue.
                        if (theQueue.Count > 0)
                            //Same as above to make sure the format is correct.
                            Console.WriteLine($"{string.Join(Environment.NewLine, theQueue.Dequeue())} has been removed from the queue.{Environment.NewLine}" +
                                $"{Environment.NewLine}{string.Join(Environment.NewLine, theQueue)}");

                        else
                            Console.WriteLine("Nothing to dequeue.");
                        break;
                    default:
                        //Error message if the user doesn't use - or + input.
                        Console.WriteLine("You have to use - or + at the start of the input.");
                        break;
                }
            }
            else//Empty input
                Console.WriteLine("No input. Please write a string with either - or + as a prefix.");
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
    { /*
        1. "ICA stack" in Drawings folder. Because Kalle will be there until the store closes if more customers arrive.

       */
        Console.Write("Write a string starting with + to add to theQueue and starting with - to remove fr: ");

        string input = Console.ReadLine();
        //If the input is longer than 1 character.
        if (input.Length > 1)
            //Call the method with input.
            ReverseStringWithStack(input);

    }

    private static void ReverseStringWithStack(string input)
    {
        //Create a stack of characters.
        Stack<char> charStack = new();

        //Run through all characters in input and push the characters to the stack.
        foreach (char c in input)
            charStack.Push(c);
        //StringBuilder to increase performance because possibility of many concatenations.
        StringBuilder sbReverse = new();

        //I first tried a Foreach loop but it threw InvalidOperationException. So I instead chose a while loop that 
        //continues as long as there is something in the stack.
        while (charStack.Count > 0)
            //Pops the stack into the stringbuilder.
            sbReverse.Append(charStack.Pop());

        //ToString to write out as a string.
        Console.WriteLine(sbReverse.ToString());
    }

    /*
         * Use this method to check if the paranthesis in a string is Correct or incorrect.
         * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
         * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
     */
    static void CheckParanthesis()
    {/*
        1. The stack so that I can match the closing parenthesis with the open ones I have stored in the stack.
           This is because if the stack is ({[( the next closing parenthesis has to be a ).
      
      */

        Console.WriteLine("Write a string with parenthesis and you will be informed if it is valid.");
        string input = Console.ReadLine();
        //Stack of chars so that I can save the open parenthesis and pop them in reverse order.
        Stack<char> openP = new();
        //Checks if input contains atleast 1 parenthesis of any kind.
        if (input.IndexOfAny(['(', ')', '[', ']', '{', '}']) >= 0)
        {
            //Iterate over all the characters in the string.
            foreach (char c in input)
            {
                //If the current character is a opening parenthesis it gets added to the stack.
                if (c == '(' || c == '{' || c == '[')
                    openP.Push(c);
                //If the current character is a closing parenthesis.
                else if (c == ')' || c == '}' || c == ']')
                {
                    //Pop the open parenthesis that is ontop in the stack. TryPop to avoid exception if empty. Discard bool since I'm not using it.
                    _ = openP.TryPop(out char pop); //pop equals ´\0´ if TryPop fails.

                    //If pop(open parenthesis or default value) doesn't match the current character, CW not valid and return.
                    if (c == ')' && pop != '(' ||
                        c == ']' && pop != '[' ||
                        c == '}' && pop != '{')
                    {
                        Console.WriteLine("The string you have given is not valid.");
                        return;
                    }
                }
            }
            //Runs if the foreach goes without any errors.
            if (openP.Count == 0)
                Console.WriteLine("Your string is valid!");
            else Console.WriteLine("Your string is not valid.");
        }
        else
            //Runs if the input does not contain any parenthesis.
            Console.WriteLine("Your string doesn't contain any parenthesis.");
    }

    //WIP
    static int RecursiveOdd(int n)
    {

        if (n == 1)
        {
            return 1;
        }

        return (RecursiveOdd(n - 1) + 2);

    }
}

