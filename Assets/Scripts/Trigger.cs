using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Trigger : MonoBehaviour
{
    [SerializeField] ParticleSystem ps;
    [SerializeField] CapsuleCollider diamond;
    [SerializeField] GameOverHandler gameOverHandler;
    
   private void OnTriggerEnter(Collider other) {
        Debug.Log(other.tag);
        ps.Play();
        diamond.enabled = false;
        transform.GetChild(0).gameObject.SetActive(false);
        Destroy(gameObject,1f);
        StartCoroutine(Delay(other.tag));
        
    }
    IEnumerator Delay(string name)
    {
        yield return new WaitForSeconds(0.6f);
        gameOverHandler.GameOver(name);
    }
}
