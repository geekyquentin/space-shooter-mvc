namespace SpaceShooter.Models {
    #region ---------------------- Public Methods ---------------------------

    public enum GameState {
        NONE,
        PLAY,
        PAUSE,
        GAMEOVER,
    }

    public enum UIScreen {
        NONE,
        StartUI,
        GamePlayUI,
        SettingsUI
    }

    #endregion -----------------------------------------------------------
}