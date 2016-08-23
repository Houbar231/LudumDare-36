using UnityEngine;
using System.Collections;
public class TerrainGenerator : MonoBehaviour {
    float[,] Heights;
    public Material MapMat;

    public int w, h;
    [Range(0,8)]
    public int NumberOfOctaves;
    [Range(0, 1)]
    public float persistance;
    [Range(0, 4)]
    public float lacunarity;
    [Range(0, 10)]
    public int StartFrequency;
    [Range(-0.45f, 0.45f)]
    public float AltitudeBoost;
    public bool DoesNormalizeMap;
    [Range(0, 10)]
    public int NumberOfSmoothings;
    [Range(1,10)]
    public int RateOfSmoothings;
    public Gradient ColorGradient;
    [Range(0, 10000000)]
    public int Seed;


    public void Start() {
        Heights = new float[w+1, h+1];

        for(int x = 0; x < w+1; x++) {
            for(int y = 0; y < h+1; y++) {
                GeneratePerlin(x, y);
            }
        }
        SmoothMap();
        if(DoesNormalizeMap)
            NormalizeMap();
        GenerateTexture();
        //GenerateMesh();
    }
    public void GeneratePerlin(int x, int y) {
        float range = 0;
        float frequency = StartFrequency;
        float amplitude = 1;
        Heights[x, y] = 0;

        for(int i = 0; i < NumberOfOctaves; i++, frequency *= lacunarity, amplitude *= persistance) {
            Heights[x, y] += amplitude * Mathf.PerlinNoise((((x + Seed )/ (float)w)) * frequency, (((y + Seed) / (float)h)) * frequency);
            range += amplitude;
        }
        Heights[x, y] /= range;
        Heights[x, y] += AltitudeBoost;
        
    }
    public void SmoothMap() {
        for(int it = 0; it < NumberOfSmoothings; it++) {
            float sum = 0;
            for(int x = 0; x < w+1; x++) {
                for(int y = 0; y < h+1; y++) {
                    sum += Heights[x, y];
                }
            }
            float average = sum / (w * h);
            for(int x = 0; x < w+1; x++) {
                for(int y = 0; y < h+1; y++) {
                    for(int i = 0; i < RateOfSmoothings; i++) {
                        Heights[x, y] += average;
                    }
                    Heights[x, y] /= RateOfSmoothings;
                }
            }
        }
    }
    public void NormalizeMap() {
        float MaxVal = 0;
        for(int x = 0; x < w+1; x++) {
            for(int y = 0; y < h+1; y++) {
                if(Heights[x, y] > MaxVal)
                    MaxVal = Heights[x, y];
            }
        }
        for(int x = 0; x < w+1; x++) {
            for(int y = 0; y < h+1; y++) {
                Heights[x, y] = Heights[x, y] / MaxVal;
            }
        }
    }
    public void GenerateTexture() {
        Texture2D t = new Texture2D(w, h, TextureFormat.RGB24, true);
        t.filterMode = FilterMode.Point;
        for(int x = 0; x < w; x++) {
            for(int y = 0; y < h; y++) {
                t.SetPixel(x, y, ColorGradient.Evaluate(Heights[x, y]));//Color.Lerp(Color.black, Color.white, Heights[x, y]));
            }
        }
        t.Apply();
        MapMat.mainTexture = t;
    }
    public void GenerateMesh() {
        if(transform.Find("Terrain") != null) {
            DestroyImmediate(transform.Find("Terrain").gameObject);
        }
        GameObject g = new GameObject("Terrain");
        g.transform.SetParent(this.transform);
        g.transform.position = new Vector3(-(w / 2f), -(h / 2f));
        Mesh TerrMesh = g.AddComponent<MeshFilter>().mesh = new Mesh();
        TerrMesh.name = "Terrain";
        g.AddComponent<MeshRenderer>().material = MapMat;

        Vector3[] vertices;
        int[] triangles;
        Vector2[] uvs;

        vertices = new Vector3[(w + 1) * (h + 1)];
        uvs = new Vector2[vertices.Length];
        for(int i = 0, y = 0; y <= h; y++) {
            for(int x = 0; x <= w; x++, i++) {
                vertices[i] = new Vector3(x, y, Heights[x, y]*10);
                uvs[i] = new Vector2((float)x / w, (float)y / h);
            }
        }
        TerrMesh.vertices = vertices;
        triangles = new int[6 * w * h];
        for(int ti = 0, vi = 0, y = 0; y < h; y++, vi++) {
            for(int x = 0; x < w; x++, ti += 6, vi++) {
                triangles[ti] = vi;
                triangles[ti + 3] = triangles[ti + 2] = vi + 1;
                triangles[ti + 4] = triangles[ti + 1] = vi + w + 1;
                triangles[ti + 5] = vi + w + 2;
            }
        }
        TerrMesh.triangles = triangles;
        TerrMesh.RecalculateNormals();
        TerrMesh.uv = uvs;
    }
}
