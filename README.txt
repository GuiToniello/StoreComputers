# Store Computers

> Trabalho para a disciplina de Desenvolvimento de Sistemas


## Integra��o com o Twitter

> A integra��o com o twitter foi implementada ao cadastrar um computador no sistema.

> Isso foi implementado na camada de Aplica��o, no ComputerService.cs, metodo de Create().


## Funcionamento dos Testes


> Para o funcionamento dos testes, � necess�rio informar as chaves do twitter em:

* Infraestrtura > Infraestrtura.Data.Twitter > PostRepository.cs

> As chaves podem ser informadas em string.



## Execu��o da Aplica��o


> Para testar, ap�s informar as chaves do twitter (sess�o anterior), execute o projeto da camada de Apresenta��o

> E cadastre um novo computador, assim, al�m de cadastrar no banco deve gerar um post no twitter.