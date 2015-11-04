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
    }
}