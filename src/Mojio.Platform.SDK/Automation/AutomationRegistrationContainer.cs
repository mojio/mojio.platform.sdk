using Mojio.Platform.SDK.Automation.StandardProfiles;
using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.Contracts.Automation;

namespace Mojio.Platform.SDK.Automation
{
    public class AutomationRegistrationContainer : IRegistrationContainer
    {
        public void Register(IDIContainer container)
        {
            container.Register<IAutomationProfile, iOSMotionAutomationProfile>("ios");
            container.Register<IAutomationProfile, AndroidMotionAutomationProfile>("android");
            container.Register<IAutomationProfile, AutomationProfile>();
            container.Register<IAutomationTask, AutomationTask>();
        }
    }
}
