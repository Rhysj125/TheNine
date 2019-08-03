using Assets.Standard_Assets;
using Assets.Standard_Assets.Interfaces;
using System;
using UnityEngine;

public enum DamageType { Default, Melee, Bullet, Explosive }

public class Player : IPlayer, IDamageable
{

    private static readonly Player INSTANCE = new Player();

    public event EventHandler OnReload;

    //Constants
    private const int MAX_SPEED = 20;
    private const int MAX_HEALTH = 500;
    private const float MAX_RELOAD_SPEED = 10;
    private const float MAX_FIRERATE = 10;

    //Position
    public Vector3 position { get; set; }

    //Health related stats
    public int MaxHealthPoints { get; private set; }
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
        return INSTANCE;
    }

    private Player()
    {
        MaxHealthPoints = 100;
        CurrentHealth = MaxHealthPoints;
        ArmorMultiplier = 1.2f;

        AmmoCapacity = 10;
        AmmoCount = AmmoCapacity;
        ShotCount = 1;

        MovementSpeed = 10;
        ReloadSpeed = 0.5f;
        FireRate = 10;
    }

    /// <summary>
    /// Player takes damage.
    /// </summary>
    /// <param name="damage"></param>
    /// <returns></returns>
    public void TakeDamage(int damage)
    {
        if (damage > 0)
        {
            CurrentHealth -= (int) Math.Floor(damage * ArmorMultiplier);
        }

        if(CurrentHealth <= 0)
        {
            //Die();
        }
    }

    /// <summary>
    /// Explosive damage negates any armor held by the Player, dealing more damage.
    /// </summary>
    /// <param name="damage"></param>
    public void TakeExplosiveDamage(int damage)
    {
        if(damage > 0)
        {
            CurrentHealth -= damage;
        }

        if(CurrentHealth <= 0)
        {
            //Die()
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
        if(MaxHealthPoints + additionalHealth < MAX_HEALTH)
        {
            MaxHealthPoints += additionalHealth;
        }
        else
        {
            MaxHealthPoints = MAX_HEALTH;
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

    public void Destory()
    {
        //Would just show game over or something along those lines
    }
}
