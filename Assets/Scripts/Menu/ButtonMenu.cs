using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMenu : OnHoverHelper
{
    // Start is called before the first frame update
    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        onHover = () => renderer.material.EnableKeyword("_EMISSION");
        onNoHover = () => renderer.material.DisableKeyword("_EMISSION");
    }

    protected override void ActionOnHover(GameObject gameObject)
    {
        if (this.gameObject != gameObject) return;
        isHovered = true;
        ActionOnHover();
    }
} 