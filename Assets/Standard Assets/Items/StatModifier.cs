using System;
using UnityEngine;

namespace Assets.Standard_Assets.Items
{
    public enum Stat { Health, MovementSpeed, FireRate, ReloadSpeed, Ammo, ShotCount };

    [Serializable]
    class StatModifier
    {
        [SerializeField]
        private Stat stat;
        [SerializeField]
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
                    Player.GetInstance().IncreaseAmmoCapacity((int)value);
                    break;

                case Stat.FireRate:
                    Player.GetInstance().IncreaseFireRate((int) value);
                    break;

                case Stat.Health:
                    Player.GetInstance().IncreaseMaxHealth((int)value);
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
