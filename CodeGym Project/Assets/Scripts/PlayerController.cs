using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int mySpeed;
    public Vector3[] checkpoints = new Vector3[4];
    public int targetCheckpoint;
    public bool isRotating;
    public enum DriveMode
    {
        Manual,
        Automatic
    }
    public DriveMode mode;
    // Start is called before the first frame update
    void Start()
    {
        targetCheckpoint = 0;
        isRotating = false;
        mode = DriveMode.Manual;
    }

    // Update is called once per frame
    void Update()
    {
        switch (mode)
        {
            case DriveMode.Manual:
                ManualMode();
                break;
            case DriveMode.Automatic:
                AutomaticMode(); 
                break;
        }
    }
    void AutomaticMode()
    {
        if ((transform.position - checkpoints[targetCheckpoint]).magnitude < 0.1f && isRotating is false)
        {
            SetNextTarget();
            isRotating = true;
        }
        else MovingFoward(targetCheckpoint);
        if (isRotating) RotateToLeft();
    }
    void ManualMode()
    {
        transform.position += transform.TransformDirection(0f, 0f, Input.GetAxis("Vertical") * Time.deltaTime * mySpeed);
        transform.Rotate(Vector3.up, Input.GetAxis("Horizontal"));
    }
    void MovingFoward(int myTarget)
    {
        transform.position = Vector3.MoveTowards(transform.position, checkpoints[myTarget], mySpeed * Time.deltaTime);
    }
    void RotateToLeft()
    {
        transform.Rotate(Vector3.down, 90f);
        isRotating = false;
    }
    void SetNextTarget()
    {
        if (targetCheckpoint < 3) targetCheckpoint++;
        else targetCheckpoint = 0;
    }    
}
