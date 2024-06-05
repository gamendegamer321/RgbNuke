using System;
using Mirror;

namespace RgbNuke;

public class FakeConnection : NetworkConnectionToClient
{
    public FakeConnection(int connectionId) : base(connectionId)
    {
    }

    public override string address => "localhost";

    public override void Send(ArraySegment<byte> segment, int channelId = 0)
    {
    }

    public override void Disconnect()
    {
    }
}