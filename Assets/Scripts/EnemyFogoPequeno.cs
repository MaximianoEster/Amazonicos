using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFogoPequeno : MonoBehaviour
{
    public int vida;
    private GameController _gameController;

    void Start()
    {
        vida = 2;
        _gameController = FindObjectOfType(typeof(GameController)) as GameController;
    }

    void Update()
    {
        if (vida <= 0){
            //GameObject temp = Instantiate(_gameController.fumaca[1], transform.position, transform.rotation);
            //Destroy(temp, 1f);
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Tiro2"))
        {
            vida -= 1;
        }
    }
}