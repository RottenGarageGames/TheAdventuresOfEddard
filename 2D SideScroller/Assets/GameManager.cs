using UnityEngine;

public class GameManager : ScriptableObject
{
    public static void KillPlayer(CalebPlayerController player)
    {
        Destroy(player.gameObject);

        //do ui things
    }
}