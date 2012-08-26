using UnityEngine;
using System.Collections;

public class BackgroundMoveManager : MonoBehaviour {

    public float repeatEveryX = 500;
    public float repeatEveryY = 500;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float fractionX = 1 - ((Player.distanceTraveledX % repeatEveryX) / repeatEveryX);
        float fractionY = 1 - ((Player.distanceTraveledY % repeatEveryY) / repeatEveryY);

        this.renderer.material.SetTextureOffset("_BumpMap", new Vector2(fractionX, fractionY));
	}
}
