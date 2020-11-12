using System;

public class Test
{

    public static void Main(string[] args)
    {
        
        int noOfTests = int.Parse(args[0]);

        for (int i=1;i<=noOfTests;i++)
        {
            var isPrime = true;
            int test = int.Parse(args[i]);
            for (int j=2;j<test;j++)
            {
                if (test%j == 0)
                {
                    Console.WriteLine("NIE");
                    isPrime = false;
                    break;
                }
            }
            if (isPrime)
            {
                Console.WriteLine("TAK");
            }
        }
    }

    //rozwiązanie z inputem przez konsolę
    /*
	public static void Main()
	{
		bool userInputStatus = false;
		int numberOfTests = 0;
		do
		{
			Console.Write("How much tests - integer greater than 0 and less than 100.000: ");
			userInputStatus = int.TryParse(Console.ReadLine(), out numberOfTests);
			if (numberOfTests <= 0 || numberOfTests >= 100000) { userInputStatus = false; }
		} while (!userInputStatus);

        int[] tests = new int[numberOfTests];
        for (int i = 0; i < numberOfTests; i++)
        {
            do
		    {
			    Console.Write($"Enter number to test {i + 1} out of {numberOfTests}: ");
			    userInputStatus = int.TryParse(Console.ReadLine(), out int test);
			    if (test < 1 || test > 10000) 
                { 
                    Console.WriteLine($"Wrong input {test}. Enter integer greater than 0 and less than 10.001.");
                    userInputStatus = false; 
                }
                if (userInputStatus)
                {
                    tests[i] = test;
                }
            } while (!userInputStatus);
        }

        foreach (var number in tests)
        {
            var isPrime = true;
            for(int i =2; i < number; i++)
            {
                if (number % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            if (isPrime)
            {
                Console.WriteLine("TAK");
            }
            else
            {
                Console.WriteLine("NIE");
            }
        }
	}
    */
}