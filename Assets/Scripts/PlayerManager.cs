using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour 
{
    public GameObject Player;
    private static int Deaths;
	// Use this for initialization
    public void Start ()
    {
        if (Player == null)
            this.enabled = false;
        Deaths = 0;
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if(Player.transform.position.y <= -15 )
            ResetPlayer();
	}

    public void ResetPlayer()
    {
        Player.transform.position = new Vector2(0, 3);
        Deaths++;
    }
    public static int GetDeaths()
    {
        return Deaths;
    }
}
