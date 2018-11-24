using Assets.Standard_Assets.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player{

    private const int MAX_SPEED = 20;
    private int healthPoints;
    private int ammo;
    private int movementSpeed;
    
    public Player()
    {
        healthPoints = 100;
        ammo = 10;
        movementSpeed = 10;
    }

    public void TakeDamage(int damage)
    {
        if(damage > 0)
        {
            healthPoints -= damage;
        }

        if(healthPoints >= 0)
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
    }

    public void PickUpItem(Item item)
    {

    }

}
