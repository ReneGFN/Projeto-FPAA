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

    public override string ToString()
    {
        return $"Unidade {Origem + 1} <-> Unidade {Destino + 1} | Custo: {Peso}";
    }
}
