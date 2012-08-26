using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public abstract class Fish : MonoBehaviour
{
        
    public GameObject BodyCollider;
    public GameObject HeadCollider;

    public abstract void HandleBodyCollision(GameObject other);

    public abstract void HandleHeadCollision(GameObject other);

}
