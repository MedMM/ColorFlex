using UnityEngine;
[System.Serializable]

public class Jumper : MonoBehaviour
{
    [SerializeField] private PlayerSide[] sides;
    [SerializeField] private SpriteRenderer[] playerSideColors;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 4000;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        for (int i = 0; i < playerSideColors.Length; i++)
        {
            playerSideColors[i].color = GameManager.instance.GetColor(i);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(0, 0);
        rb.AddForce(new Vector2(0, jumpForce));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            CheckCollisions();
            Jump();
        }
    }

    private void CheckCollisions()
    {
        for (int i = 0; i < sides.Length; i++)
        {
            if (sides[i].IsSideHit())
            {
                if (sides[i].GetColor() == sides[i].GetPlatformColor())
                {
                    sides[i].BouncePlatform();
                    GameManager.instance.AddScore(1);
                }
                else if (sides[i].GetPlatformColor() == sides[i].GetPlatformDefaultColor())
                {
                    sides[i].BouncePlatform();
                }
                else
                {
                    //TakeDamage();
                }
            }
        }
    }
}



