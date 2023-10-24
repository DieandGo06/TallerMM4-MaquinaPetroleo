using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rodillo : MonoBehaviour
{
    public float maxSpeed;
    public float currentSpeed;
    public float maxDeceleration;
    public float currentDeceleration;
    public List<Rigidbody2D> iconos = new List<Rigidbody2D>();

    bool estaGirando;
    bool estaFrenando;


    private void Start()
    {

    }

    private void Update()
    {
        if (!estaGirando)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                IniciarTirada();
                Tareas.Nueva(3, () => estaFrenando = true);
            }
        }
        
    }

    private void FixedUpdate()
    {
        if(estaGirando)
        {
            Girar();
            if (estaFrenando) Frenar();
        }
    }


    void Girar()
    {
        foreach (Rigidbody2D icono in iconos)
        {
            float newPosY = icono.transform.position.y + (currentSpeed * Time.fixedDeltaTime);
            icono.MovePosition(new Vector3(icono.transform.position.x, newPosY, icono.transform.position.z));
        }
    }

    void Frenar()
    {
        currentSpeed -= currentDeceleration* Time.fixedDeltaTime;
        currentDeceleration -= Time.fixedDeltaTime;

        if(currentSpeed <= 0)
        {
            currentSpeed = 0;
            estaGirando = false;
            estaFrenando = false;
            currentDeceleration = maxDeceleration;
        }
    }

    void IniciarTirada()
    {
        estaGirando = true;
        currentSpeed = maxSpeed;
        currentDeceleration = maxDeceleration;
    }
}