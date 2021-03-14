using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteDoor : MonoBehaviour
{
  public GameObject enemyList;

  private void Update()
  {
    if (enemyList.transform.childCount == 0){
        Destroy(gameObject);
    }   
  }
}
