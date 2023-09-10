using System.Drawing;
using System.Net.Sockets;
Console.ForegroundColor = ConsoleColor.DarkRed;
Console.WriteLine("[*] " + "Easy Port Scanner");
Console.WriteLine("[*] " + "Created by SeargeantOfArmy", Color.DarkRed);

Console.WriteLine("");
Console.Write("[*] " + "Enter an IP address >> ", Color.DarkRed);


string InternetProtocol;

InternetProtocol = Console.ReadLine();

Console.Write("[*] " + "Enter the number of threads >> ", Color.DarkRed);


int NumberOfThreads = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("");
bool Success = false;

int CurrentPort = 1;
int OpenPort;

void CheckPort(object Port)
{
	using (TcpClient Scan = new TcpClient())
	{
		int CurrentPort = Convert.ToInt32(Port);

        string readText = File.ReadAllText(System.Environment.CurrentDirectory + "\\log.txt");
        try
		{
			Scan.Connect(InternetProtocol, CurrentPort);
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("[*] " + CurrentPort + " IS OPEN, ADDED TO THE LOG.", Color.Green);
			Console.Beep();
			using (StreamWriter writer = new StreamWriter(System.Environment.CurrentDirectory + "\\log.txt"))
			{
				writer.WriteLine(readText+InternetProtocol + ":" + CurrentPort);
				writer.Close();
			}
		}
		catch
		{

			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("[!] " + CurrentPort + " IS CLOSED", Color.Red);
		}
	}
}
for (int i = 0; i < NumberOfThreads; i++)
{
	Thread CheckThread = new Thread(CheckPort);
	CurrentPort++;
	CheckThread.Start(CurrentPort);
}

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("[*] Threads created!", Color.Red);
Thread.Yield();

