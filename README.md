# 🚛 Projeto Transporte: Controle de Frotas (Pilha)

Este projeto foi desenvolvido como atividade acadêmica para aplicar conceitos avançados de **Estrutura de Dados**, especificamente o uso de **Pilhas (`Stack<T>`)**, em uma aplicação **C# Console**. O sistema simula a logística de uma empresa de fretamento que opera rotas entre aeroportos (ex: Congonhas <-> Guarulhos), onde o gerenciamento das garagens segue rigorosamente a lógica LIFO (*Last In, First Out*).

## 🎯 Objetivos

- **Estrutura de Dados (Pilha)**: Implementar garagens onde o estacionamento é feito de ré e em fila única. O último veículo a entrar é obrigatoriamente o primeiro a sair.
- **Controle de Jornada**: Gerenciar o estado da operação (Iniciada/Encerrada).
  - *Início*: Distribui veículos alternadamente entre as garagens.
  - *Fim*: Gera relatórios de passageiros e "limpa" as ocorrências para o dia seguinte.
- **Logística de Viagem**: Controlar o fluxo de transporte (Origem -> Destino) somente quando a lotação do veículo estiver completa.
- **Restrições de Cadastro**: Permitir o cadastro de novos veículos e garagens apenas quando a jornada diária estiver encerrada.
- **Relatórios**: Listar veículos estacionados, viagens efetuadas e total de passageiros transportados.

## 🛠️ Ferramentas Utilizadas

- C# (.NET)
- Visual Studio
- Git e GitHub

## 🗂️ Estrutura do Projeto
```
📁 projeto-fretamento-cs/
├── 📁 cs-fretamento
|   ├── 📄 Program.cs
|   ├── 📄 Aeroporto.cs
|   ├── 📄 Fretadora.cs
|   ├── 📄 Garagem.cs
|   ├── 📄 Veiculo.cs
|   ├── 📄 Viagem.cs
|   ├── 📄 Utils.cs
│   └── 📄 cs-fretamento.sln
├── 📄 .gitignore
└── 📄 README.md
```

## 🚀 Como Executar

1. Abra a IDE **Visual Studio 2022**.
2. Vá em **Clonar um Repositório** e digite o link `https://github.com/Guilh3rme-M3ndes/projeto-fretamento-cs`.
3. Selecione a pasta desejada e clone o projeto.
4. Execute a aplicação a partir do **Visual Studio 2022**.

## 👨‍🏫 Autores

- **Stiven Richardy Silva Rodrigues**  
  Estudante de Análise e Desenvolvimento de Sistemas | IFSP — Campus Cubatão  
  [@Stiven-Richardy](https://github.com/Stiven-Richardy)

- **Guilherme Mendes de Sousa**  
  Estudante de Análise e Desenvolvimento de Sistemas | IFSP — Campus Cubatão  
  [@Guilh3rme-M3ndes](https://github.com/Guilh3rme-M3ndes)

## 📚 Referências

- C# Reference: [Microsoft C#](https://learn.microsoft.com/pt-br/visualstudio/get-started/csharp/?view=vs-2022)
