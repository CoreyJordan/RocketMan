using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Bumped friendly.");
                break;
            case "Finish":
                Debug.Log("Congrats.");
                break;
            default:
                Debug.Log("You crashed.");
                break;
        }
    }
}
