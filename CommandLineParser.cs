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
            try
            {
                if (args.Length == 0)
                {
                    throw new ArgumentException();
                }

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
            }
            catch (Exception)
            {
                Console.WriteLine("Usage: ConsoleMail.exe");
                Console.WriteLine("-from fromAddress");
                Console.WriteLine("-to toAddress");
                Console.WriteLine("-host SMTP host");
                Console.WriteLine("-port SMTP port");
                Console.WriteLine("-subject mail subject");
                Console.WriteLine("-html container html file");
                Console.WriteLine("-image start a new image, do this once for each image you want to add");
                Console.WriteLine("       and follow with -filePath -mimeType -identifier for each image");
                Console.WriteLine("-filePath path to next image");
                Console.WriteLine("-mimeType mimetype of next image (i.e. image/jpeg");
                Console.WriteLine("-identifier CID for next image");
                result = null;
            }

            return result;
        }
    }
}
