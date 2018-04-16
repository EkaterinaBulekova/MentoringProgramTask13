using System.Diagnostics;
using PerformanceCounterHelper;

namespace MvcMusicStore.Infrastructure
{
    [PerformanceCounterCategory("MvcMusicStore", PerformanceCounterCategoryType.MultiInstance, "Some information")]
    public enum StoreCounters
    {
        [PerformanceCounter("Go to Home count","go to home", PerformanceCounterType.NumberOfItems32)]
        GoToHome,

        [PerformanceCounter("Successful LogIn", "LogIn", PerformanceCounterType.NumberOfItems32)]
        LogInSuccess,

        [PerformanceCounter("Successful LogOff", "LogOff", PerformanceCounterType.NumberOfItems32)]
        LogOffSuccess
    }
}