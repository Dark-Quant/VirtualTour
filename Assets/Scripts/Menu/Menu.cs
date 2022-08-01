using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject leftArrow;
    public GameObject rightArrow;
    public GameObject screen;
    public GameObject button;
    public List<Tour> tours;

    private int tourIndex = 0;

    private void Awake()
    {
        Events.onSelect.AddListener(PreviousTour); 
        Events.onSelect.AddListener(NextTour);
        Events.onSelect.AddListener(Select);
    }
    private void PreviousTour(GameObject gameObject)
    {
        if (gameObject != leftArrow) return;
        tourIndex--;
        if (tourIndex < 0)
        {
            tourIndex = tours.Count - 1;
        }
        ChangePreviewTour();
    }
    private void NextTour(GameObject gameObject)
    {
        if (gameObject != rightArrow) return;
        tourIndex++;
        if (tourIndex > tours.Count - 1)
        {
            tourIndex = 0;
        }
        ChangePreviewTour();
    }

    private void Select(GameObject gameObject)
    {
        if (gameObject != button) return;
        // Load Scene
        SceneManager.LoadScene(tours[tourIndex].title);
    }

    private void ChangePreviewTour()
    {
        screen.GetComponent<Renderer>().material.SetTexture("_MainTex", tours[tourIndex].icon);
    }
    
}

//[Serializable]
//public class Tour
//{
//    public string title;
//    public Texture icon;
//}