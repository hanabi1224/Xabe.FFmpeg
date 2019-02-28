using System;
using Xunit;

namespace Xabe.FFmpeg.Test
{
    public class RunnableInDebugOnlyAttribute : FactAttribute
    {
        public RunnableInDebugOnlyAttribute()
        {
#if !DEBUG
            Skip = "Only running in interactive mode.";
#endif
        }
    }

    public class SkipAppVeyorFactAttribute : FactAttribute
    {
        public SkipAppVeyorFactAttribute()
        {
            if (EnvironmentUtils.IsAppVeyorBuild)
            {
                Skip = "Skip on AppVeyor build";
            }
        }
    }

    public class SkipAppVeyorTheoryAttribute : TheoryAttribute
    {
        public SkipAppVeyorTheoryAttribute()
        {
            if (EnvironmentUtils.IsAppVeyorBuild)
            {
                Skip = "Skip on AppVeyor build";
            }
        }
    }

    public static class EnvironmentUtils
    {
        public static bool IsAppVeyorBuild => StringComparer.OrdinalIgnoreCase.Equals(Environment.GetEnvironmentVariable("APPVEYOR"), "true");
    }
}
