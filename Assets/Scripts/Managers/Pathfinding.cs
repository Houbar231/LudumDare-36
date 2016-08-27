using UnityEngine;
using System.Collections.Generic;

public class Pathfinding : MonoBehaviour {
    public static Pathfinding Instance;
    public int DestX, DestY;
    public Dictionary<MapTile, MapTile> NextTileToDest;

    void Awake() {
        Instance = this;
        NextTileToDest = new Dictionary<MapTile, MapTile>();
    }

    public void DoPathfinding() {
        Queue<MapTile> ToBeChecked = new Queue<MapTile>();
        ToBeChecked.Enqueue(Map.Instance.Tiles[DestX, DestY]);

        while(ToBeChecked.Count > 0) {
            MapTile ToBeCheckedNext = ToBeChecked.Dequeue();

            for(int i = Mathf.Max(ToBeCheckedNext.Data.x - 1, 0); i < Mathf.Min(ToBeCheckedNext.Data.y + 1, GeneralReference.r.Width-1); i++) {
                for(int j = Mathf.Max(ToBeCheckedNext.Data.y - 1, 0); j < Mathf.Min(ToBeCheckedNext.Data.y + 1, GeneralReference.r.Height-1); j++) { 
                    if(i == DestX && j == DestY) {
                        continue;
                    }
                    //Hello
                    if(! NextTileToDest.ContainsKey(Map.Instance.Tiles[i, j])) {
                        ToBeChecked.Enqueue(Map.Instance.Tiles[i, j]);
                        NextTileToDest.Add(Map.Instance.Tiles[i, j], ToBeCheckedNext);
                    }
                }
            }
        }
    }
}
