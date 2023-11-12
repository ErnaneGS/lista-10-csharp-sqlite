using System;
using Microsoft.Data.Sqlite;


class Program
{
    static void Main()
    {

        string conexaoString = "Data Source=db/DB_BANK_PAIVA.db";
        InicializaDb(conexaoString);

        HashSet<ContaBancaria> contas = new HashSet<ContaBancaria>();

        DateTime dataAtual = DateTime.Now;
        Console.WriteLine("------------------------------------------------");
        Console.WriteLine(dataAtual + " Sistema de Contas Bancárias ");
        Console.WriteLine("------------------------------------------------");

        while (true)
        {
            Console.WriteLine("\nEscolha uma opção:");
            Console.WriteLine("1 - Criar conta");
            Console.WriteLine("2 - Depositar dinheiro");
            Console.WriteLine("3 - Sacar dinheiro");
            Console.WriteLine("4 - Verificar saldo");
            Console.WriteLine("5 - Listar contas");
            Console.WriteLine("0 - Sair");

            string opcao = Console.ReadLine() ?? "";

            switch (opcao)
            {
                case "1":
                    ContaBancariaService.CriarConta(contas);
                    break;
                case "2":
                    ContaBancariaService.Depositar();
                    break;
                case "3":
                    ContaBancariaService.Sacar();
                    break;
                case "4":
                    ContaBancariaService.VerificarSaldo();
                    break;
                case "5":
                    ContaBancariaService.ListarContas();
                    break;
                case "0":
                    Console.WriteLine("---> Encerrado");
                    return;
                default:
                    Console.WriteLine("---> Opção inválida!");
                    break;
            }
        }

        static void InicializaDb(string conexaoString)
        {
            using (var conexao = new SqliteConnection(conexaoString))
            {
                conexao.Open();

                using (var command = new SqliteCommand("CREATE TABLE IF NOT EXISTS Contas (Numero INT PRIMARY KEY, Titular TEXT, Saldo REAL);", conexao))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
