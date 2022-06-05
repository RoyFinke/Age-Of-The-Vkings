using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombThrow : MonoBehaviour
{
    [SerializeField] private GameObject _BombPrefab;
    [SerializeField] private Transform _BombMarker;
    [SerializeField] private Transform _BombthrowDirectionMarker;
    [SerializeField] private float _BombInitialSpeed = 30f;
    [SerializeField] private float _BombInitialAngularVelocity = 30f;
    public ParticleSystem OnFire;
    public GameObject OnFire1;
    public GameObject OnFire2;
    public GameObject OnFire3;
    public GameObject OnFire4;
    public GameObject Block;
    [SerializeField] float TimeToShoot = 0;
    [SerializeField] float MinTimeToShoot = 2;
    [SerializeField] float MaxTimeToShoot = 5;
    public CameraController BombShootistrue;
    public static bool ButtonWasPressed = false;
    public AxeThrowController BallScoreRef;
    AxeThrowController axeScript;



    public void Start()
    {
        Block = GameObject.Find("Block");
        
    }
   
    private void Shoot()
    {


        
        
        {
            var BombInstance = Instantiate(_BombPrefab);
            BombInstance.transform.position = _BombMarker.transform.position;
        }
    
        
        
    }
    public void Update()
    {
        if (TimeToShoot <= Time.time && ButtonWasPressed == true && AxeThrowController.BallScore < 12)
        {
            TimeToShoot = Random.Range(MinTimeToShoot, MaxTimeToShoot);
            Debug.Log("2");
           Shoot();
            TimeToShoot = Random.Range(MinTimeToShoot, MaxTimeToShoot) + Time.time;

        }
    
    }
    private void OnTriggerEnter(Collider other)
    {
      



        Destroy(gameObject);
        OnFire.Play();
        OnFire4.SetActive(true);
        OnFire1.SetActive(true);
        OnFire2.SetActive(true);
        OnFire3.SetActive(true);

    }




}
