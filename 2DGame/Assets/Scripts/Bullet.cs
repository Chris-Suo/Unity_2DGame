using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject explosion;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("GG");
        Destroy(gameObject);
        GameObject temp = Instantiate(explosion, transform.position, transform.rotation);
        Destroy(temp, 1.5f);
    }
}
