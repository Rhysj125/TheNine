using Assets.Standard_Assets;
using Assets.Standard_Assets.Enums;
using Assets.Standard_Assets.Interfaces;
using System;
using UnityEngine;

public class Player : IPlayer, IDamageable
{

    private static Player Instance;

    public event EventHandler OnReload;

    //Constants
    private const int MAX_SPEED = 20;
    private const int MAX_HEALTH = 500;
    private const float MAX_RELOAD_SPEED = 10;
    private const float MAX_FIRERATE = 10;

    //Position
    public Vector3 position { get; set; }

    //Health related stats
    public int BaseHealth { get; private set; }
    public int CurrentHealth { get; private set; }
    public float ArmorMultiplier { get; private set; }

    //Ammo related stats
    public int AmmoCapacity { get; private set; }
    public int AmmoCount { get; private set; }
    public int ShotCount { get; private set; }

    //Speed related stats
    public float MovementSpeed { get; private set; }
    public float ReloadSpeed { get; private set; }
    public float FireRate { get; private set; }

    public static Player GetInstance()
    {
        if (Instance == null)
        {
            Instance = new Player();
        }

        return Instance;
    }

    private Player()
    {
        ResetToDefault();
    }

    public void ResetToDefault()
    {
        BaseHealth = 100;
        ArmorMultiplier = 1.2f;
        CurrentHealth = BaseHealth;

        AmmoCapacity = 10;
        AmmoCount = AmmoCapacity;
        ShotCount = 1;

        MovementSpeed = 10;
        ReloadSpeed = 0.5f;
        FireRate = 10;
    }

    public void TakeDamage(int damage, DamageType damageType)
    {
        if (damage > 0)
        {
            switch (damageType)
            {
                case DamageType.Melee:
                case DamageType.Bullet:
                    CurrentHealth -= Convert.ToInt32(Math.Floor(damage / ArmorMultiplier));
                    break;

                case DamageType.Explosive:
                    CurrentHealth -= damage;
                    break;

                default:
                    throw new NotImplementedException($"Damage Type: {damageType} not implemented");
            }
        }

        if(CurrentHealth <= 0)
        {
            //Die();
        }
    }

    public void IncreaseMovementSpeed(float additionalSpeed)
    {
        if (MovementSpeed + additionalSpeed < MAX_SPEED)
        {
            MovementSpeed += additionalSpeed;
        }
        else
        {
            MovementSpeed = MAX_SPEED;
        }
    }

    public void IncreaseMaxHealth(int additionalHealth)
    {
        if(BaseHealth + additionalHealth < MAX_HEALTH)
        {
            BaseHealth += additionalHealth;
        }
        else
        {
            BaseHealth = MAX_HEALTH;
        }
    }

    public void Shoot()
    {
        AmmoCount -= ShotCount;

        if(AmmoCount <= 0)
        {
            Reload();
        }
    }

    public void Reload()
    {
        if (AmmoCount != AmmoCapacity)
        {
            AmmoCount = AmmoCapacity;
            OnReload.Invoke(this, EventArgs.Empty);
        }
    }

    public void Heal(int amount)
    {
        if(CurrentHealth + amount < MAX_HEALTH)
        {
            CurrentHealth += amount;
        }
        else
        {
            CurrentHealth = MAX_HEALTH;
        }
    }

    public void IncreaseReloadSpeed(float additonalSpeed)
    {
        
    }

    public void IncreaseAmmoCapacity(int additonalAmmoCapacity)
    {
        AmmoCapacity += additonalAmmoCapacity;
    }

    public void IncreaseFireRate(int additionalFireRate)
    {
        FireRate += additionalFireRate;
    }

    public void SetInteractable(Interactable interactable)
    {
        
    }

    public void Destory()
    {
        //Would just show game over or something along those lines
    }
}
