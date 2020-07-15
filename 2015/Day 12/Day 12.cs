using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using AoC;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Day_12
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = IO.Input;
            IO.Output(SumOfAllNumbers(input));

            //Part 2
            //https://www.reddit.com/r/adventofcode/comments/3wh73d/day_12_solutions/cxw7z9h?utm_source=share&utm_medium=web2x

            //Skapar ett dynamiskt objekt eftersom vi inte vet om vi har object, array eller value
            dynamic o = JsonConvert.DeserializeObject(input);

            IO.Output(GetSum(o, "red"));


            Console.ReadKey();

        }

        private static int SumOfAllNumbers(string input)
        {

            //Removes every char that isnt a number or a comma
            char[] allowed = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ',', '-' };

            int i = 0;
            while (i < input.Length)
            {
                if (!allowed.Contains(input[i]))
                {
                    input = input.Remove(i, 1);
                }

                else
                    i++;
            }

            //Separates all the numbers and adds them
            int sum = 0;
            string[] numbers = input.Split(',');

            for (i = 0; i < numbers.Length; i++)
                if (numbers[i] != "")
                    sum += int.Parse(numbers[i]);

            return sum;

        }


        static long GetSum(JObject obj, string avoid = null)
        {
            //Om vi har ett objekt kollar vi om den har en property som vi vill undvika
            bool shouldAvoid = false;

            foreach (JToken child in obj.Children())
            {
                if (child.Type == JTokenType.Property)
                {
                    //om child är en property och värdena innehåller vad vi vill undvika sätter vi det till sant
                    //vi kollar om count == 1 eftersom den gav false-positive utslag på arrayer som innehöll avoid
                    if (child.Values().Contains(avoid) && child.Values().Count() == 1)
                    {
                        shouldAvoid = true;
                    }

                }

            }

           
            if (shouldAvoid)
                return 0;


            //Om vi inte ska undvika det så räknar vi ut summan av childs
            long sum = 0;
            foreach (JToken child in obj.Children())
            {
                //Skapar ett dynamiskt objekt eftersom vi inte vet om vi har object, array eller value
                dynamic o = child as dynamic;
                sum += GetSum(o, avoid);
            }

            return sum;
        }


        static long GetSum(JArray arr, string avoid)
        {
            //Om det är en array så räknar vi bara igenom summan för alla children till objektet
            long sum = 0;
            foreach (JToken child in arr)
            {
                //Skapar ett dynamiskt objekt eftersom vi inte vet om vi har object, array eller value
                dynamic o = child as dynamic;
                sum += GetSum(o, avoid);
            }

            return sum;
        }

        static long GetSum(JValue val, string avoid)
        {
            //Om det är ett value så kollar vi om det är ett heltal och räknar isf upp summan med det 
            if (val.Type == JTokenType.Integer)
                return (long)val;

            else return 0;
        }

        static long GetSum(JProperty prop, string avoid)
        {
            //Om det är en property som är ett objekt så hamnar den här där vi räknar igenom objektet
            long sum = 0;

            foreach (JToken child in prop)
            {
                dynamic o = child as dynamic;
                sum += GetSum(o, avoid);
            }


            return sum;
        }

    }
}
