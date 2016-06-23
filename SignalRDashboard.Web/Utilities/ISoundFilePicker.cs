namespace SignalRDashboard.Web.Utilities
{
    public interface ISoundFilePicker
    {
        string GetRandomSoundFile(string component, SoundFileCategory category);
    }
}