using Strategy;

namespace Commands
{
    public class CmdApplyDamage : ICommand
    {
        private IDamageable _damageable;
        private float _damage;
        
        public CmdApplyDamage(IDamageable damageable, float damage)
        {
            _damageable = damageable;
            _damage = damage;
        }
        
        public void Execute() => _damageable.TakeDamage(_damage);
    }
}