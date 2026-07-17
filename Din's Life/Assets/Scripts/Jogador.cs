using UnityEngine;

public class Jogador : MonoBehaviour
{
    public Rigidbody2D rigidbody2d;
    public float velocidadeMovimento;
    
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        Vector2 velocidade = this.rigidbody2d.linearVelocity;
        
        velocidade.x = horizontal * this.velocidadeMovimento;
        velocidade.y = vertical * this.velocidadeMovimento;
        this.rigidbody2d.linearVelocity = velocidade;
    }
}
