using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool isPlacable = false;

    void OnMouseDown(){
        if (isPlacable){
            Debug.Log(transform.name);
        }
    }
}
