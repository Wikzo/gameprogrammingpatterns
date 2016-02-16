namespace SubclassSandbox
{
    // Functionality in base class: rules of thumb:
    /*
        * If only one or few subclasses use the functionality, consider implementing it directly in those subclasses
        * Functionality that calls other methods (far away in a different corner) but does NOT change state can be in subclasses
        * Functionality that DOES change state should be moved to base class
        * Encapsulate fields in base class, even if they are just forwarding calls to another class
    */

    // base class
    public abstract class SuperPower
    {
        // instead of having a lot of methods (PlaySound(), StopSound(), MuteSound()), just have a container object
        private SoundPlayer _soundPlayer;
        private ParticleSystem _particleSystem;

        public SoundPlayer SoundPlayer
        {
            get { return _soundPlayer; }
        }

        // sandbox method that all subclasses must implement
        protected abstract void Activate();

        // separating constructor and initialization
        public void Initialize(ParticleSystem particle)
        {
            _particleSystem = particle;
        }

        // encapsulates the whole process to avoid forgetting to call Initialize()
        public SuperPower CreateSkyLaunch(ParticleSystem particle)
        {
            SuperPower power = new SkyLaunchSuperPower();
            power.Initialize(particle);
            return power;
        }

        // ALTERNATIVES:
        // * can also make Initialization and _particleSystem static if they do not need to be unique per sub class!
        //      (similar to a singleton)
        // * use Service Locator to fetch the needed particles when they are spawned

        protected double GetHeroX()
        {
            // do stuff
            return 0;
        }

        protected double GetHeroY()
        {
            // do stuff
            return 0;
        }

        protected double GetHeroZ()
        {
            // do stuff
            return 0;
        }

        protected void Move(double x, double y, double z)
        {
            // do stuff
        }

        protected void PlaySound(int soundID)
        {
            // do stuff
        }

        protected void SpawnParticle(int type, int count)
        {
            // do stuff
        }
    }
}