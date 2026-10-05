namespace AppAsync
{
    // Define a classe do formulário principal herdando de Form (Windows Forms)
    public partial class Form1 : Form
    {
        // Construtor da classe Form1
        public Form1()
        {
            // Inicializa os componentes visuais criados pelo designer (botões, labels, listbox)
            InitializeComponent();
        }

        // 'async void' é necessário aqui porque é a assinatura padrão exigida por manipuladores de eventos de UI
        private async void btnIniciar_Click(object sender, EventArgs e)
        {
            // Limpa os itens anteriores do ListBox para iniciar uma nova execução
            lbResultados.Items.Clear();

            // Atualiza o texto da Label indicando ao usuário que o processo começou
            lblStatus.Text = "Status: Executando tarefas assíncronas...";

            // Desabilita o botão para impedir cliques múltiplos enquanto as tarefas rodam
            btnIniciar.Enabled = false;

            // Inicia o bloco try para capturar eventuais falhas durante a execução assíncrona
            try
            {
                // Cria e inicia as 4 tarefas concorrentes de forma independente (não bloqueante)
                // Cada método já retorna uma Task ativa imediatamente ao ser invocado
                var tarefasEmAndamento = new List<Task<string>>
                {
                    // Dispara a Tarefa 1 com duração de 1 segundo (1000 ms)
                    ExecutarTarefaAssincrona("Tarefa 1", 1000),

                    // Dispara a Tarefa 2 com duração de 8 segundos (8000 ms)
                    ExecutarTarefaAssincrona("Tarefa 2", 8000),

                    // Dispara a Tarefa 3 com duração de 4 segundos (4000 ms)
                    ExecutarTarefaAssincrona("Tarefa 3", 4000),

                    // Dispara a Tarefa 4 com duração de 2 segundos (2000 ms)
                    ExecutarTarefaAssincrona("Tarefa 4", 2000)
                };

                // Executa um loop enquanto ainda existirem tarefas pendentes na lista
                while (tarefasEmAndamento.Count > 0)
                {
                    // 'await Task.WhenAny' suspende o método e devolve o controle para a UI Thread,
                    // acordando assim que QUALQUER UMA das tarefas da lista concluir primeiro
                    Task<string> tarefaConcluida = await Task.WhenAny(tarefasEmAndamento);

                    // Remove a tarefa que acabou de finalizar da lista para não aguardá-la no próximo ciclo
                    tarefasEmAndamento.Remove(tarefaConcluida);

                    // Obtém a string de retorno da tarefa (o 'await' aqui é instantâneo, pois a tarefa já concluiu)
                    string resultado = await tarefaConcluida;

                    // Adiciona o resultado diretamente na ListBox; o SynchronizationContext garante execução na thread de UI
                    lbResultados.Items.Add(resultado);
                }

                // Quando a lista fica vazia, atualiza a label informando o término de todas as operações
                lblStatus.Text = "Status: Todas as tarefas concluídas com sucesso!";
            }
            // Captura qualquer exceção lançada pelas tarefas ou pelo fluxo
            catch (Exception ex)
            {
                // Exibe a mensagem de erro na label
                lblStatus.Text = $"Erro durante a execução: {ex.Message}";

                // Abre uma caixa de diálogo informando o erro visualmente ao usuário
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // O bloco finally sempre executa, ocorrendo erro ou sucesso
            finally
            {
                // Reativa o botão para permitir que o usuário clique e rode a demonstração novamente
                btnIniciar.Enabled = true;
            }
        }

        // Método assíncrono que simula uma operação de I/O (rede, banco ou disco) e devolve uma string
        private async Task<string> ExecutarTarefaAssincrona(string nomeTarefa, int tempoEmMilissegundos)
        {
            // Task.Delay cria um timer assíncrono sem prender nenhuma thread de SO enquanto espera
            // O operador 'await' cede a execução de volta para a thread pool até o tempo expirar
            await Task.Delay(tempoEmMilissegundos);

            // Constrói e retorna a mensagem informando a conclusão e o tempo decorrido em segundos
            return $"{nomeTarefa} concluída após {tempoEmMilissegundos / 1000}s.";
        }
    }
}