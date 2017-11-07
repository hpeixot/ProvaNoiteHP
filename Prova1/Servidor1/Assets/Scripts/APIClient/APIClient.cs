using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class APIClient : MonoBehaviour
{
    const string baseUrl = "http://localhost:58397/API";

    // Use this for initialization
    void Start()
    {
        StartCoroutine(GetItensApiAsync());
    }

    IEnumerator GetItensApiAsync()
    {
        UnityWebRequest request = UnityWebRequest.Get(baseUrl + "/Personagens");
        yield return request.Send();

        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
        }
        else
        {
            string response = request.downloadHandler.text;
            //Debug.Log(response);

            //byte[] bytes = request.downloadHandler.data;

            Personagens[] items = JsonHelper.getJsonArray<Personagens>(response);

            foreach (Personagens i in items)
            {
                ImprimirItem(i);
            }

        }
    }

    private void ImprimirItem(Personagens i)
    {
        Debug.Log("======= Dados do Personagem ==========");

        Debug.Log("Id: " + i.PersonagensID);
        Debug.Log("Tipo do Personagem: " + i.PersonagensTipo);
        Debug.Log("Especialidade: " + i.PersonagensEspecialidade);

    }
}