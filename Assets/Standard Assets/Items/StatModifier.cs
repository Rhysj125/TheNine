using System;
using UnityEngine;

namespace Assets.Standard_Assets.Items
{
    public enum BaseStat { Health, MovementSpeed, FireRate, ReloadSpeed, Ammo, ShotCount };
    public enum VariableStat { Health, Ammo}

    [Serializable]
    class BaseStatModifier
    {
        [SerializeField]
        private BaseStat stat;
        [SerializeField]
        private float value;

        public BaseStatModifier(BaseStat _stat, float _value)
        {
            stat = _stat;
            value = _value;
        }

        public void ApplyStat()
        {
            switch (stat)
            {
                case BaseStat.Ammo:
                    Player.GetInstance().IncreaseAmmoCapacity((int)value);
                    break;

                case BaseStat.FireRate:
                    Player.GetInstance().IncreaseFireRate((int) value);
                    break;

                case BaseStat.Health:
                    Player.GetInstance().IncreaseMaxHealth((int)value);
                    break;

                case BaseStat.MovementSpeed:
                    Player.GetInstance().IncreaseMovementSpeed(value);
                    break;

                case BaseStat.ReloadSpeed:
                    //Player.GetInstance().IncreaseReloadSpeed(value);
                    break;

                default:
                    break;
            }
        }
    }

    [Serializable]
    class VariableStatModifier
    {
        [SerializeField]
        private VariableStat stat;
        [SerializeField]
        private float value;

        public VariableStatModifier(VariableStat _stat, float _value)
        {
            stat = _stat;
            value = _value;
        }

        public void ApplyStat()
        {
            switch (stat)
            {
                case VariableStat.Ammo:
                    throw new NotSupportedException();
                    //Player.GetInstance().Heal((int)value);
                    break;

                case VariableStat.Health:
                    Player.GetInstance().Heal((int)value);
                    break;

                default:
                    break;
            }
        }
    }
}
