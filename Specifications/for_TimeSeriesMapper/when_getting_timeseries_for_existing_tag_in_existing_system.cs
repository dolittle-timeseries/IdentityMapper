/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;

namespace Dolittle.Edge.IdentityMapper.for_TimeSeriesMapper
{
    public class when_getting_timeseries_for_existing_tag_in_existing_system
    {
        const string system = "MySystem";
        const string other_system = "MyOtherSystem";
        const string tag = "MyTag";
        const string other_tag = "MyOtherTag";
        static Guid time_series = Guid.NewGuid();
        static Guid other_time_series = Guid.NewGuid();

        static TimeSeries result;


        static TimeSeriesMapper mapper;
        Establish context = () =>
        {
            mapper = new TimeSeriesMapper(new TimeSeriesMap(
                new Dictionary<System, TimeSeriesByTag>
                {
                    { system, new TimeSeriesByTag(new Dictionary<Tag, TimeSeries> {{ tag, time_series }} )},
                    { other_system, new TimeSeriesByTag(new Dictionary<Tag, TimeSeries> {{ other_tag, other_time_series }} )}
                }
            ));
        };

        Because of = () => result = mapper.GetTimeSeriesFor(system,tag);

        It should_return_the_timeseries = () => result.ShouldEqual((TimeSeries)time_series);
    }
}