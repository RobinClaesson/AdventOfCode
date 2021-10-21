using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC;
using AoC.Directions;
namespace Day_13
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = IO.InputRows;

            List<Cart> carts = new List<Cart>();

            Size mapSize = new Size(input[0].Length, input.Count);
            char[,] map = new char[mapSize.Height, mapSize.Width];



            //Load map and carts
            for (int y = 0; y < mapSize.Height; y++)
            {
                for (int x = 0; x < mapSize.Width; x++)
                {
                    char c = input[y][x];

                    switch (c)
                    {
                        case 'v':
                        case '^':
                            map[y, x] = '|';
                            carts.Add(new Cart(x, y, c));
                            break;
                        case '>':
                        case '<':
                            map[y, x] = '-';
                            carts.Add(new Cart(x, y, c));
                            break;


                        default:
                            map[y, x] = c;
                            break;
                    }
                }
            }

            Point firstHit = new Point(-1, -1);
            //carts.Add(new Cart(0, 0, Direction.Down));
            while (carts.Count > 1)
            {
                //Console.Clear();
                //PrintMap(map, mapSize, carts);
                //Console.ReadKey();

                carts = carts.OrderBy(c => c.Y).ThenBy(c => c.X).ToList();

                //foreach (Cart cart in carts)
                //{
                //    cart.Update(map);

                //    foreach (Cart other in carts)
                //    {
                //        if (cart != other && cart.X == other.X && cart.Y == other.Y)
                //        {
                //            if (firstHit.X == -1)
                //                firstHit = new Point(cart.X, cart.Y);


                //        }
                //    }
                //}

                List<int> toRemove = new List<int>();

                for (int i = 0; i < carts.Count; i++)
                {
                    if (!toRemove.Contains(i))
                    {
                        carts[i].Update(map);

                        for (int j = 0; j < carts.Count; j++)
                        {
                            if (!toRemove.Contains(j))
                                if (i != j && carts[i].X == carts[j].X && carts[i].Y == carts[j].Y)
                                {
                                    if (firstHit.X == -1)
                                        firstHit = new Point(carts[i].X, carts[i].Y);

                                    toRemove.Add(i);
                                    toRemove.Add(j);
                                }
                        }
                    }
                }

                if (toRemove.Count > 0)
                {
                    toRemove.Sort();
                    toRemove.Reverse();

                    foreach (int i in toRemove)
                        carts.RemoveAt(i);
                }
            }

            //PrintMap(map, mapSize, carts);
            IO.Output(firstHit.X + "," + firstHit.Y);

            IO.Output(carts[0].X + "," + carts[0].Y);



            Console.ReadKey();
        }


        private static void PrintMap(char[,] map, Size mapSize, List<Cart> carts)
        {
            for (int y = 0; y < mapSize.Height; y++)
            {
                for (int x = 0; x < mapSize.Width; x++)
                {
                    bool printCart = false;
                    foreach (Cart cart in carts)
                        if (cart.X == x && cart.Y == y)
                        {
                            printCart = true;
                            Console.Write(cart);
                        }

                    if (!printCart)
                        Console.Write(map[y, x]);
                }

                Console.WriteLine();
            }
        }
    }
}
