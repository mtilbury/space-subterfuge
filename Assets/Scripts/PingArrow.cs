using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PingArrow : MonoBehaviour
{
    public enum SetScreen { Attacker1, Attacker2, Attacker3, Defender};

    public SetScreen targetScreen = 0;
    [SerializeField]
    private Camera targetCamera;
    [SerializeField]
    private Canvas targetCanvas;

    [Space]

    private RectTransform m_icon;
    private Image m_iconImage;

    public Sprite onScreenSprite;
    public Sprite offScreenSprite;
    public Color spriteColor = Color.white;
    [Space]
    [Range(0, 600)]
    public float leftLimit;
    [Range(0, 600)]
    public float rightLimit;
    [Range(0, 600)]
    public float upLimit;
    [Range(0, 600)]
    public float downLimit;

    [Range(0, 1)]
    public float disappearRange;
    public Vector3 m_targetIconScale;
    public Vector3 m_targetOffScreenScale;
    [Space]
    public bool PointTarget = true;
    public bool ShowDebugLines;

    private bool isOnScreen;


    // Start is called before the first frame update
    void Start()
    {
        targetCamera = PingManager.Instance.GetCamera((int)targetScreen);
        targetCanvas = PingManager.Instance.GetCanvas((int)targetScreen);

        InstainateTargetIcon();
    }

    // Update is called once per frame
    void Update()
    {
        if (ShowDebugLines)
            DrawDebugLines();

        UpdateTargetPosition();
    }

    private void InstainateTargetIcon()
    {
        m_icon = new GameObject().AddComponent<RectTransform>();
        m_icon.transform.SetParent(targetCanvas.transform);
        m_icon.localScale = m_targetIconScale;
        m_icon.name = name + ": OTI icon";
        m_iconImage = m_icon.gameObject.AddComponent<Image>();
        m_iconImage.sprite = onScreenSprite;
        m_iconImage.color = spriteColor;
    }

    private void UpdateTargetPosition()
    {
        Vector3 newPos = transform.position;
        newPos = targetCamera.WorldToViewportPoint(newPos);
        Debug.Log(newPos);
        //Simple check if the target object is out of the screen or inside
     

        if (newPos.x > 1 || newPos.y > 1 || newPos.x < 0 || newPos.y < 0)
            isOnScreen = false;
        else {
            isOnScreen = true;

            if (newPos.x > .5f - disappearRange && newPos.x < .5 + disappearRange
                && newPos.y > .5f - disappearRange && newPos.y < .5 + disappearRange)
            {
                m_iconImage.enabled = false;
                return;
            }
            if (!m_iconImage.isActiveAndEnabled)
                m_iconImage.enabled = true;
        }

        
        if (newPos.z < 0)
        {
            /*
            newPos.x = 1f - newPos.x;
            newPos.y = 1f - newPos.y;
            newPos.z = 0;
            newPos = Vector3Maxamize(newPos);
            */

            newPos.x = 1f - newPos.x;
            newPos.y *= -1;
            newPos.z *= -1;
        }
        

        newPos = targetCamera.ViewportToScreenPoint(newPos);
        newPos.x = Mathf.Clamp(newPos.x, leftLimit, Screen.width - rightLimit);
        newPos.y = Mathf.Clamp(newPos.y, downLimit, Screen.height - upLimit);
        newPos.z = 0;
        //m_icon.anchoredPosition = newPos;
        //Debug.Log(m_icon.name + newPos);
        m_icon.transform.position = newPos;
        //Operations if the object is out of the screen
        if (!isOnScreen)
        {
            //Debug.Log("Is not on screen");
            //Show the target off screen icon
            m_iconImage.sprite = offScreenSprite;
            m_icon.localScale = m_targetOffScreenScale;
            if (PointTarget)
            {
                //Rotate the sprite towards the target object
                var targetPosLocal = targetCamera.transform.InverseTransformPoint(transform.position);
                var targetAngle = -Mathf.Atan2(targetPosLocal.x, targetPosLocal.y) * Mathf.Rad2Deg;
                //Apply rotation
                m_icon.transform.eulerAngles = new Vector3(0, 0, targetAngle);
            }

        }
        else
        {
            //Debug.Log("Is on screen");
            //Reset rotation to zero and swap the sprite to the "on screen" one
            m_icon.transform.eulerAngles = new Vector3(0, 0, 0);
            m_iconImage.sprite = onScreenSprite;
            m_icon.localScale = m_targetIconScale;
        }

    }

    public Vector3 Vector3Maxamize(Vector3 vector)
    {
        Vector3 returnVector = vector;
        float max = 0;
        max = vector.x > max ? vector.x : max;
        max = vector.y > max ? vector.y : max;
        max = vector.z > max ? vector.z : max;
        returnVector /= max;
        return returnVector;
    }

    public void DrawDebugLines()
    {
        Vector3 directionFromCamera = transform.position - targetCamera.transform.position;
        Vector3 cameraForwad = targetCamera.transform.forward;
        Vector3 cameraRight = targetCamera.transform.right;
        Vector3 cameraUp = targetCamera.transform.up;
        cameraForwad *= Vector3.Dot(cameraForwad, directionFromCamera);
        cameraRight *= Vector3.Dot(cameraRight, directionFromCamera);
        cameraUp *= Vector3.Dot(cameraUp, directionFromCamera);
        Debug.DrawRay(targetCamera.transform.position, directionFromCamera, Color.magenta);
        Vector3 forwardPlaneCenter = targetCamera.transform.position + cameraForwad;
        Debug.DrawLine(targetCamera.transform.position, forwardPlaneCenter, Color.blue);
        Debug.DrawLine(forwardPlaneCenter, forwardPlaneCenter + cameraUp, Color.green);
        Debug.DrawLine(forwardPlaneCenter, forwardPlaneCenter + cameraRight, Color.red);
    }

    private void OnDestroy()
    {
        Destroy(m_icon.gameObject);
    }
}
