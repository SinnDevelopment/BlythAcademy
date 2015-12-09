using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public Transform ShotgunTransform;
    public GameObject bulletPrefab;
    public Vector2 Speed;
    public GameObject player;
    public float BulletExpiryTime = 1.0f;
    public void AddBullet()
    {
        var Clone = (Instantiate(bulletPrefab, ShotgunTransform.position, ShotgunTransform.rotation)) as GameObject;
        ShootBullet(Clone, Speed);
    }

    public void ShootBullet(GameObject bullet, Vector2 forceDir)
    {
        bullet.GetComponent<Rigidbody2D>().AddForce(forceDir * (player.transform.localScale.x / 0.2704639f));
        Destroy(bullet, BulletExpiryTime);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.RightControl))
            AddBullet();
    }

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag != "Squirrel") return;
        GUIManager.AddKey();
        ScoreManager.AddScore(200);
        coll.gameObject.SetActive(false);
        Destroy(coll.gameObject);
    }

}
