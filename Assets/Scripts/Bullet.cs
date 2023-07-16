using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    [SerializeField] private float shotSpeed;
    private Vector3 direction;

    private void Awake(){
        direction = Vector3.forward;
    }

    private void Update(){
        transform.Translate(shotSpeed * direction * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other){
        if (other.TryGetComponent(out Block _block)){
            _block.Break();
            Destroy(gameObject);
        }
        if (other.TryGetComponent(out Obstacle _obstacle)){
            Bounce();
            
        }
    }

    public void Bounce(){
        direction = Vector3.back + Vector3.up;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.AddExplosionForce(100, new Vector3(0, -1, 1), 100);
    }
}