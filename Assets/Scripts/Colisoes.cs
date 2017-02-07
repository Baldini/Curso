using UnityEngine;
using System.Collections;

public class Colisoes : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D collision)
    {

        switch (collision.gameObject.tag)
        {
            case "Object":
                //print(collision.gameObject.name);
                break;
            case "Damage":
                print("E Morreu!");
                break;
            default:
                break;
        }

        //print(collision.gameObject.name);
        //print("Entrou");
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        switch (collider.gameObject.tag)
        {
            case "Object":
                //print(collider.gameObject.name);
                break;
            case "Damage":
                print("E Morreu!");
                break;
            default:
                break;
        }
    }
    //void OnCollisionExit2D()
    //{
    //    //print("Saiu");
    //}

    //void OnCollisionStay2D()
    //{

    //}
}
