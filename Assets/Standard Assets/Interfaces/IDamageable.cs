using Assets.Standard_Assets.Enums;

namespace Assets.Standard_Assets
{
    public interface IDamageable
    {
        int BaseHealth { get; }

        void TakeDamage(int amount, DamageType damageType);
        void Destory();
    }
}