using Strategy;

namespace Commands
{
    public class CmdShoot : ICommand
    {
        private IWeapon _weapon;
        
        public CmdShoot(IWeapon weapon)
        {
            _weapon = weapon;
        }
        
        public void Execute() => _weapon.Attack();
    }
}