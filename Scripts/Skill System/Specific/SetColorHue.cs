//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class SetColorHue : MonoBehaviour
//{

//    public GameObject currentInstance;
//    [Range(0f, 360f)]
//    public float colorHUE = 0f;
//    float oldColorHUE = 0f;
//    public bool isChangable = true;
//    private void Awake()
//    {
//        if (currentInstance == null)
//            currentInstance = gameObject;
//        Update();
//    }

//    private void OnEnable()
//    {
//        Update();
//    }

//    // Use this for initialization
//    private void Update()
//    {
//        if (Mathf.Abs(oldColorHUE - colorHUE) > 0.001)
//        {
//            RFX4_ColorHelper.ChangeObjectColorByHUE(currentInstance, colorHUE / 360f);
//            var transformMotion = currentInstance.GetComponentInChildren<RFX4_TransformMotion>(true);
//            if (transformMotion != null)
//            {
//                transformMotion.HUE = colorHUE / 360f;
//                foreach (var collidedInstance in transformMotion.CollidedInstances)
//                {
//                    if (collidedInstance != null) RFX4_ColorHelper.ChangeObjectColorByHUE(collidedInstance, colorHUE / 360f);
//                }
//            }

//            var rayCastCollision = currentInstance.GetComponentInChildren<RFX4_RaycastCollision>(true);
//            if (rayCastCollision != null)
//            {
//                rayCastCollision.HUE = colorHUE / 360f;
//                foreach (var collidedInstance in rayCastCollision.CollidedInstances)
//                {
//                    if (collidedInstance != null) RFX4_ColorHelper.ChangeObjectColorByHUE(collidedInstance, colorHUE / 360f);
//                }
//            }
//        }
//    }
//}
