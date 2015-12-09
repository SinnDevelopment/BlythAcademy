using UnityEngine;
using System.Collections;

public class KeyManager : MonoBehaviour
{
    public int Keys;
	// Use this for initialization
	void Start () 
    {

	}
	
	// Update is called once per frame
    public void Update ()
    {
        if (Keys < 5) return;
        for (int i = 0; i < 4; i++)
            GUIManager.AddKey();
    }
}
