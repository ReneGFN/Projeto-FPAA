class Program
{
    static void Main(string[] args)
    {
        // Instancia o menu
        Menu menu = new Menu();

        // Objeto que armazenará o grafo criado pelo usuário
        Grafo grafo = null;

        // Armazena o último resultado do algoritmo de Kruskal
        string ultimoResultado = "";

        // Variável de controle do menu
        int opcao = -1;

        // Laço principal do programa — só encerra quando o usuário digita 0
        while (opcao != 0)
        {
            menu.Cabecalho(); // Exibe o cabeçalho com a descrição do problema
            menu.Corpo();     // Exibe as opções do menu

            Console.Write("Escolha uma opção: ");

            // Lê a opção do usuário e valida se é um número
            if (!int.TryParse(Console.ReadLine(), out opcao))
                opcao = -1; // Caso o usuário digite algo inválido

            switch (opcao)
            {
                case 0:
                    Console.WriteLine("\nEncerrando o programa...");
                    break;

                case 1:
                    // Criação do grafo (define quantos vértices ele terá)
                    Console.Write("Digite o número de unidades (vértices): ");
                    int n = int.Parse(Console.ReadLine());
                    grafo = new Grafo(n);
                    Console.WriteLine("Grafo criado com sucesso!");
                    Console.WriteLine("Pressione Enter para voltar ao menu...");
                    Console.ReadLine(); // Aguarda o usuário pressionar Enter
                    break;

                case 2:
                    // Adiciona uma nova aresta (conexão)
                    if (grafo == null)
                    {
                        Console.WriteLine("Crie o grafo primeiro!");
                        Console.WriteLine("Pressione Enter para voltar ao menu...");
                        Console.ReadLine();
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
                    Console.WriteLine("Pressione Enter para voltar ao menu...");
                    Console.ReadLine();
                    break;

                case 3:
                    // Exibe todas as arestas cadastradas
                    if (grafo == null)
                    {
                        Console.WriteLine("Crie o grafo primeiro!");
                        Console.WriteLine("Pressione Enter para voltar ao menu...");
                        Console.ReadLine();
                        break;
                    }

                    grafo.ExibirArestas();
                    Console.WriteLine("\nPressione Enter para voltar ao menu...");
                    Console.ReadLine();
                    break;

                case 4:
                    // Exibe o grafo em formato de lista de adjacência
                    if (grafo == null)
                    {
                        Console.WriteLine("Crie o grafo primeiro!");
                        Console.WriteLine("Pressione Enter para voltar ao menu...");
                        Console.ReadLine();
                        break;
                    }

                    grafo.ExibirGrafo();
                    Console.WriteLine("\nPressione Enter para voltar ao menu...");
                    Console.ReadLine();
                    break;

                case 5:
                    // Executa o algoritmo de Kruskal e exibe o resultado
                    if (grafo == null)
                    {
                        Console.WriteLine("Crie o grafo primeiro!");
                        Console.WriteLine("Pressione Enter para voltar ao menu...");
                        Console.ReadLine();
                        break;
                    }

                    ultimoResultado = Algoritmos.Kruskal(grafo);
                    menu.Resultado(ultimoResultado);
                    Console.WriteLine("\nPressione Enter para voltar ao menu...");
                    Console.ReadLine();
                    break;
            }
        }
    }
}
