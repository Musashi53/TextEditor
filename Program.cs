namespace TextEditor
{
  class Program
  {
    static void Main(string[] args)
    {
      Menu();
    }

    static void Menu()
    {
      Console.Clear();
      Console.WriteLine("----------------------------");
      Console.WriteLine("- O que você deseja fazer? -");
      Console.WriteLine("- 1 - Abrir um arquivo     -");
      Console.WriteLine("- 2 - Criar novo arquivo   -");
      Console.WriteLine("- 0 - Sair                 -");
      Console.WriteLine("----------------------------");

      Console.Write("Resposta: ");
      short option = short.Parse(Console.ReadLine());

      switch(option)
      {
        case 1: OpenFile(); break;
        case 2: EditFile(); break;
        case 0: System.Environment.Exit(0); break;
      }
    }

    static void OpenFile()
    {
      Console.Clear();
      Console.WriteLine("Qual é o caminho do arquivo?");
      Console.WriteLine("------------------------------");

      Console.Write("Resposta: ");
      string path = Console.ReadLine();

      using (var file = new StreamReader(path))
      {
        string text = file.ReadToEnd();
        Console.WriteLine(text);
      }

      Console.WriteLine("");
      Console.ReadLine();
      Menu();
    }

    static void EditFile()
    {
      Console.Clear();
      Console.WriteLine("Digite seu texto abaixo (ESC para sair)");
      Console.WriteLine("----------------------------");
      string text = "";

      do
      {
        text += Console.ReadLine();
        text += Environment.NewLine;

      }
      while(Console.ReadKey().Key != ConsoleKey.Escape);
      
      SaveFile(text);
    }

    static void SaveFile(string text)
    {
      Console.Clear();
      Console.WriteLine("Qual caminho para salvar o arquivo?");
      var path = Console.ReadLine();

      
      using (var file = new StreamWriter(path))
      {
        file.Write(text);
      }

      Console.WriteLine($"Arquivo {path} salvo com sucesso!");
      Menu();
    }
  }
}