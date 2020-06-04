using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroUpdate2 : MonoBehaviour
{
    private float velocidade = 4;
    private int count;

    private player player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<player>();    
        count = 0;

        if (player.y == 72)
        {
            Destroy(this.gameObject, .3f);
        } 
        else 
        {
            Destroy(this.gameObject, .6f);
        }
    }

    void Update()
    {

        if (count == 0)
        {
            if (player.tiroAngle >= 180)
            {
                GetComponent<SpriteRenderer>().sortingOrder = 4;
            } else {
                GetComponent<SpriteRenderer>().sortingOrder = -2;
            }
            GetComponent<Rigidbody2D>().AddForce(new Vector2(player.x, player.y));
            count = 1;
        }
    }
    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("FogoBaixo"))
        {
            Destroy(this.gameObject);
        }
    }
}
