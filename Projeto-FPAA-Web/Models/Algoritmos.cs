namespace Projeto_FPAA_Web.Models
{
    // Classe que implementa o algoritmo de Kruskal para encontrar a Árvore Geradora Mínima (AGM) de um grafo.
    public class Algoritmos
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
        // Retorna um objeto com o resultado (custo total e arestas escolhidas).
        public static ResultadoKruskal Kruskal(Grafo grafo)
        {
            var resultado = new ResultadoKruskal();

            // Verifica se o grafo possui arestas.
            if (grafo.ListaArestas.Count == 0)
            {
                resultado.Sucesso = false;
                resultado.Mensagem = "Nenhuma aresta cadastrada.";
                return resultado;
            }

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
            {
                resultado.Sucesso = false;
                resultado.Mensagem = "Não foi possível interligar todas as unidades (grafo desconexo).";
                return resultado;
            }

            // Soma dos pesos das arestas da AGM.
            resultado.CustoTotal = agm.Sum(a => a.Peso);
            resultado.ArestasEscolhidas = agm;
            resultado.Sucesso = true;
            resultado.Mensagem = "Algoritmo executado com sucesso!";

            return resultado;
        }
    }

    // Classe para armazenar o resultado do algoritmo de Kruskal
    public class ResultadoKruskal
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public int CustoTotal { get; set; }
        public List<Aresta> ArestasEscolhidas { get; set; }

        public ResultadoKruskal()
        {
            ArestasEscolhidas = new List<Aresta>();
        }
    }
}
