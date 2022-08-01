using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Tour 
{
    public string title;
    public Texture2D icon;

    private GameObject gameMananager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("GameManager.prefab"));
    private byte[] rawIcon;
    private List<GameObject> scenes;
    private EnvironmentLibrary environments;

    public Tour(string title)
    {
        environments = gameMananager.GetComponentInChildren<EnvironmentLibrary>();
    }

    //public byte[] RawIcon
    //{
    //    get
    //    {
    //        return rawIcon;
    //    }
    //    set
    //    {
    //        rawIcon = value;
    //    }
    //}

    //public Texture2D Icon
    //{
    //    get
    //    {
    //        Texture2D texture = new Texture2D(2, 2);
    //        if (texture.LoadImage(rawIcon))
    //        {
    //            return texture;
    //        }
    //        else
    //        {
    //            return null;
    //        }
    //    }
    //    set
    //    {
    //        rawIcon = value.EncodeToPNG();
    //    }
    //}
}
