using UnityEngine;

public class CollisionHandler : MonoBehaviour
{    
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case Tags.Obstacle:
                print("rocket got destroyed");
                RocketMovement.instance.SpawnSparksFX(collision.GetContact(0).point);
                GameManager.instance.OnExplosion();
                break;
            case Tags.Portal:
                GameManager.instance.LoadNextScene(3);
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Tags.Portal))
        {
            GameManager.instance.LoadNextScene(3);
            GameManager.instance.OnPortalEnter();
        }
    }
}
