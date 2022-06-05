using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public GameObject Block;
    public float BombBall;
    public float MinimumSpeed;
    public float MaximumSpeed;
    public ParticleSystem OnFire;
    public GameObject OnFire1;
    public GameObject OnFire2;
    public GameObject OnFire3;
    public GameObject OnFire4;
    bool CanHit1 = true;




    void Start()
    {
        Block = GameObject.Find("Block");
        BombBall = Random.Range(MinimumSpeed, MaximumSpeed);
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Block.transform.position, BombBall * Time.deltaTime);
        
    }

    private void OnTriggerEnter(Collider other)
    {

       

            AxeThrowController.Life2--;



            Destroy(gameObject);
          
        
    }


    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Axe") && CanHit1 == true)
        {
            Destroy(gameObject);
            AxeThrowController.BallScore++;
            CanHit1 = false;
           
        }
       
    }
  

   
    }


