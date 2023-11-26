using SupperFFmpeg.Core.Contracts.Models;
using SupperFFmpeg.Core.Models.FFmpegStreams;
using System;
using System.Buffers;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace SupperFFmpeg.Core.Common.JsonConverters;

public class FFmpegStreamConverter : JsonConverter<IFFmpegStream>
{
    public override IFFmpegStream? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var job = JsonObject.Parse(ref reader);
        var type = job["codec_type"].GetValue<string>();
        if (string.IsNullOrWhiteSpace(type))
            return null;
        if (type == "video")
        {
            return JsonSerializer.Deserialize<VideoStream>(job);
        }else if(type == "audio")
        {
            return JsonSerializer.Deserialize<AudioStream>(job);
        }else if(type == "subtitle")
        {

            return JsonSerializer.Deserialize<AudioStream>(job);
        }
        return null;
    }

    public override void Write(Utf8JsonWriter writer, IFFmpegStream value, JsonSerializerOptions options)
    {
        if(value is VideoStream video)
        {
            JsonSerializer.Serialize(writer, typeof(VideoStream));
        }else if(value is SubTitleStream subtitle)
        {
            JsonSerializer.Serialize(writer, typeof(SubTitleStream));
        }else if(value is AudioStream audio)
        {
            JsonSerializer.Serialize(writer, typeof(AudioStream));
        }
    }
}
