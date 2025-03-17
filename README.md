# Desafio Desenvolvimento - WinForms 🚀

Bem-vindo ao repositório da solução do **Desafio Desenvolvimento WinForms**, proposto pela [Netspeed](https://netspeed.com.br/) como parte do processo seletivo para a vaga de Desenvolvedor VB.NET.

## 📌 Descrição do Projeto
Este projeto é um sistema simples de **registro de chamados**, desenvolvido em **VB.NET Windows Forms**, utilizando o banco de dados **SQLite**. O objetivo principal foi corrigir erros existentes, implementar novos módulos e realizar melhorias significativas na aplicação.

---

## 🛠️ Tecnologias Utilizadas
- **Linguagem:** VB.NET
- **Framework:** .NET Framework 4.5.2
- **Banco de Dados:** SQLite
- **IDE:** Visual Studio 2022 ou 2019

---

## 🔧 Configuração do Projeto

### Pré-requisitos
Certifique-se de ter as seguintes ferramentas instaladas em seu ambiente:
1. **.NET Framework 4.5.2**  
   [Baixar aqui](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net452)
2. **Sqliteman Database Manager (Portable)**  
   [Baixar aqui](https://portableapps.com/apps/development/sqliteman-portable)
3. **Microsoft RDLC Report Designer 2022**  
   [Baixar aqui](https://marketplace.visualstudio.com/items?itemName=ProBITools.MicrosoftRdlcReportDesignerf)
4. **Visual Studio Community Edition**  
   [Baixar aqui](https://visualstudio.microsoft.com/pt-br/vs/community/)

### Instruções para Configuração
1. **Clone este repositório:**
   ```bash
   git clone https://github.com/SeuUsuario/WinForms_Desafio_Desenvolvimento.git
   cd WinForms_Desafio_Desenvolvimento

2. **Restaure os pacotes NuGet:**
No Visual Studio, vá para Ferramentas > Gerenciador de Pacotes NuGet > Gerenciar Pacotes para a Solução e clique em Restaurar.

3. **Configure o banco de dados:**

- Certifique-se de que o arquivo DesafioDB.db está localizado na pasta /BackEnd/Dados/ do projeto.

- O caminho do banco de dados é configurado dinamicamente para evitar dependência de diretórios fixos.

4. **Compile e execute o projeto:** 

Abra o projeto no Visual Studio, configure o projeto como "Startup Project", e execute

---

## 🚀 Funcionalidades Implementadas
- [x] Implementação do CRUD de Departamentos.

- [x] Correção do relatório de Departamentos.

- [x] Resolução de erros no módulo de Chamados.

- [x] Adicionada funcionalidade de duplo-clique nas telas de listagem para edição.

## Melhorias Extras (Opcional)
- [x] Validação de entrada de dados (limite de caracteres, permitir apenas números em campos específicos, etc.).

- [x] Restrições de regras de negócio (ex.: não permitir datas retroativas em chamados).

- [x] Outras otimizações que podem ser sugeridas.
