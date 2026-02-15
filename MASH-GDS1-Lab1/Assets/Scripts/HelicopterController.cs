using UnityEngine;

public class HelicopterController : MonoBehaviour
{

    public float moveSpeed = 5f;

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveX, moveY, 0f);

        transform.position += movement * moveSpeed * Time.deltaTime;
    }

}
