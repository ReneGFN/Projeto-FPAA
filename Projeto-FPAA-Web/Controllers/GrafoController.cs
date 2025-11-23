using Microsoft.AspNetCore.Mvc;
using Projeto_FPAA_Web.Models;
using Newtonsoft.Json;

namespace Projeto_FPAA_Web.Controllers
{
    public class GrafoController : Controller
    {
        // Obtém ou cria o grafo armazenado na sessão
        private Grafo? ObterGrafo()
        {
            var grafoJson = HttpContext.Session.GetString("Grafo");
            if (string.IsNullOrEmpty(grafoJson))
                return null;
            return JsonConvert.DeserializeObject<Grafo>(grafoJson);
        }

        // Salva o grafo na sessão
        private void SalvarGrafo(Grafo grafo)
        {
            var grafoJson = JsonConvert.SerializeObject(grafo);
            HttpContext.Session.SetString("Grafo", grafoJson);
        }

        // Página inicial
        public IActionResult Index()
        {
            var grafo = ObterGrafo();
            return View(grafo);
        }

        // GET: Exibe formulário para criar grafo
        public IActionResult CriarGrafo()
        {
            return View();
        }

        // POST: Cria o grafo
        [HttpPost]
        public IActionResult CriarGrafo(int quantVertices)
        {
            if (quantVertices <= 0)
            {
                TempData["Erro"] = "O número de vértices deve ser maior que zero.";
                return View();
            }

            var grafo = new Grafo(quantVertices);
            SalvarGrafo(grafo);
            TempData["Sucesso"] = $"Grafo criado com sucesso com {quantVertices} unidades!";
            return RedirectToAction("Index");
        }

        // GET: Exibe formulário para adicionar aresta
        public IActionResult AdicionarAresta()
        {
            var grafo = ObterGrafo();
            if (grafo == null)
            {
                TempData["Erro"] = "Crie o grafo primeiro!";
                return RedirectToAction("Index");
            }
            ViewBag.QuantVertices = grafo.QuantVertices;
            return View();
        }

        // POST: Adiciona aresta ao grafo
        [HttpPost]
        public IActionResult AdicionarAresta(int origem, int destino, int peso)
        {
            var grafo = ObterGrafo();
            if (grafo == null)
            {
                TempData["Erro"] = "Crie o grafo primeiro!";
                return RedirectToAction("Index");
            }

            // Validações
            if (origem < 1 || origem > grafo.QuantVertices || 
                destino < 1 || destino > grafo.QuantVertices)
            {
                ViewBag.QuantVertices = grafo.QuantVertices;
                TempData["Erro"] = "Valores de origem ou destino inválidos!";
                return View();
            }

            if (origem == destino)
            {
                ViewBag.QuantVertices = grafo.QuantVertices;
                TempData["Erro"] = "Origem e destino devem ser diferentes!";
                return View();
            }

            if (peso <= 0)
            {
                ViewBag.QuantVertices = grafo.QuantVertices;
                TempData["Erro"] = "O peso deve ser maior que zero!";
                return View();
            }

            // Converte para índice base 0
            grafo.AdicionarAresta(origem - 1, destino - 1, peso);
            SalvarGrafo(grafo);
            TempData["Sucesso"] = "Aresta adicionada com sucesso!";
            return RedirectToAction("Index");
        }

        // Exibe todas as arestas
        public IActionResult ListarArestas()
        {
            var grafo = ObterGrafo();
            if (grafo == null)
            {
                TempData["Erro"] = "Crie o grafo primeiro!";
                return RedirectToAction("Index");
            }
            return View(grafo);
        }

        // Exibe o grafo (lista de adjacência)
        public IActionResult VisualizarGrafo()
        {
            var grafo = ObterGrafo();
            if (grafo == null)
            {
                TempData["Erro"] = "Crie o grafo primeiro!";
                return RedirectToAction("Index");
            }

            var adjacencia = grafo.ObterListaAdjacencia();
            return View(adjacencia);
        }

        // Exibe o grafo de forma gráfica/visual
        public IActionResult VisualizarGrafoGrafico()
        {
            var grafo = ObterGrafo();
            if (grafo == null)
            {
                TempData["Erro"] = "Crie o grafo primeiro!";
                return RedirectToAction("Index");
            }
            return View(grafo);
        }

        // Executa o algoritmo de Kruskal
        public IActionResult ExecutarKruskal()
        {
            var grafo = ObterGrafo();
            if (grafo == null)
            {
                TempData["Erro"] = "Crie o grafo primeiro!";
                return RedirectToAction("Index");
            }

            var resultado = Algoritmos.Kruskal(grafo);
            ViewBag.Grafo = grafo;
            return View(resultado);
        }

        // Limpa o grafo da sessão
        public IActionResult LimparGrafo()
        {
            HttpContext.Session.Remove("Grafo");
            TempData["Sucesso"] = "Grafo removido com sucesso!";
            return RedirectToAction("Index");
        }
    }
}
