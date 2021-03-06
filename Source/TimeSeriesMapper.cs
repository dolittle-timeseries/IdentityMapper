﻿// Copyright (c) RaaLabs. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

namespace RaaLabs.Edge.IdentityMapper
{
    public class TimeSeriesMapper
    {
        private readonly Identities _identities;

        public TimeSeriesMapper(Identities identities)
        {
            _identities = identities;
        }

        public Guid GetTimeSeriesFor(string source, string tag)
        {
            ThrowIfMissingSystem(source);
            ThrowIfTagIsMissingInSystem(source, tag);
            return _identities[source][tag];
        }

        void ThrowIfMissingSystem(string source)
        {
            if (!_identities.ContainsKey(source)) throw new MissingSourceException(source);
        }

        void ThrowIfTagIsMissingInSystem(string source, string tag)
        {
            if (!_identities[source].ContainsKey(tag)) throw new MissingTagInSourceException(source, tag);
        }
    }
}
