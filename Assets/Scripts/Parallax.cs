using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour
{


    public Transform background;
    public Transform Camera;
    public float parallaxScale = 4;
    public float velocidade = 1;
    private Vector3 Destino;
    private Vector3 PreviewCamPosition;
    // Use this for initialization
    void Start()
    {
        PreviewCamPosition = Camera.position;
    }

    // Update is called once per frame
    void Update()
    {

        float Parallax = (PreviewCamPosition.x - Camera.position.x) * parallaxScale;
        Destino = new Vector3(background.position.x + Parallax, background.position.y, background.position.z);

        background.position = Vector3.Lerp(background.position, Destino, velocidade * Time.deltaTime);

        PreviewCamPosition = Camera.position;

    }
}
