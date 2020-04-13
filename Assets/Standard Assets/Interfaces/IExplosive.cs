namespace Assets.Standard_Assets.Interfaces
{
    public interface IExplosive
    {
        float ExplosiveRadius { get; }
        int ExplosiveDamage { get; }
        bool IsExploding { get; set; }

        void Explode();
    }
}
