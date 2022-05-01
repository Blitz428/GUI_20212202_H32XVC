namespace GUItar_HerOE.Logic
{
    interface IMusicLogic
    {
        int CurrentMusicLenght();
        string CurrentMusicName();
        void StartMusic(int id);
        void StopMusic(int id);
        public void CustomMusicDelete();
        public bool CustomMusicLoading();
    }
}