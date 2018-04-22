using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMail
{
    /// <summary>
    /// Configuration for the entire program.
    /// </summary>
    internal class Configuration
    {
        internal Configuration()
        {
            ImageAttachments = new List<ImageAttachment>();
        }

        /// <summary>
        /// An image attachment.
        /// </summary>
        internal class ImageAttachment
        {
            /// <summary>
            /// Path to the image
            /// </summary>
            public string FilePath { get; set; }

            /// <summary>
            /// Mime type for the image
            /// </summary>
            public string MimeType { get; set; }

            /// <summary>
            /// CID for the image
            /// </summary>
            public string Identifier { get; set; }
        }

        /// <summary>
        /// SMTP Host
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// SMTP port
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Attachments to use
        /// </summary>
        public List<ImageAttachment> ImageAttachments { get; set; }

        /// <summary>
        /// HTML Master file links will embed into
        /// </summary>
        public string HtmlFile { get; set; }

        /// <summary>
        /// From address
        /// </summary>
        public string FromAddress { get; internal set; }

        /// <summary>
        /// To address
        /// </summary>
        public string ToAddress { get; internal set; }

        /// <summary>
        /// Mail subject
        /// </summary>
        public string Subject { get; internal set; }
    }
}
