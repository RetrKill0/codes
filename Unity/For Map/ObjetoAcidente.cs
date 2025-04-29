using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//By RetrKill0
public class ObjetoAcidente : MonoBehaviour
{
    [SerializeField] Vector3 spawnPos = new Vector3(-524.8200f, 0.75f, 209.38f);
    [SerializeField] Vector3 spawnRot = new Vector3(0.0f, 108.472f, 0.0f);
    [SerializeField] private int feeValue = 1000;

    void Start()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if(PlayerController.I.GetPlayerCar(out PlayerCar pCar))
        {
            Accident();
        }
    }

    private void Accident() 
    {
        HudManager.I.ShowAccidentScreen(feeValue);
        
        if (PlayerController.I.IsOnMission)
        {
            PlayerController.I.CurrentMission.Terminar();
        }
        PlayerController.I.PlayerCar.TeleportTo(spawnPos, Quaternion.Euler(spawnRot));
    }
}
