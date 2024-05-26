using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using System.Net;

Console.WriteLine("Hello, World!");

MimeMessage message = new();
message.From.Add(new MailboxAddress("VN Dotnet", "donotreply@vndotnet.homes"));
message.To.Add(MailboxAddress.Parse("minhtrn98@gmail.com"));
message.Subject = "TEST";
message.Body = new TextPart(TextFormat.Html) { Text = "<h2>TESTING</h2>" };


using SmtpClient smtp = new();
await smtp.ConnectAsync("mail.privateemail.com", 465, MailKit.Security.SecureSocketOptions.StartTls);
var creds = new NetworkCredential("donotreply@vndotnet.homes", "zxcvbnm123.", "vndotnet.homes");
var c = CredentialCache.DefaultNetworkCredentials;
await smtp.AuthenticateAsync(creds);
await smtp.SendAsync(message);
await smtp.DisconnectAsync(true);

Console.WriteLine("Done");
