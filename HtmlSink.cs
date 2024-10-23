using System;
using System.IO;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace ITCTraining.Serilog.Sinks.Html 
{
    public class HtmlSink : ILogEventSink
    {
        private readonly string _filePath;

        public HtmlSink(string filePath)
        {
            _filePath = filePath;

            // 创建文件并写入 HTML 头部
            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, "<html><body><h1>Log Output</h1><table border='1'>");
            }
        }

        public void Emit(LogEvent logEvent)
        {
            var logMessage = logEvent.RenderMessage();
            var logTime = logEvent.Timestamp.ToString("yyyy-MM-dd HH:mm:ss");
            var logLevel = logEvent.Level.ToString();

            // 格式化为 HTML 行
            var htmlLine = $"<tr><td>{logTime}</td><td>{logLevel}</td><td>{logMessage}</td></tr>";

            // 追加日志行到 HTML 文件
            File.AppendAllText(_filePath, htmlLine);
        }

        public void Dispose()
        {
            // 在关闭时添加 HTML 尾部
            File.AppendAllText(_filePath, "</table></body></html>");
        }
    }

    public static class HtmlSinkExtensions
    {
        public static LoggerConfiguration HtmlSink(
            this LoggerConfiguration loggerConfiguration, string filePath)
        {
            return loggerConfiguration
                .WriteTo.Sink(new HtmlSink(filePath)); // 确保这里引用的是你的 HtmlSink
        }
    }
}
