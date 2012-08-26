using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class EnemyFish : Fish
{
    public EnemyManager manager;

    public virtual float GetScore()
    {
        return 100.0f;
    }


    public abstract void ResetState();

    public override void HandleBodyCollision(GameObject other)
    {
        Debug.Log("Body Collide check against " + other.GetType().Name);
        GameObjectProperties props = (GameObjectProperties)other.GetComponent("GameObjectProperties");

        if (props != null)
        {
            if (props.isPlayer)
            {
                Player player = (Player)other.GetComponent("Player");
                Player.instance.InformEaten(this);
                manager.InformDeath(this);
            }
            if (props.isLethal)
            {
                Player.instance.InformKilled(this);
                manager.InformDeath(this);
            }
        }
        else
        {
            Debug.Log("Body Cannot collide with " + other.GetType().Name + ", no properties");
        }
    }

    public override void HandleHeadCollision(GameObject other)
    {
        Debug.Log("Head Collide check against " + other.GetType().Name);
        GameObjectProperties props = (GameObjectProperties)other.GetComponent("GameObjectProperties");

        if (props != null)
        {
            if (props.isPlayer)
            {
                Player player = (Player)other.GetComponent("Player");
                player.Die();
            }
            if (props.isLethal)
            {
                manager.InformDeath(this);
            }
        }
        else
        {
            Debug.Log("Head Cannot collide with " + other.GetType().Name + ", no properties");
        }
    }

}
