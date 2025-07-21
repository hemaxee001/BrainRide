using System;
using UnityEngine;
using UnityEngine.UI;

public class carManager : MonoBehaviour
{
    public Rigidbody2D carRb;
    public WheelJoint2D frontWheelJoint, backWheelJoint;

    public float speedForward;
    public float speedBackward;

    public float Torque;
    private JointMotor2D backMotor, frontMotor;
    public static carManager instance;

    public ParticleSystem ps;

    bool isMoveLeft = false;
    bool isMoveRight = false;

    private bool wasMoving = false;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update

    void Start()
    {

        carRb = GetComponent<Rigidbody2D>();

        backMotor = backWheelJoint.motor;
        frontMotor = frontWheelJoint.motor;
        backMotor.maxMotorTorque = Torque;
        frontMotor.maxMotorTorque = Torque;
        backMotor.motorSpeed = 0;
        frontMotor.motorSpeed = 0;

        backWheelJoint.useMotor = true; //
        frontWheelJoint.useMotor = true;//

        backWheelJoint.motor = backMotor;
        frontWheelJoint.motor = frontMotor;
    }
    void Update()
    {

        if (MAIN.instance.fuelSlider.value == 0 || !MAIN.isGameRunning)
        {
            backMotor.motorSpeed = 0;
            frontMotor.motorSpeed = 0;
            frontWheelJoint.motor = frontMotor;
            backWheelJoint.motor = backMotor;
            StopEngineAudio();
            return;
        }
        //else
        //{
        //    isCarMoving = true; 
        //}
        float x = 0;
        bool isCurrentlyMoving = false;
        x = Input.GetAxis("Horizontal");
        if (x > 0 || isMoveRight)
        {
            backMotor.motorSpeed = Mathf.Abs(speedForward);
            frontMotor.motorSpeed = Mathf.Abs(speedForward);
            isCurrentlyMoving = true;


        }
        else if (x < 0 || isMoveLeft)
        {
            backMotor.motorSpeed = -Mathf.Abs(speedBackward);
            frontMotor.motorSpeed = -Mathf.Abs(speedBackward);
            isCurrentlyMoving = true;


        }
        else
        {
            backMotor.motorSpeed = 0;
            frontMotor.motorSpeed = 0;
            isCurrentlyMoving = false;

            ps.Stop();
        }
        frontWheelJoint.motor = frontMotor;
        backWheelJoint.motor = backMotor;


        if (isCurrentlyMoving && !wasMoving)
        {

            PlayEngineAudio();
            ps.Play();
        }
        else if (!isCurrentlyMoving && wasMoving)
        {
            StopEngineAudio();
            ps.Stop();
        }


    }

    public void moveToLeft(bool isMoveLeft)
    {
        print("moveToLeft called with value: " + isMoveLeft);
        this.isMoveLeft = isMoveLeft;
    }
    public void moveToRight(bool isMoveRight)
    {
        print("moveToRight called with value: " + isMoveRight);
        this.isMoveRight = isMoveRight;
    }
    private void StopEngineAudio()
    {
        if (AudioManager.instance.carEngineAudioSource.isPlaying)
            AudioManager.instance.carEngineAudioSource.Stop();
    }

    private void PlayEngineAudio()
    {
        if (!AudioManager.instance.carEngineAudioSource.isPlaying)
            AudioManager.instance.carEngineAudioSource.Play();
    }
}



/*
  void Update()
    {
        
        if(MAIN.instance.fuelSlider.value <=0)
        {
            isCarMoving = false; // Stop the car if fuel is empty
        }
        else
        {
            isCarMoving = true; // Allow the car to move if fuel is available
        }

        float x = 0;
        x = Input.GetAxis("Horizontal");
        if (x>0)
        {
            backMotor.motorSpeed = Mathf.Abs(speedForward);
            frontMotor.motorSpeed = Mathf.Abs(speedForward);
            //backMotor.motorSpeed = speedForward;
            //frontMotor.motorSpeed = speedForward;

            //frontMotor.maxMotorTorque = Torque;
            //backMotor.maxMotorTorque = Torque;

            //frontWheelJoint.motor = frontMotor;
            //backWheelJoint.motor = backMotor;

        }
        else if(x < 0)
        {
            backMotor.motorSpeed = -Mathf.Abs(speedBackward);
            frontMotor.motorSpeed = -Mathf.Abs(speedBackward);
            //backMotor.motorSpeed = speedBackward;
            //frontMotor.motorSpeed = speedBackward;
            //frontMotor.maxMotorTorque = Torque;
            //backMotor.maxMotorTorque = Torque;
            //frontWheelJoint.motor = frontMotor;
            //backWheelJoint.motor = backMotor;
        }     
        else
        {
            backMotor.motorSpeed = 0;
            frontMotor.motorSpeed = 0;
        }
        frontWheelJoint.motor = frontMotor;
        backWheelJoint.motor = backMotor;
    }
 
 
 */






