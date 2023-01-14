using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] TMP_Text WinText;
    [SerializeField] GameObject WinSFX;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameOver(string playerName)
    {
        gameObject.SetActive(true);
        WinText.text= playerName + " Wins";
        GameManager.gameManager.setGameState(false);
        GameObject SFX = Instantiate(WinSFX,transform.position,Quaternion.identity);
        Destroy(SFX,1f);
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
