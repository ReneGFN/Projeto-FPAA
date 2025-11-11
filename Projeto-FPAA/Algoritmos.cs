// Classe que implementa o algoritmo de Kruskal para encontrar a Árvore Geradora Mínima (AGM) de um grafo.
class Algoritmos
{
    // Método auxiliar que encontra o "representante" (raiz) de um conjunto no algoritmo.
    private static int Encontrar(int x, int[] pai)
    {
        // Se o vértice x não é o próprio pai, busca recursivamente o pai verdadeiro.
        if (pai[x] != x)
            pai[x] = Encontrar(pai[x], pai);
        return pai[x];
    }

    // Método auxiliar que une dois conjuntos distintos.
    private static void Unir(int x, int y, int[] pai)
    {
        int raizX = Encontrar(x, pai);
        int raizY = Encontrar(y, pai);
        pai[raizX] = raizY; // Faz a raiz de X apontar para a raiz de Y.
    }

    // Implementação do algoritmo de Kruskal.
    // Retorna uma string com o resultado (custo total e arestas escolhidas).
    public static string Kruskal(Grafo grafo)
    {
        // Verifica se o grafo possui arestas.
        if (grafo.ListaArestas.Count == 0)
            return "Nenhuma aresta cadastrada.";

        // Lista de arestas que formarão a Árvore Geradora Mínima (AGM).
        List<Aresta> agm = new List<Aresta>();

        // Ordena todas as arestas do grafo em ordem crescente de peso.
        List<Aresta> arestasOrdenadas = grafo.ListaArestas
                                             .OrderBy(a => a.Peso)
                                             .ToList();

        // Inicializa o vetor 'pai' (cada vértice é pai de si mesmo inicialmente).
        int[] pai = new int[grafo.QuantVertices];
        for (int i = 0; i < grafo.QuantVertices; i++)
            pai[i] = i;

        // Percorre todas as arestas em ordem crescente de peso.
        foreach (Aresta aresta in arestasOrdenadas)
        {
            int origem = aresta.Origem;
            int destino = aresta.Destino;

            // Se a aresta conecta dois conjuntos diferentes, ela é adicionada à AGM.
            if (Encontrar(origem, pai) != Encontrar(destino, pai))
            {
                agm.Add(aresta);
                Unir(origem, destino, pai); // Une os conjuntos.
            }

            // Interrompe se já formou a AGM completa (n - 1 arestas).
            if (agm.Count == grafo.QuantVertices - 1)
                break;
        }

        // Se o número de arestas na AGM for menor que (n - 1), o grafo é desconexo.
        if (agm.Count != grafo.QuantVertices - 1)
            return "Não foi possível interligar todas as unidades (grafo desconexo).";

        // Soma dos pesos das arestas da AGM.
        int soma = agm.Sum(a => a.Peso);

        // Monta a string de resultado final.
        string resultado = $"Custo total mínimo: {soma}\n";
        resultado += "\nConexões escolhidas:\n";

        // Adiciona as arestas que fazem parte da AGM.
        foreach (Aresta a in agm)
            resultado += $"{a}\n";

        return resultado;
    }
}