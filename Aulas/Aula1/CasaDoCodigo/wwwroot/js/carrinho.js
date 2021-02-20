
class Carrinho {

	clickIncremento(btn) {
		let data = this.getData(btn);
		data.Quantidade++;

		this.postQuantidade(data);
	}

	clickDecremento(btn) {
		let data = this.getData(btn);

		if (data.Quantidade > 0) {
			data.Quantidade--;
			this.postQuantidade(data);
		}
	}

	getData(elemento) {
		//O método parents obtém os "ancestrais"(elementos acima da hierarquia) do elemento.
		//O método find vai obter os elementos abaixo da hiearquia.
		var linhaItem = $(elemento).parents('[item-id]');
		var itemId = $(linhaItem).attr('item-id');
		var qtde = $(linhaItem).find('input').val();

		return { Id: itemId, Quantidade: qtde };
	}

    postQuantidade(data) {
        $.ajax({
			url: '/Pedido/UpdateQuantidade',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(data)
		}).done(function (response) {
			// refresh na página
			//location.reload();
			let itemPedido = response.itemPedido;
			let linhaItem = $('[item-id=' + itemPedido.id + ']');

			//ao procurar um elemento não precisa de []
			//substituindo o valor exibido no formulário pelo que retornou do banco
			linhaItem.find('input').val(itemPedido.quantidade);

			//subtotal é um atributo e precisa de []
			linhaItem.find('[subtotal]').html((itemPedido.subtotal).duasCasas());

			$('[numero-itens]').html('Total: ' + response.carrinhoViewModel.itens.length + ' itens');
			$('[total]').html((response.carrinhoViewModel.total).duasCasas());

			if (itemPedido.quantidade == 0)
				linhaItem.remove();
			
		});
	}

	updateQuantidade(input) {
		let data = this.getData(input);
		this.postQuantidade(data);
	}
	
}

var carrinho = new Carrinho();

Number.prototype.duasCasas = function() {
	return this.toFixed(2).replace('.', ',');
};