using UnityEngine;
using System.Collections;

public class Plataforma : MonoBehaviour
{

    public Transform Plat;
    public Transform A;
    public Transform B;
    private Vector3 Destino;

    public float Velocidade = 1;

    // Use this for initialization
    void Start()
    {
        Plat.position = A.position;
        Destino = B.position;
    }

    // Update is called once per frame
    void Update()
    {

        Plat.position = Vector3.MoveTowards(Plat.position, Destino, Velocidade * Time.deltaTime);

        if (Destino == Plat.position)
        {
            if (Destino == B.position)
                Destino = A.position;
            else if (Destino == A.position)
                Destino = B.position;
        }
    }
}
