using OpenQA.Selenium;

namespace Dmitriy_Vysotskyy2._0;

public sealed class DriverWrapper
{
    private DriverWrapper() {}
    
    private static IWebDriver _instance;

    private static bool IsDisposed
    {
        get
        {
            try
            {
                var instancePageSource = _instance.PageSource;
                return false;
            }
            catch (UnhandledAlertException)
            {
                return false;
            }
            catch
            {
                return true;
            }
        }
    }

    public static IWebDriver GetInstance()
    {
        if (_instance == null || IsDisposed)
            _instance = WebDriverFactory.GetWebDriver(BrowserConfig.BrowserType);

        return _instance;
    }
}