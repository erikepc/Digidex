using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Joke.Models;
using Joke.Data;
using Joke.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Joke.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _context;

    public HomeController(ILogger<HomeController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        HomeVM home = new() {
            Tipos = [.. _context.Tipos.ToList()],
            Planetas = [.. _context.Planetas.ToList()]
        };
        return View(home);
    }

   public IActionResult Details(int id)
        {
            // Obtém o planeta atual com o tipo relacionado
            var planeta = _context.Planetas
                .Include(p => p.AdicionarTipo) // Inclui o tipo do planeta
                .AsNoTracking() // Melhorar a performance se a entidade não for alterada
                .FirstOrDefault(p => p.Id == id);

            if (planeta == null)
            {
                return NotFound(); // Retorna uma página 404 se o planeta não for encontrado
            }

            // Obtém o planeta anterior e o próximo
            var anterior = _context.Planetas
                .Where(p => p.Id < id)
                .OrderByDescending(p => p.Id)
                .FirstOrDefault();

            var proximo = _context.Planetas
                .Where(p => p.Id > id)
                .OrderBy(p => p.Id)
                .FirstOrDefault();

            // Cria o ViewModel com os dados
            var viewModel = new DetailsVM
            {
                Atual = new PlanetaVM
                {
                    Id = planeta.Id,
                    Nome = planeta.Nome,
                    Idade = planeta.Idade,
                    Descricao = planeta.Descricao,
                    Foto = planeta.Foto,
                    Composicao = planeta.Composicao,
                    AdicionarTipo = new TipoVM
                    {
                        Nome = planeta.AdicionarTipo.Nome,
                        Cor = planeta.AdicionarTipo.Cor
                    }
                },
                Anterior = anterior != null ? new PlanetaVM
                {
                    Id = anterior.Id,
                    Nome = anterior.Nome
                } : null,
                Proximo = proximo != null ? new PlanetaVM
                {
                    Id = proximo.Id,
                    Nome = proximo.Nome
                } : null
            };

            return View(viewModel); // Retorna a view com o ViewModel
        }
      public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}