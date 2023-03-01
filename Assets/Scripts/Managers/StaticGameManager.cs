using System;

namespace DogukanKarabiyik.RunnerGame.Managers
{
    public static class StaticGameManager
    {
        public static Action OnLevelStart;
        public static Action OnLevelOver;

        public static Action OnLevelSuccess;
        public static Action OnLevelFail;
        
        public static void GameStart()
        {
            OnLevelStart?.Invoke();
        }

        public static void GameFail()
        {
            OnLevelOver?.Invoke();
            OnLevelFail?.Invoke();
        }

        public static void GameSuccess()
        {
            OnLevelOver?.Invoke();
            OnLevelSuccess?.Invoke();
        }
    }
}


