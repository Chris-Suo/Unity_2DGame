using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Move Speed"), Range(0, 1000)]
    public float speed = 10.5f;
    [Header("Bullet")]
    public GameObject bullet;
    [Header("Bullet Point")]
    public Transform point;
    [Header("Bullet Speed"), Range(0, 5000)]
    public int speedBullet = 2000;

    public AudioClip soundFire;
    [Header("Track Range"), Range(0, 1000)]
    public float rangeTrack = 10.5f;
    [Header("Attack Range"), Range(0, 1000)]
    public float rangeAttack = 4.5f;
    [Header("Attack Interval"), Range(0, 5)]
    public float intervalAttack = 2.5f;

    public int score = 50;

    private Transform player;
    private Rigidbody2D rig;
    private AudioSource aud;
    private Animator ani;
    private float timer;
    //private GameManager gm;

    private void Move()
    {
        if (player.position.x > transform.position.x)
        {
            transform.eulerAngles = Vector3.zero;
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        float dis = Vector3.Distance(player.position, transform.position);

        if (dis < rangeAttack)
        {
            ani.SetBool("isRunning", false);
            rig.velocity = new Vector2(0, rig.velocity.y);
            Fire();
        }
        else if (dis < rangeTrack)
        {
            rig.velocity = transform.right * speed;
            rig.velocity = new Vector2(rig.velocity.x, rig.velocity.y);
            ani.SetBool("isRunning", true);
        }
    }

    private void Fire()
    {
        if (timer >= intervalAttack)
        {
            timer = 0;
            aud.PlayOneShot(soundFire, Random.Range(0.3f, 0.5f));
            GameObject temp = Instantiate(bullet, point.position, point.rotation);
            temp.GetComponent<Rigidbody2D>().AddForce(transform.right * speedBullet + transform.up * 100);
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    private void Dead()
    {
        enabled = false;
        ani.SetBool("isDead", true);
        GetComponent<CapsuleCollider2D>().enabled = false;
        rig.Sleep();
        Destroy(gameObject, 2.5f);
        //    gm.AddScore(score);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0, 0, 1, 0.3f);
        Gizmos.DrawSphere(transform.position, rangeTrack);

        Gizmos.color = new Color(1, 0, 0, 0.3f);
        Gizmos.DrawSphere(transform.position, rangeAttack);
    }

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();

        //gm = FindObjectOfType<GameManager>();

        player = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Dead();
        }
    }

}
