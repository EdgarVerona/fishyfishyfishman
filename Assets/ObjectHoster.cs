using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class ObjectHoster : MonoBehaviour {

    public abstract List<Transform> GetHostedObjects();

}
