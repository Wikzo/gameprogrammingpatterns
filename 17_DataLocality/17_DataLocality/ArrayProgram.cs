using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17_DataLocality
{
    // Not really useful, since it does not use pointers as in the book example

    class ArrayProgram
    {
        static int numberOfEntities = 10000;

        private static GameEntity[] _entities;
        private static AIComponent[] _aiComponents;
        private static PhysicsComponent[] _physicsComponents;
        private static RenderComponent[] _renderComponents;

        static void Main(string[] args)
        {
            _entities = new GameEntity[numberOfEntities];
            _aiComponents = new AIComponent[numberOfEntities];
            _physicsComponents = new PhysicsComponent[numberOfEntities];
            _renderComponents = new RenderComponent[numberOfEntities];

            CreateEntitiesInArray();

            Stopwatch sw = new Stopwatch();
            sw.Start();

            int index = 0;
            while (index < 10)
            {
                for (int i = 0; i < numberOfEntities; i++)
                {
                    _entities[i].Ai.Update();
                }

                for (int i = 0; i < numberOfEntities; i++)
                {
                    _entities[i].Physics.Update();
                }

                for (int i = 0; i < numberOfEntities; i++)
                {
                    _entities[i].Render.Update();
                }

                index++;
            }

            sw.Stop();

            Console.WriteLine("---- Using entities and pointers: ----");
            Console.WriteLine("Elapsed={0}", sw.Elapsed);

            sw.Restart();

            index = 0;
            while (index < 10)
            {
                for (int i = 0; i < numberOfEntities; i++)
                {
                    _aiComponents[i].Update();
                }

                for (int i = 0; i < numberOfEntities; i++)
                {
                    _physicsComponents[i].Update();
                }

                for (int i = 0; i < numberOfEntities; i++)
                {
                    _renderComponents[i].Update();
                }

                index++;
            }

            sw.Stop();

            Console.WriteLine("---- Using arrays with components: ----");
            Console.WriteLine("Elapsed={0}", sw.Elapsed);


            Console.ReadLine();
        }

        private static void CreateEntitiesInArray()
        {
            for (int i = 0; i < numberOfEntities; i++)
            {
                PhysicsComponent p = new PhysicsComponent();
                AIComponent ai = new AIComponent();
                RenderComponent r = new RenderComponent();

                _physicsComponents[i] = p;
                _aiComponents[i] = ai;
                _renderComponents[i] = r;

                GameEntity g = new GameEntity(p, ai, r);
                _entities[i] = g;
            }
        }
    }
}
