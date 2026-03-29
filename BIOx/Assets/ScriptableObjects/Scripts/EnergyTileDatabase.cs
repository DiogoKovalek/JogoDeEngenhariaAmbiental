using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


[CreateAssetMenu(menuName = "ScrObj/TilesDatabase")]
public class EnergyTileDatabase : ScriptableObject
{
    [SerializeField] private int size = 11;
    [SerializeField] private TileBase[] tilesOn;
    [SerializeField] private TileBase[] tilesOff;

    private void OnValidate()
    {
        if(tilesOn == null || tilesOff == null) return;
        if(tilesOn.Length != size && tilesOn.Length != 0)
        {
            Debug.LogError("\"tilesOn\" in EnergyTileDatabase not have same size that \"size\"", this);
        }
        if(tilesOff.Length != size && tilesOff.Length != 0)
        {
            Debug.LogError("\"tilesOff\" in EnergyTileDatabase not have same size that \"size\"", this);
        }
    }

    public TileBase GetOn(TileBase tOff)
    {
        for(int i = 0; i < size; i++)
        {
            if(tOff.Equals(tilesOff[i])) return tilesOn[i];
        }
        Debug.LogError("Not found tileOn");
        return null;
    }
    public TileBase GetOff(TileBase tOn)
    {
        for(int i = 0; i < size; i++)
        {
            if(tOn.Equals(tilesOn[i])) return tilesOff[i];
        }
        Debug.LogError("Not found tileOn");
        return null;
    }
}