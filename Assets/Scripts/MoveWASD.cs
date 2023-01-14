using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWASD : MonoBehaviour
{
    public CharacterController controller;
    [SerializeField] float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVel;
    [SerializeField] Animator Anim;
    [SerializeField] float speedBoost = 4f;
    [SerializeField] GameObject PowerUpSFX;
    float activeSpeed;
    UIHandler uIHandler;

    // Start is called before the first frame update
    void Start()
    {
        activeSpeed = speed;
        uIHandler = FindObjectOfType<UIHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.gameManager.gameState)
        {
            PlayerMovement();
        }
        
    }

    private void PlayerMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(-vertical, 0f, horizontal).normalized;
        if (dir.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVel, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            controller.Move(dir * activeSpeed * Time.deltaTime);
        }
        Anim.SetFloat("speed",dir.magnitude);
    }
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("PowerUp"))
        {
            activeSpeed=speed+speedBoost;
            Debug.Log("activeSpeed: "+activeSpeed );
            GameObject SFX =  Instantiate(PowerUpSFX,other.transform.position,Quaternion.identity);
            StartCoroutine(Timer());
            
            uIHandler.powerSlider1();
            uIHandler.hasPowerUp1= true;
            Destroy(other.gameObject);
            Destroy(SFX,1f);
        }
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(4f);
        activeSpeed=speed;
        
    }
}
