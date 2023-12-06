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
    // Start is called before the first frame update
    void Start()
    {
        targetCheckpoint = 0;
        isRotating = false;
    }

    // Update is called once per frame
    void Update()
    {
        MovingFoward(targetCheckpoint);
        if ((transform.position - checkpoints[targetCheckpoint]).magnitude < 0.1f && isRotating is false)
        {
            if (targetCheckpoint < 3) targetCheckpoint++;
            else targetCheckpoint = 0;
            isRotating = true;
        }
        if (isRotating) RotateToLeft();
    }

    void MovingFoward(int myTarget)
    {
        switch (myTarget)
        {
            case 0:
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + mySpeed * Time.deltaTime);
                break;
            case 1:
                transform.position = new Vector3(transform.position.x - mySpeed * Time.deltaTime, transform.position.y, transform.position.z);
                break;
            case 2:
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - mySpeed * Time.deltaTime);
                break;
            case 3:
                transform.position = new Vector3(transform.position.x + mySpeed * Time.deltaTime, transform.position.y, transform.position.z);
                break;
        }

    }
    void RotateToLeft()
    {
        transform.Rotate(Vector3.down, 90f);
        isRotating = false;

    }

}
