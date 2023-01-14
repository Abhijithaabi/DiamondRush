using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [SerializeField] GameObject startMenu;
    [SerializeField] GameObject Ui;
    [SerializeField] Image player1PowerUp;
    [SerializeField] Image player2PowerUp;
    [SerializeField] float maxTime = 4f;
    float timeLeft;
    public bool hasPowerUp1 = false;
    public bool hasPowerUp2 = false;
    SpawnManager spawnManager;
    
    private void Start() {
        Ui.SetActive(false);
        timeLeft = maxTime;
        spawnManager = FindObjectOfType<SpawnManager>();
    }
    public void StartGame()
    {
        startMenu.SetActive(false);
        GameManager.gameManager.setGameState(true);
        Ui.SetActive(true);
        player1PowerUp.enabled=false;
        player2PowerUp.enabled=false;
        spawnManager.spawnPlayers();
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    private void Update() {
        if(hasPowerUp1)
        {
            
            if(timeLeft>0)
            {
                timeLeft -=Time.deltaTime;
                player1PowerUp.fillAmount = timeLeft/maxTime;
            }
            else
            {
                hasPowerUp1=false;
                timeLeft=maxTime;
            }
        }
        if(hasPowerUp2)
        {
            
            if(timeLeft>0)
            {
                timeLeft -=Time.deltaTime;
                player2PowerUp.fillAmount = timeLeft/maxTime;
            }
            else
            {
                hasPowerUp2=false;
                timeLeft=maxTime;
            }
        }
    }
    public void powerSlider1()
    {
        player1PowerUp.enabled=true;
    }
    public void powerSlider2()
    {
        player2PowerUp.enabled=true;
    }
}
