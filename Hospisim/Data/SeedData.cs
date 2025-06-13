using Hospisim.Domain.Entities;
using Hospisim.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospisim.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            Console.WriteLine("SeedData.Initialize() chamado");
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {

                 
                if (context.Especialidades.Any())
                {
                    Console.WriteLine("Banco já contém dados, seed não executado.");
                    return; // Banco já foi populado
                }

                // Seed Especialidades
                var especialidades = new List<Especialidade>
                {
                    new Especialidade { Id = Guid.NewGuid(), Nome = "Cardiologia" },
                    new Especialidade { Id = Guid.NewGuid(), Nome = "Pediatria" },
                    new Especialidade { Id = Guid.NewGuid(), Nome = "Ortopedia" },
                    new Especialidade { Id = Guid.NewGuid(), Nome = "Neurologia" },
                    new Especialidade { Id = Guid.NewGuid(), Nome = "Ginecologia" },
                    new Especialidade { Id = Guid.NewGuid(), Nome = "Dermatologia" },
                    new Especialidade { Id = Guid.NewGuid(), Nome = "Psiquiatria" },
                    new Especialidade { Id = Guid.NewGuid(), Nome = "Oftalmologia" },
                    new Especialidade { Id = Guid.NewGuid(), Nome = "Urologia" },
                    new Especialidade { Id = Guid.NewGuid(), Nome = "Gastroenterologia" },
                    new Especialidade { Id = Guid.NewGuid(), Nome = "Pneumologia" },
                    new Especialidade { Id = Guid.NewGuid(), Nome = "Endocrinologia" }
                };

                context.Especialidades.AddRange(especialidades);
                context.SaveChanges();

                // Seed Pacientes
                var pacientes = new List<Paciente>
                {
                    new Paciente
                    {
                        Id = Guid.NewGuid(),
                        NomeCompleto = "Maria Silva Santos",
                        CPF = "1234567801",
                        DataNascimento = new DateTime(1985, 3, 15),
                        Sexo = "Feminino",
                        TipoSanguineo = "A+",
                        Telefone = "(11) 98765-4321",
                        Email = "maria.silva@email.com",
                        EnderecoCompleto= "Rua das Flores, 123 - São Paulo/SP",
                        NumeroCartaoSUS = "123456789012345",
                        EstadoCivil = "Casada",
                        PossuiPlanoSaude = true
                    },
                    new Paciente
                    {
                        Id = Guid.NewGuid(),
                        NomeCompleto = "João Carlos Oliveira",
                        CPF = "23456792",
                        DataNascimento = new DateTime(1978, 7, 22),
                        Sexo = "Masculino",
                        TipoSanguineo = "O-",
                        Telefone = "(11) 97654-3210",
                        Email = "joao.oliveira@email.com",
                        EnderecoCompleto= "Av. Paulista, 456 - São Paulo/SP",
                        NumeroCartaoSUS = "234567890123456",
                        EstadoCivil = "Solteiro",
                        PossuiPlanoSaude = false
                    },
                    new Paciente
                    {
                        Id = Guid.NewGuid(),
                        NomeCompleto = "Ana Paula Costa",
                        CPF = "345670123",
                        DataNascimento = new DateTime(1992, 11, 8),
                        Sexo = "Feminino",
                        TipoSanguineo = "B+",
                        Telefone = "(11) 96543-2109",
                        Email = "ana.costa@email.com",
                        EnderecoCompleto = "Rua Augusta, 789 - São Paulo/SP",
                        NumeroCartaoSUS = "345678901234567",
                        EstadoCivil = "Solteira",
                        PossuiPlanoSaude = true
                    },
                    new Paciente
                    {
                        Id = Guid.NewGuid(),
                        NomeCompleto = "Pedro Henrique Lima",
                        CPF = "4567890234",
                        DataNascimento = new DateTime(1965, 5, 30),
                        Sexo = "Masculino",
                        TipoSanguineo = "AB+",
                        Telefone = "(11) 95432-1098",
                        Email = "pedro.lima@email.com",
                        EnderecoCompleto = "Rua da Consolação, 321 - São Paulo/SP",
                        NumeroCartaoSUS = "456789012345678",
                        EstadoCivil = "Casado",
                        PossuiPlanoSaude = true
                    },
                    new Paciente
                    {
                        Id = Guid.NewGuid(),
                        NomeCompleto = "Carla Fernanda Souza",
                        CPF = "5678901245",
                        DataNascimento = new DateTime(1988, 9, 12),
                        Sexo = "Feminino",
                        TipoSanguineo = "O+",
                        Telefone = "(11) 94321-0987",
                        Email = "carla.souza@email.com",
                        EnderecoCompleto = "Rua Liberdade, 654 - São Paulo/SP",
                        NumeroCartaoSUS = "567890123456789",
                        EstadoCivil = "Divorciada",
                        PossuiPlanoSaude = false
                    },
                    new Paciente
                    {
                        Id = Guid.NewGuid(),
                        NomeCompleto= "Roberto Carlos Pereira",
                        CPF = "6789013456",
                        DataNascimento = new DateTime(1975, 1, 18),
                        Sexo = "Masculino",
                        TipoSanguineo = "A-",
                        Telefone = "(11) 93210-9876",
                        Email = "roberto.pereira@email.com",
                        EnderecoCompleto= "Av. Ibirapuera, 987 - São Paulo/SP",
                        NumeroCartaoSUS = "678901234567890",
                        EstadoCivil = "Casado",
                        PossuiPlanoSaude = true
                    },
                    new Paciente
                    {
                        Id = Guid.NewGuid(),
                        NomeCompleto= "Juliana Alves Rodrigues",
                        CPF = "789014567",
                        DataNascimento = new DateTime(1990, 4, 25),
                        Sexo = "Feminino",
                        TipoSanguineo = "B-",
                        Telefone = "(11) 92109-8765",
                        Email = "juliana.rodrigues@email.com",
                        EnderecoCompleto= "Rua Oscar Freire, 147 - São Paulo/SP",
                        NumeroCartaoSUS = "789012345678901",
                        EstadoCivil = "Solteira",
                        PossuiPlanoSaude = false
                    },
                    new Paciente
                    {
                        Id = Guid.NewGuid(),
                        NomeCompleto= "Marcos Antonio Silva",
                        CPF = "89012345678",
                        DataNascimento = new DateTime(1982, 12, 3),
                        Sexo = "Masculino",
                        TipoSanguineo = "AB-",
                        Telefone = "(11) 91098-7654",
                        Email = "marcos.silva@email.com",
                        EnderecoCompleto= "Rua Bela Vista, 258 - São Paulo/SP",
                        NumeroCartaoSUS = "890123456789012",
                        EstadoCivil = "Casado",
                        PossuiPlanoSaude = true
                    },
                    new Paciente
                    {
                        Id = Guid.NewGuid(),
                        NomeCompleto= "Fernanda Santos Lima",
                        CPF = "90123456789",
                        DataNascimento = new DateTime(1995, 6, 14),
                        Sexo = "Feminino",
                        TipoSanguineo = "O+",
                        Telefone = "(11) 90987-6543",
                        Email = "fernanda.lima@email.com",
                        EnderecoCompleto= "Av. Faria Lima, 369 - São Paulo/SP",
                        NumeroCartaoSUS = "901234567890123",
                        EstadoCivil = "Solteira",
                        PossuiPlanoSaude = false
                    },
                    new Paciente
                    {
                        Id = Guid.NewGuid(),
                        NomeCompleto= "Carlos Eduardo Martins",
                        CPF = "01234567890",
                        DataNascimento = new DateTime(1970, 8, 27),
                        Sexo = "Masculino",
                        TipoSanguineo = "A+",
                        Telefone = "(11) 98876-5432",
                        Email = "carlos.martins@email.com",
                        EnderecoCompleto= "Rua Vergueiro, 741 - São Paulo/SP",
                        NumeroCartaoSUS = "012345678901234",
                        EstadoCivil = "Viúvo",
                        PossuiPlanoSaude = true
                    }
                };
                try
                {
                    context.Pacientes.AddRange(pacientes);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao salvar pacientes: " + ex.Message);
                    throw;
                }
                

                // Seed Profissionais de Saúde
                var profissionais = new List<ProfissionalSaude>
                {
                    new ProfissionalSaude
                    {
                        Id = Guid.NewGuid(),
                        NomeCompleto= "Dr. Ricardo Almeida",
                        CPF = "11122233344",
                        Email = "ricardo.almeida@hospital.com",
                        Telefone = "(11) 99999-1111",
                        RegistroConselho = "CRM-SP 123456",
                        TipoRegistro = "CRM",
                        EspecialidadeId = especialidades[0].Id, // Cardiologia
                        DataAdmissao = new DateTime(2015, 1, 15),
                        CargaHorariaSemanal = 40,
                        Turno = "Manhã",
                        Ativo = true
                    },
                    new ProfissionalSaude
                    {
                        Id = Guid.NewGuid(),
                        NomeCompleto= "Dra. Patricia Santos",
                        CPF = "22233344455",
                        Email = "patricia.santos@hospital.com",
                        Telefone = "(11) 99999-2222",
                        RegistroConselho = "CRM-SP 234567",
                        TipoRegistro = "CRM",
                        EspecialidadeId = especialidades[1].Id, // Pediatria
                        DataAdmissao = new DateTime(2018, 3, 20),
                        CargaHorariaSemanal = 36,
                        Turno = "Tarde",
                        Ativo = true
                    },
                    new ProfissionalSaude
                    {
                        Id = Guid.NewGuid(),
                        NomeCompleto= "Dr. Fernando Costa",
                        CPF = "33344455566",
                        Email = "fernando.costa@hospital.com",
                        Telefone = "(11) 99999-3333",
                        RegistroConselho = "CRM-SP 345678",
                        TipoRegistro = "CRM",
                        EspecialidadeId = especialidades[2].Id, // Ortopedia
                        DataAdmissao = new DateTime(2012, 7, 10),
                        CargaHorariaSemanal = 44,
                        Turno = "Integral",
                        Ativo = true
                    },
                    new ProfissionalSaude
                    {
                        Id = Guid.NewGuid(),
                        NomeCompleto= "Dra. Mariana Oliveira",
                        CPF = "4445556677",
                        Email = "mariana.oliveira@hospital.com",
                        Telefone = "(11) 99999-4444",
                        RegistroConselho = "CRM-SP 456789",
                        TipoRegistro = "CRM",
                        EspecialidadeId = especialidades[3].Id, // Neurologia
                        DataAdmissao = new DateTime(2020, 2, 5),
                        CargaHorariaSemanal = 40,
                        Turno = "Manhã",
                        Ativo = true
                    },
                    new ProfissionalSaude
                    {
                        Id = Guid.NewGuid(),
                        NomeCompleto= "Dra. Lucia Fernandes",
                        CPF = "55566677788",
                        Email = "lucia.fernandes@hospital.com",
                        Telefone = "(11) 99999-5555",
                        RegistroConselho = "CRM-SP 567890",
                        TipoRegistro = "CRM",
                        EspecialidadeId = especialidades[4].Id, // Ginecologia
                        DataAdmissao = new DateTime(2016, 9, 12),
                        CargaHorariaSemanal = 36,
                        Turno = "Tarde",
                        Ativo = true
                    },
                    new ProfissionalSaude
                    {
                        Id = Guid.NewGuid(),
                        NomeCompleto= "Dr. Paulo Henrique",
                        CPF = "66677788899",
                        Email = "paulo.henrique@hospital.com",
                        Telefone = "(11) 99999-6666",
                        RegistroConselho = "CRM-SP 678901",
                        TipoRegistro = "CRM",
                        EspecialidadeId = especialidades[5].Id, // Dermatologia
                        DataAdmissao = new DateTime(2019, 4, 8),
                        CargaHorariaSemanal = 32,
                        Turno = "Manhã",
                        Ativo = true
                    },
                    new ProfissionalSaude
                    {
                        Id = Guid.NewGuid(),
                        NomeCompleto= "Dra. Camila Rodrigues",
                        CPF = "7778889900",
                        Email = "camila.rodrigues@hospital.com",
                        Telefone = "(11) 99999-7777",
                        RegistroConselho = "CRM-SP 789012",
                        TipoRegistro = "CRM",
                        EspecialidadeId = especialidades[6].Id, // Psiquiatria
                        DataAdmissao = new DateTime(2017, 11, 25),
                        CargaHorariaSemanal = 40,
                        Turno = "Tarde",
                        Ativo = true
                    },
                    new ProfissionalSaude
                    {
                        Id = Guid.NewGuid(),
                        NomeCompleto= "Dr. Roberto Silva",
                        CPF = "88899900011",
                        Email = "roberto.silva@hospital.com",
                        Telefone = "(11) 99999-8888",
                        RegistroConselho = "CRM-SP 890123",
                        TipoRegistro = "CRM",
                        EspecialidadeId = especialidades[7].Id, // Oftalmologia
                        DataAdmissao = new DateTime(2014, 6, 30),
                        CargaHorariaSemanal = 36,
                        Turno = "Manhã",
                        Ativo = true
                    },
                    new ProfissionalSaude
                    {
                        Id = Guid.NewGuid(),
                        NomeCompleto= "Dr. Anderson Lima",
                        CPF = "999001122",
                        Email = "anderson.lima@hospital.com",
                        Telefone = "(11) 99999-9999",
                        RegistroConselho = "CRM-SP 901234",
                        TipoRegistro = "CRM",
                        EspecialidadeId = especialidades[8].Id, // Urologia
                        DataAdmissao = new DateTime(2021, 1, 18),
                        CargaHorariaSemanal = 44,
                        Turno = "Integral",
                        Ativo = true
                    },
                    new ProfissionalSaude
                    {
                        Id = Guid.NewGuid(),
                        NomeCompleto= "Dra. Beatriz Costa",
                        CPF = "00011122233",
                        Email = "beatriz.costa@hospital.com",
                        Telefone = "(11) 99999-0000",
                        RegistroConselho = "CRM-SP 012345",
                        TipoRegistro = "CRM",
                        EspecialidadeId = especialidades[9].Id, // Gastroenterologia
                        DataAdmissao = new DateTime(2013, 8, 22),
                        CargaHorariaSemanal = 40,
                        Turno = "Tarde",
                        Ativo = true
                    }
                };

                context.ProfissionaisSaude.AddRange(profissionais);
                context.SaveChanges();

                // Seed Prontuários
                var prontuarios = new List<Prontuario>();
                for (int i = 0; i < pacientes.Count; i++)
                {
                    prontuarios.Add(new Prontuario
                    {
                        Id = Guid.NewGuid(),
                        PacienteId = pacientes[i].Id,
                        Numero = $"PRONT-{2024:D4}-{(i + 1):D4}",
                        DataAbertura = DateTime.Now.AddDays(-Random.Shared.Next(30, 365)),
                        ObservacoesGerais = $"Prontuário do paciente {pacientes[i].NomeCompleto}. Histórico médico em acompanhamento."
                    });
                }

                context.Prontuarios.AddRange(prontuarios);
                context.SaveChanges();

                // Seed Atendimentos
                var atendimentos = new List<Atendimento>();
                var tiposAtendimento = new[] { "Consulta", "Emergência", "Retorno", "Exame", "Procedimento" };
                var statusAtendimento = new[] { "Agendado", "Em Andamento", "Realizado", "Cancelado" };
                var locais = new[] { "Consultório 1", "Consultório 2", "Sala de Emergência", "Sala de Exames", "UTI" };

                for (int i = 0; i < 15; i++)
                {
                    atendimentos.Add(new Atendimento
                    {
                        Id = Guid.NewGuid(),
                        ProntuarioId = prontuarios[i % prontuarios.Count].Id,
                        Paciente = pacientes[i % pacientes.Count],
                        ProfissionalSaudeId = profissionais[i % profissionais.Count].Id,
                        DataHora = DateTime.Now.AddDays(-Random.Shared.Next(1, 30)),
                        Tipo = tiposAtendimento[i % tiposAtendimento.Length],
                        Status = statusAtendimento[i % statusAtendimento.Length],
                        Local = locais[i % locais.Length]
                    });
                }

                context.Atendimentos.AddRange(atendimentos);
                context.SaveChanges();
                // Seed Prescricoes
                var receitas = new List<Prescricao>();
                var medicamentos = new[] { "Paracetamol", "Ibuprofeno", "Amoxicilina", "Dipirona", "Omeprazol", "Losartana", "Metformina", "Sinvastatina" };
                var dosagens = new[] { "500mg", "200mg", "875mg", "1g", "20mg", "50mg", "850mg", "40mg" };
                var frequencias = new[] { "8/8h", "12/12h", "24/24h", "6/6h", "De manhã", "À noite", "Antes das refeições" };

                for (int i = 0; i < 12; i++)
                {
                    receitas.Add(new Prescricao
                    {
                        Id = Guid.NewGuid(),
                        AtendimentoId = atendimentos[i % atendimentos.Count].Id,
                        ProfissionalId = profissionais[i % profissionais.Count].Id,
                        Medicamento = medicamentos[i % medicamentos.Length],
                        Dosagem = dosagens[i % dosagens.Length],
                        ViaAdministracao = "Oral",
                        Frequencia = frequencias[i % frequencias.Length],
                        DataInicio = DateTime.Now.AddDays(-Random.Shared.Next(1, 30)),
                        DataFim = DateTime.Now.AddDays(-Random.Shared.Next(1, 30)),
                        StatusPrescricao = "Conforme previsto",
                        ReacoesAdversas = "Não ocorrentes",
                        Observacoes = "Tomar conforme orientação médica"
                    });
                }

                context.Prescricoes.AddRange(receitas);
                context.SaveChanges();

                // Seed Exames
                var exames = new List<Exame>();
                var tiposExame = new[] { "Hemograma", "Raio-X", "Ultrassom", "Tomografia", "Ressonância", "Eletrocardiograma", "Urina", "Glicemia" };

                for (int i = 0; i < 10; i++)
                {
                    var dataSolicitacao = DateTime.Now.AddDays(-Random.Shared.Next(5, 20));
                    exames.Add(new Exame
                    {
                        Id = Guid.NewGuid(),
                        AtendimentoId = atendimentos[i % atendimentos.Count].Id,
                        Tipo = tiposExame[i % tiposExame.Length],
                        DataSolicitacao = dataSolicitacao,
                        DataRealizacao = dataSolicitacao.AddDays(Random.Shared.Next(1, 7)),
                        Resultado = "Resultado dentro dos parâmetros normais",
                    });
                }

                context.Exames.AddRange(exames);
                context.SaveChanges();

                // Seed Internacoes
                var Internacoes = new List<Internacao>();

                var motivos = new[] { "Cirurgia eletiva", "Emergência cardíaca", "Tratamento oncológico", "Recuperação pós-operatória", "Observação clínica" };
                var quartos = new[] { "101", "102", "201", "202", "301", "302", "UTI-01", "UTI-02" };
                var leitos = new[] { "A", "B", "C", "D" };
                var setores = new[] { "Clínica Médica", "Cirurgia", "UTI", "Pediatria", "Ortopedia" };
                var status = new[] { "Ativa", "Em observação", "Encerrada", "Transferida" };

                for (int i = 0; i < 8; i++)
                {
                    var dataEntrada = DateTime.Now.AddDays(-Random.Shared.Next(5, 20));

                    Internacoes.Add(new Internacao
                    {
                        Id = Guid.NewGuid(),
                        PacienteId = pacientes[i].Id,
                        AtendimentoId = atendimentos[i].Id,

                        DataEntrada = dataEntrada,
                        PrevisaoAlta = dataEntrada.AddDays(Random.Shared.Next(1, 10)),
                        MotivoInternacao = motivos[i % motivos.Length],
                        Quarto = quartos[i % quartos.Length],
                        Leito = leitos[i % leitos.Length],
                        Setor = setores[i % setores.Length],
                        PlanoSaudeUtilizado = "Unimed", 
                        ObservacoesClinicas = "Paciente apresenta evolução estável.",
                        StatusInternacao = status[i % status.Length]
                    });
                }


                context.Internacoes.AddRange(Internacoes);
                context.SaveChanges();

                // Seed Altas Hospitalares
                var altasHospitalares = new List<AltaHospitalar>();
                var condicoesSaida = new[] { "Estável", "Melhorado", "Inalterado", "Crítico" };

                for (int i = 0; i < 5; i++)
                {
                    altasHospitalares.Add(new AltaHospitalar
                    {
                        Id = Guid.NewGuid(),
                        InternacaoId = Internacoes[i].Id,
                        Data= Internacoes[i].DataEntrada.AddDays(Random.Shared.Next(1, 10)),
                        CondicaoPaciente = condicoesSaida[i % condicoesSaida.Length],
                        InstrucoesPosAlta = "Retorno em 7 dias para reavaliação"
                    });
                }

                context.AltasHospitalares.AddRange(altasHospitalares);
                context.SaveChanges();
            }
        }
    }
}