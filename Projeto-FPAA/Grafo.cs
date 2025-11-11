using System;
using System.Collections.Generic;
using System.Linq;

class Grafo
{
    public int QuantVertices { get; private set; }
    public List<Aresta> ListaArestas { get; private set; }

    public Grafo(int quantVertices)
    {
        QuantVertices = quantVertices;
        ListaArestas = new List<Aresta>();
    }

    public void AdicionarAresta(int origem, int destino, int peso)
    {
        ListaArestas.Add(new Aresta(origem, destino, peso));
    }

    public void ExibirArestas()
    {
        if (ListaArestas.Count == 0)
        {
            Console.WriteLine("Nenhuma conexão cadastrada ainda.");
            return;
        }

        Console.WriteLine("Conexões cadastradas:");
        Console.WriteLine("--------------------------------------------------");
        foreach (var aresta in ListaArestas)
            Console.WriteLine(aresta);
    }

    public void ExibirGrafo()
    {
        if (ListaArestas.Count == 0)
        {
            Console.WriteLine("Nenhuma conexão cadastrada ainda.");
            return;
        }

        Console.WriteLine("Representação do grafo (lista de adjacência):");
        Console.WriteLine("--------------------------------------------------");

        var adjacencia = new Dictionary<int, List<string>>();

        for (int i = 0; i < QuantVertices; i++)
            adjacencia[i] = new List<string>();

        foreach (var a in ListaArestas)
        {
            adjacencia[a.Origem].Add($"{a.Destino + 1} (custo {a.Peso})");
            adjacencia[a.Destino].Add($"{a.Origem + 1} (custo {a.Peso})");
        }

        foreach (var kvp in adjacencia)
        {
            Console.WriteLine($"Unidade {kvp.Key + 1} -> {string.Join(", ", kvp.Value)}");
        }
    }
}
