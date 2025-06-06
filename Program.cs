using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PowerNow
{
    class Program
    {
        class FalhaEletrica
        {
            public DateTime DataHora { get; set; }
            public string Local { get; set; }
            public string Causa { get; set; }
            public int DuracaoMin { get; set; }
            public string Impacto { get; set; }

            public override string ToString()
            {
                return $"\n🛑 Data/Hora: {DataHora}\n📍 Local: {Local}\n⚡ Causa: {Causa}\n⏱️ Duração: {DuracaoMin} min\n📉 Impacto: {Impacto}\n";
            }
        }

        static List<FalhaEletrica> falhas = new List<FalhaEletrica>();
        const string logPath = "eventos.log";

        static void Main(string[] args)
        {
            if (!Autenticar()) return;

            Console.WriteLine("=== ⚡ ENERGIA - PAINEL DE CRISES CIBERNÉTICAS ===\n");

            while (true)
            {
                Console.WriteLine("1. Registrar nova falha elétrica");
                Console.WriteLine("2. Ver registros ativos");
                Console.WriteLine("3. Gerar relatório de crise");
                Console.WriteLine("4. Exibir estatísticas do sistema");
                Console.WriteLine("5. Sair\n");
                Console.Write("Opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1": RegistrarFalha(); break;
                    case "2": ListarFalhas(); break;
                    case "3": GerarRelatorio(); break;
                    case "4": ExibirEstatisticas(); break;
                    case "5": return;
                    default: Console.WriteLine("\n⚠️ Opção inválida.\n"); break;
                }
            }
        }

        static bool Autenticar()
        {
            const string usuario = "admin";
            const string senha = "energia2025";

            Console.WriteLine("🔐 Login necessário para acessar o painel.");
            for (int i = 3; i > 0; i--)
            {
                Console.Write("Usuário: ");
                string u = Console.ReadLine();
                Console.Write("Senha: ");
                string s = Console.ReadLine();

                if (u == usuario && s == senha)
                {
                    Console.WriteLine("\n✅ Acesso concedido.\n");
                    return true;
                }
                else
                {
                    Console.WriteLine($"❌ Dados incorretos. Tentativas restantes: {i - 1}\n");
                }
            }
            return false;
        }

        static void RegistrarFalha()
        {
            try
            {
                Console.Write("Local da falha: ");
                string local = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(local)) throw new Exception("Local não pode estar vazio.");

                Console.Write("Causa provável (chuva, queda, sabotagem...): ");
                string causa = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(causa)) throw new Exception("Causa não pode estar vazia.");

                Console.Write("Duração (em minutos): ");
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input)) throw new Exception("Duração não pode estar vazia.");
                if (!int.TryParse(input, out int duracao) || duracao <= 0) throw new Exception("Duração deve ser um número positivo.");

                Console.Write("Impacto (baixo, médio, alto): ");
                string impacto = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(impacto)) throw new Exception("Impacto não pode estar vazio.");

                var falha = new FalhaEletrica
                {
                    DataHora = DateTime.Now,
                    Local = local,
                    Causa = causa,
                    DuracaoMin = duracao,
                    Impacto = impacto
                };

                falhas.Add(falha);
                LogEvento($"[OK] Falha registrada: {falha.Local}, {falha.Causa}");

                Console.WriteLine("\n✅ Falha registrada com sucesso.\n");
            }
            catch (Exception ex)
            {
                LogEvento($"[ERRO] Registro falha: {ex.Message}");
                Console.WriteLine($"\n❌ Erro: {ex.Message}\n");
            }
        }

        static void ListarFalhas()
        {
            if (falhas.Count == 0)
            {
                Console.WriteLine("\n⚠️ Nenhuma falha registrada até o momento.\n");
                return;
            }

            Console.WriteLine("\n📋 Registros Ativos:");
            foreach (var f in falhas)
                Console.WriteLine(f);

            LogEvento("[OK] Falhas listadas");
        }

        static void GerarRelatorio()
        {
            string path = "relatorio_falhas.txt";
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (var f in falhas)
                    sw.WriteLine(f);
            }

            LogEvento("[OK] Relatório gerado");
            Console.WriteLine($"\n📁 Relatório salvo em: {Path.GetFullPath(path)}\n");
        }

        static void ExibirEstatisticas()
        {
            Console.WriteLine("\n📊 Estatísticas:");
            Console.WriteLine($"Total de falhas registradas: {falhas.Count}");

            if (falhas.Count > 0)
            {
                double mediaDuracao = falhas.Average(f => f.DuracaoMin);
                var locais = string.Join(", ", falhas.Select(f => f.Local).Distinct());

                Console.WriteLine($"Duração média: {mediaDuracao:F1} minutos");
                Console.WriteLine($"Locais afetados: {locais}");
            }

            LogEvento("[OK] Estatísticas exibidas\n");
        }

        static void LogEvento(string mensagem)
        {
            using (StreamWriter sw = new StreamWriter(logPath, append: true))
            {
                sw.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} {mensagem}");
            }
        }
    }
}
    