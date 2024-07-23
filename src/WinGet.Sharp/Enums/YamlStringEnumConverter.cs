using System.Reflection;
using System.Runtime.Serialization;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;

namespace WinGet.Sharp.Enums;

public class YamlStringEnumConverter : IYamlTypeConverter
{
    public bool Accepts(Type type) => type.IsEnum;

    public object? ReadYaml(IParser parser, Type type, ObjectDeserializer rootDeserializer)
    {
        var parsedEnum = parser.Consume<Scalar>();
        var serializableValues = type.GetMembers()
            .Select(m => new
            {
                Key = m.GetCustomAttributes<EnumMemberAttribute>(true).Select(ema => ema.Value).FirstOrDefault(),
                Value = m
            })
            .Where(pa => !string.IsNullOrEmpty(pa.Key))
            .ToDictionary(pa => pa.Key!, pa => pa.Value);

        if (!serializableValues.ContainsKey(parsedEnum.Value))
        {
            if (parsedEnum.Value == "null")
                return null;

            return Enum.Parse(type, parsedEnum.Value, true);
        }

        return Enum.Parse(type, serializableValues[parsedEnum.Value].Name);
    }

    public void WriteYaml(IEmitter emitter, object? value, Type type, ObjectSerializer rootSerializer)
    {
        if (value is null)
        {
            emitter.Emit(new Scalar("~"));
            return;
        }

        var enumMember = type.GetMember(value.ToString()!).FirstOrDefault();
        var yamlValue = enumMember?.GetCustomAttributes<EnumMemberAttribute>(true).Select(ema => ema.Value).FirstOrDefault() ?? value.ToString();
        emitter.Emit(new Scalar(yamlValue));
    }
}
