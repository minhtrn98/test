using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;

Console.WriteLine("Hello, World!");

MimeMessage message = new();
message.From.Add(new MailboxAddress("VN Dotnet", "donotreply@vndotnet.homes"));
message.To.Add(MailboxAddress.Parse("minhtrn98@gmail.com"));
message.Subject = "TEST";
message.Body = new TextPart(TextFormat.Html) { Text = "<h2>TESTING</h2>" };


using SmtpClient smtp = new();
await smtp.ConnectAsync("mail.privateemail.com", 465);
await smtp.SendAsync(message);
await smtp.DisconnectAsync(true);

Console.WriteLine("Done");
