using UnityEngine;
using UnityEngine.SceneManagement;

public class HelicopterController : MonoBehaviour
{
    public float moveSpeed = 5f;

    Rigidbody2D rb;
    Camera cam;
    SpriteRenderer sr;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        sr = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector2 input = new Vector2(moveX, moveY).normalized;
        Vector2 target = rb.position + input * moveSpeed * Time.fixedDeltaTime;

        target = ClampToCamera(target);

        rb.MovePosition(target);
    }

    Vector2 ClampToCamera(Vector2 target)
    {
        if (cam == null) return target;

        Vector3 min = cam.ViewportToWorldPoint(new Vector3(0f, 0f, 0f));
        Vector3 max = cam.ViewportToWorldPoint(new Vector3(1f, 1f, 0f));

        float halfW = 0.25f;
        float halfH = 0.25f;

        if (sr != null)
        {
            halfW = sr.bounds.extents.x;
            halfH = sr.bounds.extents.y;
        }

        float x = Mathf.Clamp(target.x, min.x + halfW, max.x - halfW);
        float y = Mathf.Clamp(target.y, min.y + halfH, max.y - halfH);

        return new Vector2(x, y);
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tree"))
        {
            GameManager gm = FindFirstObjectByType<GameManager>();
            if (gm != null)
                gm.GameOver();
        }
    }
}