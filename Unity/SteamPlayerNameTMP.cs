using UnityEngine;
using TMPro;
using Steamworks;

public class SteamPlayerNameTMP : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerNameText;
    
    private void Start()
    {
        if (SteamManager.Initialized)
        {
            string playerName = SteamFriends.GetPersonaName();
            if (playerNameText != null)
            {
                playerNameText.text = "Driver: " + playerName;
            }
        }
        else
        {
            if (playerNameText != null)
            {
                playerNameText.text = "Driver: Player";
            }
        }
    }
}
