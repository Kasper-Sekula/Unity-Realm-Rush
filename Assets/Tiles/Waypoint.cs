using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool isPlacable = false;
    [SerializeField] GameObject balista;

    void OnMouseDown(){
        if (isPlacable){
            Instantiate(balista, transform.position, Quaternion.identity);
            isPlacable = false;
        }
    }
}
