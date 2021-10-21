using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using AoC;
namespace Day_10
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = IO.InputRows;
            List<Light> lights = new List<Light>();

            //Create lights
            foreach (string row in input)
            {
                lights.Add(new Light(row));
            }

            int seconds = 0;
            while (true)
            {
                //Update lights
                foreach (Light l in lights)
                    l.Update();

                seconds++;

                //Caclulate viewport 
                Vector2 min = new Vector2(int.MaxValue);
                Vector2 max = new Vector2(int.MinValue);

                foreach (Light light in lights)
                {
                    if (light.Position.X < min.X)
                        min.X = light.Position.X;
                    if (light.Position.X > max.X)
                        max.X = light.Position.X;
                    if (light.Position.Y < min.Y)
                        min.Y = light.Position.Y;
                    if (light.Position.Y > max.Y)
                        max.Y = light.Position.Y;
                }

                Rectangle view = new Rectangle((int)min.X, (int)min.Y, (int)(max.X - min.X), (int)(max.Y - min.Y));

                //"Font" Size is 10
                if (view.Height <= 10)
                {
                    Console.Clear();
                    PrintLights(lights, view);
                    Console.WriteLine("Seconds: " + seconds);
                    Console.ReadKey();
                    break;
                }
            }
        }

        private static void PrintLights(List<Light> lights, Rectangle view)
        {
            StringBuilder sb = new StringBuilder();

            for (int y = view.Top; y <= view.Bottom; y++)
            {
                for (int x = view.Left; x <= view.Right; x++)
                {
                    bool wrote = false;
                    for (int i = 0; i < lights.Count(); i++)
                        if (lights[i].Position.X == x && lights[i].Position.Y == y)
                        {
                            sb.Append("#");
                            wrote = true;
                            break;
                        }


                    if (!wrote)
                        sb.Append(".");
                }

                sb.AppendLine();
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
