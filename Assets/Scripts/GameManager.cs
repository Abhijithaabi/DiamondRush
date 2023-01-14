using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public bool gameState = false;
    [SerializeField] GameObject Camera1;
    [SerializeField] GameObject Camera2;
    private void Awake() {
        if(gameManager != null && gameManager != this)
        {
            Destroy(this);
        }
        else
        {
            gameManager = this;
        }
    }
    public void setGameState(bool state)
    {
        gameState = state;
    }
    void Update()
    {
        if(gameState)
        {
            if(Input.GetKey(KeyCode.C))
            {
                Camera1.SetActive(true);
                Camera2.SetActive(false);
            }
            if(Input.GetKey(KeyCode.Z))
            {
                Camera1.SetActive(false);
                Camera2.SetActive(true);
            }
        }    
    }
}
