using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class gameover_controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(backMenu());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator backMenu(){
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("Menu"); 
    }
}
