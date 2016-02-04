using System;

// http://gafferongames.com/game-physics/fix-your-timestep/

namespace GameLoop
{
    class Program
    {

        private const double FIXED_TIME_STEP = 1000d/60d;

        private static DateTime _current;
        private static DateTime _previous;

        private static double _elapsed;
        private static double _lag;

        private static int _updateCalls;
        private static int _renderCalls;
        private static double _totalRunTime;

        static void Main(string[] args)
        {
            _previous = DateTime.Now;

            while (_totalRunTime < 1000)
                GameLoop();

            Console.WriteLine(String.Format("Total Update() calls: {0}\nTotal Render() calls: {1}", _updateCalls, _renderCalls));
            Console.ReadLine();
        }

        static void GameLoop()
        {
            _current = DateTime.Now;
            _elapsed = (_current - _previous).TotalMilliseconds;
            _previous = _current;

            _totalRunTime += _elapsed;
            _lag += _elapsed;

            ProcessInput();

            while (_lag > FIXED_TIME_STEP)
            {
                Update(FIXED_TIME_STEP);
                _lag -= FIXED_TIME_STEP;
            }

            Render(_elapsed);
        }

        static void ProcessInput() { }

        static void Update(double delta)
        {
            SimulateHeavyCalculations();

            Console.WriteLine(String.Format("Updating [{0} ms]", delta));
            _updateCalls++;
        }

        private static void SimulateHeavyCalculations()
        {
            Random random = new Random();
            int randomSleep = random.Next(100);
            var startDt = DateTime.Now;
            while (true)
            {
                if ((DateTime.Now - startDt).TotalMilliseconds >= randomSleep)
                    break;
            }
        }

        static void Render(double delta)
        {
            Console.WriteLine(String.Format("Rendering [{0} ms]", delta));
            _renderCalls++;

        }
    }
}
