using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using PostSharp.Aspects;

namespace CourseWebUI.Core.Aspects.Postsharp.Performance
{
    [Serializable]
    public class PerformanceCounterAspect:OnMethodBoundaryAspect
    {
        private int _interval;
        [NonSerialized]
        private Stopwatch stopwatch;

        public PerformanceCounterAspect(int interval=5)
        {
            _interval = interval;
        }
        public override void RuntimeInitialize(MethodBase method)
        {
            stopwatch = Activator.CreateInstance<Stopwatch>();
        }
        public override void OnEntry(MethodExecutionArgs args)
        {
            stopwatch.Start();
            base.OnEntry(args);
        }
        public override void OnSuccess(MethodExecutionArgs args)
        {
            stopwatch.Stop();
            if (stopwatch.Elapsed.TotalSeconds > _interval)
                Debug.Write(String.Format("{0}.{1} --> {2} ", args.Method.DeclaringType.FullName, args.Method.Name,stopwatch.Elapsed.TotalSeconds));
            stopwatch.Reset();
            base.OnSuccess(args);
        }

    }
}
