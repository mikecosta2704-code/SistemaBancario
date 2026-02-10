using System;
using SistemaBancarioV2.Servicos;

class Program
{
    static void Main()
    {
        BancoService banco = new BancoService();
        int opcao;

        do
        {
            Console.WriteLine("\n=== SISTEMA BANCÁRIO V2 ===");
            Console.WriteLine("1 - Criar conta");
            Console.WriteLine("2 - Depositar");
            Console.WriteLine("3 - Sacar");
            Console.WriteLine("4 - Mostrar saldo");
            Console.WriteLine("5 - Mostrar extrato");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha: ");

            int.TryParse(Console.ReadLine(), out opcao);
            Console.Clear();

            switch (opcao)
            {
                case 1:
                    CriarConta(banco);
                    break;
                case 2:
                    Depositar(banco);
                    break;
                case 3:
                    Sacar(banco);
                    break;
                case 4:
                    MostrarSaldo(banco);
                    break;
                case 5:
                    MostrarExtrato(banco);
                    break;
            }

        } while (opcao != 0);
    }

    static void CriarConta(BancoService banco)
    {
        Console.Write("Número da conta: ");
        int numero = int.Parse(Console.ReadLine()!);

        Console.Write("Titular: ");
        string titular = Console.ReadLine()!;

        Console.WriteLine("Tipo:");
        Console.WriteLine("1 - Conta Corrente");
        Console.WriteLine("2 - Conta Poupança");
        int tipo = int.Parse(Console.ReadLine()!);

        Console.WriteLine(
            banco.CriarConta(numero, titular, tipo)
            ? "Conta criada com sucesso!"
            : "Erro ao criar conta."
        );
    }

    static void Depositar(BancoService banco)
    {
        Console.Write("Número da conta: ");
        int numero = int.Parse(Console.ReadLine()!);

        Console.Write("Valor: ");
        double valor = double.Parse(Console.ReadLine()!);

        Console.WriteLine(
            banco.Depositar(numero, valor)
            ? "Depósito realizado."
            : "Conta não encontrada."
        );
    }

    static void Sacar(BancoService banco)
    {
        Console.Write("Número da conta: ");
        int numero = int.Parse(Console.ReadLine()!);

        Console.Write("Valor: ");
        double valor = double.Parse(Console.ReadLine()!);

        Console.WriteLine(
            banco.Sacar(numero, valor)
            ? "Saque realizado."
            : "Saldo insuficiente ou conta inexistente."
        );
    }

    static void MostrarSaldo(BancoService banco)
    {
        Console.Write("Número da conta: ");
        int numero = int.Parse(Console.ReadLine()!);

        var saldo = banco.ObterSaldo(numero);

        if (saldo == null)
            Console.WriteLine("Conta não encontrada.");
        else
            Console.WriteLine($"Saldo atual: R$ {saldo}");
    }

    static void MostrarExtrato(BancoService banco)
    {
        Console.Write("Número da conta: ");
        int numero = int.Parse(Console.ReadLine()!);

        var extrato = banco.ObterExtrato(numero);

        if (extrato == null)
        {
            Console.WriteLine("Conta não encontrada.");
            return;
        }

        Console.WriteLine("\n=== EXTRATO ===");
        foreach (var item in extrato)
            Console.WriteLine(item);
    }
}
