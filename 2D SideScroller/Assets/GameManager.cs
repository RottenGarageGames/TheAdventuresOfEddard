using UnityEngine;

public class GameManager : ScriptableObject
{
    public static void KillPlayer(CalebPlayerController player)
    {
        player.Heal(1000000);

        //do ui things
    }
}