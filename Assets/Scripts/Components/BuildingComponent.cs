using System;
using UnityEngine;

public class BuildingComponent : MonoBehaviour
{
    public GameObject CollectionIcon;
    public int Seconds;
    
    private IslandComponent islandComponent;
    private bool ready;

    public DateTime DateTime { get; set; }
    public int Id { get; set; }

    private void Start()
    {
        var buildingController = GameObject.FindObjectOfType<BuildingController>();
        this.islandComponent = buildingController.CurrentIsland;
        this.CollectionIcon.SetActive(false);
    }

    private void Update()
    {
        if (DateTime.Now > this.DateTime)
        {
            this.ready = true;
            this.CollectionIcon.SetActive(true);
        }
<<<<<<< HEAD
    }

    public void Collect()
    {
        if (this.ready)
        {
            this.islandComponent.Add(Resource.Wood, 1);
            this.DateTime = DateTime.Now.AddSeconds(this.Seconds);
            this.ready = false;
            this.CollectionIcon.SetActive(false);
=======
        
        if (Input.GetMouseButtonUp(0))
        {
            if (!blocked)
            {
                position = this.transform.position;
                position.z = -0.1f;
                GameObject.Destroy(this);
            }

            else
            {
                GameObject.Destroy(this.gameObject);
            }
>>>>>>> a0123f590d22768e45b1637c7d19138f56f988fd
        }
    }
}
