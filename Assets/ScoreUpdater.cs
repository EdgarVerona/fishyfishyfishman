using UnityEngine;
using System.Collections;

public class ScoreUpdater : MonoBehaviour {

    private GUIText text;

	// Use this for initialization
	void Start () {
        GUIText textComponent = (GUIText)this.GetComponent("GUIText");
        if (textComponent != null)
        {
            this.text = textComponent;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Player.instance != null)
        {
            this.text.text = "Score: " + (int)Mathf.Floor(Player.instance.score);
        }
	}
}
