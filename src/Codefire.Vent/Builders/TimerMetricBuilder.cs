﻿using System;
using System.Diagnostics;
using Codefire.Vent.Models;

namespace Codefire.Vent.Builders
{
    public class TimerMetricBuilder : MessageBuilder<TimerMetricBuilder>
    {
        public TimerMetricBuilder(IVentLog logger, VentMessage msg)
            : base(logger, msg)
        {
        }

        public TimerMetricBuilder Measure(Action action)
        {
            var stopwatch = Stopwatch.StartNew();
            try
            {
                action.Invoke();
            }
            finally
            {
                stopwatch.Stop();
                Assign(data => data.Value = Convert.ToDouble(stopwatch.ElapsedMilliseconds));
            }

            return this;
        }

        public TimerMetricBuilder Value(double value)
        {
            return Assign(data => data.Value = value);
        }
    }
}