using GUItar_HerOE.Models;

namespace GUItar_HerOE.Logic
{
    public interface IGameLogic
    {
        string CurrentSong { get; set; }
        int Point { get; set; }

        void CheckGuitar(string color);
        void GuitarTick(Guitar guitar);
        void OneTick();
    }
}