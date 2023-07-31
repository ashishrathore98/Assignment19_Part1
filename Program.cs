using System;

public delegate int ArithmeticOperation(int a, int b);

public class Program
{
    public static int Add(int a, int b)
    {
        return a + b;
    }

    public static int Subtract(int a, int b)
    {
        return a - b;
    }

    public static int Multiply(int a, int b)
    {
        return a * b;
    }

    public static int Divide(int a, int b)
    {
        if (b == 0)
        {
            Console.WriteLine("Cannot divide by zero.");
        }
        return a / b;
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Delegates");
        ArithmeticOperation addOperation = Add;
        ArithmeticOperation subOperation = Subtract;
        ArithmeticOperation mulOperation = Multiply;
        ArithmeticOperation divOperation = Divide;

        while (true)
        {
            Console.WriteLine("Enter two integers (or type 'exit' to quit):");
            string user_input = Console.ReadLine();

            if (user_input == "exit")
            {
                break;
            }

            int num1;
            if (!int.TryParse(user_input, out num1))
            {
                Console.WriteLine("Invalid input for the first integer. Please enter a valid integer.");
                continue;
            }

            string user_input2 = Console.ReadLine();
            int num2;
            if (!int.TryParse(user_input2, out num2))
            {
                Console.WriteLine("Invalid input for the second integer. Please enter a valid integer.");
                continue;
            }

            Console.WriteLine("Choose an arithmetic operation:");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");

            string operationChoice = Console.ReadLine();
            int choice;
            if (!int.TryParse(operationChoice, out choice) || choice < 1 || choice > 4)
            {
                Console.WriteLine("Invalid choice. Please enter a valid number between 1 and 4.");
                continue;
            }

            int result = 0;

            switch (choice)
            {
                case 1:
                    result = addOperation(num1, num2);
                    Console.WriteLine($"Sum is: {result}");
                    break;
                case 2:
                    result = subOperation(num1, num2);
                    Console.WriteLine($"Difference is: {result}");
                    break;
                case 3:
                    result = mulOperation(num1, num2);
                    Console.WriteLine($"Product is: {result}");
                    break;
                case 4:
                    try
                    {
                        result = divOperation(num1, num2);
                        Console.WriteLine($"Division is: {result}");
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
            }
        }
    }
}