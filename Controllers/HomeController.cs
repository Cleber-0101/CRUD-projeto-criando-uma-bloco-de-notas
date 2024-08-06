using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WordProjetoView.Data;
using WordProjetoView.Models;

namespace WordProjetoView.Controllers
{
    public class HomeController : Controller
    {       

        //ir ate o Banco e pegar os arquivos salvos e mostrar na tela 

        private readonly AppDbContext _context;


        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var documentos = await _context.Documentos.ToListAsync();

            return View(documentos);
        }


        public IActionResult CriarDocumento()
        {
            return View();  
        }


    
        public async Task<IActionResult> EditarDocumento(int id)
        {
            var documento = await _context.Documentos.FirstOrDefaultAsync(d => d.id == id);
            return View(documento);
        }


        public async Task<IActionResult> RemoverDocumento(int id)
        {
            var documento = await _context.Documentos.FirstOrDefaultAsync(d => d.id == id);
            _context.Documentos.Remove(documento);
            await _context.SaveChangesAsync();  

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> EditarDocumento(Documento documentoEditado)
        {
            if(ModelState.IsValid)
            {
                var documento = await _context.Documentos.FirstOrDefaultAsync(d => d.id == documentoEditado.id);
                documento.Titulo = documentoEditado.Titulo;
                documento.conteudo = documentoEditado.conteudo; 
                documento.DataCriacao = DateTime.Now;

                _context.Update(documento);
                await _context.SaveChangesAsync();  

                return RedirectToAction("Index");
            }
            else
            {

              return View(documentoEditado);
            
            }
          
        }


        [HttpPost]
        public async Task<IActionResult> CriarDocumento(Documento documentoRecebido)
        {
            if(ModelState.IsValid)
            {
                _context.Add(documentoRecebido);  
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }else
            {
                return View(documentoRecebido);
            }
        }
    }
}
