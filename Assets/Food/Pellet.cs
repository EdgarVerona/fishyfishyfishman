using UnityEngine;
using System.Collections;

public class Pellet : MonoBehaviour {

    public PelletManager manager;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    
    void OnTriggerEnter(Collider other)
    {
        Player player = (Player)other.gameObject.GetComponent("Player");
        if (player != null)
        {
            player.InformEaten(this);
            if (this.manager)
            {
                manager.Recycle(this.transform);
            }
            else
            {
                this.gameObject.SetActiveRecursively(false);
            }
        }
    }


}
