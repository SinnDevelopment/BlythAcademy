using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour 
{
    public void Start () 
    {
        GetComponent<AudioSource>().PlayDelayed(1.0f);
	}
	
}
