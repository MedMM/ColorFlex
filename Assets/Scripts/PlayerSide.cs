using UnityEngine;

public class PlayerSide : MonoBehaviour
{
    private float raycastDistance = 6.5f;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private PlatformScript GetPlatformScript()
    {
        return Physics2D.Raycast(transform.position, transform.right, 10).collider.gameObject.GetComponent<PlatformScript>();
    }

    public bool IsSideHit()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 6.5f);

        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }

    public Color GetPlatformColor()
    {
        return GetPlatformScript().GetPlatformColor();
    }

    public Color GetPlatformDefaultColor()
    {
        return GetPlatformScript().GetDefaultColor();
    }

    public Color GetColor()
    {
        return spriteRenderer.color;
    }

    public void BouncePlatform()
    {
        GetPlatformScript().NextColor();
    }
}
