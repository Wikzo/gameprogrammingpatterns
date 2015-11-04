namespace Prototype
{
    public class Spawner
    {
        private Monster prototype;

        public Spawner(Monster prototype)
        {
            this.prototype = prototype;
        }

        

        public Monster SpawnMonster()
        {
            return this.prototype.Clone();
        }

        // -------------------------------
        // using callbacks instead:
        public delegate Monster SpawnCallback();
        private event SpawnCallback _onSpawnMonster;

        public Spawner(SpawnCallback spawnCallback)
        {
            _onSpawnMonster += spawnCallback;
        }

        public Monster SpawnMonsterViaCallback()
        {
            if (_onSpawnMonster != null)
                return _onSpawnMonster();
            else
                return null;
        }
    }
}