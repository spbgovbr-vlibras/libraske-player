using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "User", menuName = "Libraske/Web/User")]
public class UserSO : ScriptableObject
{
    private string _name;
    private string _id;
    private string _token;

    public string Name { get => _name; }
    public string Id { get => _id;}
    public string Token { get => _token;}

    private void Awake()
    {
        
    }
}