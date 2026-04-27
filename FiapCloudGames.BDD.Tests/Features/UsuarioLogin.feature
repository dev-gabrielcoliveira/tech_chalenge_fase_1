Feature: Cadastro de Usuário

Scenario: Cadastro com dados válidos
	Given que eu insiro um objeto usuário com dados válidos
	When eu realizo o cadastro
	Then o sistema deve aceitar o usuário

Scenario: Cadastro com email inválido
  Given que eu insiro um usuário com email inválido
  When eu realizo o cadastro
  Then o sistema deve rejeitar o usuário

Scenario: Cadastro com senha inválida
  Given que eu insiro um usuário com senha inválida
  When eu realizo o cadastro
  Then o sistema deve rejeitar o usuário 