using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jump;

    private float move;
    private bool isOnFloor;
    private bool isMoving;

    public Rigidbody2D rb;
    public Animator anim;
    public SpriteRenderer sprite;

    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private AudioSource coinSound;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        /*if (rb == null)
            Debug.LogError("Rigidbody2D não encontrado no Player!");

        if (anim == null)
            Debug.LogError("Animator não encontrado no Player!");

        if (sprite == null)
            Debug.LogError("SpriteRenderer não encontrado no Player!");

        if (jumpSound == null)
            Debug.LogError("JumpSound não atribuído no Inspector!");

        if (coinSound == null)
            Debug.LogError("CoinSound não atribuído no Inspector!");*/
    }

    void Update()
    {
        move = Input.GetAxis("Horizontal");

        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocityY);

        if (Input.GetButtonDown("Jump") && isOnFloor)
        {
            rb.AddForce(new Vector2(rb.linearVelocityX, jump));
            isOnFloor = false;

            if (jumpSound != null)
                jumpSound.Play();
        }

        if (move > 0)
        {
            isMoving = true;
            sprite.flipX = false;
        }
        else if (move < 0)
        {
            isMoving = true;
            sprite.flipX = true;
        }
        else
        {
            isMoving = false;
        }

        anim.SetBool("isMoving", isMoving);
        anim.SetBool("isOnFloor", isOnFloor);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isOnFloor = true;
        }
    }

    public void PlayCoinSound()
    {
        if (coinSound != null)
            coinSound.Play();
    }
}