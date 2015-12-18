using System;
using System.Collections.Generic;
using System.Diagnostics;
using DoubleBuffer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest_DoubleBuffer
{
    [TestClass]
    public class UnitTest1
    {
        private Stage _stage;
        private List<Comedian> _comedians;
        private const int NUMBER_OF_ACTORS = 3;

        Comedian Harry = new Comedian("Harry");
        Comedian Baldy = new Comedian("Baldy");
        Comedian Chump = new Comedian("Chump");

        [TestInitializeAttribute]
        public void Setup()
        {
            _stage = new Stage(NUMBER_OF_ACTORS);
            _comedians = new List<Comedian>();
        }

        [TestMethod]
        public void TestMethod1()
        {
            string expected = "Harry was slapped by somebody\n";
            string results = "";

            // the order they are added does not matter
            Harry.Face(Baldy);
            Baldy.Face(Chump);
            Chump.Face(Harry);

            expected += "Baldy was slapped by Harry\n";
            expected += "Chump was slapped by Baldy\n";
            expected += "Harry was slapped by Chump\n";

            _stage.AddActor(Harry, 0);
            _stage.AddActor(Baldy, 1);
            _stage.AddActor(Chump, 2);

            results += Harry.Slap("somebody");

            for (int i = 0; i < NUMBER_OF_ACTORS+1; i++)
                results += _stage.Update(i);

            Assert.AreEqual(expected, results);

        }
    }
}
