using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : OnHoverHelper
{
    private void Start()
    {
        Material material = GetComponent<Renderer>().material;
        onHover = () => material.EnableKeyword("_EMISSION");
        onNoHover = () => material.DisableKeyword("_EMISSION");
    }
    protected override void ActionOnHover(GameObject gameObject)
    {
        if (this.gameObject != gameObject) return;
        isHovered = true;
        ActionOnHover();
    }
}
