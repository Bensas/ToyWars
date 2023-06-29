namespace Strategy
{
    public interface IMissile : IProjectile
    {
        public void SetRadar(IRadar radar);
    }
}