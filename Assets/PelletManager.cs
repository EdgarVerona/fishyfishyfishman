using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PelletManager : ObjectHoster {

    public Transform prefab;
    public int numberOfPellets;
    public float recycleOffset;

    public Vector3 minPosition;
    public Vector3 maxPosition;

    private List<Transform> pellets;

	// Use this for initialization
	void Start () {
        pellets = new List<Transform>();

        for (int count = 0; count < numberOfPellets; count++)
        {
            Transform newPellet = (Transform)Instantiate(prefab);

            Pellet pelletBehavior = (Pellet)newPellet.GetComponent("Pellet");
            if (pelletBehavior != null)
            {
                pelletBehavior.manager = this;
            }

            pellets.Add(newPellet);

            Recycle(newPellet);
        }
	}

    // Update is called once per frame
    void Update()
    {
        for (int count = 0; count < numberOfPellets; count++)
        {
            if (pellets[count].localPosition.x + recycleOffset < Player.distanceTraveledX)
            {
                Recycle(pellets[count]);
            }
            else if (pellets[count].localPosition.x - recycleOffset > Player.distanceTraveledX)
            {
                Recycle(pellets[count]);
            }
            else if (pellets[count].localPosition.y + recycleOffset < Player.distanceTraveledY)
            {
                Recycle(pellets[count]);
            }
            else if (pellets[count].localPosition.y - recycleOffset > Player.distanceTraveledY)
            {
                Recycle(pellets[count]);
            }
        }
	}

    public void Recycle(Transform pellet)
    {
        Vector3 position = new Vector3(
            Random.Range(minPosition.x + Player.distanceTraveledX, maxPosition.x + Player.distanceTraveledX),
            Random.Range(minPosition.y + Player.distanceTraveledY, maxPosition.y + Player.distanceTraveledY),
            Random.Range(minPosition.z, maxPosition.z));

        pellet.localPosition = position;
        pellet.gameObject.SetActiveRecursively(true);
    }

    public override List<Transform> GetHostedObjects()
    {
        return this.pellets;
    }
}
