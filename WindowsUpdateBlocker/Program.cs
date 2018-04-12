using Topshelf;

namespace WindowsUpdateBlocker
{
    public static class Program
    {
        public static void Main()
        {
            HostFactory.Run(config =>
            {
                config.Service<WindowsUpdateBlockerService>(sc =>
                {
                    sc.ConstructUsing(() => new WindowsUpdateBlockerService());

                    sc.WhenStarted(s => s.Start());
                    sc.WhenStopped(s => s.Stop());
                });

                config.SetDisplayName("Windows Update Blocker");
                config.SetServiceName("WindowsUpdateBlocker");
                config.SetDescription("Blocks windows updates from running.");
                config.RunAsLocalSystem();
                config.StartAutomatically();

                config.EnableServiceRecovery(rc =>
                {
                    rc.RestartService(1);
                });
            });
        }
    }
}