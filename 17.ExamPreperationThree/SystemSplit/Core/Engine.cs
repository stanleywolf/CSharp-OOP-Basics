using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Engine:IEngine
{
    private IReader reader;
    private IWriter writer;
    private ICommandInterpreter commandInterpreter;

    public Engine(IReader reader, IWriter writer, ICommandInterpreter commandInterpreter)
    {
        this.reader = reader;
        this.writer = writer;
        this.commandInterpreter = commandInterpreter;
    }
    public void Run()
    {
        while (true)
        {
            var data = reader.ReadLine();
            if (data == "System Split")
            {
                commandInterpreter.ProcessCommand(data.Split());
                continue;
            }
            if (data == "Analyze()")
            {
                var token = data.Substring(0, 7);
                List<string> cc = new List<string>();
                cc.Add(token);
                string result = commandInterpreter.ProcessCommand(cc);
                writer.WriteLine(result);
                continue;
            }
            string typeCommand = SplitCommandData(data);
            IList<string> args = SplitArgsData(data);
            args.Insert(0,typeCommand);

            try
            {
                this.commandInterpreter.ProcessCommand(args);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    private IList<string> SplitArgsData(string data)
    {
        var splited = data.Split(new char[] {'(', ')'}, StringSplitOptions.RemoveEmptyEntries).ToList();
        var agrs = new List<string>();
        foreach (var s in splited[1].Split(", "))
            agrs.Add(s);
        return agrs;
    }

    private string SplitCommandData(string data)
    {
        return data.Split("(").First();
    }
}