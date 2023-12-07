using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject target;
    public PlayerController playerController;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.mode == PlayerController.DriveMode.Manual)
            ManualMode();
        else AutomaticMode();
        gameObject.transform.rotation = target.transform.rotation;
    }
    void AutomaticMode()
    {
        gameObject.transform.position = transform.TransformDirection(target.transform.position.x - 3f, 
            target.transform.position.y + 3.5f, target.transform.position.z - 8f);
    }
    void ManualMode()
    {
        switch (playerController.targetCheckpoint)
        {
            case 0:
                gameObject.transform.position = new Vector3(target.transform.position.x,
                    target.transform.position.y + 3.5f, target.transform.position.z - 8f);
                break;
            case 1:
                gameObject.transform.position = new Vector3(target.transform.position.x + 8f,
                    target.transform.position.y + 3.5f, target.transform.position.z);
                break;
            case 2:
                gameObject.transform.position = new Vector3(target.transform.position.x,
                    target.transform.position.y + 3.5f, target.transform.position.z + 8f);
                break;
            case 3:
                gameObject.transform.position = new Vector3(target.transform.position.x - 8f,
                    target.transform.position.y + 3.5f, target.transform.position.z);
                break;
        }
    }
}
