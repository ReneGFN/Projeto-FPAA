using System;
using System.Collections.Generic;
using System.Linq;

// Classe que representa uma ARESTA de um grafo.
// Cada aresta conecta dois vértices (unidades) e possui um peso (custo da conexão).
class Aresta
{
    // Propriedades que armazenam os vértices de origem, destino e o peso da aresta.
    public int Origem, Destino, Peso;

    // Construtor que inicializa uma nova aresta com os valores informados.
    public Aresta(int origem, int destino, int peso)
    {
        Origem = origem;     // Índice do vértice de origem
        Destino = destino;   // Índice do vértice de destino
        Peso = peso;         // Custo ou distância entre as duas unidades
    }

    // Sobrescreve o método ToString() para retornar uma representação textual da aresta
    public override string ToString()
    {
        // Adiciona +1 aos vértices apenas para exibir de forma mais amigável
        return $"Unidade {Origem + 1} <-> Unidade {Destino + 1} | Custo: {Peso}";
    }
}
