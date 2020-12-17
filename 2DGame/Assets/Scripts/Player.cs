using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Move speed"), Range(0, 1000)]
    public float speed = 10.5f;
    [Header("Jump heigh"), Range(0, 3000)]
    public int jump = 100;
    //[Header("Is on the ground"), Tooltip("check if player is on the ground")]
    //public bool isGrounded = false;
    [Header("Bullet")]
    public GameObject bullet;
    [Header("Point"), Tooltip("Bullet start position")]
    public Transform point;
    [Header("Bullet speed"), Range(0, 5000)]
    public int speedBullet = 1200;
    [Header("Sound Fire")]
    public AudioClip soundFire;
    [Header("Sound Jump")]
    public AudioClip soundJump;
    [Header("HP"), Range(0, 10)]
    public int live = 3;

    public Vector2 offset;
    public float radis = 0.3f;

    private int score;
    private AudioSource aud;
    private Rigidbody2D rig;
    private Animator ani;


    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Move();
        Jump();
        Fire();
    }


    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        rig.velocity = new Vector2(h * speed, rig.velocity.y);

        ani.SetBool("isRunning", h != 0);
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);

        }

    }


    private void Jump()
    {
        if (Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y) + offset, radis, 1 << 8))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rig.AddForce(transform.up * jump);
                aud.PlayOneShot(soundJump);
            }
        }
    }

    private void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject ibullet = Instantiate(bullet, point.position, point.rotation);
            ibullet.GetComponent<Rigidbody2D>().AddForce(transform.right * speedBullet + transform.up * 50);

            aud.PlayOneShot(soundFire);
        }

    }


    private void Dead(string obj)
    {
        if (obj.Equals("DeadZone"))
        {
            ani.SetBool("isDead", true);
            enabled = false;
            Invoke("Replay", 2);
        }
    }

    private void Replay()
    {
        SceneManager.LoadScene("Zone1");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Dead(collision.gameObject.name);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawSphere(new Vector2(transform.position.x, transform.position.y) + offset, radis);
    }
}
