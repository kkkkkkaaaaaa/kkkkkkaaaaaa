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
        /// <returns></returns>
        public static DbCommand DeriveParameters(this DbCommand command)
        {
            var _ = command.GetType().Assembly
                    .GetTypes()
                    .Where(t => t.Name.EndsWith(@"CommandBuilder"))
                    .SingleOrDefault(t =>
                    {
                        var method = t
                                .GetMethods()
                                .SingleOrDefault(m => m.Name.EndsWith(@"DeriveParameters"))
                            ;

                        var __ = method?.Invoke(t, BindingFlags.Static, null, new[] { command, },
                            CultureInfo.InvariantCulture);

                        return true;
                    })
                ;

            return command;
        }

        /* 
            // *CommandBuilder
            var builder = command.GetType()
                .Assembly.GetTypes()
                .Where(t => t.Name.EndsWith(@"CommandBuilder"))
                .FirstOrDefault();

            // *CommandBuilder.DeriveParameters()
            var derive = builder?.GetMethods()
                .Where(m => m.Name == @"DeriveParameters")
                .FirstOrDefault();

            // *CommandBuilder.DeriveParameters(command)
            derive?.Invoke(null, new[] { command, });
         */

        /*
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
        */

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

        #region Obsolete members...

        /*
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
        */

        /*
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
        */


        #endregion
    }

}
