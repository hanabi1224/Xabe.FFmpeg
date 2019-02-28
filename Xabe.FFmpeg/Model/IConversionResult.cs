﻿using System;

namespace Xabe.FFmpeg.Model
{
    /// <summary>
    ///     Information about conversion
    /// </summary>
    public interface IConversionResult
    {
        /// <summary>
        ///     Result of conversion
        /// </summary>
        bool Success { get; }

        /// <summary>
        ///     Output IMediaInfo
        /// </summary>
        Lazy<IMediaInfo> MediaInfo { get; }

        /// <summary>
        ///     Date and time of starting conversion
        /// </summary>
        DateTime StartTime { get; }

        /// <summary>
        ///     Date and time of starting conversion
        /// </summary>
        DateTime EndTime { get; }

        /// <summary>
        ///     Conversion duration
        /// </summary>
        TimeSpan Duration { get; }

        /// <summary>
        ///     Arguments passed to ffmpeg
        /// </summary>
        string Arguments { get; }

        /// <summary>
        /// FFmpeg process id
        /// </summary>
        int FFmpegProcessId { get; }
    }
}
