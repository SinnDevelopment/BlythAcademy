using UnityEngine;
using System.Collections;

public class AIController : MonoBehaviour 
{
    Vector2 dir;
    bool dirRight = true;
    float speed = 2f;
    public Transform Start;
    public Transform End;

    public void Awake()
    {
        
    }

    public void Update()
    {
        if (transform != null)
        {
            if (dirRight)
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            else
                transform.Translate(-Vector2.right * speed * Time.deltaTime);

            if (transform.position.x >= End.position.x)
            {
                dirRight = false;
            }

            if (transform.position.x <= Start.position.x)
            {
                dirRight = true;
            }
        }
    }

    public IEnumerator Move()
    {
        Vector2 dir = new Vector2(Random.Range(-30f,0f), 0);
        GetComponent<Rigidbody2D>().AddForce(dir * Random.Range(-1f, 1f));
        yield return new WaitForSeconds(4f);
    }
}
