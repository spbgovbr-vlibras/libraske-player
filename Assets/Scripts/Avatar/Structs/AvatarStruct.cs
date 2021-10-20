using System;
using UnityEngine;

namespace Lavid.Libraske.Avatar
{


    /// <summary> Stores the personalization settings for the avatar </summary>
    [Serializable]
    public struct AvatarStruct<T>
    {
        #region Data
        [SerializeField] private T _cabelo;
        [SerializeField] private T _corpo;

        [SerializeField] private T _iris;
        [SerializeField] private T _pupila;
        [SerializeField] private T _olhos;

        [SerializeField] private T _dentes;
        [SerializeField] private T _lingua;

        [SerializeField] private T _camisa;
        [SerializeField] private T _calca;
        [SerializeField] private T _acessorios;
        #endregion

        public T GetProperty(AvatarPropertiesEnum property)
        {
            return (property) switch
            {
                AvatarPropertiesEnum.ACESSORIOS => _acessorios,
                AvatarPropertiesEnum.CABELO => _cabelo,
                AvatarPropertiesEnum.CALCA => _calca,
                AvatarPropertiesEnum.CAMISA => _camisa,
                AvatarPropertiesEnum.CORPO => _corpo,
                AvatarPropertiesEnum.DENTES => _dentes,
                AvatarPropertiesEnum.IRIS => _iris,
                AvatarPropertiesEnum.LINGUA => _lingua,
                AvatarPropertiesEnum.OLHOS => _olhos,
                AvatarPropertiesEnum.PUPILA => _pupila,
                _ => throw new NotImplementedException()
            };
        }

        public void SetProperty(AvatarPropertiesEnum property, T value)
        {
            switch (property) 
            {
                case AvatarPropertiesEnum.ACESSORIOS:
                    _acessorios = value;
                    break;
                case AvatarPropertiesEnum.CABELO:
                    _cabelo = value;
                    break;
                case AvatarPropertiesEnum.CALCA:
                    _calca = value;
                    break;
                case AvatarPropertiesEnum.CAMISA:
                    _camisa = value;
                    break;
                case AvatarPropertiesEnum.CORPO:
                    _corpo = value;
                    break;
                case AvatarPropertiesEnum.DENTES:
                    _dentes = value;
                    break;
                case AvatarPropertiesEnum.IRIS:
                    _iris = value;
                    break;
                case AvatarPropertiesEnum.LINGUA:
                    _lingua = value;
                    break;
                case AvatarPropertiesEnum.OLHOS:
                    _olhos = value;
                    break;
                case AvatarPropertiesEnum.PUPILA:
                    _pupila = value;
                    break;
            }
        }
    }
}