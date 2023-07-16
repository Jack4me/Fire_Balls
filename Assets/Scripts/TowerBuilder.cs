using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class TowerBuilder : MonoBehaviour {
    [SerializeField] private float sizeTower;
    [SerializeField] private Transform buildPoint;
    [SerializeField] private Block block;
    [SerializeField] private List<Block> blockList;
    [SerializeField] private Color[] colors;

    private void Start(){
        
    }

    public List<Block> BuildTowerBlocks(){
        blockList = new List<Block>();
        Transform curentPoint = buildPoint;
        for (int i = 0; i < sizeTower; i++){
            Block newBlock = CreateBlock(curentPoint);
            newBlock.SetColor(colors[Random.Range(0, colors.Length)]);
            blockList.Add(newBlock);
            curentPoint = newBlock.transform;
        }
        return blockList;
    }

    public Block CreateBlock(Transform curentPosition){
        return Instantiate(block, GetBlockPosition(curentPosition), quaternion.identity, buildPoint);
    }

    private Vector3 GetBlockPosition(Transform _curentPoint){
        return new Vector3(buildPoint.transform.position.x,
            _curentPoint.position.y + _curentPoint.localScale.y / 2 + block.transform.localScale.y / 2,
            _curentPoint.transform.position.z);
    }
}