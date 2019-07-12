using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneInfo : MonoBehaviour {
    public static GameSceneInfo Instance
    {
        get; private set;
    }
    private void Awake()
    {
        Instance = this;
    }

    public Transform ReusableGameObjectParent;
}
