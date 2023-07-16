using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Tank : MonoBehaviour {
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private Bullet bullet;
    [SerializeField] private float delayShot;
    [SerializeField] private float bounceDistance;
    private float timer;
    private void Update(){
        timer += Time.deltaTime;
        if (Input.GetMouseButton(0)){
            if (timer > delayShot){
                timer = 0;
                Shot();
                transform.DOMoveZ(transform.position.z - bounceDistance, delayShot / 2).SetLoops(2, LoopType.Yoyo);
            }
        }
    }

    public void Shot(){
        Instantiate(bullet, bulletSpawn.position, Quaternion.identity, transform);
    }
}
