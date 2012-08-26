using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;



public class Clownfish : EnemyFish
{

    public float speed = 10.0f;
    public float awarenessDistance = 50.0f;
    
    public Vector3 goalPosition = new Vector3(0, 0, 0);
    public bool hasGoal = false;

    // Use this for initialization
    void Start()
    {
    }

    void Update()
    {
        if (this.hasGoal)
        {
            float currentDistance = (this.transform.position - this.goalPosition).sqrMagnitude;

            if (currentDistance < 0.1f)
            {
                this.hasGoal = false;
            }
        }
        else
        {
            if (Player.instance != null)
            {
                float currentDistance = (this.transform.position - Player.instance.transform.position).magnitude;

                if (currentDistance < this.awarenessDistance)
                {
                    this.gameObject.transform.LookAt(Player.instance.gameObject.transform);
                    this.goalPosition = Player.instance.transform.position;
                    this.rigidbody.velocity = ((Player.instance.transform.position - this.transform.position).normalized * this.speed);
                    this.hasGoal = true;
                }
                else
                {
                    this.rigidbody.velocity = new Vector3(0, 0, 0);
                    this.hasGoal = false;
                }
            }
        }
        
        
    }

    public override float GetScore()
    {
        return 300.0f;
    }

    public override void ResetState()
    {
        this.goalPosition = new Vector3(0, 0, 0);
        this.rigidbody.velocity = new Vector3(0, 0, 0);
        this.hasGoal = false;
    }

}
