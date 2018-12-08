namespace Assets.Standard_Assets.Items
{
    public enum Stat { Health, MovementSpeed, FireRate, ReloadSpeed, Ammo };

    class StatModifier
    {
        private Stat stat;
        private float value;

        public StatModifier(Stat _stat, float _value)
        {
            stat = _stat;
            value = _value;
        }

        public void ApplyStatBoost()
        {
            switch (stat)
            {
                case Stat.Ammo:
                    //Player.GetInstance().IncreaseAmmo(value);
                    break;

                case Stat.FireRate:
                    //Player.GetInstance().IncreaseFireRate(value);
                    break;

                case Stat.Health:
                    Player.GetInstance().IncreaseHealth((int)value);
                    break;

                case Stat.MovementSpeed:
                    Player.GetInstance().IncreaseMovementSpeed(value);
                    break;

                case Stat.ReloadSpeed:
                    //Player.GetInstance().IncreaseReloadSpeed(value);
                    break;

                default:
                    break;
            }
        }
    }
}
