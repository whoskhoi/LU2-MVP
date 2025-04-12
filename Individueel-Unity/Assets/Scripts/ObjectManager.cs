using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Text;

public class ObjectManager : MonoBehaviour
{
    [SerializeField] private string baseUrl = "https://avansict2232301.azurewebsites.net";

    // GET all objects for a given world
    public void GetAllObjects(int worldId)
    {
        string url = $"{baseUrl}/api/object/world/{worldId}";
        StartCoroutine(GetRequest(url));
    }

    // GET one worldobject by ID
    public void GetByObject(int id)
    {
        string url = $"{baseUrl}/api/object/{id}";
        StartCoroutine(GetRequest(url));
    }

    // POST create worldobject
    public void CreateObject(string type, float positionX, float positionY)
    {
        var dto = new CreateUpdateWorldObjectDto
        {
            Type = type,
            PositionX = positionX,
            PositionY = positionY
        };
        string json = JsonUtility.ToJson(dto);
        StartCoroutine(PostRequest($"{baseUrl}/api/object", json));
    }

    // PUT update worldobject
    public void UpdateWorldObject(int id, string type, float positionX, float positionY)
    {
        var dto = new CreateUpdateWorldObjectDto
        {
            Type = type,
            PositionX = positionX,
            PositionY = positionY
        };
        string json = JsonUtility.ToJson(dto);
        StartCoroutine(PutRequest($"{baseUrl}/api/object/{id}", json));
    }

    // DELETE worldobject
    public void DeleteObject(int id)
    {
        StartCoroutine(DeleteRequest($"{baseUrl}/api/object/{id}"));
    }

    private IEnumerator GetRequest(string url)
    {
        using var request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("GET success: " + request.downloadHandler.text);
        }
        else
        {
            Debug.LogError("GET error: " + request.error);
        }
    }

    private IEnumerator PostRequest(string url, string jsonBody)
    {
        var request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonBody);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("POST success: " + request.downloadHandler.text);
        }
        else
        {
            Debug.LogError("POST error: " + request.error);
        }
    }

    private IEnumerator PutRequest(string url, string jsonBody)
    {
        var request = new UnityWebRequest(url, "PUT");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonBody);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("PUT success: " + request.downloadHandler.text);
        }
        else
        {
            Debug.LogError("PUT error: " + request.error);
        }
    }

    private IEnumerator DeleteRequest(string url)
    {
        var request = UnityWebRequest.Delete(url);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("DELETE success: " + request.downloadHandler.text);
        }
        else
        {
            Debug.LogError("DELETE error: " + request.error);
        }
    }
}

[System.Serializable]
public class CreateUpdateWorldObjectDto
{
    public string Type;
    public float PositionX;
    public float PositionY;

}