using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popUpSignPost : MonoBehaviour
{

    public GameObject enemyList;

    private float tiltAngle = 90.0f;
    private float smooth = 5f;

    void Update()
    {
        if (enemyList.transform.childCount == 0){
            rotateSignPost();
        }
    }

    void rotateSignPost(){

        float tiltAroundZ = tiltAngle;

        Quaternion target = Quaternion.Euler(0,0,tiltAroundZ);

        gameObject.transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
    

    }
}
