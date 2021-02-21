using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CasaDoCodigo.Models;
using CasaDoCodigo.Repositories;
using CasaDoCodigo.Repositories.Interfaces;
using CasaDoCodigo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CasaDoCodigo.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IItemPedidoRepository _itemPedidoRepository;

        public PedidoController(IProdutoRepository produtoRepository, IPedidoRepository pedidoRepository,
                                IItemPedidoRepository itemPedidoRepository)
        {
            _produtoRepository = produtoRepository;
            _pedidoRepository = pedidoRepository;
            _itemPedidoRepository = itemPedidoRepository;
        }

        public IActionResult Carrossel()
        {
            return View(_produtoRepository.GetProdutos());
        }

        public IActionResult Carrinho(string codigo)
        {
            if (!string.IsNullOrEmpty(codigo))
            {
                _pedidoRepository.AddItem(codigo);
            }

            List<ItemPedido> itens = _pedidoRepository.GetPedido().Itens;
            CarrinhoViewModel viewModel = new CarrinhoViewModel(itens);

            return View(viewModel);
        }

        public IActionResult Cadastro()
        {
            var pedido = _pedidoRepository.GetPedido();

            if (pedido == null)
                return RedirectToAction(nameof(Carrossel));

            return View(pedido.Cadastro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastro(Pedido pedido)
        {
            if (ModelState.IsValid)
            {

            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Resumo(Cadastro cadastro)
        {
            if (ModelState.IsValid)
            {
                return View(_pedidoRepository.UpDateCadastro(cadastro));
            }

            return RedirectToAction(nameof(Cadastro));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public UpdateQuantidadeResponse UpdateQuantidade([FromBody]ItemPedido itemPedido)
        {
            return _pedidoRepository.UpdateQuantidade(itemPedido);
        }
    }
}