using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeDetector : MonoBehaviour{
    TowerController tcRoot;
    float timeNextBullet;
    Transform target;


    void OnTriggerStay (Collider obj){
        switch (obj.tag){
            case "Enemy":
                target=obj.gameObject.GetComponent<Enemy_Actor>().damagePoint;
                tcRoot.towerHead.transform.LookAt(new Vector3(target.position.x,tcRoot.towerHead.transform.position.y,target.position.z));
                tcRoot.cannon.transform.LookAt(target.position);
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
