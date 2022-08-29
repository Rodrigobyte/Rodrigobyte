using UnityEngine;
using System.Collections;

public class Coletar : MonoBehaviour
{
    public float DistanciaMaxima = 5.0f;
    public string TagObjetos = "Itens";
    public string CenaLoad = "CENA";
    public int QuantidadeDeItens = 5;
    private bool mensagem;
    private int numDeItens;
    void Start()
    {
        numDeItens = 0;
    }
    void Update()
    {
        // raycast
        RaycastHit PontoDeColisao;
        if (Physics.Raycast(transform.position, transform.forward, out PontoDeColisao, 10))
        {
            if (Vector3.Distance(transform.position, PontoDeColisao.point) <= DistanciaMaxima && PontoDeColisao.transform.gameObject.tag == TagObjetos)
            {
                mensagem = true;
                if (Input.GetMouseButtonDown(0))
                {
                    Destroy(PontoDeColisao.transform.gameObject);
                    numDeItens++;
                }
            }
            else
            {
                mensagem = false;
            }
        }
        else
        {
            mensagem = false;
        }
        // load
        if (numDeItens >= QuantidadeDeItens)
        {
            Application.LoadLevel(CenaLoad);
        }
    }
    void OnGUI()
    {
        GUI.Label(new Rect(20, 20, 180, 50), "ITENS: " + numDeItens);
        if (mensagem == true)
        {
            GUI.Label(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 25, 180, 50), "Pressione o botao direito do mouse para pegar");
        }
    }
}
