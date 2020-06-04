using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int vida;
    private GameController _gameController;
    // Start is called before the first frame update
    void Start()
    {
        vida = 5;
        _gameController = FindObjectOfType(typeof(GameController)) as GameController;
    }

    // Update is called once per frame
    void Update()
    {
        if (vida <= 0){
            //GameObject temp = Instantiate(_gameController.fumaca[0], transform.position, transform.rotation);
            //Destroy(temp, 1f);
            SpawnLoot();
            Destroy(this.gameObject);
        }
    }

    void SpawnLoot()
    {
        int idItem = 0;
        int rand = Random.Range(0,100);
        
        if(rand < 35){
            
            rand = Random.Range(0, 100);
            
            if(rand > 70){
                idItem = 0;
            }
            else{
                idItem = 1;
            }

            Instantiate(_gameController.fogoLoot[idItem], transform.position, transform.localRotation);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Tiro"))
        {
            vida -= 1;
        }
    }
}
