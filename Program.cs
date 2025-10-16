using System;
using System.Numerics;

class Program
{
    static void Main()
    {
        var converter = new NumSysConvert();

        while (true)
        {
            Console.WriteLine("\n1:10-p  2:p-10  3:arithmetic  4:Bin  5:Oct  6:Hex  0:exit");
            Console.Write("option: ");
            var choice = Console.ReadLine();

            if (choice == "0") break;

            try
            {
                switch (choice)
                {
                    case "1":
                        Console.Write("number in 10: ");
                        var n1 = BigInteger.Parse(Console.ReadLine());
                        Console.Write("base p: ");
                        var p1 = int.Parse(Console.ReadLine());
                        Console.WriteLine($"result: {converter.FromDecimal(n1, p1)}");
                        break;

                    case "2":
                        Console.Write("base p: ");
                        var p2 = int.Parse(Console.ReadLine());
                        Console.Write("number in p: ");
                        var s2 = Console.ReadLine();
                        Console.WriteLine($"in 10: {converter.ToDecimal(s2, p2)}");
                        break;

                    case "3":
                        Console.Write("base p: ");
                        var p3 = int.Parse(Console.ReadLine());
                        Console.Write("first number: ");
                        var a = Console.ReadLine();
                        Console.Write("second number: ");
                        var b = Console.ReadLine();
                        Console.Write("operation (+-*/): ");
                        var op = Console.ReadLine()[0];

                        var x = converter.ToDecimal(a, p3);
                        var y = converter.ToDecimal(b, p3);

                        var r = op switch
                        {
                            '+' => x + y,
                            '-' => x - y,
                            '*' => x * y,
                            '/' => y != 0 ? x / y : throw new DivideByZeroException(),
                            _ => throw new Exception("unknown operation")
                        };

                        Console.WriteLine($"10: {r}  p: {converter.FromDecimal(r, p3)}");
                        break;

                    case "4":
                        Console.Write("number in 10: ");
                        var binNum = BigInteger.Parse(Console.ReadLine());
                        Console.WriteLine($"Bin: {converter.Bin(binNum)}");
                        break;

                    case "5":
                        Console.Write("number in 10: ");
                        var octNum = BigInteger.Parse(Console.ReadLine());
                        Console.WriteLine($"Oct: {converter.Oct(octNum)}");
                        break;

                    case "6":
                        Console.Write("number in 10: ");
                        var hexNum = BigInteger.Parse(Console.ReadLine());
                        Console.WriteLine($"Hex: {converter.Hex(hexNum)}");
                        break;

                    default:
                        Console.WriteLine("unknown option");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"error: {ex.Message}");
            }
        }
    }
}