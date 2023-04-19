using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectController : MonoBehaviour
{

    public Transform theCam;
    public float moveSpeed;
    public Transform minPos, maxPos;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.PlayLevelSelectMusic();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 adjustedMousePos = new Vector2(Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height);
        Debug.Log(adjustedMousePos);

        if(adjustedMousePos.x > .75f)
        {
            theCam.position += theCam.right * moveSpeed * Time.deltaTime;
        }

        if(adjustedMousePos.x < .25f)
        {
            theCam.position -= theCam.right * moveSpeed * Time.deltaTime;
        }

        theCam.position = new Vector3(Mathf.Clamp(theCam.position.x, minPos.position.x, maxPos.position.x), theCam.position.y, theCam.position.z);
    }
}
