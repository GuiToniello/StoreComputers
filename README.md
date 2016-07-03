# Store Computers

> Trabalho Final para a disciplina de Desenvolvimento de Sistemas - Sistemas de Informação - UNIPLAC


## Integração com o Twitter

> A integração com o twitter foi implementada ao cadastrar uma placa-mãe no sistema.

> Isso foi implementado na camada de Aplicação, em MotherboardService.cs, metodo de Create().


## Funcionamento dos Testes


> Para o funcionamento dos testes, é necessário informar as chaves do twitter em:

* Infraestrtura > Infraestrtura.Data.Twitter > PostRepository.cs

> As chaves podem ser informadas em string.



## Execução da Aplicação


> Para testar, após informar as chaves do twitter (sessão anterior), execute o projeto da camada de Apresentação

> E cadastre um novo computador, assim, além de cadastrar no banco deve gerar um post no twitter.
