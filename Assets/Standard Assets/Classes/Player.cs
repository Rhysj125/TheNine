public class Player{

    private static readonly Player INSTANCE = new Player();

    private const int MAX_SPEED = 20;
    private const int MAX_HEALTH = 500;

    private int maxHealthPoints;
    private int currentHealth;
    private int ammo;
    private int movementSpeed;
    
    public static Player GetInstance()
    {
        return INSTANCE;
    }

    private Player()
    {
        maxHealthPoints = 100;
        currentHealth = maxHealthPoints;
        ammo = 10;
        movementSpeed = 10;
    }

    public void TakeDamage(int damage)
    {
        if(damage > 0)
        {
            currentHealth -= damage;
        }

        if(maxHealthPoints >= 0)
        {
            //Player dies
        }
    }

    public int GetMovementSpeed()
    {
        return movementSpeed;
    }

    public void IncreaseSpeed(int additionalSpeed)
    {
        if (movementSpeed + additionalSpeed < MAX_SPEED)
        {
            movementSpeed += additionalSpeed;
        }
        else
        {
            movementSpeed = MAX_SPEED;
        }
    }

    public void IncreaseHealth(int additionalHealth)
    {
        if(maxHealthPoints + additionalHealth < MAX_HEALTH)
        {
            maxHealthPoints += additionalHealth;
        }
        else
        {
            maxHealthPoints = MAX_HEALTH;
        }
    }
}
