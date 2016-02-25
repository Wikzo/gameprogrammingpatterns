using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeObject
{
    class Program
    {
        static void Main(string[] args)
        {
            /////////////////////////////////////////////////////////////////////
            // two ways of creating & initializing monsters

            // create monster directly using breed - allocation and initialization happens automatically inside constructor
            Breed troll = new Breed(null, 10, "Troll attack");
            Monster monsterTrollOne = new Monster(troll, "Troll1");

            // using breed to create monster - separates object allocation and initialization
            Monster monsterTrollTwo = troll.CreateMonster("Troll2");

            Console.WriteLine(string.Format("Troll 1 HP: {0}; Troll 1 attack: {1}",
                monsterTrollOne.GetHealth(),
                monsterTrollOne.GetAttack()));

            /////////////////////////////////////////////////////////////////////

            Console.WriteLine();

            /////////////////////////////////////////////////////////////////////
            // using inheritance to create base monster breed
            Breed wizardBreed = new Breed(null, 5, "Generic magic attack");
            Breed fireWizardBreed = new Breed(wizardBreed, 0, "Fire magic attack"); // passing in 0: inherits from parent
            Breed spellCasterWizardBreed = new Breed(wizardBreed, 8, null);

            Monster m1 = wizardBreed.CreateMonster("M1");
            Monster m2 = fireWizardBreed.CreateMonster("M2");
            Monster m3 = spellCasterWizardBreed.CreateMonster("M3");

            Console.WriteLine(m1.ToString());
            Console.WriteLine(m2.ToString());
            Console.WriteLine(m3.ToString());

            /////////////////////////////////////////////////////////////////////

            Console.ReadLine();
        }
    }
}
