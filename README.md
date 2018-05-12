# ConsoleMail
ConsoleMail is a program designed to allow email messages to be sent with embedded images to apple mail and gmail.

Why is this needed? Well, dear reader, because both these email programs do not understand the concept of embedding base64 images into script tags, nor do they deal with attachments particularly well.  The only way to get a nicely formatted image into a HTML email message is to use what is known as a CID, or content id (see https://tools.ietf.org/html/rfc2392).  Everything else I've tried either doesn't display correctly, or just ends up as an attachment which is not displayed inline.

ConsoleMail deals with a couple of subtle points around how to send such messages and avoids you having to think about them.  It's a standalone binary program that should run nicely on .NET 4.6 and above installations. If you are so inclined it will also easily port to .NET core as there are no complex dependancies.

# Command Line Flags

## -to

An email address, or a comma separated list of email addresses.  Can be specified multiple times.

## -from

The email address the  mail is to be sent from.

## -host

The IP address or host name of the mail server

## -port

The port of the mail server

## -subject

The mail subject line

## -html

Path to a HTML file containing image tags with CIDs in them.  Typically this will look like:

`<img src="cid:allRunningYearSaveRate.png@lollypop.org" />`

## -image

Denotes a new image

### -filePath

The path to the image to be attached as a CID.  Use a png, gif or jpeg for best results.  Smaller files work better as gmail will arbitarily cut off messages over a couple of hundred K.

### -mimeType

Standard mime types such as image/png or image/jpeg.

### -identifier

The CID that matches a CID in the HTML file - for example, in our sample about the CID is allRunningYearSaveRate.png@lollypop.org

## Sample Usage

-from a@lollypop.org -to c@mac.com -host lpf-server1-new -port 25 -subject "Test email" -html ..\..\test\test.html -image -filePath ..\..\test\rose.jpg -mimeType image/jpeg -identifier rose -image -filePath ..\..\test\lilly.jpg -mimeType image/jpeg -identifier lilly

## File Locations
See the Releases folder for prebuilt binaries.
See the Test folder for samples images and html files illustrating how this should be used.

