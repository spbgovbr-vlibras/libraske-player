using Lavid.Libraske.Util;
using Lavid.Libraske.Web;
using NUnit.Framework;
using UnityEngine;

public class AccessSetupTest
{
    private const int StringSize = 8;
    private readonly string IsGuestValue = "true"; //"false"

    // A Test behaves as an ordinary method
    [Test]
    public void AccessSetupTestSimplePasses()
    {
        // Use the Assert class to test conditions
        GameObject obj = GameObject.Instantiate(new GameObject());
        obj.AddComponent<AccessSetup>();
        AccessSetup setup = obj.GetComponent<AccessSetup>();

        string rToken = StringGenerator.GenerateString(StringSize);
        string aToken = StringGenerator.GenerateString(StringSize);
        string userName = StringGenerator.GenerateString(StringSize);
        string email = StringGenerator.GenerateString(StringSize);
        Boolean isGuest = new Boolean(IsGuestValue);

        setup.SetRefreshToken(rToken);
        setup.SetAccessToken(aToken);
        setup.SetName(userName);
        setup.SetEmail(email);
        setup.SetIsGuest(IsGuestValue);

        // Setting value to AccessSetup class, simulating React Framework's inputs
        Assert.AreSame(rToken, setup.GetReceivedData().refreshToken);
        Assert.AreSame(aToken, setup.GetReceivedData().accessToken);
        Assert.AreSame(userName, setup.GetReceivedData().userName);
        Assert.AreSame(email, setup.GetReceivedData().email);
        Assert.IsTrue(isGuest.IsEquals(setup.GetReceivedData().isGuest));
        // After these steps above, class AccessSetup sets the values to AccessData class

        // Checking if the values setted by AccessSetup is matching
        Assert.AreSame(AccessData.RefreshToken, setup.GetReceivedData().refreshToken);
        Assert.AreSame(AccessData.AccessToken, setup.GetReceivedData().accessToken);
        Assert.AreSame(AccessData.UserName, setup.GetReceivedData().userName);
        Assert.AreSame(AccessData.Email, setup.GetReceivedData().email);
        Assert.IsTrue(AccessData.IsGuest.IsEquals(setup.GetReceivedData().isGuest));
    }
}
