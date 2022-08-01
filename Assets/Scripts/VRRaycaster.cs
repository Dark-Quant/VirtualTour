using UnityEngine;
using UnityEngine.Events;

public class VRRaycaster : MonoBehaviour
{
    public Transform leftHandAnchor = null;
    public Transform rightHandAnchor = null;
    public Transform centerEyeAnchor = null;
    public LineRenderer lineRenderer = null;
    public float maxRayDistance = 500.0f;
    public float maxLineDistance = 0.3F;
    public LayerMask excludeLayers;

    void Awake()
    {
        // Render 
        if (leftHandAnchor == null)
        {
            Debug.LogWarning("Assign LeftHandAnchor in the inspector!");
            GameObject left = GameObject.Find("LeftHandAnchor");
            if (left != null)
            {
                leftHandAnchor = left.transform;
            }
        }
        if (rightHandAnchor == null)
        {
            Debug.LogWarning("Assign RightHandAnchor in the inspector!");
            GameObject right = GameObject.Find("RightHandAnchor");
            if (right != null)
            {
                rightHandAnchor = right.transform;
            }
        }
        if (centerEyeAnchor == null)
        {
            Debug.LogWarning("Assign CenterEyeAnchor in the inspector!");
            GameObject center = GameObject.Find("CenterEyeAnchor");
            if (center != null)
            {
                centerEyeAnchor = center.transform;
            }
        }
        if (lineRenderer == null)
        {
            Debug.LogWarning("Assign a line renderer in the inspector!");
            lineRenderer = gameObject.AddComponent<LineRenderer>();
            lineRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
            lineRenderer.receiveShadows = false;
            lineRenderer.widthMultiplier = 0.02f;
        }

        // Listeners
        Events.onTouchStart.AddListener(OnTouchStart);
        Events.onTouchEnd.AddListener(OnTouchEnd);
       
    }

    //private void OnDestroy()
    //{
    //    Events.onTouchStart.RemoveListener(OnTouchStart);
    //    Events.onTouchEnd.RemoveListener(OnTouchEnd);
    //}

    Transform Pointer
    {
        get
        {
            OVRInput.Controller controller = OVRInput.GetConnectedControllers();
            if ((controller & OVRInput.Controller.RTouch) != OVRInput.Controller.None)
            {
                return rightHandAnchor;
            }
            else if ((controller & OVRInput.Controller.LTouch) != OVRInput.Controller.None)
            {
                return leftHandAnchor;
            }
            // If no controllers are connected, we use ray from the view camera. 
            // This looks super ackward! Should probably fall back to a simple reticle!
            return centerEyeAnchor;
        }
    }



    void Update()
    {
        Transform pointer = Pointer;
        if (pointer == null) return;
        Ray laserPointer = new Ray(pointer.position, pointer.forward);

        if (lineRenderer != null)
        {
            lineRenderer.SetPosition(0, laserPointer.origin);
            lineRenderer.SetPosition(1, laserPointer.origin + laserPointer.direction * maxLineDistance);
        }
        RaycastHit hit;
        if (Physics.Raycast(laserPointer, out hit, maxRayDistance, ~excludeLayers))
        {
            if (lineRenderer != null && hit.distance < maxLineDistance)
            {
                lineRenderer.SetPosition(1, hit.point);
            }
            Events.onHover.Invoke(hit.transform.gameObject);
        }
    }

    private void OnTouchStart()
    {
        lineRenderer.SetColors(new Color(0f, 0f, 230f), new Color(125f, 125, 240f));
    }
    
    private void OnTouchEnd()
    {
        lineRenderer.startColor = new Color(250f, 250f, 250f);
        lineRenderer.endColor = new Color(250f, 250f, 250f);
        OnSelect();
    }

    private void OnSelect()
    {
        Transform pointer = Pointer;
        if (pointer == null) return;
        RaycastHit hit;
        if (Physics.Raycast(new Ray(pointer.position, pointer.forward), out hit, maxRayDistance, ~excludeLayers))
        {
            Events.onSelect.Invoke(hit.transform.gameObject);
        }
    }
}