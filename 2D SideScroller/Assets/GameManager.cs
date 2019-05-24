using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static void KillPlayer(CalebPlayerController player)
    {
        Destroy(player.gameObject);

        //do ui things
    }
}