using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SistemaDeVida : MonoBehaviour
{
    [SerializeField] private int vida = 100;
    [SerializeField] private int mana = 100;
    [SerializeField] private Slider manaIndicador;
    [SerializeField] private Slider vidaIndicador;
    private bool estaVivo = true;
    private bool levarDano = true;
    private PlayerMovement pMove;
    private bool podeRecarregarMana = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (manaIndicador == null)
        {
            manaIndicador = GameObject.Find("Mana").GetComponent<Slider>();
            manaIndicador.maxValue = mana;
            manaIndicador.value = mana;
        }

        if (vidaIndicador == null)
        {
            vidaIndicador = GameObject.Find("Vida").GetComponent<Slider>();
            vidaIndicador.maxValue = vida;
            vidaIndicador.value = vida;
        }

        pMove = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool EstaVivo()
    {
        return estaVivo;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Fatal") && estaVivo && levarDano)
        {
            StartCoroutine(LevarDano(10));
        }
    }

    public void Dano(int dano)
    {
        if (estaVivo && levarDano)
        {
            StartCoroutine(LevarDano(dano));
        }
    }

    IEnumerator LevarDano(int dano)
    {
        levarDano = false;

        if (vida > 0)
        {
            pMove.Hit(); // Chama o m�todo Hit do PlayerMovement para executar a anima��o de dano
            vida -= dano;
            vidaIndicador.value = vida;
            VerificarVida();
            yield return new WaitForSeconds(0.5f);
            levarDano = true;
        }
    }

    private void VerificarVida()
    {
        if (vida <= 0)
        {
            vida = 0;
            estaVivo = false;
        }
    }

    public void UsarMana()
    {
        mana -= 10;
        manaIndicador.value = mana;
        if (podeRecarregarMana)
        {
            StartCoroutine("RecarregaMana");
        }
    }

    public void CargaMana(int carga)
    {
        mana += carga;
        manaIndicador.value = mana;
        if (mana > 100)
        {
            mana = 100;
            manaIndicador.value = vida;
        }
    }
    public void CargaVida(int carga)
    {
        vida += carga;
        vidaIndicador.value = vida;
        if (vida > 100)
        {
            vida = 100;
            vidaIndicador.value = vida;
        }
    }

    public int GetVida()
    {
        return vida;
    }

    public int GetMana()
    {
        return mana;
    }
    IEnumerator RecarregaMana()
    {
        podeRecarregarMana = false;
        yield return new WaitForSeconds(2f);
        mana += 10;
        manaIndicador.value = mana;
        if (mana > 100)
        {
            mana = 100;
            manaIndicador.value = vida;
        }
        podeRecarregarMana = true;
    }

    IEnumerator RecarregaVida()
    {
        yield return new WaitForSeconds(2f);
        vida += 10;
        vidaIndicador.value = vida;
        if (vida > 100)
        {
            vida = 100;
            vidaIndicador.value = vida;
        }
    }
}