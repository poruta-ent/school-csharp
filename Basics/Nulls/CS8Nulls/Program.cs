#nullable enable

using System;

namespace CS8Nulls
{
    class Program
    {
        static void Main(string[] args)
        {
            var message = new Message()
            {
                From = null,
                Text = "text"
            };

            MessagePopulator.Populate(message);

            Console.WriteLine(message.From ?? "no from");
            Console.WriteLine(message.Text);
            Console.WriteLine(message.From!.Length); //! -> null forgiving operator
            Console.WriteLine(message.ConvertFromToUpper());
        
        }
    }
}
