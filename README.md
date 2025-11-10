
# OO Template Method - Solução

Este repositório contém implementações didáticas dos quatro exercícios propostos no PDF: Importação, Pedidos, Pagamento e Sync. A estrutura segue a sugestão: cada exercício tem uma biblioteca "Core" (classe base) e implementações concretas.

## Estrutura de pastas
```
/src
  Importacao.Core
  Importacao.Alunos
  Importacao.Produtos
  Pedidos.Core
  Pedidos.Nacional
  Pedidos.Internacional
  Pagamento.Core
  Pagamento.BR
  Pagamento.US
  Sync.Core
  Sync.Erp
  Sync.Marketplace
/tests
  Importacao.Tests
  Pedidos.Tests
  Pagamento.Tests
  Sync.Tests
```

## Resumo das decisões de design (breve)
- Cada *orquestrador* público (Executar / Processar) define o fluxo fixo e delega variações a no máximo 3 ganchos protegidos (abstract/virtual).
- `abstract` foi escolhido quando a etapa não tem implementação padrão segura (ex: ValidarRegistro, CalcularFrete, CalcularImpostos).
- `virtual` (no-op) foi escolhido para pontos opcionais (ex: PosConsolidacao, AposReservaEstoque, AntesDeRegistrar, PosAplicacao).

## Como executar testes simples
Os diretórios `tests/*` contêm pequenos programas console para demonstrar o comportamento. Para executar (precisa do .NET SDK instalado):

```bash
# compile e execute manualmente (exemplo)
# entre em tests/Importacao.Tests
dotnet new console -n Importacao.Tests -o tmpproj -f net7.0   # opcional: criar projeto
# Ou simplesmente copie os arquivos para um projeto console e rode dotnet run
```

(Observação: os projetos de exemplo aqui são arquivos fonte; você pode criar projetos .NET e adicionar referências entre as pastas conforme desejar.)

## Diagrama textual (exemplo simplificado)
Importacao:
ImportadorBase (Executar -> ValidarRegistro* -> Consolidar -> PosConsolidacao?) 
  |- ImportacaoAlunos (override ValidarRegistro, override PosConsolidacao)
  |- ImportacaoProdutos (override ValidarRegistro)

Pedidos:
PedidoProcessor (Processar -> ValidarItens -> ReservarEstoque -> CalcularFrete* -> CalcularTotal -> Persistir -> GerarConfirmacao*)
  |- PedidoNacionalProcessor (CalcularFrete, GerarConfirmacao)
  |- PedidoInternacionalProcessor (CalcularFrete, GerarConfirmacao, override AposReservaEstoque)

Pagamento:
PaymentFlow (Processar -> ValidarPedido -> CalcularImpostos* -> AntesDeRegistrar? -> RegistrarPagamento -> AposRegistrar? -> FormatarRecibo*)
  |- BrPaymentFlow (CalcularImpostos, FormatarRecibo)
  |- UsPaymentFlow (CalcularImpostos, FormatarRecibo, override AntesDeRegistrar)

Sync:
SyncProcessor (Executar -> ColetarBruto* -> Normalizar -> AplicarDiferencas -> PosAplicacao? -> GerarRelatorio*)
  |- SyncErpFlow (ColetarBruto, GerarRelatorio)
  |- SyncMarketplaceFlow (ColetarBruto, GerarRelatorio, override PosAplicacao)

## Checklist curto (para revisão)
- [ ] Orquestrador público define fluxo fixo
- [ ] Ganchos protegidos (max 3 por exercício) — abstract quando obrigatório, virtual para extensão
- [ ] Sem if/switch por tipo no orquestrador
- [ ] Override que reutilize base.X() quando aplicável (ex.: PosConsolidacao em Importacao.Alunos, AposReservaEstoque em Internacional chama base)
- [ ] README com diagrama e justificativas
- [ ] Tests/pequenos runners demonstrando cada fluxo

## Observações finais
Este é um material de apoio e um ponto de partida — o professor pode exigir que cada diretório seja um projeto C# separado com `.csproj` e `.sln`. Se quiser, eu posso transformar esta estrutura em uma solução `.sln` com `csproj` completos e configurar os testes com xUnit/NUnit/MSTest — diga qual versão do .NET você prefere (net6.0, net7.0, net8.0) que eu gero os arquivos correspondentes e um zip pronto para abrir no Visual Studio / dotnet CLI.


## Como executar os testes (xUnit)

Abra a solução `TemplateMethod.sln` no Visual Studio ou use o `dotnet` CLI:

```bash
# compilar todos os projetos
dotnet build

# executar os testes
dotnet test
```
