namespace DoubleBuffer
{
    public class Comedian : Actor
    {
        public Comedian(string name) : base(name) { }

        public Actor Facing { get; set; }

        public void Face(Actor actor)
        {
            Facing = actor;
        }

        public override string Update()
        {
            if (CurrentSlapped)
                return Facing.Slap(this);
            else
                return null;
        }
    }
}