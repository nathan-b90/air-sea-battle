/*
 * By Nathan Barrett
 * Copyright Betari 1977
 */

// Global gameplay delegates.
namespace Betari.AirSeaBattle.Scripts.Game
{
    public delegate void GamePausedHandler();
    public delegate void GameResumedHandler();
    public delegate void GameOverHandler();
    public delegate void PlaneDestroyedHandler(int score);
    public delegate void TimeChangedHandler(int time);
}