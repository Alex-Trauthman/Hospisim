# HOSPISIM - Sistema de Gestão Hospitalar

Sistema desenvolvido para modernizar a gestão clínica do Hospital Vida Plena, garantindo segurança, rastreabilidade de atendimentos e controle completo de informações dos pacientes.

## 🏥 Sobre o Projeto

O HOSPISIM é uma aplicação web desenvolvida em ASP.NET Core MVC que oferece uma solução completa para gestão hospitalar, abrangendo desde o cadastro de pacientes até o controle de altas hospitalares.

## 🚀 Tecnologias Utilizadas

- **ASP.NET Core 8.0** - Framework web
- **Entity Framework Core** - ORM para acesso a dados
- **SQL Server** - Banco de dados
- **Bootstrap 5** - Framework CSS para interface responsiva
- **C#** - Linguagem de programação

## 📋 Funcionalidades

### Módulos Principais:
- **Gestão de Pacientes** - Cadastro completo com dados pessoais e médicos
- **Profissionais de Saúde** - Controle de médicos, enfermeiros e especialistas
- **Prontuários Médicos** - Histórico completo dos pacientes
- **Atendimentos** - Registro de consultas, emergências e procedimentos
- **Prescrições Médicas** - Controle de medicamentos e dosagens
- **Exames** - Solicitação e resultados de exames
- **Internamentos** - Gestão de leitos e quartos
- **Altas Hospitalares** - Processo de alta e instruções pós-internação

## 🗄️ Estrutura do Banco de Dados

### Entidades Principais:

**Paciente**
- Dados pessoais completos (CPF, nome, nascimento)
- Informações médicas (tipo sanguíneo, plano de saúde)
- Contato (telefone, email, endereço)

**Profissional de Saúde**
- Dados profissionais (CRM, COREN, especialidade)
- Informações trabalhistas (carga horária, turno)
- Vinculação com especialidades médicas

**Atendimento**
- Registro de consultas e procedimentos
- Vinculação paciente-profissional
- Controle de status e localização

### Relacionamentos:
```
Paciente (1:N) Prontuário (1:N) Atendimento
Profissional (N:1) Especialidade
Profissional (1:N) Atendimento
Atendimento (1:N) Prescrição
Atendimento (1:N) Exame
Atendimento (0..1:1) Internação
Internação (0..1:1) Alta Hospitalar
```

## ⚙️ Configuração e Execução

### Pré-requisitos:
- .NET 8.0 SDK
- SQL Server (LocalDB ou instância completa)
- Visual Studio 2022 ou VS Code

### Passos para execução:

1. **Clone o repositório:**
```bash
git clone [URL_DO_REPOSITORIO]
cd hospisim
```

2. **Configure a string de conexão:**
Edite o arquivo `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\mssqllocaldb;Database=HospisimDb;Trusted_Connection=true;MultipleActiveResultSets=true"
  }
}
```

3. **Execute as migrations:**
```bash
dotnet ef database update
```

4. **Execute a aplicação:**
```bash
dotnet run
```

5. **Acesse no navegador:**
```
https://localhost:5001 (esta é a porta padrão, em caso de erro, confira se não esta reservada a outro processo)
```

### Dados de Teste:
O sistema inclui dados iniciais (seed) com:
- 10+ pacientes cadastrados
- Profissionais de saúde de diversas especialidades
- Atendimentos de exemplo
- Dados completos para teste de todas as funcionalidades

## 📁 Estrutura do Projeto

```
Hospisim/
├── Controllers/          # Controllers MVC
├── Models/              # Entidades e contexto do banco
├── Views/               # Views Razor
├── Data/                # Configurações do Entity Framework
├── Migrations/          # Migrations do banco de dados
└── wwwroot/            # Arquivos estáticos (CSS, JS, imagens)
```

## 🔧 Principais Controllers

- **PatientsController** - CRUD de pacientes
- **ProfissionaisSaudeController** - Gestão de profissionais
- **AtendimentosController** - Controle de atendimentos
- **ProntuariosController** - Gestão de prontuários
- **ReceitasController** - Prescrições médicas
- **ExamesController** - Solicitação e resultados
- **InternamentosController** - Controle de internações
- **AltasHospitalaresController** - Processo de alta

## 🎯 Objetivos Alcançados

✅ **Modernização da gestão clínica**
- Interface web moderna e intuitiva
- Processos digitalizados e automatizados

✅ **Segurança das informações**
- Controle de acesso por usuário
- Validação de dados em todas as operações

✅ **Rastreabilidade completa**
- Histórico detalhado de todos os atendimentos
- Vinculação entre pacientes, profissionais e procedimentos

✅ **Controle total de informações**
- Cadastro completo de pacientes
- Gestão integrada de todos os processos hospitalares

## 📞 Suporte

Para dúvidas ou sugestões sobre o sistema, entre em contato através dos canais oficiais do Hospital Vida Plena.

---

**HOSPISIM** - Modernizando a gestão hospitalar com tecnologia e eficiência.
