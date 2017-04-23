using UnityEngine;

public class PlanetGenerator : MonoBehaviour {

    public GameObject planetObj;
    public Object[] objects;
    public bool autoUpdate;

    private System.Random rnd;

    private void Start() {
        Generate();
    }

    public void Generate() {
        if(GameObject.Find("Planet")) {
            DestroyImmediate(GameObject.Find("Planet"));
        }

        GameObject planet = Instantiate(planetObj);
        planet.name = "Planet";

        rnd = new System.Random();
        foreach(Object obj in objects) {
            SpawnObject(obj, planet.transform);
        }
    }

    private void SpawnObject(Object obj, Transform parent) {
        GameObject objectCollection = new GameObject(obj.name);
        objectCollection.transform.parent = parent;
        int count = rnd.Next(obj.min, obj.max);
        for(int i = 0; i < count; i++) {
            GameObject newObj = Instantiate(obj.gameObject, objectCollection.transform);
            newObj.transform.rotation = Quaternion.Euler(
                rnd.Next(0, 360 / obj.minRotation) * obj.minRotation,
                0f,
                rnd.Next(0, 360 / obj.minRotation) * obj.minRotation
            );
        }
    }
}

[System.Serializable]
public struct Object {
    public string name;
    public GameObject gameObject;
    public int min, max;
    public int minRotation;
}