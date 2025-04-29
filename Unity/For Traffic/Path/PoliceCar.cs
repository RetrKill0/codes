using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//By RetrKill0
public class PoliceCar : MonoBehaviour
{
    [SerializeField] private int multaValor = 100;
    [SerializeField] private int multaValorADD = 100;
    [SerializeField] private AudioSource sireneAudio;

    private bool jogadorBateuNaViatura = false;


    private void Update()
    {
        if (jogadorBateuNaViatura)
        {
            //Debug.Log("Jogador bateu na viatura!");
            AumentarMulta();
            jogadorBateuNaViatura = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerCar playerCar = other.GetComponent<PlayerCar>();
        if (playerCar != null)
        {
            if (other.CompareTag("ColliderMulta"))
            {
                CarAddOns carAddOns = playerCar.GetComponent<CarAddOns>();
                if (carAddOns != null && !carAddOns.emplacado)
                {
                    AplicarMulta(playerCar);
                }
            }
            else if (other.CompareTag("ColliderViatura"))
            {
                jogadorBateuNaViatura = true;
            }
        }
    }

    private void AplicarMulta(PlayerCar playerCar)
    {
        PlayerController playerController = playerCar.GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.Pagar(multaValor);
            sireneAudio.Play();
        }
    }

    public void AumentarMulta()
    {
        multaValor += multaValorADD;
    }
}
