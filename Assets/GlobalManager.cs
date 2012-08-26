using UnityEngine;
using System.Collections;

public class GlobalManager : MonoBehaviour {

    public static GlobalManager Instance;

    public Transform GUIMenu;
    public Transform GUI;
    public Transform playerPrefab;
    public Transform pelletManagerObject;
    public Transform goldfishManagerObject;
    public Transform clownfishManagerObject;

    public PelletManager pelletManager;
    public EnemyManager goldfishManager;
    public EnemyManager clownfishManager;

    private Player player;

	// Use this for initialization
	void Start () {
        GlobalManager.Instance = this;

        pelletManager = (PelletManager)pelletManagerObject.GetComponent("PelletManager");
        goldfishManager = (EnemyManager)goldfishManagerObject.GetComponent("EnemyManager");
        clownfishManager = (EnemyManager)clownfishManagerObject.GetComponent("EnemyManager");

        Transform playerObject = (Transform)Instantiate(this.playerPrefab);

        this.player = (Player)playerObject.GetComponent("Player");
	}
	
	// Update is called once per frame
    void Update()
    {
        if (!this.player.isAlive)
        {
            if (Input.GetButtonDown("Fire"))
            {
                this.goldfishManager.Reset();
                this.clownfishManager.Reset();
                this.player.Respawn();
            }
        }
    }

}
