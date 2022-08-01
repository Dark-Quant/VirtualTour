using System;
using UnityEngine;

[Serializable]
public class Teleporter : MonoBehaviour
{
    public GameObject rig;
    public GameObject gameManager;
    public Environments environment;
    private Texture2D texture;

    private Color colorDefault;
    private bool isHovered = false;
    private bool wasHovered = false;
    private EnvironmentLibrary environmentLibrary;
    private SkyboxController skyboxController;
    private TourScenes tourScenes;

    //public byte[] RawTexture
    //{
    //    get
    //    {
    //        return texture;
    //    }
    //    set
    //    {
    //        texture = value;
    //    }
    //}

    //public Texture2D Texture
    //{
    //    get
    //    {
    //        Texture2D texture = new Texture2D(2, 2);
    //        if (texture.LoadImage(this.texture))
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
    //        texture = value.EncodeToPNG();
    //    }
    //}

    private void Awake()
    {
        if (!gameObject.TryGetComponent<SpriteRenderer>(out _))
        {
            Debug.LogError("GameObject don't have got SpriteRenderer");
            Destroy(gameObject);
        }

        environmentLibrary = gameManager.GetComponentInChildren<EnvironmentLibrary>();
        skyboxController = gameManager.GetComponentInChildren<SkyboxController>();
        tourScenes = gameManager.GetComponent<TourScenes>();

        // Liseners
        Events.onHover.AddListener(ChangeColor);
        Events.onSelect.AddListener(TeleportRig);
    }

    private void OnDestroy()
    {
        Events.onHover.RemoveListener(ChangeColor);
        Events.onSelect.RemoveListener(TeleportRig);
    }

    private void Start()
    {
        colorDefault = GetComponent<SpriteRenderer>().color;
    }

    private void Update()
    {
        ChangeColor();
        isHovered = false;
    }

    public void ChangeColor(GameObject gameObject)
    {
        if (gameObject != this.gameObject) return;
        ChangeColor(true);
    }
    
    public void ChangeColor(bool _isHovered)
    {
        isHovered = _isHovered;
        ChangeColor();
    }

    public void ChangeColor()
    {
        if (isHovered && !wasHovered)
        {
            StartCoroutine(Utils.Interpolate(0.25f, colorDefault, Color.black, UpdateColor));
            wasHovered = true;
        }
        if (!isHovered && wasHovered)
        {
            StartCoroutine(Utils.Interpolate(0.25f,  GetComponent<SpriteRenderer>().color, colorDefault, UpdateColor));
            wasHovered = false;
        }
    }


    private void UpdateColor(Color color)
    {
        GetComponent<SpriteRenderer>().color = color;
    }

    public void TeleportRig(GameObject gameObject)
    {
        if (this.gameObject != gameObject) return;
        rig.transform.position = new Vector3(0f, 0f, 0f);
        skyboxController.NewEnvironment(environmentLibrary.environments[(int)environment]);
        transform.parent.gameObject.SetActive(false);
        tourScenes.SetActiveScene(environmentLibrary.environments[(int)environment].environmentName, true);
    }
}
