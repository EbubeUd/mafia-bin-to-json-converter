using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BinaryProject
{
    
   public  class Program
    {
      
        static void Main(string[] args)
        {

            //string binPath = "D:/Games/Mafia/tables/vehicles.bin";
            //string jsonPath = "D:/RemoteWork/Mafia/";
            //BinReaderService.ReadBinFile(binPath, jsonPath, true); 
            //Console.ReadLine();

            int sol = solution(new int[6] { 1, 3, 6, 4, 1, 2 });
            Console.WriteLine(sol);
            Console.ReadLine();
        }



        public static int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)

            Array.Sort(A);
            int highestNumber = A[A.Length - 1];
            int currentNumber = A[0];
            int ans = highestNumber + 1;
            if (highestNumber <= 0) return 1;

            for (int i = 1; i < A.Length - 1; i++)
            {
                if (A[i] < 0)
                {
                    currentNumber = A[i];
                    continue;
                }

                if ((A[i] - currentNumber) > 1)
                {
                    ans = currentNumber + 1;

                    break;
                }

                currentNumber = A[i];
            }
            return ans;
        }

    }
}
