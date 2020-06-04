using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;     

public class MenuButtons : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject optionsMenuUI;

    

    public AudioClip playButtonSound;
    public AudioClip bgMusicMenu;

    public AudioSource audioSource;

    

    public float startWaitTime;
    private float waitTime;

    public float startWaitTimeFade;
    private float waitTimeFade;

    public GameObject startAnim;
    public GameObject creditsAnim;
    public GameObject quitAnim;

    public GameObject creditos;
    public GameObject tutorialObj;
    
    public Animator transitionAnim;
    public GameObject fade;

    public GameObject menu2;

    GameManager gameManager;

    void Start()
    {
        //audioSource.Play(bgMusicMenu);
        waitTime = startWaitTime;
        waitTimeFade = startWaitTimeFade;
        gameManager = GameManager.gameManager;
        
        
    }

    void Update()
    {
        waitTime -= Time.deltaTime;
            if (waitTime < 0)
            {
                //waitTime = startWaitTime;
                startAnim.SetActive(false);
                creditsAnim.SetActive(false);
                quitAnim.SetActive(false);
                mainMenuUI.SetActive(true);
            }

         if(Input.GetKeyDown("escape"))
       {
           creditos.SetActive(false);
           tutorialObj.SetActive(false);
       }
    }
    public void playGame()
    {
        audioSource.PlayOneShot(playButtonSound, 0.4f);
        StartCoroutine(loadScene());
    }

    public void quitGame()
    {
        audioSource.PlayOneShot(playButtonSound, 0.4f);
        Application.Quit();
        print("Saiu");
    }

    public void credits()
    {
       audioSource.PlayOneShot(playButtonSound, 0.4f);
       StartCoroutine(loadCredits());
       //audioSource.PlayOneShot(playButtonSound, 0.3f);
       //StartCoroutine(loadCredits());
       
       
    }

    public void tutorial()
    {
       audioSource.PlayOneShot(playButtonSound, 0.4f);
       StartCoroutine(loadTutorial());   
    }

    IEnumerator loadScene()
    {
        audioSource.PlayOneShot(playButtonSound, 0.4f);
        fade.SetActive(true);
        
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("Main"); 
        gameManager.vida = 10;
        gameManager.agua = 100;
    }

     IEnumerator loadCredits()
    {
        audioSource.PlayOneShot(playButtonSound, 0.4f);
        fade.SetActive(true);
        yield return new WaitForSeconds(2);
        fade.SetActive(false);
        creditos.SetActive(true); 
        yield return new WaitForSeconds(45);
        creditos.SetActive(false);
    }

     IEnumerator loadTutorial()
    {
        audioSource.PlayOneShot(playButtonSound, 0.4f);
        fade.SetActive(true);
        yield return new WaitForSeconds(2);
        fade.SetActive(false);
        tutorialObj.SetActive(true); 
        
    }

  

    
}
