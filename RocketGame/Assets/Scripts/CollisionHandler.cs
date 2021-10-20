using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case Tags.Obstacle:
                print("rocket got destroyed");
                GameManager.instance.RestartScene();
                break;
            case Tags.Portal:
                GameManager.instance.LoadNextScene();
                break;
            default:
                break;
        }
    }
}
