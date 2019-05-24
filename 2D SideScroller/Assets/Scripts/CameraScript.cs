using ExitGames.Demos.DemoAnimator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public PhotonView photonView;

    void Start()
    {
        photonView = gameObject.GetPhotonView();
        CameraWork _cameraWork = this.gameObject.GetComponent<CameraWork>();
        if(_cameraWork != null)
        {
            if(photonView.isMine)
            {
                _cameraWork.OnStartFollowing();
            }
        }
        else
        {
            Debug.LogError("Missing Camera Component");
        }
    }
}
