using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandComponent : MonoBehaviour
{
    private const int Maximum = 40;

    public int Id;

    private BuildingController buildingController;

    public Dictionary<Resource, int> Resources { get; set; }

    private void Awake()
    {
        this.Resources = new Dictionary<Resource, int>();
    }

    private void Start()
    {
        this.buildingController = GameObject.FindObjectOfType<BuildingController>();
    }

    public void Add(Resource resource, int value)
    {
        if (!this.Resources.ContainsKey(resource))
            this.Resources.Add(resource, 0);
        this.Resources[resource] = Mathf.Min(this.Resources[resource] + value, Maximum);

        this.buildingController.Set(this);
    }
}
