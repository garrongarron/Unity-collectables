using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    
    public Collector instance;

    public event EventHandler OnEnter;
    public static List<TriggerArea> list = new List<TriggerArea>();
    
    public void Add(TriggerArea ta){
        list.Add(ta);
        int i = list.Count;
        list[i-1].OnEnter += Collector.ShowEvent;
    }
    
    public static void ShowEvent(object sender, EventArgs e){
        TriggerArea trigger = (TriggerArea) sender;
        Debug.Log("Show in screen this event "+trigger.str);
        Debug.Log("Increase amount "+trigger.number);
        if(trigger.consumable){
            Destroy(trigger.gameObject);
        }
    }    
}
