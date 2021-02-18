
class Carrinho {

	clickIncremento(btn) {
		let data = this.getData(btn);
		data.Quantidade++;

		this.postQuantidade(data);
	}

	clickDecremento(btn) {
		let data = this.getData(btn);
		data.Quantidade--;

		this.postQuantidade(data);
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
        });
	}

	updateQuantidade(input) {
		let data = this.getData(input);
		this.postQuantidade(data);
	}
	
}

var carrinho = new Carrinho();