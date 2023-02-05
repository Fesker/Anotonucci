using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public enum InteractableState
    {
        soil,
        plant,
        fire,
        root
    }

    public  InteractableState interactableState;
    public List<Sprite> plantSprites;

    private float timeToDry = 2.0f;
    private float deathTime = 10.0f;
    private bool startCount = false;
    private bool plantIsDry = false;
    [SerializeField] private float timer;

    void Start()
    {
        int[] sprites = { 0 };
        PlantInteraction(Interactable.InteractableState.fire, sprites);
    }
    
    private void Update()
    {
        // Cuando lo activo?
        if (startCount)
        {
            timer += Time.deltaTime;
        }

        if (timer >= deathTime)
        {
            timer = 0;
            InteractableDeath();
        }
    }


    public void ChangeInteractableState(InteractableState newState)
    {
        interactableState = newState;
        timer = 0;
    }

    public void PlantInteraction(InteractableState newState, int[] sprites)
    {
        GetComponent<SpriteRenderer>().sprite = plantSprites[sprites[0]];
        ChangeInteractableState(newState);
        if (newState == InteractableState.plant)
        {
            StartCoroutine(ChangePlantToDry());
        }

        if (newState == InteractableState.fire || newState == InteractableState.root || (newState == InteractableState.plant && plantIsDry))
        {
            startCount = true;
        }
        else
        {
            startCount = false;
        }
    }
    
    private void InteractableDeath()
    {
        GetComponent<SpriteRenderer>().sprite = plantSprites[0];
        interactableState = Interactable.InteractableState.soil;
        startCount = false;
    }

    private IEnumerator ChangePlantToDry()
    {
        yield return new WaitForSeconds(timeToDry);
        GetComponent<SpriteRenderer>().sprite = plantSprites[2];
        plantIsDry = true;
    }
}
