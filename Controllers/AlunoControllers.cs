using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using cadastro_senai.Repositorio;
using cadastro_senai.Dominio;
using System.Collections.Generic;
using System.Linq;

namespace cadastro_senai.Controllers
{
    public class AlunoController : Controller
    {
       AlunoRep objAlunoRep = new AlunoRep();   
   
    // GET: /<controller>/   
        public IActionResult Index()   
        {   
            List<Aluno> lstAluno = new List<Aluno>();  
            try
            {
                lstAluno = objAlunoRep.Listar().ToList();       
            }
            catch (System.Exception ex)
            {
                TempData["Erro"] = ex.Message;
            }

            return View(lstAluno);
            
        }   

        [HttpGet]     
        public IActionResult Cadastrar()     
        {     
            return View();     
        }     
        
        [HttpPost]     
        [ValidateAntiForgeryToken]     
        public IActionResult Cadastrar([Bind] Aluno Aluno)     
        {     
            if (ModelState.IsValid)     
            {     
                objAlunoRep.Cadastrar(Aluno);     
                return RedirectToAction("Index");     
            }     
            return View(Aluno);     
        } 

        [HttpGet]   
        public IActionResult Editar(int? id)   
        {   
            if (id == null)   
            {   
                return NotFound();   
            }   
            Aluno Aluno = objAlunoRep.BuscarAlunoPorId(id);   
        
            if (Aluno == null)   
            {   
                return NotFound();   
            }   
            return View(Aluno);   
        }   
        
        [HttpPost]   
        [ValidateAntiForgeryToken]   
        public IActionResult Editar(int id, [Bind]Aluno Aluno)   
        {   
            if (id != Aluno.Id)   
            {   
                return NotFound();   
            }   
            if (ModelState.IsValid)   
            {   
                objAlunoRep.Atualizar(Aluno);   
                return RedirectToAction("Index");   
            }   
            return View(Aluno);   
        }  

        [HttpGet]   
        public IActionResult Detalhes(int? id)   
        {   
            if (id == null)   
            {   
                return NotFound();   
            }   
            Aluno Aluno = objAlunoRep.BuscarAlunoPorId(id);   
        
            if (Aluno == null)   
            {   
                return NotFound();   
            }   
            return View(Aluno);   
        }

        [HttpGet]   
        public IActionResult Excluir(int? id)   
        {   
            if (id == null)   
            {   
                return NotFound();   
            }   

            Aluno Aluno = objAlunoRep.BuscarAlunoPorId(id);  
        
            if (Aluno == null)   
            {   
                return NotFound();   
            }   
            return View(Aluno);   
        }   
        
        [HttpPost, ActionName("Excluir")]   
        [ValidateAntiForgeryToken]   
        public IActionResult ExclusaoConfirmada(int? id)   
        {   
            objAlunoRep.Excluir(id);   
            return RedirectToAction("Index");   
        }
    }
}