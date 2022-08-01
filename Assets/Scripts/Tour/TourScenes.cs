using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TourScenes : MonoBehaviour
{
    public GameObject scenes;

    private void Awake()
    {
        if (scenes == null)
        {
            scenes = GameObject.Find("Scenes");
        }
    }

    public void AddScene(string name)
    {
        Instantiate(new GameObject(name), new Vector3(0f, 0f, 0f), Quaternion.identity).transform.SetParent(scenes.transform);
    }

    public GameObject GetScene(string name)
    {
        return scenes.transform.Find(name).gameObject;
    }

    public void SetActiveScene(string name, bool active)
    {
        GetScene(name).SetActive(active);
    }
}
