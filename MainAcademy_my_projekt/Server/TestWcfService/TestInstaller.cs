/*
http://www.csharp-examples.net/install-net-service/
"c:\Windows\Microsoft.NET\Framework64\v4.0.30319\InstallUtil.exe" "c:\srv\501_srv.exe"
"c:\Windows\Microsoft.NET\Framework64\v4.0.30319\InstallUtil.exe" /u "c:\srv\501_srv.exe"
*/

using System.ComponentModel;
using System.Configuration.Install;
using System.IO;
using System.ServiceProcess;

namespace TestWcfService
{
    [RunInstaller(true)]
    public class TestInstaller : Installer
    {
        private readonly ServiceProcessInstaller _serviceProcessInstaller;
        private readonly ServiceInstaller _serviceInstaller;

        public TestInstaller()
        {
            _serviceProcessInstaller = new ServiceProcessInstaller();
            _serviceInstaller = new ServiceInstaller();

            _serviceProcessInstaller.Account = ServiceAccount.NetworkService;

            _serviceInstaller.ServiceName = Path.GetFileNameWithoutExtension(typeof(Program).Assembly.CodeBase);
            _serviceInstaller.DisplayName = Path.GetFileNameWithoutExtension(typeof(Program).Assembly.CodeBase);
            _serviceInstaller.Description = Path.GetFileNameWithoutExtension(typeof(Program).Assembly.CodeBase);
            _serviceInstaller.StartType = ServiceStartMode.Automatic;

            Installers.AddRange(new Installer[] { _serviceProcessInstaller, _serviceInstaller });
        }
    }
}