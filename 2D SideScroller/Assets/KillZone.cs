using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            var player = collision.GetComponent<CalebPlayerController>();

            GameManager.KillPlayer(player);
        }
        //else if(other.tag == "Enemy")
        //{
        //    var enemy = other.GetComponent<EnemyController>();

        //    Destroy(enemy);
        //}   
    }
}
