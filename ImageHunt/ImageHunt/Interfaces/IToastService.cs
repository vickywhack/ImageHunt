namespace ImageHunt.Interfaces
{
    public interface IToastService
    {
        void ShowToast(string message, bool isLongToast = false);
    }
}
