using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Fantasma : MonoBehaviour
{

    private Movimentacao player;
    public float Velocidade = 0.3f;
    public List<Sprite> sprites;
    public SpriteRenderer spriteRender;
    private bool lookLeft;

    // Use this for initialization
    void Start()
    {
        player = (Movimentacao)GameObject.FindObjectOfType((typeof(Movimentacao)));
        spriteRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= player.transform.position.x && !lookLeft)
            Flip();
        else if (transform.position.x < player.transform.position.x && lookLeft)
            Flip();

        if (transform.position.x >= player.transform.position.x && player.movingRight)
        {
            Move();
        }
        else if (transform.position.x < player.transform.position.x && !player.movingRight)
        {
            Move();
        }
        else
        {
            spriteRender.sprite = sprites[1];
        }
    }
    private void Move()
    {
        spriteRender.sprite = sprites[0];
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 1 * Time.deltaTime);
    }

    void Flip()
    {
        lookLeft = !lookLeft;
        var theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
