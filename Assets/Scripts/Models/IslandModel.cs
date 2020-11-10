using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class IslandModel
{
    public List<RegionModel> Regions;
    public List<Resource> ResourceKeys;
    public List<int> ResourceValues;
    public int Id;
    
    public IslandModel(int id)
    {
        this.Regions = new List<RegionModel>();
        this.ResourceKeys = new List<Resource>();
        this.ResourceValues = new List<int>();
        this.Id = id;
    }

    public void Set(BuildingComponent buildingComponent, int regionId)
    {
        var region = this.Regions.Where(r => r.Id == regionId).FirstOrDefault();
        if (region == null)
        {
            region = new RegionModel(regionId);
            this.Regions.Add(region);
        }
        region.Set(buildingComponent);
    }

    public void Remove(GameObject buildingObject, int regionId)
    {
        var region = this.Regions.Where(r => r.Id == regionId).FirstOrDefault();
        if (region == null)
            return;
        region.Remove(buildingObject);
    }
}
