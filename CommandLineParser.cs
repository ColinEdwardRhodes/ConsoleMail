using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleMail.Configuration;

namespace ConsoleMail
{
    /// <summary>
    /// CommandLineParser
    /// </summary>
    internal class CommandLineParser
    {
        /// <summary>
        /// Parse the command line and return a configuration object for use by the program.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        internal static Configuration Parse(string[] args)
        {
            Configuration result = new Configuration();
            ImageAttachment currentAttachment = null;

            for (int pos = 0; pos < args.Length; pos++)
            {
                switch (args[pos++])
                {
                    case "-from":
                        result.FromAddress = args[pos];
                        break;
                    case "-to":
                        result.ToAddress = args[pos];
                        break;
                    case "-host":
                        result.Host = args[pos];
                        break;
                    case "-port":
                        result.Port = Int32.Parse(args[pos]);
                        break;
                    case "-subject":
                        result.Subject = args[pos];
                        break;
                    case "-html":
                        result.HtmlFile = args[pos];
                        break;
                    case "-image":
                        currentAttachment = new ImageAttachment();
                        pos--;
                        break;
                    case "-filePath":
                        currentAttachment.FilePath = args[pos];
                        break;
                    case "-mimeType":
                        currentAttachment.MimeType = args[pos];
                        break;
                    case "-identifier":
                        currentAttachment.Identifier = args[pos];
                        break;
                }

                if (currentAttachment != null)
                {
                    result.ImageAttachments.Add(currentAttachment);
                }
            }

            return result;
        }
    }
}
