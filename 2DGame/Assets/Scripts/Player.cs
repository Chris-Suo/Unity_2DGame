using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Move speed"), Range(0, 1000)]
    public float speed = 10.5f;
    [Header("Jump heigh"), Range(0, 3000)]
    public int jump = 100;
    [Header("Is on the ground"), Tooltip("check if player is on the ground")]
    public bool isGrounded = false;
    [Header("Bullet")]
    public GameObject bullet;
    [Header("Point"), Tooltip("Bullet start position")]
    public Transform point;
    [Header("Bullet speed"), Range(0, 5000)]
    public int speedBullet = 800;
    [Header("Sound Fire")]
    public AudioClip soundFire;
    [Header("HP"), Range(0, 10)]
    public int live = 3;

    private int score;
    private AudioSource aud;
    private Rigidbody2D rig;
    private Animator ani;

   
    private void Awake()
    {       
        rig = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }

    
    private void Move()
    {        
        float h = Input.GetAxis("Horizontal");       
        rig.velocity = new Vector2(h * speed, rig.velocity.y);
        
    }

    
    private void Jump()
    {

    }

    
    private void Fire()
    {

    }

    
    private void Dead(string obj)
    {

    }
}
