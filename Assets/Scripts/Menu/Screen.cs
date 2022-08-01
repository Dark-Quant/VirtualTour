using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen : OnHoverHelper
{
    public GameObject button;
    private void Start()
    {
        button.SetActive(false);
        onHover = () =>
        {
            StartCoroutine(Utils.Interpolate(0.2f, GetComponent<Renderer>().material.GetColor("_Color"), Color.gray,
                (color) => GetComponent<Renderer>().material.SetColor("_Color", color)));
            button.SetActive(true);
        };
        onNoHover = () =>
        {
            StartCoroutine(Utils.Interpolate(0.2f, GetComponent<Renderer>().material.GetColor("_Color"), Color.white,
                            (color) => GetComponent<Renderer>().material.SetColor("_Color", color)));
            button.SetActive(false);
        };
    }

    protected override void ActionOnHover(GameObject gameObject)
    {
        if (gameObject != this.gameObject && gameObject != button) return;
        isHovered = true;
        ActionOnHover();
    }
}
