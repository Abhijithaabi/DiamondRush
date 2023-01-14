using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform spwan in spawnPoints)
        {
            spwan.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void spawnPlayers()
    {
        int randomIndex1 = Random.Range(0, spawnPoints.Length);
        int randomIndex2 = Random.Range(0, spawnPoints.Length);
        // Check if the indices are the same
        while (randomIndex1 == randomIndex2) {
            randomIndex2 = Random.Range(0, spawnPoints.Length);
        }
        Transform randomElement1 = spawnPoints[randomIndex1];
        Transform randomElement2 = spawnPoints[randomIndex2];
        Debug.Log("Random element 1: " + randomElement1);
        Debug.Log("Random element 2: " + randomElement2);
        Instantiate(player1,randomElement1.position,randomElement1.rotation);
        Instantiate(player2,randomElement2.position,randomElement2.rotation);
        
    }
}
