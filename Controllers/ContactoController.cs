using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projetos___ASP.NET_MVC.Context;
using Projetos___ASP.NET_MVC.Models;

namespace Projetos___ASP.NET_MVC.Controllers
{
    public class ContactoController : Controller
    {
        private readonly AgendaContext _context;

        public ContactoController(AgendaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //Aqui ta pegando todos meus contatos do banco de dados e transformando em uma lista
            var contatos = _context.Contatos.ToList();
            return View(contatos);
        }
        /* Aqui primeiro eu faço o front-end para ter a tela de criar um novo contato
        que posso preencher e clicar no botão de relamene criar, depois q eu clicar em criar
        ele vai acionar o meotodo post/create e passar as informações para a variavel
        e salva-las no banco de dados
        */
        public IActionResult Criar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Criar(Contacto contato)
        {
            if (ModelState.IsValid)
            {
                _context.Contatos.Add(contato);
                _context.SaveChanges();
                //E aqui depois de salvar eu vou redirecionar para a tela de index
                return RedirectToAction(nameof(Index));
            }
            return View(contato);
        }

        //Aqui eu só pego o Id que estou e leio ele, depois sim eu dou a logica para o botão "editar"
        //Através de outro metodo para de fato editar as propriedades do Id
        [HttpGet]
        public IActionResult Editar(int id)
        {
            var contato = _context.Contatos.Find(id);

            if (contato == null)
                return RedirectToAction(nameof(Index));

            return View(contato);
        }
        //Aqui é a logica para o botão editar
        [HttpPost]
        public IActionResult Editar(Contacto contato)
        {
            var contatoBanco = _context.Contatos.Find(contato.Id);

            contatoBanco.Nome = contato.Nome;
            contatoBanco.Telefone = contato.Telefone;
            contatoBanco.Ativo = contato.Ativo;

            _context.Contatos.Update(contatoBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detalhes(int id)
        {
            var contato = _context.Contatos.Find(id);

            if (contato == null)
                return RedirectToAction(nameof(Index));

            return View(contato);
        }
        //Aqui eu só estou exibindo a pagina de detalhe do contato, a logica para realmente deletar vem depois
        public IActionResult Deletar(int id)
        {
            var contato = _context.Contatos.Find(id);

            if (contato == null)
                return RedirectToAction(nameof(Index));

            return View(contato);
        }
        [HttpPost]
        public IActionResult Deletar(Contacto contacto)
        {
            var contatoBanco = _context.Contatos.Find(contacto.Id);

            _context.Contatos.Remove(contatoBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));

        }
    }
}