using Unity.VisualScripting;
using UnityEngine;

public class GameMenager : MonoBehaviour
{
    PrimitiveType primiriveToPlace;

    Vector3 nextShapePreviewPos = new Vector3(-7, 1, 1);
    GameObject previewObject;

    void Start()
    {
        GenerateNextShape();
    }

    void GenerateNextShape()
    {
        switch (Random.Range(0, 4))
        {
            case 0: primiriveToPlace = PrimitiveType.Cube; break;
            case 1: primiriveToPlace = PrimitiveType.Sphere; break;
            case 2: primiriveToPlace = PrimitiveType.Capsule; break;
            case 3: primiriveToPlace = PrimitiveType.Cylinder; break;
            default: primiriveToPlace = PrimitiveType.Cube; break;
        }

        if (previewObject) Destroy(previewObject);

        previewObject = GameObject.CreatePrimitive(primiriveToPlace);
        previewObject.name = "Preview shape";
        previewObject.transform.position = nextShapePreviewPos;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(1)) //right mouse button
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100))
            {
                GameObject go = GameObject.CreatePrimitive(primiriveToPlace);

                go.transform.localScale = Vector3.one * 0.3f;
                go.transform.position = hit.point + new Vector3(0, 1f, 0);
                go.transform.rotation = Random.rotation;

                Block block = go.GetComponent<Block>();

                switch (primiriveToPlace)
                {
                    case PrimitiveType.Cube: go.name = "5"; break;
                    case PrimitiveType.Sphere: go.name = "10"; break;
                    case PrimitiveType.Capsule: go.name = "15"; break;
                    case PrimitiveType.Cylinder: go.name = "20"; break;
                }

                go.AddComponent<Rigidbody>();

                //Control color randomness
                    Color randomColor = Random.ColorHSV();

                    float H, S, V;
                    Color.RGBToHSV(randomColor, out H, out S, out V);
                    
                    S = 0.8f;
                    V = 0.8f;

                    randomColor = Color.HSVToRGB(H, S, V);

                    go.GetComponent<MeshRenderer>().material.color = randomColor;

                //MUST BE INSIDE ASSETS/RESURCES
                Texture texture = Resources.Load<Texture>("spruce_texture");

                Debug.Log(texture);

                //go.GetComponent<MeshRenderer>().material.SetTexture("_BaseMap", texture);
                go.GetComponent<MeshRenderer>().material.mainTexture = texture;

                go.AddComponent<DestroyOnFall>();

                go.AddComponent<DragWithMouse>();

                GenerateNextShape();
            }

        }
    }
}
