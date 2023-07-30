using System.Diagnostics;
using LiteNetwork.Server;

namespace ChatApp.Networking;

public class Host : LiteServer<ConnectedAgent>
{
    public Host(LiteServerOptions options, IServiceProvider? serviceProvider = null) : base(options, serviceProvider)
    {
    }

    protected override void OnAfterStart()
    {
        base.OnAfterStart();
        Debug.WriteLine("[HOST] Server started.");
    }
}