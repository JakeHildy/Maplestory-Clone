using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 10.0f;

    // Cached component references
    Rigidbody2D myRigidbody;

    private Vector2 initialLocalScale;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        initialLocalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        FlipSprite();
    }

    private void Run()
    {
        float controlThrow = Input.GetAxis("Horizontal"); // -1 to +1
        Vector2 playerVelocity = new Vector2(controlThrow * speed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;
    }


    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = IsRunning();
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(initialLocalScale.x * -Mathf.Sign(myRigidbody.velocity.x), initialLocalScale.y);
        }
    }

    private bool IsRunning()
    {
        return Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
    }
}
