using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum Approach
{
    ApproachOne,
    ApproachTwo
}

namespace DoubleBuffer
{
    class Program
    {
        static void Main(string[] args)
        {

            Stage stage = new Stage();

            Comedian Harry = new Comedian("Harry");
            Comedian Baldy = new Comedian("Baldy");
            Comedian Chump = new Comedian("Chump");

            Harry.Face(Baldy);
            Baldy.Face(Chump);
            Chump.Face(Harry);


            Approach approach = Approach.ApproachTwo;

            switch (approach)
            {
                case Approach.ApproachOne:
                    stage.AddActor(Harry, 0);
                    stage.AddActor(Baldy, 1);
                    stage.AddActor(Chump, 2);
                    break;
                case Approach.ApproachTwo:
                    stage.AddActor(Harry, 2);
                    stage.AddActor(Baldy, 1);
                    stage.AddActor(Chump, 0);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            Harry.Slap();
            stage.Update();
            stage.Update();
            stage.Update();

            Console.ReadLine();
        }
    }
}
