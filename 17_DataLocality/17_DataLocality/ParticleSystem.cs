using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17_DataLocality
{
    class ParticleSystem
    {
        private int _numberOfParticles;
        private static int MAX_PARTICLES = 100000;
        private static Particle[] _particles;

        static ParticleSystem ()
        {
            _particles = new Particle[MAX_PARTICLES];
        }

        public void UpdateParticlesNaive()
        {
            // updates all particles at all times
            for (int i = 0; i < _numberOfParticles; i++)
            {
                _particles[i].Update();
            }
        }

        public void UpdateParticlesFlag()
        {
            // only updates particles that are active
            // HOWEVER: we still skipp across memory a lot, since the processing aren't contiguous
            for (int i = 0; i < _numberOfParticles; i++)
            {
                if (_particles[i].IsActive)
                    _particles[i].Update();
            }
        }

        private int _numActive;
        public void UpdateParticlesSorted()
        {
            // array is sorted so that _numActive describes all the active particles, while the rest are inactive
            for (int i = 0; i < _numActive; i++)
            {
                _particles[i].Update();
            }
        }

        public void ActiveParticle(int index)
        {
            // make sure particle is not already active
            Debug.Assert(index >= _numActive);

            // swap it with the first inactive particle right after the active particles
            Particle temp = _particles[_numActive]; // first inactive particle
            _particles[_numActive] = _particles[index]; // now it holds an active particle
            _particles[index] = temp; // moved to inactive particlces

            _numActive++;
        }

        public void DeactivateParticle(int index)
        {
            // make sure the particle is not already deactive
            Debug.Assert(index < _numActive);

            _numActive--;

            // swap it with the last active particle right before the inactive one
            Particle temp = _particles[_numActive]; // last active particle
            _particles[_numActive] = _particles[index]; // now it holds an inactive particle
            _particles[index] = temp; // now it holds an active particle
        }
    }
}
