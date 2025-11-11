
class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();
        Grafo grafo = null;
        string ultimoResultado = "";

        int opcao = -1;

        while (opcao != 0)
        {
            menu.Cabecalho();
            menu.Corpo();
            Console.Write("Escolha uma opção: ");

            if (!int.TryParse(Console.ReadLine(), out opcao))
                opcao = -1;

            switch (opcao)
            {
                case 0:
                    Console.WriteLine("\nEncerrando o programa...");
                    break;

                case 1:
                    Console.Write("Digite o número de unidades (vértices): ");
                    int n = int.Parse(Console.ReadLine());
                    grafo = new Grafo(n);
                    Console.WriteLine("Grafo criado com sucesso!");
                    Console.ReadKey();
                    break;

                case 2:
                    if (grafo == null)
                    {
                        Console.WriteLine("Crie o grafo primeiro!");
                        Console.ReadKey();
                        break;
                    }

                    Console.Write("Unidade de origem: ");
                    int origem = int.Parse(Console.ReadLine()) - 1;

                    Console.Write("Unidade de destino: ");
                    int destino = int.Parse(Console.ReadLine()) - 1;

                    Console.Write("Custo da conexão: ");
                    int peso = int.Parse(Console.ReadLine());

                    grafo.AdicionarAresta(origem, destino, peso);
                    Console.WriteLine("Aresta adicionada com sucesso!");
                    Console.ReadKey();
                    break;

                case 3:
                    if (grafo == null)
                    {
                        Console.WriteLine("Crie o grafo primeiro!");
                        Console.ReadKey();
                        break;
                    }

                    grafo.ExibirArestas();
                    Console.ReadKey();
                    break;

                case 4:
                    if (grafo == null)
                    {
                        Console.WriteLine("Crie o grafo primeiro!");
                        Console.ReadKey();
                        break;
                    }

                    grafo.ExibirGrafo();
                    Console.ReadKey();
                    break;

                case 5:
                    if (grafo == null)
                    {
                        Console.WriteLine("Crie o grafo primeiro!");
                        Console.ReadKey();
                        break;
                    }

                    ultimoResultado = Algoritmos.Kruskal(grafo);
                    menu.Resultado(ultimoResultado);
                    break;

            }
        }
    }
}﻿
