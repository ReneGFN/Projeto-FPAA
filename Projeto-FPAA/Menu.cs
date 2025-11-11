// Classe responsável por exibir o menu e as telas do programa no console.
// Ela apenas lida com a parte visual e de interação com o usuário (interface textual).
internal class Menu
{
    // Exibe o cabeçalho principal do programa, com título e explicação do problema.
    public void Cabecalho()
    {
        Console.Clear(); // Limpa a tela antes de mostrar o cabeçalho
        Console.WriteLine("PUC - Problema da Interligação de Unidades");
        Console.WriteLine("===================================================================");
        Console.WriteLine("Descrição do problema:");
        Console.WriteLine("A PUC possui várias unidades que precisam ser interligadas por rede");
        Console.WriteLine("de forma eficiente e com baixo custo. O problema foi modelado como");
        Console.WriteLine("um grafo, onde cada unidade representa um vértice e as conexões");
        Console.WriteLine("possíveis entre elas são arestas com custos associados.\n");
        Console.WriteLine("Objetivo: Encontrar a Árvore Geradora Mínima usando o algoritmo de Kruskal.");
        Console.WriteLine("===================================================================");
    }

    // Exibe o corpo do menu principal com as opções disponíveis ao usuário.
    public void Corpo()
    {
        Console.WriteLine();
        Console.WriteLine("MENU PRINCIPAL");
        Console.WriteLine("===================================================================");
        Console.WriteLine("0. Sair");
        Console.WriteLine("1. Criar grafo");
        Console.WriteLine("2. Adicionar aresta (conexão entre unidades)");
        Console.WriteLine("3. Exibir todas as arestas cadastradas");
        Console.WriteLine("4. Exibir grafo (lista de adjacência)");
        Console.WriteLine("5. Executar Algoritmo de Kruskal (menor custo total)");
        Console.WriteLine();
    }

    // Exibe o resultado de uma operação (por exemplo, o resultado do algoritmo de Kruskal)
    // e aguarda o usuário pressionar uma tecla para retornar ao menu.
    public void Resultado(string mensagem)
    {
        Console.Clear(); // Limpa a tela antes de exibir o resultado
        Console.WriteLine("RESULTADO");
        Console.WriteLine("===================================================================");
        Console.WriteLine(mensagem); // Mostra a mensagem recebida como parâmetro
        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
        Console.ReadKey(); // Espera o usuário pressionar uma tecla
    }
}
