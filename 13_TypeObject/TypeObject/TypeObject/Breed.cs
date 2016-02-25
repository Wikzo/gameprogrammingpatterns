namespace TypeObject
{
    public class Breed
    {
        public Breed Parent { get; set; }
        public string Name = "NA";

        private int _startingHealth;
        private string _attack;


        private bool _allowForDynamicParentChanges = true;

        public Breed(Breed parent, int startingHealth, string attack)
        {
            // can store parent field to allow for modifications during runtime
            if (_allowForDynamicParentChanges)
                Parent = parent;
            else if (!_allowForDynamicParentChanges)
            {
                if (parent != null)
                {
                    if (_startingHealth == 0) _startingHealth = Parent.StartingHealth;
                    if (_attack == null) _attack = Parent.Attack;
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
                    if (Parent == null || _startingHealth != 0)
                        return _startingHealth;
                    else
                        return Parent.StartingHealth;
                }
                else
                    return _startingHealth;
            }
            set { _startingHealth = value; }
        }

        public string Attack
        {
            get
            {
                // shared data through inheritance
                // this allows for dynamical modifications but also takes more memory, since it has to store the parent
                if (_allowForDynamicParentChanges)
                {
                    if (Parent == null || _attack != null)
                        return _attack;
                    else
                        return Parent.Attack;
                }
                else
                    return _attack;
            }
            set { _attack = value; }

        }
    }
}