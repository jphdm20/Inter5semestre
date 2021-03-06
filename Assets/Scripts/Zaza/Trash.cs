using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : _InteractionOBJ
{
    public override _Item itenOnThis {get;set;}   //  Item no interagível.
    public override bool hasItemOnIt {get;set;}  //  Booleana para checar se o interagível tem um item nele ou não. 
    internal override bool blinking {get ; set;}   //   Referência pro material com Shader de Highlight.
    internal override float blinkTimer {get; set;}
     public Renderer renderers;    
   

    public float blinkTime;
  
    public override _Item GiveItens(_Item itenToGive){return null;} 
    public override void ReceiveItens( _Item itenReceived){itenReceived.gameObject.SetActive(false);}   //  Método para receber item. 
    public override void Interact(_Item itenInHand, PJ_Character chef)  //  Método para lidar com as interações.
    
    {

        if(itenInHand != null)
        {
            switch(itenInHand.type)
            {

                case ItemType._Pan: 
                
                    if(itenInHand.GetComponent<Pan>().currentTime != 0)
                    {
                        itenInHand.GetComponent<Pan>().GiveItem("Jogando no lixo");
                    }
                
                
                break;
                
                

                case ItemType._Plate: itenInHand.GetComponent<Plates>().CleanPlate();break;

                default : ReceiveItens(chef.GiveIten(chef.itenInHand)); break;
            }

        }
        else return;

    }
    void Update()
    {
        if(blinking == true) Blink();
    }
     public void Blink()
    {
        blinkTimer += Time.deltaTime;
        renderers.material.SetInt("_BlinkOn" , 1);

        if(blinkTimer >= blinkTime)
        {
            StopBlinking();
        }

    }

    public void StopBlinking()
    {
        renderers.material.SetInt("_BlinkOn" , 0);
        blinking = false;
        blinkTimer = 0;
    }



}
