using System;
using System.Numerics;

public class NumSysConvert
{
    private static readonly string Digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    public string FromDecimal(BigInteger number, int targetBase)
    {
        if (targetBase < 2 || targetBase > 36)
            throw new ArgumentException("base must be from 2 to 36");

        if (number == 0) return "0";

        bool negative = number < 0;
        number = BigInteger.Abs(number);
        string result = "";

        while (number > 0)
        {
            result = Digits[(int)(number % targetBase)] + result;
            number /= targetBase;
        }

        return negative ? "-" + result : result;
    }

    public BigInteger ToDecimal(string number, int sourceBase)
    {
        if (sourceBase < 2 || sourceBase > 36)
            throw new ArgumentException("base must be from 2 to 36");

        string numStr = number.ToUpper().Trim();
        bool negative = numStr.StartsWith("-");
        if (negative) numStr = numStr.Substring(1);

        BigInteger result = 0;

        foreach (char c in numStr)
        {
            int value = Digits.IndexOf(c);
            if (value < 0 || value >= sourceBase)
                throw new ArgumentException($"invalid '{c}'");
            result = result * sourceBase + value;
        }

        return negative ? -result : result;
    }

    public string Bin(BigInteger n)
    {
        return FromDecimal(n, 2);
    }

    public string Oct(BigInteger n)
    {
        return FromDecimal(n, 8);
    }

    public string Hex(BigInteger n)
    {
        return FromDecimal(n, 16);
    }
}