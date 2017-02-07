using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    private Movimentacao player;
    public Transform L;
    public Transform R;
    private Vector3 Destino;
    public float Velocidade = 1;
    // Use this for initialization
    void Start()
    {
        player = (Movimentacao)FindObjectOfType(typeof(Movimentacao));
    }

    // Update is called once per frame
    void Update()
    {
        Destino = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);


        if (player.transform.position.x > L.position.x && player.transform.position.x < R.position.x)
        {
            transform.position = Vector3.Lerp(transform.position, Destino, Velocidade * Time.deltaTime);
        }
        else if (transform.position.x > L.position.x && transform.position.x < R.position.x)
        {
            transform.position = Vector3.Lerp(transform.position, Destino, Velocidade * Time.deltaTime);
        }


    }
}
