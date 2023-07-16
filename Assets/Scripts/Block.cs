using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour {
   public event UnityAction<Block> bulletHit;
   [SerializeField] private ParticleSystem destroyEffect;
   private MeshRenderer meshRenderer;

   private void Awake(){
      meshRenderer = GetComponent<MeshRenderer>();
   }

   public void SetColor(Color _color){
      meshRenderer.material.color = _color;
   }
   public void Break(){
      bulletHit?.Invoke(this);
      ParticleSystemRenderer renderer = Instantiate(destroyEffect, transform.position, destroyEffect.transform.rotation).GetComponent<ParticleSystemRenderer>();
      renderer.material.color = meshRenderer.material.color;
      Destroy(gameObject);
   }
    
}
