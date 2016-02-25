namespace TypeObject
{
    public class Breed
    {
        private int _startingHealth;
        private string _attack;
        private Breed _parent;

        private bool _allowForDynamicParentChanges = true;

        public Breed(Breed parent, int startingHealth, string attack)
        {
            // can store parent field to allow for modifications during runtime
            if (_allowForDynamicParentChanges)
                _parent = parent;
            else if (!_allowForDynamicParentChanges)
            {
                if (parent != null)
                {
                    if (_startingHealth == 0) _startingHealth = _parent.StartingHealth;
                    if (_attack == null) _attack = _parent.Attack;
                }
            }

            _startingHealth = startingHealth;
            _attack = attack;
        }

        public Monster CreateMonster(string name)
        {
            return new Monster(this, name);
        }

        public int StartingHealth
        {
            get
            {
                // shared data through inheritance
                // this allows for dynamical modifications but also takes more memory, since it has to store the parent
                if (_allowForDynamicParentChanges)
                {
                    if (_parent == null || _startingHealth != 0)
                        return _startingHealth;
                    else
                        return _parent.StartingHealth;
                }
                else
                    return _startingHealth;
            }
        }

        public string Attack
        {
            get
            {
                // shared data through inheritance
                // this allows for dynamical modifications but also takes more memory, since it has to store the parent
                if (_allowForDynamicParentChanges)
                {
                    if (_parent == null || _attack != null)
                        return _attack;
                    else
                        return _parent.Attack;
                }
                else
                    return _attack;
            }
        }
    }
}