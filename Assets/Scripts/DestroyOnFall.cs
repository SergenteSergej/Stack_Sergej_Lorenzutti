using UnityEngine;

public class DestroyOnFall : MonoBehaviour
{
    //Update is called once per frame
    private void Update()
    {
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
