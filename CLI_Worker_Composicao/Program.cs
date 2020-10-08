using System;
using CLI_Worker_Composicao.Entities.Enums;
using CLI_Worker_Composicao.Entities;
using System.Globalization;

namespace CLI_Worker_Composicao
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Entre com o nome do Departamento: ");
            string nomeDepart = Console.ReadLine();
            Department dpto = new Department(nomeDepart);

            Console.WriteLine("");
            Console.WriteLine("Entre com os dados do Funcionário: ");

            Console.Write("Nome: ");
            string nomeFunc = Console.ReadLine();
            Console.Write("Nível (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Salário base: ");
            double salaryBase = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.WriteLine("");
            Worker func = new Worker(nomeFunc, level, salaryBase, dpto);

            Console.Write("O Funcionário trabalhou em quantos contratos ?: ");
            int totalContract = int.Parse(Console.ReadLine());

            for (int i = 1; i <= totalContract; i++) {
                Console.WriteLine($"Entre com os dados do contrato # { i }:");
                Console.Write("Data (DD/MM/YYYY): ");
                DateTime dt = DateTime.Parse(Console.ReadLine());
                Console.Write("Valor por hora: ");
                double vrH = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duração: ");
                int duracao = int.Parse(Console.ReadLine());
                Console.WriteLine("");
                HourContract contract = new HourContract(vrH, duracao, dt);
                func.AddContract(contract);
            }

            Console.WriteLine("");
            Console.Write("Entre com o mês e ano para calcular a remuneção: (MM/YYYY): ");
            string mesAno = Console.ReadLine();
            int mes = int.Parse(mesAno.Substring(0, 2));
            int ano = int.Parse(mesAno.Substring(3));
            Console.WriteLine("");
            Console.WriteLine($"Nome: {func.Name}");
            Console.WriteLine($"Departamento: {func.DepartamentWorker.Name}");
            Console.WriteLine($"Remunerção em {mesAno}: {func.Income(ano, mes).ToString("F2", CultureInfo.InvariantCulture)}");
        }
    }
}
