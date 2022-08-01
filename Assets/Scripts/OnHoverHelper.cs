using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class OnHoverHelper : MonoBehaviour
{
    protected bool isHovered = false;
    protected bool wasHovered = false;
    protected UnityAction onHover;
    protected UnityAction onNoHover;

    private void Awake()
    {
        Events.onHover.AddListener(ActionOnHover);
    }

    private void OnDestroy()
    {
        Events.onHover.AddListener(ActionOnHover);
    }

    private void Update()
    {
        ActionOnHover();
        isHovered = false;
    }
    protected abstract void ActionOnHover(GameObject gameObject);
    protected void ActionOnHover()
    {
        if (isHovered && !wasHovered)
        {
            onHover.Invoke();
            wasHovered = true;
        }
        if (!isHovered && wasHovered)
        {
            onNoHover.Invoke();
            wasHovered = false;
        }
    }
}
