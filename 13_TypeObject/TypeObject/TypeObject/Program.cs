using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TypeObject
{
    class Program
    {
        private static List<Monster> MonstersCreatedViaJSON;


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
            Breed fireWizardBreed = new Breed(wizardBreed, 0, "Fire magic attack");
            // passing in 0: inherits from parent
            Breed spellCasterWizardBreed = new Breed(wizardBreed, 8, null);

            Monster m1 = wizardBreed.CreateMonster("M1");
            Monster m2 = fireWizardBreed.CreateMonster("M2");
            Monster m3 = spellCasterWizardBreed.CreateMonster("M3");

            Console.WriteLine(m1.ToString());
            Console.WriteLine(m2.ToString());
            Console.WriteLine(m3.ToString());

            /////////////////////////////////////////////////////////////////////

            /////////////////////////////////////////////////////////////////////
            // created dynamically via json file
            Console.WriteLine("\nCreated via JSON file:");

            ReadJsonData("BreedJson.json");
            foreach (var m in MonstersCreatedViaJSON)
                Console.WriteLine(m.ToString());

            /////////////////////////////////////////////////////////////////////

            Console.ReadLine();
        }


        public static void ReadJsonData(String path)
        {
            // using http://www.newtonsoft.com/json/help/html/Introduction.htm

            // remember to put the "BreedJson.json" file in bin/Debug folder!

            try
            {
                // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(path))
                {
                    string lines = sr.ReadToEnd();
                    MonstersCreatedViaJSON = new List<Monster>(CreateMonstersFromJsonArray(lines));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        private static List<Monster> CreateMonstersFromJsonArray(string jsonString)
        {
            // NOTE: does not work with object reference to parents

            List<Monster> monsterList = new List<Monster>();
            JArray jArray = JArray.Parse(jsonString);

            foreach (var a in jArray)
            {
                Breed b = (Breed)a.ToObject(typeof(Breed));
                Monster m = b.CreateMonster(b.Name);
                monsterList.Add(m);
            }

            return monsterList;
        }
    }
}
