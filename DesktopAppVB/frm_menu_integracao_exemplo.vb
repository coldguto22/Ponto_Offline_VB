' ============================================================================
' Exemplo de Integração: Como usar SincronizadorPonto no formulário principal
' ============================================================================
' Este arquivo mostra como integrar o módulo de sincronização no seu app VB.NET

Imports System.Windows.Forms

Public Class frm_menu_exemplo
    ' Declarar o sincronizador como variável de classe
    Private sincronizador As New SincronizadorPonto()
    Private timerSincronizacao As New System.Timers.Timer(30000) ' 30 segundos

    ''' <summary>
    ''' Evento de carregamento do formulário principal
    ''' Aqui iniciamos o sincronizador automático
    ''' </summary>
    Private Sub frm_menu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' ... seu código de inicialização existente ...

        ' ===== NOVO: Inicializar sincronização automática =====
        inicializarSincronizacao()
    End Sub

    ''' <summary>
    ''' Inicializa o timer de sincronização automática
    ''' Será chamado a cada 30 segundos
    ''' </summary>
    Private Sub inicializarSincronizacao()
        ' Configurar o evento do timer
        AddHandler timerSincronizacao.Elapsed, AddressOf TimerSincronizacao_Tick
        timerSincronizacao.AutoReset = True
        timerSincronizacao.Enabled = True
        timerSincronizacao.Start()

        ' Log (opcional)
        Console.WriteLine("Sincronização automática iniciada (a cada 30 segundos)")
    End Sub

    ''' <summary>
    ''' Executado a cada 30 segundos pelo timer
    ''' Tenta sincronizar registros pendentes
    ''' </summary>
    Private Async Sub TimerSincronizacao_Tick(sender As Object, e As EventArgs)
        ' Sincronizar de forma assíncrona (não bloqueia a UI)
        Try
            Await sincronizador.SincronizarAsync()
            ' Atualizar label de status (opcional)
            If Me.InvokeRequired Then
                Me.Invoke(Sub() lblStatusSincronizacao.Text = "Sincronizado em: " & DateTime.Now.ToString("HH:mm:ss"))
            Else
                lblStatusSincronizacao.Text = "Sincronizado em: " & DateTime.Now.ToString("HH:mm:ss")
            End If
        Catch ex As Exception
            ' Log de erro (opcional)
            Console.WriteLine("Erro ao sincronizar: " & ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Exemplo: Botão para marcar ponto no desktop (offline)
    ''' Este é o fluxo típico quando o funcionário clica "Marcar Ponto"
    ''' </summary>
    Private Sub btnMarcarPonto_Click(sender As Object, e As EventArgs) Handles btnMarcarPonto.Click
        ' 1. Validar entrada
        Dim cpf As String = txtCPF.Text.Trim()
        If String.IsNullOrEmpty(cpf) Then
            MsgBox("Por favor, digite o CPF")
            Return
        End If

        ' 2. Buscar funcionário no banco LOCAL (ou via API)
        ' Opção A: Buscar localmente (mais rápido, funciona offline)
        Dim funcionario = BuscarFuncionarioLocal(cpf)
        If funcionario Is Nothing Then
            MsgBox("Funcionário não encontrado")
            Return
        End If

        ' 3. Obter tipo de marcação (ENTRADA ou SAIDA)
        Dim tipo As String = cbxTipo.SelectedValue.ToString()

        ' 4. Obter geolocalização (OPCIONAL)
        Dim latitude As Double? = Nothing
        Dim longitude As Double? = Nothing

        ' Se quiser capturar GPS (ex: via Windows.Devices.Geolocation)
        ' latitude = ObterLatitudeGPS()
        ' longitude = ObterLongitudeGPS()

        ' 5. Registrar ponto localmente (será sincronizado depois)
        Dim sucesso = sincronizador.RegistrarPontoLocal(funcionario.id, tipo, latitude, longitude)

        If sucesso Then
            ' Feedback visual
            MsgBox("✓ Ponto registrado com sucesso!" & vbCrLf & _
                   "Será sincronizado com o servidor automaticamente.", MsgBoxStyle.Information)

            ' Limpar campos
            txtCPF.Clear()
            cbxTipo.SelectedIndex = 0

            ' Atualizar label de status (opcional)
            lblUltimoRegistro.Text = "Último registro: " & DateTime.Now.ToString("HH:mm:ss") & " - " & tipo

            ' Incrementar contador (opcional)
            ' lblTotalRegistros.Text = "Total registrado: " & (Integer.Parse(lblTotalRegistros.Text) + 1)

        Else
            MsgBox("Erro ao registrar ponto. Tente novamente.", MsgBoxStyle.Exclamation)
        End If
    End Sub

    ''' <summary>
    ''' Buscar funcionário localmente por CPF (usa banco local)
    ''' Funciona offline
    ''' </summary>
    Private Function BuscarFuncionarioLocal(cpf As String) As Dynamic
        Try
            Dim sql = "SELECT id, nome, CPF FROM tb_funcionarios WHERE CPF = '" & cpf.Replace("'", "''") & "'"
            Dim rs = ExecutarConsulta(sql)

            If Not rs.EOF Then
                Return New With {
                    .id = rs("id"),
                    .nome = rs("nome"),
                    .cpf = rs("CPF")
                }
            End If
            Return Nothing
        Catch
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Botão para forçar sincronização (útil para testes)
    ''' </summary>
    Private Async Sub btnSincronizarAgora_Click(sender As Object, e As EventArgs)
        btnSincronizarAgora.Enabled = False
        btnSincronizarAgora.Text = "Sincronizando..."

        Try
            Await sincronizador.SincronizarAsync()
            MsgBox("Sincronização concluída!", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox("Erro ao sincronizar: " & ex.Message, MsgBoxStyle.Exclamation)
        Finally
            btnSincronizarAgora.Enabled = True
            btnSincronizarAgora.Text = "Sincronizar Agora"
        End Try
    End Sub

    ''' <summary>
    ''' Exemplo: Visualizar registros pendentes (debug)
    ''' </summary>
    Private Sub btnVerPendentes_Click(sender As Object, e As EventArgs)
        Try
            Dim sql = "SELECT * FROM tb_registros_ponto_pending WHERE sincronizado = 0"
            Dim rs = ExecutarConsulta(sql)

            Dim msg As String = "Registros pendentes: " & vbCrLf & vbCrLf

            If rs.RecordCount = 0 Then
                msg = "Nenhum registro pendente"
            Else
                While Not rs.EOF
                    msg &= "- " & rs("tipo") & " (" & rs("data") & " " & rs("hora") & ")" & vbCrLf
                    rs.MoveNext()
                End While
            End If

            MsgBox(msg, MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox("Erro: " & ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    ''' <summary>
    ''' Ao fechar o formulário, parar o timer
    ''' </summary>
    Private Sub frm_menu_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        timerSincronizacao.Stop()
        timerSincronizacao.Dispose()
    End Sub

End Class

' ============================================================================
' ELEMENTOS DA UI QUE VOCÊ PRECISA ADICIONAR AO DESIGNER
' ============================================================================
'
' ComboBox: cbxTipo
'   Items: "ENTRADA", "SAIDA"
'
' TextBox: txtCPF
'   Placeholder: "Digite o CPF"
'
' Label: lblStatusSincronizacao
'   Text: "Aguardando sincronização..."
'
' Label: lblUltimoRegistro
'   Text: "Último registro: -"
'
' Button: btnMarcarPonto
'   Text: "Marcar Ponto"
'
' Button: btnSincronizarAgora
'   Text: "Sincronizar Agora"
'
' Button: btnVerPendentes
'   Text: "Ver Pendentes (Debug)"
'
' ============================================================================
