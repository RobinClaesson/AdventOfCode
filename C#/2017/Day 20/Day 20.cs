using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC;
namespace Day_20
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = IO.InputRows;

            List<Particle> particles = new List<Particle>();

            foreach (string row in input)
                particles.Add(new Particle(row));

            int index = 0;

            //Part 1
            for (int i = 0; i < particles.Count; i++)
            {
                if (particles[i].a.Length() < particles[index].a.Length())
                    index = i;
            }

            IO.Output(index);


            //Part 2
            int lastCount = -1;
            int updatesSinceCol = 0;
            while (updatesSinceCol < 1000)
            {
                lastCount = particles.Count;
                //Update
                foreach (Particle particle in particles)
                    particle.Update();

                //check collision
                for (int i = 0; i < particles.Count; i++)
                    for (int j = 0; j < particles.Count; j++)
                        if (i != j && particles[i].p == particles[j].p)
                        {
                            particles[i].alive = false;
                            particles[j].alive = false;
                            updatesSinceCol = 0;
                        }

                //Removes dead particles
                for (int i = 0; i < particles.Count; i++)
                    if (!particles[i].alive)
                    {
                        particles.RemoveAt(i);
                        i--;
                    }

                updatesSinceCol++;
            }

            
            IO.Output(particles.Count);
            Console.ReadKey();
        }
    }
}
