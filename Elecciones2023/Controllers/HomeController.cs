using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Elecciones2023.Models;

namespace Elecciones2023.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewBag.ListadoPartidos=BD.ListarPartidos();
        return View("Index");
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
    public IActionResult VerDetallePartido(int idPartido)
    {
        ViewBag.ListadoCandidato=BD.ListarCandidatos(idPartido);
        ViewBag.partidito=BD.VerInfoPartido(idPartido);
        ViewBag.candidate=BD.VerInfoCandidato(idPartido);
        return View("VerDetallePartido");
    }
    public IActionResult VerDetalleCandidato(int idCandidato)
    {
        ViewBag.candidate=BD.VerInfoCandidato(idCandidato);
        return View("VerDetalleCandidato");
    }
    public IActionResult AgregarCandidato(int idPartido)
    {
        ViewBag.partidito=BD.VerInfoPartido(idPartido);
        return View("AgregarCandidato");
    }
    public IActionResult GuardarCandidato(Candidato can)
    {
        BD.AgregarCandidato(can);
        return View("VerDetallePartido");
        //return RedirectToAction("VerDetallePartido", IdPartido);
    }
    public IActionResult EliminarCandidato(int idCandidato, int idPartido)
    {
        BD.EliminarCandidato(idCandidato);
        BD.VerInfoPartido(idPartido);
        return View("VerDetallePartido");
    }
    public IActionResult Elecciones()
    {
        return View("IntroElecciones");
    }
    public IActionResult Creditos()
    {
        return View("VerCreditos");
    }
}
