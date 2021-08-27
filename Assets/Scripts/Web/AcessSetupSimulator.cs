using UnityEngine;

public class AcessSetupSimulator : MonoBehaviour
{
    public AccessSetup acessSetup;
    public string userName;
    public string refreshToken;
    public string accessToken;
    public string email;

    private void OnEnable()
    {
        //string id = "562e354d-772b-492a-8c28-ce7d29735324";
        //string name = userName;//"admintest";
        //string email = "admin@test.com";
        //string profilePhoto = null;
        //string refreshToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJjcGYiOm51bGwsImlhdCI6MTYyNDQxMTMzNiwiZXhwIjoxNjI0NDk3NzM2fQ.zBsHAk1u-8UK8WWT1V3h6LzYorMGdNq78rSs05jTWPk";
        //string cpf = null;
        //string created_at = "2021-06-12T01:51:17.901Z";
        //string updated_at = "2021-06-12T01:51:17.901Z";
        //string accessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJjcGYiOm51bGwsImlhdCI6MTYyNDQxMTMzNiwiZXhwIjoxNjI0NDk3NzM2fQ.qGh51GOFdTyVLNwjUVoPF1FQc5zTzEsedu7y15iqhnw";
        acessSetup.ReceiveData(refreshToken, accessToken, name, email);
    }
}
