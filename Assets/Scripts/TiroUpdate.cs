using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroUpdate : MonoBehaviour
{
    private player player;
    private float velocidade = 4;
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<player>();    
        count = 0;
        Destroy(this.gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * velocidade * Time.deltaTime);   
        if (count == 0)
        {
            gameObject.transform.Rotate(0f, 0f, player.tiroAngle, Space.Self);
            count = 1;
        } 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Fogo"))
        {
            Destroy(this.gameObject);
        }
    }
}
