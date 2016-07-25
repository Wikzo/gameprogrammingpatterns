using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _15_EventQueue
{
    struct PlayMessage
    {
        public int Id;
        public int Volume;
    }

    public static class Audio
    {
        private static int MAX_PENDING = 16;
        private static int _head;
        private static int _tail;
        private static PlayMessage[] _pending = new PlayMessage[MAX_PENDING];

        
        static Audio() 
        {
            //Console.WriteLine("Audio constructor called!");
            Initialize();
        }

        public static void Initialize()
        {
            _head = 0; // where requests are read from - oldest pending request 
            _tail = 0; // next enqueued request will be written to - just past the end of the queue
        }

        public static void PlaySound(int soundID, int volume)
        {
            // makes sure there is room to queue a new sound
            // using a ring buffer, the tail wraps around to the beginning of the array when it reaches the end
            Debug.Assert((_tail + 1)%MAX_PENDING != _head);

            _pending[_tail].Id = soundID;
            _pending[_tail].Volume = volume;
            _tail = (_tail + 1)%MAX_PENDING;
        }

        public static void Update()
        {
            // should realistically be called using an update loop (60 FPS)

            Console.WriteLine("Audio Update() loop called");

            for (int i = 0; i < MAX_PENDING; i++)
            {
                if (_head == _tail)
                    return;

                LoadResources(_head);
                StartSound(_pending[_head].Id, 1, _pending[_head].Volume);

                _head = (_head + 1) % MAX_PENDING;
            }
        }

        private static void StartSound(int ressource, int channel, int volume)
        {
            Console.WriteLine("--- Playing sound [{0}] at volume [{1}] ---", ressource, volume);
        }

        private static void LoadResources(int head)
        {
            // RessourceID resource = LoadSound(_pending[_head].Id);
            // int channel = FindOpenChannel();
            // if (channel == -1) return;
        }
    }
}
