using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeDetector : MonoBehaviour{
    TowerController tcRoot;
    float timeNextBullet;

    void OnTriggerStay (Collider obj){
        switch (obj.tag){
            case "Enemy":
                tcRoot.towerHead.transform.LookAt(new Vector3(obj.transform.position.x,tcRoot.towerHead.transform.position.y,obj.transform.position.z));
                tcRoot.cannon.transform.LookAt(obj.transform.position);
                if(Time.time>timeNextBullet){
                Instantiate(tcRoot.bulletReference,tcRoot.bulletSpawn.position,tcRoot.bulletSpawn.rotation);
                timeNextBullet =Time.time + tcRoot.fireRate;

                }

            break;
            
        }
    }
    void Start (){
        tcRoot = transform.parent.gameObject.GetComponent<TowerController>();
    }
}
