using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Text;
using System.Collections.Generic;

public class WorldManager : MonoBehaviour
{
    [SerializeField] private string baseUrl = "https://avansict2232301.azurewebsites.net";

    // GET /api/world
    public void GetAllWorlds()
    {
        StartCoroutine(GetRequest($"{baseUrl}/api/world"));
    }

    // POST /api/world
    public void CreateWorld(string name)
    {
        var dto = new CreateUpdateWorldDto { Name = name };
        string json = JsonUtility.ToJson(dto);
        StartCoroutine(PostRequest($"{baseUrl}/api/world", json));
    }

    private IEnumerator GetRequest(string url)
    {
        Debug.Log("GET " + url);
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                string jsonResult = request.downloadHandler.text;
                Debug.Log("Worlds JSON: " + jsonResult);
            }
            else
            {
                Debug.LogError("GET Error: " + request.error);
            }
        }
    }

    private IEnumerator PostRequest(string url, string jsonBody)
    {
        Debug.Log("POST " + url + " Body: " + jsonBody);
        var request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonBody);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Response: " + request.downloadHandler.text);
        }
        else
        {
            Debug.LogError("POST Error: " + request.error);
        }
    }
}

// Dto
[System.Serializable]
public class CreateUpdateWorldDto
{
    public string Name;
}
