using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
{
    public AnimationCurve VelocityOnXAxis;
    public AnimationCurve VelocityOnYAxis;
    public AnimationCurve VelocityOnZAxis;

    float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Vector3 ds = new Vector3(VelocityOnXAxis.Evaluate(timer), VelocityOnYAxis.Evaluate(timer), VelocityOnZAxis.Evaluate(timer)) * Time.deltaTime;
        transform.Translate(ds, Space.World);
    }
}
