using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Timers;

namespace SystemMonitor
{
    public class SystemMonitor
    {
        private Timer timer;
        private EventLog eventLog;

        public SystemMonitor()
        {
            timer = new Timer();
            timer.Interval = 5000; // interwał w milisekundach (tu: 5 sekund)
            timer.Elapsed += TimerElapsed;

            eventLog = new EventLog();
            eventLog.Source = "SystemMonitor";
            if (!EventLog.SourceExists(eventLog.Source))
            {
                EventLog.CreateEventSource(eventLog.Source, "Application");
            }
        }

        public void StartMonitoring()
        {
            timer.Start();
        }

        public void StopMonitoring()
        {
            timer.Stop();
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            // Tutaj zbieramy dane z liczników systemowych i przetwarzamy je

            // Przykładowe dane do zapisania do dziennika zdarzeń
            double cpuUsage = GetCpuUsage();
            double memoryUsage = GetMemoryUsage();

            // Przykładowe warunki do zapisu zdarzeń
            if (cpuUsage > 90)
            {
                LogEvent("High CPU Usage: " + cpuUsage.ToString("0.00") + "%");
            }

            if (memoryUsage > 80)
            {
                LogEvent("High Memory Usage: " + memoryUsage.ToString("0.00") + "%");
            }
        }

        private double GetCpuUsage()
        {
            // Tutaj należy zaimplementować pobieranie informacji o użyciu procesora
            // Przykładowa implementacja:
            return new PerformanceCounter("Processor", "% Processor Time", "_Total").NextValue();
        }

        private double GetMemoryUsage()
        {
            // Tutaj należy zaimplementować pobieranie informacji o użyciu pamięci
            // Przykładowa implementacja:
            return new PerformanceCounter("Memory", "Available MBytes").NextValue();
        }

        private void LogEvent(string message)
        {
            eventLog.WriteEntry(message, EventLogEntryType.Warning);
        }
    }
}
