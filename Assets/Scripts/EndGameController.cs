using UnityEngine;
using System.Collections;

public class EndGameController : MonoBehaviour {

    SpriteRenderer rend;
    public GameObject Player;
	// Use this for initialization
    public void Start () {
        rend = this.gameObject.GetComponent<SpriteRenderer>();
        Player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
    public void Update () 
    {
	    if(GUIManager.keys >= 4)
        {
            //active
            if(this.name.Contains("83") || this.name.Contains("71"))
            {
                rend.enabled = false;
            }
            //active
            if (this.name.Contains("59") || this.name.Contains("47"))
            {
                rend.enabled = true;
                
            }
            if (Player.transform.position.x >= 1.07f && Player.transform.position.x <= 1.81f)
            {
                Debug.Log("Game Over :D");
                Application.LoadLevel(2);
            }
        }
        
	}
}
