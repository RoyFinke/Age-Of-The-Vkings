using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AxeThrowController : MonoBehaviour
{
    [SerializeField] private GameObject _axePrefab;
    [SerializeField] private Transform _axeMarker;
    [SerializeField] private Transform _throwDirectionMarker;
    [SerializeField] private float _axeInitialSpeed = 30f;
    [SerializeField] private float _axeInitialAngularVelocity = 30f;
    public int PersonTargets;
    public int Targets;
    public Text ScoreText1;
    public Text ScoreText2;
    public Text Life;
    public static int Life2 = 3;
    public bool GameStarted = false;
    public bool dayEnded;
    public Animator AxeAnimation;
    public GameObject TryAgainCard;
    public Text BallScoreText;
    public static int BallScore = 0;
    public GameObject VictoryCanvas;
    public CameraController Pause;
    public GameObject PauseGame;
    public bool GameIsPaused = false;
    public GameObject OnFire2;
    public GameObject OnFire3;
    public GameObject OnFire4;
    public GameObject OnFire5;
    public GameObject OnFire1;
    public CameraController AimImage1;
   
    



    private void Update()
    {
        CreateAxeOnClick();
        AddScore();
        Defeat();



        if (BallScore == 12)
        {
            VictoryCanvas.SetActive(true);
            Debug.Log("1");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        }

        if (Life2 == 2)
        {
            OnFire2.SetActive(true);
            OnFire3.SetActive(true);
            

        }
        if (Life2 == 1)
        {
            OnFire4.SetActive(true);
            OnFire5.SetActive(true);
          
        }
        if (Life2 ==0)
        {
            OnFire1.SetActive(true);
        }
    }
    void AddScore()
    {
        ScoreText1.text = PersonTargets.ToString();
        ScoreText2.text = Targets.ToString();
        Life.text = Life2.ToString();
        BallScoreText.text = BallScore.ToString();
    }

    private void CreateAxeOnClick()
    {
        if (Input.GetMouseButtonDown(0) && GameStarted == true)
        {
                AxeAnimation.SetTrigger("Throw");
        }
      
    }
    public void Defeat()
    {
        if (Life2 <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            TryAgainCard.SetActive(true);



        }
    }

        
     
    
    public void AxeThrowMass()
    {
       
            var axeInstance = Instantiate(_axePrefab);
            axeInstance.transform.position = _axeMarker.transform.position;
            axeInstance.transform.eulerAngles = _axeMarker.transform.eulerAngles;


            var rigidBody = axeInstance.GetComponent<Rigidbody>();
            //rigidBody.velocity = transform.forward * _axeInitialSpeed;

            rigidBody.AddForce(_throwDirectionMarker.forward * _axeInitialSpeed, ForceMode.VelocityChange);
            var angularVelocityRadians = _axeInitialAngularVelocity * Mathf.Deg2Rad;
            rigidBody.AddTorque(axeInstance.transform.up * angularVelocityRadians, ForceMode.VelocityChange);
            dayEnded = true;
        
    }
    public void ResumeGame()
    {
        GameIsPaused = false;
        PauseGame.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
        Pause.GamePaused = false;
        Pause.CameraMovementOn = true;
        AimImage1.AimImage.SetActive(true);
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        TryAgainCard.SetActive(false);
        SceneManager.LoadScene(3);
        Life2 = 3;
        BallScore = 0;
        BombThrow.ButtonWasPressed = false;
        AimImage1.AimImage.SetActive(true);
        
    }
   

}
