using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

sealed public class PowerCable : ReceivesEnergy
{
    private Tilemap tilemap;
    [SerializeField] EnergyTileDatabase etDB;
    void Start() {
        tilemap = GetComponent<Tilemap>();
    } 
    protected override void deciveON() {
        base.deciveON();
        cablesOn();
    }
    protected override void deciveOFF() {
        base.deciveOFF();
        cablesOff();
    }

    private void cablesOn(){
        BoundsInt bounds = tilemap.cellBounds;
        TileBase[] tiles = tilemap.GetTilesBlock(bounds);

        for(int i = 0; i < tiles.Length; i++){
            if(tiles[i] == null) continue;
            tiles[i] = etDB.GetOn(tiles[i]);
        }

        tilemap.SetTilesBlock(bounds, tiles);
    }
    private void cablesOff()
    {
        BoundsInt bounds = tilemap.cellBounds;
        TileBase[] tiles = tilemap.GetTilesBlock(bounds);

        for(int i = 0; i < tiles.Length; i++){
            if(tiles[i] == null) continue;
            tiles[i] = etDB.GetOff(tiles[i]);
        }

        tilemap.SetTilesBlock(bounds, tiles);
    }
}
