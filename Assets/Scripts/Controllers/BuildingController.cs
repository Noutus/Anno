using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class BuildingController : MonoBehaviour
{
    private List<IslandModel> islands;

    private bool changed;

    public IslandComponent CurrentIsland { get; set; }
    public int RegionId { get; set; }

    private void Awake()
    {
        this.Load();
    }

    private void Update()
    {
        if (this.changed)
        {
            this.Save();
        }
    }

    public List<BuildingModel> Get()
    {
        var island = this.islands.Where(i => i.Id == this.CurrentIsland.Id).FirstOrDefault();
        if (island == null)
            return new List<BuildingModel>();

        var region = island.Regions.Where(r => r.Id == this.RegionId).FirstOrDefault();
        if (region == null)
            return new List<BuildingModel>();

        return region.Buildings;
    }

    public void Set(IslandComponent islandComponent)
    {
        var island = this.islands.Where(isl => isl.Id == this.CurrentIsland.Id).FirstOrDefault();
        if (island == null)
        {
            island = new IslandModel(this.CurrentIsland.Id);
            this.islands.Add(island);
        }

        else
        {
            island.ResourceKeys = new List<Resource>();
            island.ResourceValues = new List<int>();

            foreach (var pair in islandComponent.Resources)
            {                
                island.ResourceKeys.Add(pair.Key);
                island.ResourceValues.Add(pair.Value);
            }
        }

        this.changed = true;
    }

    public void Set(BuildingComponent buildingComponent)
    {
        var island = this.islands.Where(i => i.Id == this.CurrentIsland.Id).FirstOrDefault();
        if (island == null)
        {
            island = new IslandModel(this.CurrentIsland.Id);
            this.islands.Add(island);
        }
        island.Set(buildingComponent, this.RegionId);
        this.changed = true;
    }

    public void Remove(GameObject buildingObject)
    {
        var island = this.islands.Where(i => i.Id == this.CurrentIsland.Id).FirstOrDefault();
        if (island == null)
            return;
        island.Remove(buildingObject, this.RegionId);
        this.changed = true;
    }

    private void Load()
    {
        var path = Application.persistentDataPath + "/game.save";

        if (!File.Exists(path))
            this.islands = new List<IslandModel>();

        else
        {
            try
            {
                var formatter = new BinaryFormatter();
                Stream file;
                using (file = File.Open(path, FileMode.Open))
                {
                    this.islands = formatter.Deserialize(file) as List<IslandModel>;
                }
            }

            catch(Exception e)
            {
                this.islands = new List<IslandModel>();
            }
        }
        
        this.changed = false;
    }

    private void Save()
    {
        var path = Application.persistentDataPath + "/game.save";
        var formatter = new BinaryFormatter();
        var file = File.Create(path);

        formatter.Serialize(file, this.islands);
        file.Close();

        this.changed = false;
    }
}
