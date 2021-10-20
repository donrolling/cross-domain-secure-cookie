namespace cookie_example.Services
{
    public interface ICookieService
    {
        T GetCookie<T>(string name);

        void SetCookie<T>(string name, T data);
    }
}