using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    private static float Score = 0f;
    public GameObject Player;
    public GameObject Squirrel;

    public Transform SquirrelStart;
    PlayerManager pm;

    public void Start () 
    {
        if(Player == null)
        {
            Player = GameObject.Find("Player");
        }
        pm = Player.GetComponent<PlayerManager>();
        
        Score = 0;
	}

    public void Update ()
    {
        if (!this.enabled) return;
        if (!(Player.transform.position.y <= -40f)) return;
        if (Squirrel == null) return;
        Squirrel.transform.position = SquirrelStart.transform.position;
        RemoveScore(100f);
        pm.ResetPlayer();
    }

    public static void RemoveScore(float amount)
    {
        Score -= amount;
    }
    public static void AddScore(float amount)
    {
        Score += amount;
    }
    public static float GetScore()
    {
        return Score;
    }
}
