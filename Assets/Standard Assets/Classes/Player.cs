public class Player{

    private static readonly Player INSTANCE = new Player();

    //Constants
    private const int MAX_SPEED = 20;
    private const int MAX_HEALTH = 500;
    private const float MAX_RELOAD_SPEED = 10;
    private const float MAX_FIRERATE = 10;

    //Health related stats
    public int MaxHealthPoints { get; private set; }
    public int CurrentHealth { get; private set; }

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

        AmmoCapacity = 10;
        AmmoCount = AmmoCapacity;
        ShotCount = 1;

        MovementSpeed = 10;
        ReloadSpeed = 10;
        FireRate = 10;
    }

    /// <summary>
    /// Player takes damage and if the player dies returns true;
    /// </summary>
    /// <param name="damage"></param>
    /// <returns></returns>
    public bool TakeDamage(int damage)
    {
        if(damage > 0)
        {
            CurrentHealth -= damage;
        }

        if(CurrentHealth >= 0)
        {
            //Player dies
            return true;
        }

        return false;
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
        AmmoCount = AmmoCapacity;
    }

    public void Heal(int amount)
    {
        if(CurrentHealth + amount > MAX_HEALTH)
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
}
