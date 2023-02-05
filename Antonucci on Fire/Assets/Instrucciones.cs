using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Instrucciones : MonoBehaviour
{
    [SerializeField] GameObject placa1;
    [SerializeField] GameObject placa2;
    [SerializeField] GameObject placa3;
    [SerializeField] GameObject boton;
    void Start()
    {
        StartCoroutine(CambiaPlacas());
    }

    private IEnumerator CambiaPlacas()
    {
        yield return new WaitForSeconds(10);
        placa1.SetActive(false);
        placa2.SetActive(true);
        yield return new WaitForSeconds(10);
        placa2.SetActive(false);
        placa3.SetActive(true);
        boton.SetActive(true);
    }
}
