using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceComponent : MonoBehaviour
{
    public Text Text;

    public Resource Resource;

    private BuildingController buildingController;

    private void Start()
    {
        this.buildingController = GameObject.FindObjectOfType<BuildingController>();
    }

    private void Update()
    {
        var island = this.buildingController.CurrentIsland;
        if (island != null)
        {
            this.Text.text = string.Format("{0}", island.Get(this.Resource));
        }
    }
}
