using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAccuracy : MonoBehaviour
{
    public float testAccuracy = 90f;
    public int maxNum = 10000;
    public bool trigger = false;
    private void Update()
    {
        if (trigger)
        {
            trigger = false;

            Vector3 fwd = Vector3.forward;
            Vector3 tmp;
            float c = 1f / maxNum;
            float averageHorizontalAngle = 0f;
            float averageVerticalAngle = 0f;
            float tmpAngle;
            for (int i = 0; i < maxNum; i++)
            {
                tmp = Gamef.GenerateRandomDirection(fwd,testAccuracy);
                tmpAngle = Vector3.Angle(fwd, tmp);
                averageVerticalAngle += tmpAngle;
                tmpAngle = Vector3.SignedAngle(Vector3.right, Vector3.ProjectOnPlane(tmp, Vector3.forward), Vector3.forward);
                averageHorizontalAngle += tmpAngle;
            }
            averageHorizontalAngle *= c;
            averageVerticalAngle *= c;
            UnityEngine.Debug.Log(string.Format("Avg H Angle = {0}, Avg V Angle = {1}", averageHorizontalAngle, averageVerticalAngle));
        }
    }
}
