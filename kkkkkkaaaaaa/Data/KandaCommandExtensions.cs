using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Reflection;

namespace kkkkkkaaaaaa.Data
{
    public static class KandaCommandExtensions
    {

        public static DbCommand DeriveParameters(this DbCommand command)
        {
            var _ = command.GetType().Assembly
                    .GetTypes()
                    .Where(t => t.Name.EndsWith(@"CommandBuilder"))
                    .Select(t =>
                    {
                        var method = t.GetMethods()
                                .Where(m => m.Name.EndsWith(@"DeriveParameters"))
                                .SingleOrDefault()
                            ;

                        method?.Invoke(t, BindingFlags.Static, null, new[] { command, }, CultureInfo.InvariantCulture);

                        return t;
                    })
                    .ToArray()
                // .SingleOrDefault()
                ;

            return command;
        }
        // CommandBuilder.DeriveParameters()


        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <param name="type"></param>
        /// <returns></returns>
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
        public static DbCommand SetCommandText(this DbCommand command, string text)
        {
            command.CommandText = text;

            return command;
        }
    }

}
