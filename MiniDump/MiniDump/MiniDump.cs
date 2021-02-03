// Copyright (c) 2018-2021, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs
{
    using System;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Text;

    /// <summary>
    /// A class that can generate mini-dumps.
    /// </summary>
    public static class MiniDump
    {
        /// <summary>
        /// Occurs when a mini-dump is generated or fails.
        /// </summary>
        public static event EventHandler<MessageEventArgs> DumpMessage;

        [SuppressMessage("Major Code Smell", "S4220:Events should have proper arguments", Justification = "Cannot be null.")]
        internal static void ExceptionEventHandlerCode(Exception e, bool threadException)
        {
            var exceptionData = $"{e.GetType()}: {e.Message}{Environment.NewLine}{e.StackTrace}{Environment.NewLine}";
            var outputData = Encoding.ASCII.GetBytes(exceptionData);

            // do not dump or close if in a debugger.
            if (!Debugger.IsAttached)
            {
                ForceClosure.ForceClose = true;

                // if this is not Windows, MiniDumpToFile(), which calls MiniDumpWriteDump() in dbghelp.dll
                // cannot be used as it does not exist. I need to figure out mini-dumping for
                // these platforms manually. In that case I guess it does not matter much anyway
                // with the world of debugging and running in a IDE.
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    if (string.IsNullOrEmpty(MiniDumpAttribute.CurrentInstance.DumpLogFileName))
                    {
                        MiniDumpAttribute.CurrentInstance.DumpLogFileName = SettingsFile.ErrorLogPath;
                    }

                    if (string.IsNullOrEmpty(MiniDumpAttribute.CurrentInstance.DumpFileName))
                    {
                        MiniDumpAttribute.CurrentInstance.DumpFileName = SettingsFile.MiniDumpPath;
                    }

                    using (var fileStream = File.OpenWrite(MiniDumpAttribute.CurrentInstance.DumpLogFileName))
                    {
                        fileStream.Write(outputData, 0, outputData.Length);
                    }

                    MiniDumpToFile(MiniDumpAttribute.CurrentInstance.DumpFileName, MiniDumpAttribute.CurrentInstance.DumpType);
#if WITH_WINFORMS
                    DumpMessage?.Invoke(typeof(MiniDump), new MessageEventArgs(string.Format(CultureInfo.InvariantCulture, MiniDumpAttribute.CurrentInstance.Text, MiniDumpAttribute.CurrentInstance.DumpLogFileName), threadException ? MiniDumpAttribute.CurrentInstance.ThreadExceptionTitle : MiniDumpAttribute.CurrentInstance.ExceptionTitle, ErrorLevel.Error));
#else
                    DumpMessage?.Invoke(typeof(MiniDump), new MessageEventArgs(string.Format(CultureInfo.InvariantCulture, MiniDumpAttribute.CurrentInstance.Text, MiniDumpAttribute.CurrentInstance.DumpLogFileName), MiniDumpAttribute.CurrentInstance.ExceptionTitle, ErrorLevel.Error));
#endif
                }
            }
        }

        [SuppressMessage("Major Code Smell", "S4220:Events should have proper arguments", Justification = "Cannot be null.")]
        private static void MiniDumpToFile(string fileToDump, MinidumpTypes dumpType)
        {
            using (var fsToDump = File.Open(fileToDump, FileMode.Create, FileAccess.ReadWrite, FileShare.Write))
            using (var thisProcess = Process.GetCurrentProcess())
            {
                var mINIDUMP_EXCEPTION_INFORMATION = new MINIDUMP_EXCEPTION_INFORMATION
                {
                    ClientPointers = false,
#if WITH_EXCEPTIONPOINTERS
                    ExceptionPointers = Marshal.GetExceptionPointers(),
#else
                    ExceptionPointers = IntPtr.Zero,
#endif
                    ThreadId = SafeNativeMethods.GetCurrentThreadId(),
                };
                var error = SafeNativeMethods.MiniDumpWriteDump(
                    thisProcess.Handle,
                    thisProcess.Id,
                    fsToDump.SafeFileHandle,
                    dumpType,
                    ref mINIDUMP_EXCEPTION_INFORMATION,
                    IntPtr.Zero,
                    IntPtr.Zero);
                if (error > 0)
                {
                    DumpMessage?.Invoke(typeof(MiniDump), new MessageEventArgs($"Mini-dumping failed with Code: {error}", "Error!", ErrorLevel.Error));
                }
            }
        }
    }
}
