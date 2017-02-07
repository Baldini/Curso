using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bau : MonoBehaviour
{

    public List<GameObject> estados;
    public bool aberto;
    public Movimentacao player;
    // Use this for initialization
    void Start()
    {
        player = (Movimentacao)FindObjectOfType(typeof(Movimentacao));
        estados[0].SetActive(true);
        estados[1].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Interact()
    {
        if (!aberto)
        {
            player.points += 20;
            aberto = !aberto;
            estados[0].SetActive(!aberto);
            estados[1].SetActive(aberto);
        }
    }
}
