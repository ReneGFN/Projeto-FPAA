internal class Menu
{
    public void Cabecalho()
    {
        Console.Clear();
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

    public void Resultado(string mensagem)
    {
        Console.Clear();
        Console.WriteLine("RESULTADO");
        Console.WriteLine("===================================================================");
        Console.WriteLine(mensagem);
        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
        Console.ReadKey();
    }
}
