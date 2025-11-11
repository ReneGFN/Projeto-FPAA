using System;
using System.Collections.Generic;
using System.Linq;

// Classe que representa um grafo não direcionado e ponderado.
// Cada vértice representa uma unidade, e cada aresta representa uma conexão com custo.
class Grafo
{
    // Quantidade total de vértices no grafo.
    public int QuantVertices { get; private set; }

    // Lista que armazena todas as arestas do grafo.
    public List<Aresta> ListaArestas { get; private set; }

    // Construtor que inicializa o grafo com a quantidade de vértices informada.
    public Grafo(int quantVertices)
    {
        QuantVertices = quantVertices;
        ListaArestas = new List<Aresta>();
    }

    // Adiciona uma nova aresta (conexão) entre dois vértices com determinado peso (custo).
    public void AdicionarAresta(int origem, int destino, int peso)
    {
        ListaArestas.Add(new Aresta(origem, destino, peso));
    }

    // Exibe todas as arestas cadastradas no grafo de forma legível.
    public void ExibirArestas()
    {
        // Caso não existam arestas ainda
        if (ListaArestas.Count == 0)
        {
            Console.WriteLine("Nenhuma conexão cadastrada ainda.");
            return;
        }

        Console.WriteLine("Conexões cadastradas:");
        Console.WriteLine("--------------------------------------------------");

        // Percorre a lista de arestas e exibe cada uma delas
        foreach (Aresta aresta in ListaArestas)
            Console.WriteLine(aresta);
    }

    // Exibe o grafo no formato de lista de adjacência,
    // mostrando todas as conexões de cada unidade (vértice).
    public void ExibirGrafo()
    {
        if (ListaArestas.Count == 0)
        {
            Console.WriteLine("Nenhuma conexão cadastrada ainda.");
            return;
        }

        Console.WriteLine("Representação do grafo (lista de adjacência):");
        Console.WriteLine("--------------------------------------------------");

        // Dicionário que armazena, para cada vértice, uma lista de conexões (destinos e custos)
        Dictionary<int, List<string>> adjacencia = new Dictionary<int, List<string>>();

        // Inicializa uma lista vazia para cada vértice
        for (int i = 0; i < QuantVertices; i++)
            adjacencia[i] = new List<string>();

        // Preenche o dicionário com as conexões (como o grafo é não direcionado, adiciona nos dois sentidos)
        foreach (Aresta aresta in ListaArestas)
        {
            adjacencia[aresta.Origem].Add($"{aresta.Destino + 1} (custo {aresta.Peso})");
            adjacencia[aresta.Destino].Add($"{aresta.Origem + 1} (custo {aresta.Peso})");
        }

        // Exibe cada vértice e suas respectivas conexões
        foreach (KeyValuePair<int, List<string>> kvp in adjacencia)
        {
            Console.WriteLine($"Unidade {kvp.Key + 1} -> {string.Join(", ", kvp.Value)}");
        }
    }
}