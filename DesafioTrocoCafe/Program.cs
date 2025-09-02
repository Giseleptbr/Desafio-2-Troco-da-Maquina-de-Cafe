using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

class Program
{
    static void Main()
    {
        const decimal precoCafe = 2.50m;
        decimal[] aceitaveis = { 0.50m, 1.00m, 2.00m };
        var moedas = new List<decimal>();

        Console.WriteLine("Insira as moedas 0.50 1.00 ou 2.00. Digite 0 para finalizar.");

        while (true)
        {
            Console.Write("Moeda: ");
            string? entrada = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(entrada))
                continue;

            if (!decimal.TryParse(entrada, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal valor))
            {
                Console.WriteLine("Valor inválido. Use ponto como separador decimal. Exemplo 1.00");
                continue;
            }

            if (valor == 0m)
                break;

            if (!aceitaveis.Contains(valor))
            {
                Console.WriteLine("Moeda não aceita. Válidas 0.50 1.00 2.00");
                continue;
            }

            moedas.Add(valor);
        }

        decimal total = 0m;
        foreach (var m in moedas) total += m;

        string listaMoedas = string.Join(" + ", moedas.ConvertAll(m => m.ToString("F2", CultureInfo.InvariantCulture)));
        if (listaMoedas.Length == 0) listaMoedas = "nenhuma";

        Console.WriteLine();
        Console.WriteLine($"Moedas inseridas: {listaMoedas}");
        Console.WriteLine($"Valor total: R$ {total:F2}");

        if (total == precoCafe)
        {
            Console.WriteLine("Pagamento exato. Café liberado.");
        }
        else if (total < precoCafe)
        {
            Console.WriteLine($"Valor insuficiente. Ainda faltam R$ {(precoCafe - total):F2}");
        }
        else
        {
            Console.WriteLine($"Troco: R$ {(total - precoCafe):F2}");
        }
    }
}
