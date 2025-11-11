class Algoritmos
{
    private static int Encontrar(int x, int[] pai)
    {
        if (pai[x] != x)
            pai[x] = Encontrar(pai[x], pai);
        return pai[x];
    }

    private static void Unir(int x, int y, int[] pai)
    {
        int raizX = Encontrar(x, pai);
        int raizY = Encontrar(y, pai);
        pai[raizX] = raizY;
    }

    public static string Kruskal(Grafo grafo)
    {
        if (grafo.ListaArestas.Count == 0)
            return "Nenhuma aresta cadastrada.";

        var agm = new List<Aresta>();
        var arestasOrdenadas = grafo.ListaArestas.OrderBy(a => a.Peso).ToList();
        int[] pai = new int[grafo.QuantVertices];
        for (int i = 0; i < grafo.QuantVertices; i++)
            pai[i] = i;

        foreach (var aresta in arestasOrdenadas)
        {
            int origem = aresta.Origem;
            int destino = aresta.Destino;

            if (Encontrar(origem, pai) != Encontrar(destino, pai))
            {
                agm.Add(aresta);
                Unir(origem, destino, pai);
            }

            if (agm.Count == grafo.QuantVertices - 1)
                break;
        }

        if (agm.Count != grafo.QuantVertices - 1)
            return "Não foi possível interligar todas as unidades (grafo desconexo).";

        int soma = agm.Sum(a => a.Peso);
        string resultado = $"Custo total mínimo: {soma}\n";
        resultado += "\nConexões escolhidas:\n";
        foreach (var a in agm)
            resultado += $"{a}\n";

        return resultado;
    }
}
