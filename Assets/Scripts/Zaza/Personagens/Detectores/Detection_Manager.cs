using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection_Manager : MonoBehaviour
{
    ////////////////////////////////////////////////////////////////////////////
    /// Detection_Manager /////////////////////////
    ////////////////////////////////////////////////////////////////////////////
    /// Interação
    internal _InteractionOBJ interactionOBJ {get; set;}


    ////////////////////////////////////////////////////////////////////////////
    /// Permição para interagir
    internal bool canInteract {get; set;}
    
    
    ////////////////////////////////////////////////////////////////////////////
    /// Detector
    public Transform detectorPosition;  /// Posição.y do detector
    [SerializeField] internal float detectionDistance;  /// Distancia de detecção
   

    ////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////

     float glowTimer = 1;
    public float glowTime;
    bool glowing = false;
    bool hudOn;

    void Update()
    {
        if(canInteract)
        
        { Balcon b = interactionOBJ.GetComponent<Balcon>();
            if(b != null && hudOn == false)
            {
               TryToGetPlate(b);
            }
            
            Glow();
        }
    }
    public void SetDetection(_InteractionOBJ interaction)  /// Atribuir detecção  >>> chamada em InteractableDetector
    {
            interactionOBJ = interaction;     /// recebe a interação do detector e aloca aqui no manager;
            canInteract = true;     /// permite interagir;
    }
    void Glow()
    {
        if(glowTimer > 1 && glowing == false)
        {
            glowTimer -= Time.deltaTime * glowTime;
        }
        if(glowTimer <= 1 && glowing == false)
        {
            glowing = true;
        }
        if(glowTimer < 4 && glowing == true)
        {
            glowTimer += Time.deltaTime * glowTime;
        }
        if(glowTime >= 4 && glowing == true)
        {
            glowing = false;
        }



        interactionOBJ.material.SetFloat("_emission", glowTimer);
    }


    void TryToGetPlate(Balcon b)
    {
         
            if (b.hasItemOnIt)
            {
                Plates p = interactionOBJ.itenItHas.GetComponent<Plates>();
                if(p != null)
                {
                    if(hudOn == true)
                    {
                        p.hud.SetActive(false);
                    }
                    else 
                    {
                        p.hud.SetActive(true);
                        hudOn = true;
                    }
                }
            }
    }


    public void ClearDetection()    /// Limpar detecção  >>> chamada em InteractableDetector
    {
        Balcon b = interactionOBJ.GetComponent<Balcon>();
        
        if(b != null)
        {
           TryToGetPlate(b);
        }
        hudOn = false;

        canInteract = false;    /// tira a permição para interagir
        interactionOBJ.material.SetFloat("_emission", 4);
        interactionOBJ = null;    /// anula a referência de interaagível;
    }

}
