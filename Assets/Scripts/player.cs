using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class player : MonoBehaviour
{
    public float vel;
    public int tiroAngle;
    public int x,y;
    public camSet2 cameraSet;
    
    private int vida;
    private int maxVida;
    private float agua;
    private float maxAgua;
    
    GameManager gameManager;
    private float tempoDano;
    protected AudioSource audioSource;
    
    //[Header("Sons")]
    //public AudioClip atirarSound;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameManager = GameManager.gameManager;
        tiroAngle = 0;
        tempoDano = 1.5f;
        SetStatusPlayer();
        vida = maxVida; 
        agua = maxAgua; 
        gameManager.vida = vida;
        gameManager.agua = agua;
       
    }

    // Update is called once per frame
    void Update(){
        Debug.Log(gameManager.vida);
        Debug.Log(gameManager.agua);
        Rigidbody2D body = GetComponent<Rigidbody2D>();

        float movimentoX = Input.GetAxis("Horizontal");
        float movimentoY = Input.GetAxis("Vertical");

        body.velocity = new Vector2(movimentoX*vel , movimentoY*vel);
        
        // movimento x
        if (movimentoX > 0){
            GetComponent<SpriteRenderer>().flipX = false;
            GetComponent<Animator>().SetBool("runDir", true);
            GetComponent<Animator>().SetBool("runTopo", false);
            GetComponent<Animator>().SetBool("runBaixo", false);              
            tiroAngle = 0;
            x = 160;
            y = 70;
            if (movimentoY > 0){
                GetComponent<Animator>().SetBool("runDir", true);
                GetComponent<Animator>().SetBool("runTopo", true);
                GetComponent<Animator>().SetBool("runBaixo", false);              
                tiroAngle = 40;
                x = 130;
                y = 72;
            }
            if (movimentoY < 0){
                GetComponent<Animator>().SetBool("runDir", true);
                GetComponent<Animator>().SetBool("runBaixo", true);
                GetComponent<Animator>().SetBool("runTopo", false);              
                tiroAngle = 220;
                x = 130;
                y = 70;
            }
        }

        if (movimentoX < 0){
            GetComponent<SpriteRenderer>().flipX = true;
            GetComponent<Animator>().SetBool("runDir", true);
            GetComponent<Animator>().SetBool("runTopo", false);
            GetComponent<Animator>().SetBool("runBaixo", false);              
            tiroAngle = 180;
            x = -160;
            y = 70;
            if (movimentoY > 0){            
                GetComponent<Animator>().SetBool("runDir", true);
                GetComponent<Animator>().SetBool("runTopo", true);
                GetComponent<Animator>().SetBool("runBaixo", false);              
                tiroAngle = 135;
                x = -130;
                y = 72;
            }
            if (movimentoY < 0){
                GetComponent<Animator>().SetBool("runDir", true);
                GetComponent<Animator>().SetBool("runBaixo", true);
                GetComponent<Animator>().SetBool("runTopo", false);              
                tiroAngle = 225;
                x = -130;
                y = 70;
            }
        }
        if (movimentoY > 0){
            GetComponent<Animator>().SetBool("runTopo", true);
            GetComponent<Animator>().SetBool("runBaixo", false);
            GetComponent<Animator>().SetBool("runDir", false);        
            tiroAngle = 90;
            x = 0;
            y = 180;
            if (movimentoX > 0){
                GetComponent<Animator>().SetBool("runTopo", true);
                GetComponent<SpriteRenderer>().flipX = false;
                GetComponent<Animator>().SetBool("runDir", true);
                tiroAngle = 40;
                x = 130;
                y = 72;
            }
            if (movimentoX < 0){
                GetComponent<Animator>().SetBool("runTopo", true);
                GetComponent<SpriteRenderer>().flipX = true;
                GetComponent<Animator>().SetBool("runDir", true);
                tiroAngle = 135;
                x = -130;
                y = 72;
            }    
        }
        if (movimentoY < 0){
            GetComponent<Animator>().SetBool("runBaixo", true);
            GetComponent<Animator>().SetBool("runTopo", false);
            GetComponent<Animator>().SetBool("runDir", false);
            tiroAngle = 270;
            x = 0;
            y = 20;
            if (movimentoX > 0){
                GetComponent<Animator>().SetBool("runBaixo", true);
                GetComponent<SpriteRenderer>().flipX = false;
                GetComponent<Animator>().SetBool("runDir", true);
                tiroAngle = 315;
                x = 130;
                y = 70;
            }
            if (movimentoX < 0){
                GetComponent<Animator>().SetBool("runBaixo", true);
                GetComponent<SpriteRenderer>().flipX = true;
                GetComponent<Animator>().SetBool("runDir", true);
                tiroAngle = 220;
                x = -130;
                y = 70;
            }
        }
        
        if (movimentoX != 0 || movimentoY != 0){
            GetComponent<Animator>().SetBool("run", true);
        } else if (movimentoY == 0 && movimentoX == 0){
            GetComponent<Animator>().SetBool("run", false);
        }

        if(vida <= 0){
            SceneManager.LoadScene("Gameover");
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Fogo":
            StartCoroutine("TomouDano");
            break;

            case "FogoBaixo":
            StartCoroutine("TomouDano");
            break;

            case "Vida":
            gameManager.vida += 1;
            if(gameManager.vida >= 10){
                gameManager.vida = 10;
            }
            Destroy(other.gameObject);
            break;

            case "Agua":
            gameManager.agua += 10;
            if(gameManager.agua >= 100){
                gameManager.agua = 100;
            }
            Destroy(other.gameObject);
            break;
        }
    } 

    public IEnumerator TomouDano()
    {
        vida --;
        gameManager.vida--;
        StartCoroutine(cameraSet.Shake(.2f, .5f));
        if (gameManager.vida <= 0)
        {
            Physics2D.IgnoreLayerCollision(8, 10, false);
            Invoke("RecarregarFase", 4f);
            

        }

        else
        {
            if(gameManager.vida > 0){
                Physics2D.IgnoreLayerCollision(10, 8);
                for (float i = 0; i < tempoDano; i += 0.2f)
                {
                    yield return new WaitForSeconds(0.07f);
                    GetComponent<SpriteRenderer>().enabled = false;
                    yield return new WaitForSeconds(0.07f);
                    GetComponent<SpriteRenderer>().enabled = true;
                    yield return new WaitForSeconds(0.07f);
                }
                Physics2D.IgnoreLayerCollision(8, 10, false);
            }
        }
    }

    public void SetStatusPlayer(){
        maxVida = gameManager.vida;
        maxAgua = gameManager.agua;
    }
    
}