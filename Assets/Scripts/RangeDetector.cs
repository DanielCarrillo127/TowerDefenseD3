using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeDetector : MonoBehaviour{
    TowerController tcRoot;

    void OnTriggerStay (Collider obj){
        switch (obj.tag){
            case "Enemy":
                tcRoot.towerHead.transform.LookAt(obj.transform);
            break;
            
        }
    }
    void Start (){
        tcRoot = transform.parent.gameObject.GetComponent<TowerController>();
    }
}
