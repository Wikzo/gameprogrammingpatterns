namespace TypeObject
{
    public class Monster
    {
        private Breed _breed; // in C++: use friend class
        private int _currentHealth;
        private string _name = "NA";
        
        // considerations: should breed variable be encapsulated or exposed?
        
        // if exposed: outside code can change it --> harder to maintain
        // if encapsulated: can hide complexity of code; can make state logic in how a value is returned
            // e.g., to give a specific attack string when health is low
            // has to write forward methods for everything that is exposed

        public Monster(Breed breed, string name)
        {
            _breed = breed;
            _name = name;
            _currentHealth = breed.StartingHealth;
        }

        public int GetHealth()
        {
            return _currentHealth;
        }

        public string GetAttack()
        {
            return _breed.Attack;
        }

        public override string ToString()
        {
            return string.Format("Name: {0}; Starting Health: {1}; Current Health: {2}; Attack: {3}",
                this._name,
                _breed.StartingHealth,
                _currentHealth,
                _breed.Attack
                );
        }
    }
}