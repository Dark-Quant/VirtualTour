using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class Utils 
{
    public static IEnumerator Interpolate(float targetTime, float startValue, float endValue, UnityAction<float> action)
    {
        float lerpTime = 0F;

        while (lerpTime < targetTime)
        {
            lerpTime += Time.deltaTime;

            float percentage = lerpTime / targetTime;
            float finalValue = Mathf.Lerp(startValue, endValue, percentage);

            if (action != null) action.Invoke(finalValue);

            yield return null;
        }
    }
    public static IEnumerator Interpolate(float targetTime, Color startValue, Color endValue, UnityAction<Color> action)
    {
        float lerpTime = 0F;

        while (lerpTime < targetTime)
        {
            lerpTime += Time.deltaTime;

            float percentage = lerpTime / targetTime;
            Color finalValue = Color.Lerp(startValue, endValue, percentage);

            if (action != null) action.Invoke(finalValue);

            yield return null;
        }
    }
    public static Texture2D AddWatermark(Texture2D background, Texture2D watermark)
    {
        int startX = 0;
        int startY = background.height - watermark.height;

        for (int x = startX; x < background.width; x++)
        {

            for (int y = startY; y < background.height; y++)
            {
                Color bgColor = background.GetPixel(x, y);
                Color wmColor = watermark.GetPixel(x - startX, y - startY);

                Color final_color = Color.Lerp(bgColor, wmColor, wmColor.a / 1.0f);

                background.SetPixel(x, y, final_color);
            }
        }

        background.Apply();
        return background;
    }
}
