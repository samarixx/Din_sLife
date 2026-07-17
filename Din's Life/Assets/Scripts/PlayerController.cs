using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 5f;
    public Rigidbody2D playerRb;
    
    Vector2 movimento;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        movimento.x = Input.GetAxisRaw("Horizontal");
        movimento.y = Input.GetAxisRaw("Vertical");
        
    }
    
    private void FixedUpdate()
    {
        playerRb.MovePosition(playerRb.position + movimento * speed * Time.fixedDeltaTime);
    }
}
