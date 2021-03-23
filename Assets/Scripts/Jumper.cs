using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[System.Serializable]

public class Jumper : MonoBehaviour
{
    [SerializeField] private PlayerSide[] sides;
    [SerializeField] private SpriteRenderer[] playerSideColors;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 4000;
    [SerializeField] private int health = 4;
    [SerializeField] private bool isDead = false;
    [SerializeField] private bool deathless = false;



    [SerializeField] private float timeBeforeGameStarts;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        for (int i = 0; i < playerSideColors.Length; i++)
        {
            playerSideColors[i].color = GameManager.instance.GetColor(i);
        }
    }

    private void Update()
    {


    }

    private void Jump()
    {
        rb.velocity = new Vector2(0, 0);
        rb.AddForce(new Vector2(0, jumpForce));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isDead && collision.gameObject.tag == "Platform")
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

                //Debug.Log($"{sides[i].GetColor()} and { sides[i].GetPlatformColor()} == {(sides[i].GetColor().Equals(sides[i].GetPlatformColor()))}");
                if (sides[i].GetColor() == sides[i].GetPlatformColor())
                {
                    sides[i].BouncePlatform();
                    GameManager.instance.AddScore(1);
                    GameManager.instance.BackgroundStep();
                }
                else if (sides[i].GetPlatformColor() == sides[i].GetPlatformDefaultColor())
                {
                    sides[i].BouncePlatform();
                }
                else
                {
                    TakeDamage();
                }
            }
        }
    }

    private void TakeDamage()
    {
        if (deathless) { return; }
        health -= 1;
        UI_script.instance.RemoveHeart(health);
        if (health <= 0)
        {
            Die();
            return;
        }

    }

    private void Die()
    {
        GameManager.instance.GameOver();

        rb.freezeRotation = false;
        rb.constraints = RigidbodyConstraints2D.None;
        jumpForce = jumpForce * 0.3f;
        isDead = true;
    }

    public void SetDefaultSettings()
    {
        isDead = false;
        health = 4;
        jumpForce = 4000;

        rb.velocity = new Vector2(0, -1);
        rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        rb.freezeRotation = true;
        rb.gravityScale = 9.8f;
    }

    public void ChangePlayerGravity(float gravity)
    {
        rb.gravityScale = gravity;
    }
}



