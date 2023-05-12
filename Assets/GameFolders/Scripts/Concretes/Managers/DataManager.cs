using GameFolders.Scripts.Abstracts.Scriptables;
using GameFolders.Scripts.Abstracts.Utilities;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Managers
{
    public class DataManager : MonoSingleton<DataManager>
    {
        [SerializeField] private EventData eventData;
        [SerializeField] private GameData gameData;
        
        public EventData EventData => eventData;
        public GameData GameData => gameData;
    }
}
