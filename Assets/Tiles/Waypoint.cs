using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool isPlaceable = false;
    [SerializeField] GameObject balista;

    public bool IsPlaceable{ get{ return isPlaceable; } }

    void OnMouseDown(){
        if (isPlaceable){
            Instantiate(balista, transform.position, Quaternion.identity);
            isPlaceable = false;
        }
    }
}
