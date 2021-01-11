using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    public event EventHandler OnEnter;
    public string tagToDetect;
    public string str;
    public float number;
    private bool flag = false;
    public bool consumable = true;
    private static Collector col;

    private void Start() {
        if(col == null){
            col = GameObject.Find("Plane").GetComponent<Collector>();
        }
        col.Add(this);
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if(!consumable){
             if(other.gameObject.tag  == tagToDetect){
                if(str != null && number != null){
                    OnEnter?.Invoke(this, EventArgs.Empty);
                }
            } 
        } else {
          if(other.gameObject.tag  == tagToDetect && !flag){
                flag = true;
                if(str != null && number != null){
                    OnEnter?.Invoke(this, EventArgs.Empty);
                }
            } 
        }
  
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag  == tagToDetect){
            // Debug.Log(tagToDetect+" out");
        } 
    }
}