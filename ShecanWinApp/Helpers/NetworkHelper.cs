﻿using System;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading;
using ZetaLongPaths;

namespace ShecanWinApp.Helpers
{
    internal static class NetworkHelper
    {
        public static NetworkInterface GetActiveEthernetOrWifiNetworkInterface()
        {
            var nic = NetworkInterface.GetAllNetworkInterfaces().FirstOrDefault(
                a => a.OperationalStatus == OperationalStatus.Up &&
                     (a.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || a.NetworkInterfaceType == NetworkInterfaceType.Ethernet) &&
                     a.GetIPProperties().GatewayAddresses.Any(g => g.Address.AddressFamily.ToString() == "InterNetwork"));
            return nic;
        }

        private static string GetExecutingDirectoryPath => ZlpPathHelper.GetDirectoryPathNameFromFilePath(System.Reflection.Assembly.GetExecutingAssembly().Location);

        public static void SetShecanDns(string networkName, string preferredDnsServer, string alternativeDnsServer, OperationSystemEnum operationSystemEnum, Action<string> action)
        {
            var rootDirectory = GetExecutingDirectoryPath;
            switch (operationSystemEnum)
            {
                case OperationSystemEnum.Windows10:
                    {
                        var commandFilePath = ZlpPathHelper.Combine(rootDirectory, "Commands/Win/Set-Shecan-DNS-Win.bat");
                        if (!ZlpIOHelper.FileExists(commandFilePath)) throw new Exception($"\"{commandFilePath}\" not found");
                        var arguments = $@" ""{networkName}"" ""{preferredDnsServer}"" ""{alternativeDnsServer}""";
                        using var process = new Process
                        {
                            StartInfo =
                            {
                                FileName = commandFilePath,
                                Arguments = arguments,
                                UseShellExecute = false,
                                RedirectStandardOutput = true,
                                RedirectStandardError = true,
                                CreateNoWindow = true,
                                WindowStyle = ProcessWindowStyle.Normal
                            }
                        };
                        process.Start();
                        var outputWaitHandle = new AutoResetEvent(false);
                        var errorWaitHandle = new AutoResetEvent(false);
                        process.OutputDataReceived += (sender, e) =>
                        {
                            try
                            {
                                if (e.Data == null)
                                    outputWaitHandle.Set();
                                else
                                    action?.Invoke(e.Data);
                            }
                            catch (Exception ex)
                            {
                                action?.Invoke($"{ex.Message} {Environment.NewLine} {ex.InnerException?.Message ?? string.Empty}");
                            }
                        };
                        process.ErrorDataReceived += (sender, e) =>
                        {
                            try
                            {
                                if (e.Data == null)
                                    errorWaitHandle.Set();
                                else
                                    action?.Invoke(e.Data);
                            }
                            catch (Exception ex)
                            {
                                action?.Invoke($"{ex.Message} {Environment.NewLine} {ex.InnerException?.Message ?? string.Empty}");
                            }
                        };
                        process.Start();
                        process.BeginErrorReadLine();
                        process.BeginOutputReadLine();
                        const int timeoutInMilliseconds = 1 * 60 * 1000; // 1 Minute
                        if (process.WaitForExit(timeoutInMilliseconds) && (outputWaitHandle.WaitOne(timeoutInMilliseconds) || errorWaitHandle.WaitOne(timeoutInMilliseconds)))
                        {
                            if (!process.HasExited) process.Kill();
                            action?.Invoke($"Dns set");
                            return;
                        }
                        if (!process.HasExited) process.Kill();
                        action?.Invoke($"Error in Dns Setting");
                    }
                    break;
            }
        }
        public static void RemoveShecanDns(string networkName, OperationSystemEnum operationSystemEnum, Action<string> action)
        {
            var rootDirectory = GetExecutingDirectoryPath;
            switch (operationSystemEnum)
            {
                case OperationSystemEnum.Windows10:
                    {
                        var commandFilePath = ZlpPathHelper.Combine(rootDirectory, "Commands/Win/Remove-Shecan-DNS-Win.bat");
                        if (!ZlpIOHelper.FileExists(commandFilePath)) throw new Exception($"\"{commandFilePath}\" not found");
                        var arguments = $@" ""{networkName}""";
                        using var process = new Process
                        {
                            StartInfo =
                            {
                                FileName = commandFilePath,
                                Arguments = arguments,
                                UseShellExecute = false,
                                RedirectStandardOutput = true,
                                RedirectStandardError = true,
                                CreateNoWindow = true,
                                WindowStyle = ProcessWindowStyle.Normal
                            }
                        };
                        process.Start();
                        var outputWaitHandle = new AutoResetEvent(false);
                        var errorWaitHandle = new AutoResetEvent(false);
                        process.OutputDataReceived += (sender, e) =>
                        {
                            try
                            {
                                if (e.Data == null)
                                    outputWaitHandle.Set();
                                else
                                    action?.Invoke(e.Data);
                            }
                            catch (Exception ex)
                            {
                                action?.Invoke($"{ex.Message} {Environment.NewLine} {ex.InnerException?.Message ?? string.Empty}");
                            }
                        };
                        process.ErrorDataReceived += (sender, e) =>
                        {
                            try
                            {
                                if (e.Data == null)
                                    errorWaitHandle.Set();
                                else
                                    action?.Invoke(e.Data);
                            }
                            catch (Exception ex)
                            {
                                action?.Invoke($"{ex.Message} {Environment.NewLine} {ex.InnerException?.Message ?? string.Empty}");
                            }
                        };
                        process.Start();
                        process.BeginErrorReadLine();
                        process.BeginOutputReadLine();
                        const int timeoutInMilliseconds = 1 * 60 * 1000; // 1 Minute
                        if (process.WaitForExit(timeoutInMilliseconds) && (outputWaitHandle.WaitOne(timeoutInMilliseconds) || errorWaitHandle.WaitOne(timeoutInMilliseconds)))
                        {
                            if (!process.HasExited) process.Kill();
                            action?.Invoke($"Dns set");
                            return;
                        }
                        if (!process.HasExited) process.Kill();
                        action?.Invoke($"Error in Dns Setting");
                    }
                    break;
            }
        }
    }
}
