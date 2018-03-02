using System;
using System.Linq;
using System.Numerics;

class InstructionSet_broken
{
    static void Main()
    {
        checked
        {
            string institution = Console.ReadLine();

            while (institution != "END")
            {
                string[] codeArgs = institution.Split(' ').ToArray();
                BigInteger result = 0;

                switch (codeArgs[0])
                {
                    case "INC":
                    {
                        BigInteger operand = BigInteger.Parse(codeArgs[1]);
                        operand++;
                        result = operand;
                        break;
                    }
                    case "DEC":
                    {
                        BigInteger operand = BigInteger.Parse(codeArgs[1]);
                        operand--;
                        result = operand;
                        break;
                    }
                    case "ADD":
                    {
                        BigInteger operandOne = BigInteger.Parse(codeArgs[1]);
                        BigInteger operandTwo = BigInteger.Parse(codeArgs[2]);
                        result = operandOne + operandTwo;
                        break;
                    }
                    case "MLA":
                    {
                        BigInteger operandOne = BigInteger.Parse(codeArgs[1]);
                        BigInteger operandTwo = BigInteger.Parse(codeArgs[2]);
                        result = operandOne * operandTwo;
                        break;
                    }


                }
                Console.WriteLine(result);
                institution = Console.ReadLine();
            }
        }

    }
}