namespace Prototype
{
    public class SpawnerFor<T> where T : new()
    {
        

        public T SpawnMonster()
        {
            return new T();
        }

        
    }
}