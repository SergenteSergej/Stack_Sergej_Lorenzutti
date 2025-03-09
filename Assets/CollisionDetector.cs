using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    int collisions = 0;

    int cubePoints = 5;
    int spherePoints = 10;
    int capsulePoints = 7;
    int cylinderPoints = 3;

    int points;


    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        collisions++;

        if (collision.gameObject.name == "cube")
        {
            points += cubePoints;
        }
        else if (collision.gameObject.name == "sphere")
        {
            points += spherePoints;
        }
        else if (collision.gameObject.name == "capsule")
        {
            points += capsulePoints;
        }
        else if (collision.gameObject.name == "cylinder")
        {
            points += cylinderPoints;
        }

        Debug.Log($"Collision:{collision} points:{points}");

        audioSource.Play();

    }

    private void OnCollisionExit(Collision collision)
    {
        collisions--;

        if (collision.gameObject.name == "cube")
        {
            points -= cubePoints;
        }
        else if (collision.gameObject.name == "sphere")
        {
            points -= spherePoints;
        }
        else if (collision.gameObject.name == "capsule")
        {
            points -= capsulePoints;
        }
        else if (collision.gameObject.name == "cylinder")
        {
            points -= cylinderPoints;
        }

        Debug.Log($"Collisions:{collisions} points:{points}");
    }
}

