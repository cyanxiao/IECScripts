using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Camera))]
public class CameraCtrl : MonoBehaviour
{
    #region 参数
    [Header("Player View Control")]
    public float XSensitivity = 2f;
    public float YSensitivity = 4f;
    public bool clampVerticalRotation = true;
    public bool clampHorizontalRotation = true;
    public float MinX = -90f;
    public float MaxX = 90f;
    public float MinY = -90f;
    public float MaxY = 90f;
    public bool smooth = true;
    public float smoothTime = 15f;
    public bool lockCursor = true;
    [SerializeField]
    Transform cameraX;
    Transform cameraY;
    Quaternion cameraTargetYRot;
    Quaternion cameraTargatXRot;

    [Header("牵连效果")]
    public bool enableImplicatedEffect = true;
    public AnimationCurve FovCurve = AnimationCurve.EaseInOut(0f, 1f, 1f, 1.3f);
    public float MaxVelocity = 50f;
    public float smoothTimeForFov = 3f;
   
    Camera thisCamera;

    #endregion
    public static CameraCtrl Instance
    {
        get; private set;
    }

    Transform parent;
    private void Awake()
    {
        thisCamera = GetComponent<Camera>();
        parent = transform.parent;
        Instance = this;
    }

    private void Start()
    {
        if (parent == null)
        {
            GameObject obj = Resources.Load<GameObject>("EmptyObject");
            obj = Instantiate(obj, transform.position, transform.rotation);
            parent = obj.transform;
            transform.SetParent(obj.transform);
        }
        //辅助计算x轴和y轴旋转
        GameObject emptyObj = GameDB.Instance.EmptyObject;
        cameraX = Instantiate(emptyObj).transform;
        if (cameraX == null)
            Debug.Log("Null");
        cameraX.name = "camera x axis";
        cameraY = Instantiate(emptyObj).transform;
        cameraY.name = "camera y axis";
        //cameraX = transform.GetChild(0);
        //cameraY = transform;
        cameraTargatXRot = cameraX.localRotation;
        cameraTargetYRot = cameraY.localRotation;

        lockCursor = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    private void Update()
    {
        if (GameCtrl.PlayerUnit == null)
        {
            return;
        }
        CheckInput();
    }

    public void UpdatePosition()
    {
        prevPos = parent.position;
    }
    
    Vector3 prevPos;

    private void FixedUpdate()
    {
        if (GameCtrl.PlayerUnit == null)
        {
            return;
        }
        parent.position = GameCtrl.PlayerUnit.EyeTransform.position;
        UpdatePosition();
        UpdateCameraRotation(Time.fixedDeltaTime);
    }

    private float xRot, yRot;
    private void UpdateCameraRotation(float dt)
    {
        xRot = Input.GetAxis("Mouse Y") * XSensitivity;
        yRot = Input.GetAxis("Mouse X") * YSensitivity;
        cameraTargatXRot *= Quaternion.Euler(-xRot, 0f, 0f);
        cameraTargetYRot *= Quaternion.Euler(0f, yRot, 0f);

        if (clampVerticalRotation)
        {
            cameraTargatXRot = ClampRotationAroundXAxis(cameraTargatXRot);
        }
        if (clampHorizontalRotation)
        {
            cameraTargetYRot = ClampRotationAroundYAxis(cameraTargetYRot);
        }

        if (smooth)
        {
            cameraX.localRotation = Quaternion.Slerp(cameraX.localRotation, cameraTargatXRot, dt * smoothTime);
            cameraY.localRotation = Quaternion.Slerp(cameraY.localRotation, cameraTargetYRot, dt * smoothTime);
        }
        else
        {
            cameraX.localRotation = cameraTargatXRot;
            cameraY.localRotation = cameraTargetYRot;
        }
        parent.localEulerAngles = new Vector3(cameraX.localEulerAngles.x, cameraY.localEulerAngles.y, 0f);
        //SetAngleAroundZAxis(GameCtrl.PlayerUnit.EyeTransform.eulerAngles.z);
        //parent.rotation = GameCtrl.PlayerUnit.EyeTransform.rotation;
    }

    private void CheckInput()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && lockCursor)
        {
            lockCursor = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (Input.GetMouseButtonUp(0) && !lockCursor)
        {
            lockCursor = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    private Quaternion ClampRotationAroundXAxis(Quaternion q)
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1f;

        float angleX = 2f * Mathf.Rad2Deg * Mathf.Atan(q.x);

        angleX = Mathf.Clamp(angleX, MinX, MaxX);

        q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

        return q;
    }

    private Quaternion ClampRotationAroundYAxis(Quaternion q)
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1f;

        float angleY = 2f * Mathf.Rad2Deg * Mathf.Atan(q.y);

        angleY = Mathf.Clamp(angleY, MinY, MaxY);

        q.y = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleY);

        return q;
    }

    /// <summary>
    /// 设置镜头绕z轴的旋转角度。由Player的BodyBalancing设定。
    /// </summary>
    /// <param name="angle">角度</param>
    public void SetAngleAroundZAxis(float angle)
    {
        Vector3 ea = transform.localEulerAngles;
        ea.z = angle;
        transform.localEulerAngles = ea;
    }

}
