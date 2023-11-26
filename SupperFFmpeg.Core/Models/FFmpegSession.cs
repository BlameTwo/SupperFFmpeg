using SupperFFmpeg.Core.Common.JsonConverters;
using SupperFFmpeg.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace SupperFFmpeg.Core.Models
{
    public class FFmpegSession
    {
        [JsonPropertyName("format")]
        public FFmpegFormat Format { get; set; }

        [JsonPropertyName("streams")]
        public IFFmpegStream[] Streams { get; set; }
    }
}
