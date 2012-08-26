using UnityEngine;
using System.Collections;

public class Goldfish : EnemyFish {

    public float speed = 15.0f;
    public float awarenessDistance = 50.0f;
    public Vector3 minZone = new Vector3(-200, -200, 0);
    public Vector3 maxZone = new Vector3(200, 200, 0);

    public Vector3 goalPosition = new Vector3(0, 0, 0);
    public bool hasGoal = false;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
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
                    this.goalPosition = new Vector3(
                        UnityEngine.Random.Range(this.transform.position.x + minZone.x, this.transform.position.x + maxZone.x),
                        UnityEngine.Random.Range(this.transform.position.y + minZone.y, this.transform.position.y + maxZone.y),
                        0
                    );

                    this.gameObject.transform.LookAt(this.goalPosition);
                    this.rigidbody.velocity = ((this.goalPosition - this.transform.position).normalized * this.speed);
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
        return 100.0f;
    }


    public override void ResetState()
    {
        this.goalPosition = new Vector3(0, 0, 0);
        this.rigidbody.velocity = new Vector3(0, 0, 0);
        this.hasGoal = false;
    }

}
