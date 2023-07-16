using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tower : MonoBehaviour {
    private TowerBuilder towerBuilder;
    private List<Block> blockList;
    public event UnityAction<int> countSize; 
    

    private void Start(){
        towerBuilder = GetComponent<TowerBuilder>();
        blockList = towerBuilder.BuildTowerBlocks();
        countSize?.Invoke(blockList.Count);
        foreach (var block in blockList){
            block.bulletHit += OnHitEvent;
        }
    }

    public void OnHitEvent(Block _block){
        _block.bulletHit -= OnHitEvent;
        blockList.Remove(_block);
        countSize?.Invoke(blockList.Count);
        foreach (var block in blockList){
            block.transform.position = new Vector3(block.transform.position.x,
                block.transform.position.y - block.transform.localScale.y, block.transform.position.z);
        }
    }

    public int GetCountBlocks(){
        return towerBuilder.BuildTowerBlocks().Count;
    }
}