using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC;

namespace Day_15
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List<string> input = IO.InputRows;

            List<Ingredient> baseIngredients = new List<Ingredient>();

            foreach (string row in input)
            {
                string[] words = row.Split(' ');

                baseIngredients.Add(new Ingredient(words[0],
                                                        int.Parse(words[2].Substring(0, words[2].Length - 1)),
                                                        int.Parse(words[4].Substring(0, words[4].Length - 1)),
                                                        int.Parse(words[6].Substring(0, words[6].Length - 1)),
                                                        int.Parse(words[8].Substring(0, words[8].Length - 1)),
                                                        int.Parse(words[10])));
            }



            List<List<Ingredient>> recepies = Receipes(baseIngredients, 100);


            Part1(recepies);

            //Part 2
            int maxScore = int.MinValue;

            foreach (List<Ingredient> recepie in recepies)
            {
                int score = CookieScore(recepie);
                if (score > maxScore && CalorieCount(recepie) == 500)
                    maxScore = score;
            }

            IO.Output(maxScore, true);


            Console.ReadKey();
        }

        private static void Part1(List<List<Ingredient>> recepies)
        {
            int maxScore = int.MinValue;

            foreach (List<Ingredient> recepie in recepies)
            {
                int score = CookieScore(recepie);
                if (score > maxScore)
                    maxScore = score;
            }

            IO.Output(maxScore);
        }

        static List<List<Ingredient>> Receipes(List<Ingredient> baseIngredients, int recepieSum)
        {
            List<List<Ingredient>> recepies = new List<List<Ingredient>>();

            if (baseIngredients.Count == 1)
            {
                List<Ingredient> lastIngredient = new List<Ingredient>();
                lastIngredient.Add(new Ingredient(baseIngredients[0], recepieSum));
                recepies.Add(lastIngredient);
            }
            else
            {
                for (int i = 0; i < baseIngredients.Count; i++)
                {
                    List<Ingredient> otherIngredinets = new List<Ingredient>();
                    for (int j = 0; j < baseIngredients.Count; j++)
                        if (j != i)
                            otherIngredinets.Add(baseIngredients[j]);

                    for (int j = 0; j <= recepieSum; j++)
                    {
                        List<List<Ingredient>> others = Receipes(otherIngredinets, recepieSum - j);

                        foreach (List<Ingredient> other in others)
                            other.Add(new Ingredient(baseIngredients[i], j));

                        recepies.AddRange(others);
                    }
                }
            }



            return recepies;
        }

        static int CookieScore(List<Ingredient> ingredients)
        {
            int[] scores = new int[4];
            int totalScore = 1;

            foreach (Ingredient ingredient in ingredients)
            {
                scores[0] += ingredient.capacity;
                scores[1] += ingredient.durability;
                scores[2] += ingredient.flavor;
                scores[3] += ingredient.texture;
            }

            foreach (int score in scores)
            {
                if (score > 0)
                    totalScore *= score;
                else
                    totalScore *= 0;
            }

            return totalScore;
        }

        static int CalorieCount(List<Ingredient> ingredients)
        {
            int count = 0;

            foreach (Ingredient ingredient in ingredients)
                count += ingredient.calories;

            return count;
        }
    }
}
