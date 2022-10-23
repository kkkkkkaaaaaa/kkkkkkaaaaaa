using System;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;

namespace kkkkkkaaaaaa.Data
{
    /// <summary>
    /// 
    /// </summary>
    public static class KandaCommandExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        [DebuggerStepThrough()]
        public static DbCommand SetCommandType(this DbCommand command, CommandType type)
        {
            command.CommandType = type;

            return command;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        [DebuggerStepThrough()]
        public static DbCommand SetCommandText(this DbCommand command, string text)
        {
            command.CommandText = text;

            return command;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static DbCommand DeriveParameters(this DbCommand command)
        {
            var builder = command.GetType().Assembly
                    .GetTypes()
                    .Where(t => t.Name.EndsWith(@"CommandBuilder"))
                    .SingleOrDefault()
                ;
            if (builder == null) { return command; }

            var method = builder.GetMethods()
                    .Where(m => m.Name.EndsWith(@"DeriveParameters"))
                    .SingleOrDefault()
                ;
            if (method == null) { return command; }

            method.Invoke(builder, BindingFlags.Static, null, new[] { command, }, CultureInfo.InvariantCulture);

            return command;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static DbCommand BindParameters(this DbCommand command, object obj)
        {
            var type = obj.GetType();

            var members = new List<MemberInfo>();
            members.AddRange(type.GetProperties((BindingFlags.Instance | BindingFlags.Public)));
            members.AddRange(type.GetFields((BindingFlags.Instance | BindingFlags.Public)));

            var _ = command.Parameters
                .Cast<DbParameter>()
                .Select(p =>
                {
                    foreach (var member in members)
                    {
                        if (p.ParameterName == $@"@{member.Name}") { p.Value = KandaDataMapper.GetValue(member, obj); }

                        var attributes = (KandaDbParameterMappingAttribute[])member.GetCustomAttributes(typeof(KandaDbParameterMappingAttribute), true);
                        if (1 < attributes.Length) { throw new Exception(string.Format(@"KandaDbDataMapper.MapToParameters()")); }

                        foreach (var attribute in attributes)
                        {
                            if (attribute.Ignore) { continue; } // 無視
                            if (p.ParameterName != attribute.MappingName) { continue; } // 名前が一致しない
                            
                            p.DbType = attribute.DbType;
                            p.Direction = attribute.Direction;
                            p.Value = KandaDataMapper.GetValue(member, obj, attribute.DefaultValue);

                            break;
                        }
                    }
                    return p;
                })
                .ToArray();

            return command;
        }
    }

}
