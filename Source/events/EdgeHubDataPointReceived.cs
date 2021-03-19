﻿using System.Diagnostics.CodeAnalysis;
using RaaLabs.Edge.Modules.EdgeHub;

namespace RaaLabs.IdentityMapper.events
{
    [ExcludeFromCodeCoverage]
    [InputName("events")]
    class EdgeHubDataPointReceived : IEdgeHubIncomingEvent
    {
        public string Source { get; set; }

        public string Tag { get; set; }

        public dynamic Value { get; set; }

        public long Timestamp { get; set; }
    }
}
