Module Module1
    Public db As New ADODB.Connection 'Variável do Banco
    Public rs As New ADODB.Recordset 'Variável da Tabela
    Public sql, diretorio, resp As String
    Public cont As Integer

    ' Ajuste aqui o servidor padrão; pode ser sobrescrito ao chamar Conecta_banco
    Public DefaultDataSource As String = "DESKTOP-BNHPJH3\SQLEXPRESS"
    Public DefaultCatalog As String = "PontoOfflineVB"

    ' Função para verificar se a conexão está aberta
    Public Function ConexaoAberta() As Boolean
        Try
            If db Is Nothing Then Return False
            Return db.State = ADODB.ObjectStateEnum.adStateOpen
        Catch
            Return False
        End Try
    End Function

    ' Conecta ao banco; se catalog não for informado usa DefaultCatalog
    Sub Conecta_banco(Optional ByVal catalog As String = "")
        Try
            ' Fechar conexão anterior se existir
            If Not db Is Nothing AndAlso ConexaoAberta() Then
                db.Close()
            End If

            Dim targetCatalog As String = If(String.IsNullOrEmpty(catalog), DefaultCatalog, catalog)
            Dim connString As String = $"Provider=SQLOLEDB;Data Source={DefaultDataSource};Initial Catalog={targetCatalog};Trusted_Connection=yes;Connection Timeout=30;"

            ' Criar nova instância se necessário
            If db Is Nothing Then
                db = CreateObject("ADODB.Connection")
            End If

            db.Open(connString)

            ' Testar a conexão
            If ConexaoAberta() Then
                MsgBox("Conexão OK (" & targetCatalog & ")", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "CADASTRO")
            Else
                Throw New Exception("Falha ao estabelecer conexão")
            End If

        Catch ex As Exception
            MsgBox("Erro ao Conectar: " & ex.Message & vbCrLf & vbCrLf &
                   "Verifique se:" & vbCrLf &
                   "1. O SQL Server está rodando" & vbCrLf &
                   "2. O nome do servidor está correto: " & DefaultDataSource & vbCrLf &
                   "3. O banco de dados existe: " & DefaultCatalog,
                   MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERRO DE CONEXÃO")
        End Try
    End Sub

    ' Função para executar consultas SELECT de forma segura
    Public Function ExecutarConsulta(ByVal sqlQuery As String) As ADODB.Recordset
        Try
            ' Verificar se a conexão está aberta
            If Not ConexaoAberta() Then
                Conecta_banco()
            End If

            ' Criar novo recordset
            Dim rsTemp As New ADODB.Recordset
            rsTemp.Open(sqlQuery, db, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

            Return rsTemp

        Catch ex As Exception
            MsgBox("Erro ao executar consulta: " & ex.Message & vbCrLf & "SQL: " & sqlQuery,
                   MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERRO")
            Return Nothing
        End Try
    End Function

    ' Função para executar comandos INSERT/UPDATE/DELETE de forma segura
    Public Function ExecutarComando(ByVal sqlCommand As String) As Boolean
        Try
            ' Verificar se a conexão está aberta
            If Not ConexaoAberta() Then
                Conecta_banco()
            End If

            db.Execute(sqlCommand)
            Return True

        Catch ex As Exception
            MsgBox("Erro ao executar comando: " & ex.Message & vbCrLf & "SQL: " & sqlCommand,
                   MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERRO")
            Return False
        End Try
    End Function

    ' Função para limpar recursos do recordset
    Public Sub LimparRecordset(ByRef recordset As ADODB.Recordset)
        Try
            If Not recordset Is Nothing Then
                If recordset.State = ADODB.ObjectStateEnum.adStateOpen Then
                    recordset.Close()
                End If
                recordset = Nothing
            End If
        Catch ex As Exception
            ' Ignorar erros ao limpar
        End Try
    End Sub

    ' Sub Main para inicialização automática da conexão
    Sub Main()
        Try
            Conecta_banco()
            Application.Run(New frm_menu)
        Catch ex As Exception
            MsgBox("Erro na inicialização: " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERRO CRÍTICO")
            Application.Exit()
        End Try
    End Sub

End Module