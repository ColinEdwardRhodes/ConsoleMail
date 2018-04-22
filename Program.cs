using System.IO;
using System.Net.Mail;
using System.Net.Mime;

namespace ConsoleMail
{
    /// <summary>
    /// Main entry point for the ConsoleMail application.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main entry point into the program.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Configuration config = CommandLineParser.Parse(args);
            SmtpClient client = new SmtpClient(config.Host, config.Port);

            MailMessage mail = CreateMailMessage(config);
            mail.AlternateViews.Add(BuildHTMLMessage(config));

            client.Send(mail);
        }

        /// <summary>
        /// Construct a HTML message from an HTML file and a list of attachments.  Use the CID method.
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        private static AlternateView BuildHTMLMessage(Configuration config)
        {

            AlternateView alternateView = AlternateView.CreateAlternateViewFromString(File.ReadAllText(config.HtmlFile), null, MediaTypeNames.Text.Html);

            config.ImageAttachments.ForEach(x => getEmbeddedImage(alternateView, x));

            return alternateView;
        }

        /// <summary>
        /// Build a mail message from the configuration.
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        private static MailMessage CreateMailMessage(Configuration config)
        {
            MailMessage mail = new MailMessage()
            {
                IsBodyHtml = true,
                From = new MailAddress(config.FromAddress),
                Subject = config.Subject
            };

            mail.To.Add(config.ToAddress);
            return mail;
        }

        /// <summary>
        /// Build an embedded image reference
        /// </summary>
        /// <param name="attachment"></param>
        /// <returns></returns>
        private static void getEmbeddedImage(AlternateView alternateView, Configuration.ImageAttachment attachment)
        {
            LinkedResource res = new LinkedResource(attachment.FilePath, attachment.MimeType);
            res.TransferEncoding = TransferEncoding.Base64;
            res.ContentId = attachment.Identifier;
            res.ContentType.Name = attachment.Identifier;
            alternateView.LinkedResources.Add(res);
        }
    }
}
