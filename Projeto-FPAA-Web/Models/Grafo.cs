namespace Projeto_FPAA_Web.Models
{
    // Classe que representa um grafo não direcionado e ponderado.
    // Cada vértice representa uma unidade, e cada aresta representa uma conexão com custo.
    public class Grafo
    {
        // Quantidade total de vértices no grafo.
        public int QuantVertices { get; set; }

        // Lista que armazena todas as arestas do grafo.
        public List<Aresta> ListaArestas { get; set; }

        // Construtor padrão
        public Grafo()
        {
            ListaArestas = new List<Aresta>();
        }

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

        // Retorna a representação do grafo em formato de lista de adjacência
        public Dictionary<int, List<string>> ObterListaAdjacencia()
        {
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

            return adjacencia;
        }
    }
}
