using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SkyboxController : Controller
{
    protected override IEnumerator Apply(Environment environment)
    {
        float startValue = RenderSettings.skybox.GetFloat("_Exposure");
        yield return StartCoroutine(Utils.Interpolate(0.25f, startValue, 0F, UpdateExposureCallback));

        RenderSettings.skybox.SetFloat("_Rotation", environment.worldRotation);
        RenderSettings.skybox.mainTexture = environment.background;

        startValue = RenderSettings.skybox.GetFloat("_Exposure");
        yield return StartCoroutine(Utils.Interpolate(0.25f, startValue, 1F, UpdateExposureCallback));

        Debug.Log("Skybox is updated");
    }

    private void UpdateExposureCallback(float value)
    {
        RenderSettings.skybox.SetFloat("_Exposure", value);
    }
}
