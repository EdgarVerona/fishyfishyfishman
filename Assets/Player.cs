using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static float distanceTraveledX;
    public static float distanceTraveledY;

    public static float baseSpeed = 25.0f;
    public static Player instance;

    public float score = 0.0f;
    public float speed = baseSpeed;

    public Camera chaseCam;

    public Transform missilePrefab;

    private GameObject lockedObject;

    public  bool isAlive = false;

    public int missileCount = 3;
    
    void Start()
    {
        Player.instance = this;

        this.Die();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        this.gameObject.rigidbody.MovePosition(new Vector3(this.gameObject.rigidbody.position.x + (speed * Time.deltaTime * horizontal), this.gameObject.rigidbody.position.y + (speed * Time.deltaTime * vertical), this.gameObject.rigidbody.position.z));

        distanceTraveledX = this.gameObject.rigidbody.position.x;
        distanceTraveledY = this.gameObject.rigidbody.position.y;

        this.score += Time.deltaTime;
    }


    public void Die()
    {
        this.gameObject.active = false;
        this.isAlive = false;
        GlobalManager.Instance.GUIMenu.gameObject.SetActiveRecursively(true);
        GlobalManager.Instance.GUI.gameObject.SetActiveRecursively(false);
    }

    public void Respawn()
    {
        this.isAlive = true;
        this.speed = Player.baseSpeed;
        this.score = 0.0f;
        this.gameObject.active = true;
        GlobalManager.Instance.GUIMenu.gameObject.SetActiveRecursively(false);
        GlobalManager.Instance.GUI.gameObject.SetActiveRecursively(true);
    }

    public void LockNearestObject()
    {
    }



    internal void InformEaten(MonoBehaviour informer)
    {
        if (informer is Pellet)
        {
            this.speed += 10.0f;
            this.score += 100.0f;
        }
        else if (informer is EnemyFish)
        {
            this.score += ((EnemyFish)informer).GetScore();
            this.missileCount++;
        }
    }

    internal void InformKilled(MonoBehaviour informer)
    {
        // If you kill something with a missile, you get bonus score but you don't get a replenishment of missiles.
        if (informer is EnemyFish)
        {
            this.score += ((EnemyFish)informer).GetScore();
        }
    }
}