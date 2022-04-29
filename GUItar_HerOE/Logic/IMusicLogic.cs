namespace GUItar_HerOE.Logic
{
    interface IMusicLogic
    {
        string CurrentMusicLenght();
        string CurrentMusicName();
        void StartMusic(int id);
        void StopMusic(int id);
        public void CustomMusicDelete();
        public void CustomMusicLoading();
    }
}