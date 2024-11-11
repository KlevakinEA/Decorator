string[] Users = { "User1", "User2" };
INotifications Sender = new Decorator_Facebook_Notifications(Users, new Decorator_SMS_Notifications(Users, new Email_Notifications(Users)));
Sender.Send("Уведомление.");


interface INotifications
{
    public void Send(string text);
}


class Email_Notifications: INotifications
{
    private string[] Users;
    public void Send(string text) { foreach (string user in Users) Console.WriteLine(user + " получает уведомление по Email: " + text); }
    public Email_Notifications(string[] Users) { this.Users = Users; }
}


class Decorator_SMS_Notifications : INotifications
{
    private string[] Users;
    INotifications Decoratee;
    public void Send(string text) { foreach (string user in Users) Console.WriteLine(user + " получает уведомление по SMS: " + text); Decoratee.Send(text); }
    public Decorator_SMS_Notifications(string[] Users, INotifications Decoratee) { this.Users = Users; this.Decoratee = Decoratee; }
}


class Decorator_Facebook_Notifications : INotifications
{
    private string[] Users;
    INotifications Decoratee;
    public void Send(string text) { foreach (string user in Users) Console.WriteLine(user + " получает уведомление по Facebook: " + text); Decoratee.Send(text); }
    public Decorator_Facebook_Notifications(string[] Users, INotifications Decoratee) { this.Users = Users; this.Decoratee = Decoratee; }
}