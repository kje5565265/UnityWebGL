using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UserInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text_url;
    [SerializeField] private TextMeshProUGUI _text_ID;
    [SerializeField] private TextMeshProUGUI _text_Name;
    // Start is called before the first frame update
    
    void Start()
    {
        // URL 파라미터에서 유저 ID와 이름 읽기
        string url = Application.absoluteURL;
        _text_url.text = url; 
        string userId = GetUrlParameter(url, "user_id");
        string userName = GetUrlParameter(url, "user_name");
        _text_ID.text = $"User ID: {userId}";
        _text_Name.text = $"User Name: {userName}";
    }

    string GetUrlParameter(string url, string key)
    {
        string[] parameters = url.Split('?')[1].Split('&');
        foreach (string parameter in parameters)
        {
            string[] keyValue = parameter.Split('=');
            if (keyValue[0] == key)
            {
                return keyValue[1];
            }
        }
        return null;
    }
}
