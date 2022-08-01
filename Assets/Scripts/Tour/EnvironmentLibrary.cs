using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnvironmentLibrary : MonoBehaviour
{
    public SkyboxController skybox;
    public List<Environment> environments = null;

    private void Start()
    {
        RenderSettings.skybox.mainTexture = environments[0].background;
    }

    public void AddEnvironment(string environmentName, Texture2D background, int worldRotation)
    {
        environments.Add(new Environment(environmentName, background, worldRotation));
    }

    public void UpdateEnumEnvironments()
    {
        List<string> values = new List<string>();
        foreach (Environment e in this.environments)
        {
            values.Add(e.environmentName);
        }
        var environments = new CreateEnum.EnumHandler("Environments", values);

        CreateEnum.CreateEnumsFile("Assets/Scripts/Enums.cs", environments);
    }

}

[Serializable]
public class Environment
{
    public string environmentName;
    public int worldRotation = 0;

    public Texture2D background;
    public Environment(string environmentName, Texture2D texture)
    {
        this.environmentName = environmentName;
        this.background = texture;
    }

    public Environment(string environmentName, Texture2D background, int worldRotation)
    {
        this.environmentName = environmentName;
        this.background = background;
        this.worldRotation = worldRotation;
    }

    //public Environment(string environmentName, byte[] texture)
    //{
    //    this.environmentName = environmentName;
    //    this.RawBackground = texture;
    //}

    //public Environment(string environmentName, byte[] background, int worldRotation)
    //{
    //    this.environmentName = environmentName;
    //    this.RawBackground = background;
    //    this.worldRotation = worldRotation;
    //}

    //public byte[] RawBackground
    //{
    //     get
    //    {
    //        return background;
    //    }
    //    set
    //    {
    //        background = value;
    //    }
    //}

    //public Texture2D Background
    //{
    //    get
    //    {
    //        Texture2D texture = new Texture2D(2, 2);
    //        if (texture.LoadImage(background))
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
    //        background = value.EncodeToPNG();
    //    }
    //}

}