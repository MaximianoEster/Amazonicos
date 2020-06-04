using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFogo : MonoBehaviour
{
    /*
    public      Transform           enemy;
    public      Transform[]         checkPoints;
    public      float               velMoviment;
    public      float               delayStop;
    public      GameObject          marca;

    public      float               tempo, tempoAtual;
    private     int                 idCheckPoint;
    private     bool                isMoving;
    private Vector3 originalPos;


    void Start()
    {
        StartCoroutine("startMoviment");
        tempoAtual = .3f;
    }

    void Update()
    {
        tempo += Time.deltaTime;
        if(isMoving == true)
        {
            Vector3 smoothpos = Vector3.Lerp(checkPoints[1].position, checkPoints[0].position, .5f);
            transform.position = smoothpos;            
            if(tempo > tempoAtual)
            {
                StartCoroutine("spawnSombra");
                tempo = 0;
            }
        } 

       if(enemy.localPosition == checkPoints[idCheckPoint].position){
           isMoving = false;
       }
    }

    IEnumerator spawnSombra()
    {
        GameObject tempMarca = Instantiate(marca, new Vector2(enemy.position.x - .1f, enemy.position.y - .5f), enemy.rotation); 
        yield return new WaitForSeconds(0.5f);
        Destroy(tempMarca, 5f);
    }
}
*/

    public Transform fogo;
    public Transform[] checkPoints;
    public float velFogo;
    
    private bool isMoving = true;
    private int idCheckPoint;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            fogo.localPosition = Vector2.MoveTowards(fogo.localPosition, checkPoints[1].position, velFogo * Time.deltaTime);
        }
        if (fogo.localPosition == checkPoints[1].position){
            isMoving = false;
        }
    }
}

