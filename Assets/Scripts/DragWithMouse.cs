using UnityEngine;

public class DragWithMouse : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    private float depthOffset = 0f;
    private float rotationSpeed = 100f;

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(position);

        GetComponent<Rigidbody>().isKinematic = true;
    }

    void OnMouseDrag()
    {
        //Controlling the depth of the object with scroll wheel
        depthOffset += Input.mouseScrollDelta.y * 0.3f;

        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z + depthOffset);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

        transform.position = curPosition;


        ///////////////// Rotate object with WASD (object prospective)//////////////////////////
       

        //if (Input.GetKey(KeyCode.D))
        //{
        //    transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    transform.Rotate(Vector3.left, rotationSpeed * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.W))
        //{
        //    transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    transform.Rotate(Vector3.down, rotationSpeed * Time.deltaTime);
        //}




        /////////////////// Rotate object with WASD (camera prospective)/////////////////////////
        

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Camera.main.transform.up, rotationSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Camera.main.transform.up, -rotationSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(Camera.main.transform.right, rotationSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(Camera.main.transform.right, -rotationSpeed * Time.deltaTime, Space.World);
        }

    }

    private void OnMouseUpAsButton() //Called only if Mouse UP collider is the same of Mouse Down collider
    {
        GetComponent <Rigidbody>().isKinematic = false;
    }
}
