using UnityEngine;
using System.Collections;

public class OneWay : MonoBehaviour
{
    public Transform superfice;
    public Transform GroundCheck;
    private float posY;
    private Collider2D col;
    // Use this for initialization
    void Start()
    {
        GroundCheck = GameObject.Find("GroundCheck").transform;
        col = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        posY = GroundCheck.position.y;
        if (posY > superfice.position.y)
            col.enabled = true;
        else
            col.enabled = false;
    }
}
