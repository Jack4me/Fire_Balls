using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TowerSizeView : MonoBehaviour {
    [SerializeField] private TMP_Text viewCount;
    [SerializeField] private Tower tower;

    private void Awake(){
       
    }

    private void OnEnable(){
        tower.countSize += OnVisualUpdate;
    }

    private void OnDisable(){
        tower.countSize -= OnVisualUpdate;
    }

    private void OnVisualUpdate(int sizeTower){
        viewCount.text = sizeTower.ToString();
    }
}