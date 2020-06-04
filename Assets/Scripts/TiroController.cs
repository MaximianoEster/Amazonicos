using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroController : MonoBehaviour
{
    // Start is called before the first frame update
  public GameObject tiroPrefab, tiroPrefab2;
  public Transform tiroSpawn;
  public camSet2 cameraSet;

  private int tiroCD; 
  private float correctionY;
  private int correTiroY, teto;

  GameManager gameManager;
  protected AudioSource audioSource;

  
  [Header("Sons")]
  public AudioClip atirarSound;
  
  void Start()
  {
      audioSource = GetComponent<AudioSource>();
      gameManager = GameManager.gameManager;
      teto = 1;
  }

  // Update is called once per frame
  void Update()
  {
    tiroCD ++;
    if (Input.GetButton("Fire1") && tiroCD > 4 && gameManager.agua > 0){
      audioSource.PlayOneShot(atirarSound, .1f);
      gameManager.agua-= .5f;
      GameObject tempTiro = Instantiate(tiroPrefab, new Vector2(tiroSpawn.position.x, tiroSpawn.position.y + correctionY), tiroSpawn.rotation);
      tiroCD = 0;
      if (teto == 1){
        correTiroY++;
      } 
      if (teto == 2){
        correTiroY--;
      }
    }

    if (Input.GetButton("Fire2") && tiroCD > 4 && gameManager.agua > 0){
      audioSource.PlayOneShot(atirarSound, .1f);
      gameManager.agua-= .2f;
      GameObject tempTiro = Instantiate(tiroPrefab2, new Vector2(tiroSpawn.position.x, tiroSpawn.position.y + correctionY), tiroSpawn.rotation);
      tiroCD = 0;
      if (teto == 1){
        correTiroY++;
      } 
      if (teto == 2){
        correTiroY--;
      }
    }

    if (correTiroY == 1){
      correctionY = -.1f;
      teto = 1;
    }
    if (correTiroY == 2){
      correctionY = -.05f;
    }
    if (correTiroY == 3){
      correctionY = 0;
    }
    if (correTiroY == 4){
      correctionY = .05f;
    }
    if (correTiroY == 5){
      correctionY = .1f;
      teto = 2;
    }
  }
}
