using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pointer : MonoBehaviour {

    public Transform nearestObject;
    
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        
        nearestObject = null;
        float nearestDistance = float.MaxValue;

        foreach (Transform currentObject in GlobalManager.Instance.pelletManager.GetHostedObjects())
        {
            float currentDistance = (currentObject.position - this.transform.position).sqrMagnitude;

            if (currentDistance < nearestDistance)
            {
                nearestDistance = currentDistance;
                nearestObject = currentObject;
            }
        }

        if (nearestObject != null)
        {
            this.transform.LookAt(nearestObject);
            this.gameObject.SetActiveRecursively(true);
        }
        else
        {
            this.gameObject.SetActiveRecursively(false);
        }
	}
}
