﻿using Lavid.Libraske.Util;

namespace Lavid.Libraske.Web
{
    [System.Serializable]
    public struct AccessDataStruct
    {
        public string userName;
        public string email;
        public string accessToken;
        public string refreshToken;
        public Boolean isGuest;
    }
}
