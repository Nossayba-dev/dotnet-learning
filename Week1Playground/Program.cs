// // 1. Value type: struct
// var p1 = new PointStruct { X = 1 };
// var p2 = p1;
// p2.X = 99;
// Console.WriteLine($"Struct -> p1.X = {p1.X}, p2.X = {p2.X}");

// // 2. Reference type: class
// var c1 = new PointClass { X = 1 };
// var c2 = c1;
// c2.X = 99;
// Console.WriteLine($"Class  -> c1.X = {c1.X}, c2.X = {c2.X}");

// // 3. Passing to a method
// var s = new PointStruct { X = 1 };
// var c = new PointClass { X = 1 };
// Change(s);
// Change(c);
// Console.WriteLine($"After Change -> struct: {s.X}, class: {c.X}");

// void Change(object o)
// {
//     if (o is PointStruct ps) ps.X = 500;
//     if (o is PointClass pc) pc.X = 500;
// }

// struct PointStruct { public int X; }
// class PointClass { public int X; }

// int a = 5;
// Add10(a);
// Console.WriteLine(a);

// void Add10(int n) { n = n + 10; }

// var s = new PointStruct { X = 1 };
// Console.WriteLine($"Before the call -> s.X = {s.X}");

// ChangeStruct(s);

// Console.WriteLine($"After the call  -> s.X = {s.X}");

// void ChangeStruct(PointStruct p)
// {
//     Console.WriteLine($"  Inside, at the start -> p.X = {p.X}   (p is a copy of s)");
//     p.X = 500;
//     Console.WriteLine($"  Inside, after change -> p.X = {p.X}   (only the copy changed)");
// }

// struct PointStruct { public int X; }

INotifier notifier = new EmailNotifier();
notifier.Send("Ticket #12 created");

notifier = new SmsNotifier();
notifier.Send("Ticket #12 created");

interface INotifier
{
    void Send(string message);
}

class EmailNotifier : INotifier
{
    public void Send(string message) => Console.WriteLine($"[EMAIL] {message}");
}

class SmsNotifier : INotifier
{
    // public void Send(string message) => Console.WriteLine($"[SMS] {message}");
}