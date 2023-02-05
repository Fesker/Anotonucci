using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private bool canInteract;
    private Interactable interactable;


    void Update()
    {
        if (canInteract)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Cambiar el estado del interactable
                // Incrementar la puntuación
                Interaccion();
            }
        }
    }

    private void Interaccion()
    {
        switch (interactable.interactableState)
        {
            case Interactable.InteractableState.soil:
            {
                int[] sprites = new []{1}; 
                interactable.PlantInteraction(Interactable.InteractableState.plant, sprites);
                break;
            }
            case Interactable.InteractableState.plant:
            {
                // Pasados 2 seg necesitas regar
                int[] sprites = new []{0,2}; 
                interactable.PlantInteraction(Interactable.InteractableState.plant, sprites);
                break;
            }
            case Interactable.InteractableState.fire:
            {
                // Tenes que apagarlo antes del tiempo
                int[] sprites = new []{0,3};
                interactable.PlantInteraction(Interactable.InteractableState.fire, sprites);
                break;
            }
            case Interactable.InteractableState.root:
            {
                // Tenes que matar la raiz antes del tiempo
                int[] sprites = new []{0,4};
                interactable.PlantInteraction(Interactable.InteractableState.root, sprites);
                break;
            }            
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        interactable = col.GetComponent<Interactable>();

        canInteract = interactable != null;
    }
}
