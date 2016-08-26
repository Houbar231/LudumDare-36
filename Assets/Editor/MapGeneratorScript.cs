using UnityEngine;
using UnityEditor;
using System.Collections;
[CustomEditor(typeof(TerrainGenerator))]
public class MapGeneratorScript : Editor {
    public override void OnInspectorGUI() {
        DrawDefaultInspector();

        TerrainGenerator t = (TerrainGenerator)target;

        if(GUILayout.Button("Generate")) {
            t.Start();   
        }
    }
}
