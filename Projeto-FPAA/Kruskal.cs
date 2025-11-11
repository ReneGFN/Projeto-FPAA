using System;
using System.Collections.Generic;
using System.Linq;

class Aresta
{
    public int Origem, Destino, Peso;

    public Aresta(int origem, int destino, int peso)
    {
        Origem = origem;
        Destino = destino;
        Peso = peso;
    }
}

class Grafo
{
    public int QuantVertices;
    public List<Aresta> ListaArestas;

    public Grafo(int quantVertices)
    {
        QuantVertices = quantVertices;
        ListaArestas = new List<Aresta>();
    }
}

class Program
{
    static int Encontrar(int x, int[] pai)
    {
        if (pai[x] != x)
            pai[x] = Encontrar(pai[x], pai);
        return pai[x];
    }

    static void Unir(int x, int y, int[] pai)
    {
        int raizX = Encontrar(x, pai);
        int raizY = Encontrar(y, pai);
        pai[raizX] = raizY;
    }

    static string AlgoritmoKruskal(Grafo grafo)
    {
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
            return "impossivel";

        int soma = agm.Sum(a => a.Peso);
        return soma.ToString();
    }

    static void Main()
    {
        string linha;
        while ((linha = Console.ReadLine()) != null)
        {
            if (string.IsNullOrWhiteSpace(linha))
                continue;

            var valores = linha.Split();
            int n = int.Parse(valores[0]);
            int m = int.Parse(valores[1]);

            var grafo = new Grafo(n);
            for (int i = 0; i < m; i++)
            {
                var dados = Console.ReadLine().Split();
                int u = int.Parse(dados[0]) - 1;
                int v = int.Parse(dados[1]) - 1;
                int peso = int.Parse(dados[2]);

                grafo.ListaArestas.Add(new Aresta(u, v, peso));
            }

            Console.WriteLine(AlgoritmoKruskal(grafo));
        }
    }
}

