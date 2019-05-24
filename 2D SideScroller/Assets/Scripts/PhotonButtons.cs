using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotonButtons : MonoBehaviour
{
    public InputField createRoomInput, joinRoomInput;
    public Canvas NetworkingUI;
    public GameObject player;
    public Transform spawnPoint;

    public void onClickCreateRoom()
    {
        if(createRoomInput.text.Length >= 1)
        PhotonNetwork.CreateRoom(createRoomInput.text, new RoomOptions() { MaxPlayers = 4 }, null);
    }
    public void onClickJoinRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;
        PhotonNetwork.JoinOrCreateRoom(joinRoomInput.text, roomOptions, TypedLobby.Default);
    }
    private void OnJoinedRoom()
    {
        NetworkingUI.enabled = false;
        Debug.Log("We are connected to the room");
        PhotonNetwork.Instantiate(player.name, spawnPoint.position, player.transform.rotation, 0); 
    }
}
