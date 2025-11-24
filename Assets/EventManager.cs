using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    //public static readonly PlayerEvents Player = new PlayerEvents();
    public static readonly GameEvents Game = new GameEvents();
    public class PlayerEvents
    {
        
    }

    public class GameEvents
    {
        public UnityAction OnWin;
        public UnityAction OnTreasurePicked;
        public UnityAction OnGamePaused;
        public UnityAction OnGameResumed;


        
    }
}
