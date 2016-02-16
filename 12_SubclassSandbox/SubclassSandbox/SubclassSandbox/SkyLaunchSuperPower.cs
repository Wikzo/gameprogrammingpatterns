namespace SubclassSandbox
{
    public class SkyLaunchSuperPower : SuperPower
    {
        protected override void Activate()
        {
            // on the ground, spring into air
            if (GetHeroY() == 0)
            {
                Move(5, 100, 5);
                SoundPlayer.StopSound();
                SoundPlayer.PlaySound(3);
                //PlaySound(3);
                SpawnParticle(0, 100);
            }
            // near the ground, do double jump
            else if (GetHeroY() < 10f)
            {
                Move(5, GetHeroY() * -20, 5);
                SoundPlayer.StopSound();
                SoundPlayer.PlaySound(2);
                //PlaySound(2);
                SpawnParticle(2, 23);
            }
            // way up in the air, so do a dive attack
            else
            {
                Move(5, 5, 234);
                SoundPlayer.StopSound();
                SoundPlayer.PlaySound(6);
                //PlaySound(6);
                SpawnParticle(4, 49);
            }
            
        }
    }
}