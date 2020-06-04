using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider maxVida; 
    public Slider maxAgua;
    // Start is called before the first frame update
    void Start()
    {
        UpdateHealthBarUI () ; 
        UpdateWaterBarUI () ;
    }
    
    void Update()
    {
        UpdateHealthBarUI () ;
        UpdateWaterBarUI () ; 
    }
    public void UpdateHealthBarUI () {
        maxVida.value = GameManager.gameManager.vida;
        
    }

    public void UpdateWaterBarUI () {
       maxAgua.value = GameManager.gameManager.agua; 
        
    }
    
}
