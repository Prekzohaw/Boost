using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
        case "Friendly":
            Debug.Log("Friendly hit!");
            break;
        case "Obstacle":
            Debug.Log("Boom, you ded");
            break;
        case "VictoryPad":
            Debug.Log("Yay, you win");
            break;
        default:
            Debug.Log("no idea, probably ded");
            break;
        }
    }
}
