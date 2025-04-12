using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Text;

public class AuthManager : MonoBehaviour
{
    // Adjust this to your actual API base URL
    [SerializeField] private string baseUrl = "https://avansict2232301.azurewebsites.net";

    // Register a user
    public void Register(string email, string password)
    {
        // Create payload 
        var registerPayload = new RegisterDto
        {
            Email = email,
            Password = password
        };

        string json = JsonUtility.ToJson(registerPayload);
        StartCoroutine(PostRequest($"{baseUrl}/api/auth/register", json));
    }

    // Login user
    public void Login(string email, string password)
    {
        var loginPayload = new LoginDto
        {
            Email = email,
            Password = password
        };

        string json = JsonUtility.ToJson(loginPayload);
        StartCoroutine(PostRequest($"{baseUrl}/api/auth/login", json));
    }

    private IEnumerator PostRequest(string url, string jsonBody)
    {
        Debug.Log($"POST {url} | Body: {jsonBody}");

        var request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonBody);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log($"Success: {request.downloadHandler.text}");
        }
        else
        {
            Debug.LogError($"Error: {request.error}, {request.downloadHandler.text}");
        }
    }
}

// Dtos
[System.Serializable]
public class RegisterDto
{
    public string Email;
    public string Password;
}

[System.Serializable]
public class LoginDto
{
    public string Email;
    public string Password;
}