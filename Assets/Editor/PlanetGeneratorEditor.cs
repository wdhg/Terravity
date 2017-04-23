using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlanetGenerator))]
public class PlanetGeneratorEditor : Editor {

    public override void OnInspectorGUI() {
        PlanetGenerator pg = (PlanetGenerator) target;

        if(DrawDefaultInspector() && pg.autoUpdate) {
            pg.Generate();
        }

        if(GUILayout.Button("Generate")) {
            pg.Generate();
        }
    }

}
