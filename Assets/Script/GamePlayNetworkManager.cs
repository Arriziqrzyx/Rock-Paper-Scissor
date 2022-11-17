using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayNetworkManager : MonoBehaviourPunCallbacks
{
    public void BackToMenu()
    {
        StartCoroutine(BackToMenuCoroutine());
    }

    IEnumerator BackToMenuCoroutine()
    {
        PhotonNetwork.Disconnect();
        while (PhotonNetwork.IsConnected)
            yield return null;

<<<<<<< HEAD
        SceneManager.LoadScene("Menu");
=======
        SceneManager.LoadScene("Main");
>>>>>>> f715c4796f9f1b2d75adc14a1d00faa5f0325ef1
    }

    public void BackToLobby()
    {
        StartCoroutine(BackToLobbyCoroutine());
    }
    IEnumerator BackToLobbyCoroutine()
    {
        PhotonNetwork.LeaveRoom();
        while (PhotonNetwork.InRoom || PhotonNetwork.IsConnectedAndReady == false)
            yield return null;

        SceneManager.LoadScene("Lobby");
    }

    public void Replay()
    {
        if (PhotonNetwork.IsMasterClient)
        {
<<<<<<< HEAD
=======
            // var scene = SceneManager.GetActiveScene();
            // PhotonNetwork.AutomaticallySyncScene = true;
            // DontDestroyOnLoad(gameObject);
>>>>>>> f715c4796f9f1b2d75adc14a1d00faa5f0325ef1
            PhotonNetwork.LoadLevel("Lobby");

        }

    }

    public void Quit()
    {
        StartCoroutine(QuitCoroutine());
    }
    IEnumerator QuitCoroutine()
    {
        PhotonNetwork.Disconnect();
        while (PhotonNetwork.IsConnected)
            yield return null;

        Application.Quit();
    }

    public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            PhotonNetwork.CurrentRoom.IsVisible = false;
            PhotonNetwork.CurrentRoom.IsOpen = false;
            BackToLobby();
        }
    }

}
