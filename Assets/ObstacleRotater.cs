using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObstacleRotater : MonoBehaviour {
    [SerializeField] private float animationDuration;

    private void Start(){
        transform.DORotate(new Vector3(0, 720, 0), animationDuration, RotateMode.FastBeyond360)
            .SetLoops(-1, LoopType.Yoyo);
    }
}