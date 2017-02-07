using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Movimentacao : MonoBehaviour
{
    private Rigidbody2D RigidBody;
    private float Horizontal;

    private Animator anime;
    private bool Walking;
    public int points;

    public Text txtPoints;

    public bool Grounded;
    public Transform GroundCheck;
    public GameObject FacaPrefab;
    public Transform ShootPlace;

    public GameObject InteractObj;

    public bool movingRight;

    public float VelocidadeBase = 2;
    public float VelocidadeAdicional = 2;
    public float maxSpeed = 2;
    public float Velocidade = 2;
    public float ForcaPulo = 150;
    public float ShootSpeed = 6;
    void Start()
    {
        RigidBody = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
    }
    void Update()
    {
        #region GroundCheck    
        Grounded = Physics2D.OverlapCircle(GroundCheck.position, 0.002f);
        anime.SetBool("Grounded", Grounded);
        #endregion

        #region Inputs
        Horizontal = Input.GetAxis("Horizontal");

        Walking = Horizontal != 0 ? true : false;

        if ((Horizontal > 0 && movingRight) || (Horizontal < 0 && !movingRight))
            Flip();

        if (Input.GetButtonDown("Fire3"))
        {
            Velocidade = VelocidadeBase + VelocidadeAdicional;
        }
        else if (Input.GetButtonUp("Fire3"))
        {
            Velocidade = VelocidadeBase;
        }
        if (Input.GetButtonDown("Jump") && Grounded)
        {
            RigidBody.AddForce(new Vector2(0, ForcaPulo));
        }
        if (Input.GetButtonDown("Fire1"))
        {
            if (InteractObj == null)
                Shoot();
            else
                InteractObj.SendMessage("Interact", SendMessageOptions.DontRequireReceiver);
        }
        #endregion

        txtPoints.text = points.ToString();

        #region Animator
        anime.SetBool("IsRunning", Walking);
        anime.SetFloat("DownSpeed", RigidBody.velocity.y);
        #endregion
    }
    void FixedUpdate()
    {
        //print(RigidBody.velocity.magnitude);
        //if (RigidBody.velocity.magnitude < maxSpeed)
        //{
        //RigidBody.AddForce(new Vector2(Horizontal * Velocidade, 0));
        //}
        RigidBody.velocity = new Vector2(Horizontal * Velocidade, RigidBody.velocity.y);
    }
    void Flip()
    {
        movingRight = !movingRight;
        ShootSpeed *= -1;
        var TheScale = transform.localScale;
        TheScale.x *= -1;
        transform.localScale = TheScale;
    }
    void Shoot()
    {
        GameObject Faca = (GameObject)Instantiate(FacaPrefab, ShootPlace.position, transform.rotation);

        Faca.GetComponent<SpriteRenderer>().flipX = movingRight;

        Faca.GetComponent<Rigidbody2D>().velocity = new Vector2(ShootSpeed, 0);
        Destroy(Faca, 5);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        switch (col.gameObject.tag)
        {
            case "Plataforma":
                transform.SetParent(col.transform);
                break;
            case "Inimigo":
                PlayerPrefs.SetInt("Recorde", points);
                SceneManager.LoadScene("Titulo");
                break;
            default:
                break;
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        switch (col.gameObject.tag)
        {
            case "Plataforma":
                transform.SetParent(null);
                break;
            default:
                break;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.gameObject.tag)
        {
            case "Interact":
                InteractObj = col.gameObject;
                break;
            default:
                break;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        switch (col.gameObject.tag)
        {
            case "Interact":
                InteractObj = null;
                break;
            default:
                break;
        }
    }

}
