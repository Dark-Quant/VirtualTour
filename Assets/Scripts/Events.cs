using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class Events
{
    public class OnHover: UnityEvent<GameObject> 
    {
    }
    public class OnSelect : UnityEvent<GameObject> { }

    public static UnityEvent onTouchStart = new UnityEvent();
    public static UnityEvent onTouchEnd = new UnityEvent();
    public static OnHover onHover = new OnHover();
    public static OnSelect onSelect = new OnSelect();
}
