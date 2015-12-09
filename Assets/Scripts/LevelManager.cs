using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour 
{
    public static void LoadLevel(int level)
    {
        if(Application.loadedLevel.Equals(0))
        {

        }
    }
    public static void LoadLevel()
    {
        if (Application.loadedLevel.Equals(0))
        {
            Application.LoadLevel(1);
        }
    }
}
