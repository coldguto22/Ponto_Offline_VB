Imports Oracle.ManagedDataAccess.Client
Imports System.Configuration

Module Module1
    Public db As OracleConnection ' Conexão Oracle
    Public sql, diretorio, resp As String
    Public cont As Integer

    ' 🔒 Configurações agora são lidas do App.config (seguro!)
    Private ReadOnly Property OracleDataSource As String
        Get
            Return ConfigurationManager.AppSettings("OracleDataSource")
        End Get
    End Property

    Private ReadOnly Property OracleUser As String
        Get
            Return ConfigurationManager.AppSettings("OracleUser")
        End Get
    End Property

    Private ReadOnly Property OraclePassword As String
        Get
            Return ConfigurationManager.AppSettings("OraclePassword")
        End Get
    End Property

    Private ReadOnly Property OraclePort As String
        Get
            Return ConfigurationManager.AppSettings("OraclePort")
        End Get
    End Property

    Private ReadOnly Property OracleConnectionType As String
        Get
            Return ConfigurationManager.AppSettings("OracleConnectionType")
        End Get
    End Property

    Private ReadOnly Property OracleHost As String
        Get
            Return ConfigurationManager.AppSettings("OracleHost")
        End Get
    End Property

    Private ReadOnly Property OracleServiceName As String
        Get
            Return ConfigurationManager.AppSettings("OracleServiceName")
        End Get
    End Property

    Private ReadOnly Property OracleWalletLocation As String
        Get
            Return ConfigurationManager.AppSettings("OracleWalletLocation")
        End Get
    End Property

    Private ReadOnly Property OracleTnsAdmin As String
        Get
            Return ConfigurationManager.AppSettings("OracleTnsAdmin")
        End Get
    End Property

    ' Função para verificar se a conexão está aberta
    Public Function ConexaoAberta() As Boolean
        Try
            If db Is Nothing Then Return False
            Return db.State = ConnectionState.Open
        Catch
            Return False
        End Try
    End Function

    ' Conecta ao banco Oracle
    Sub Conecta_banco()
        Try
            ' Fechar conexão anterior se existir
            If Not db Is Nothing AndAlso ConexaoAberta() Then
                db.Close()
                db.Dispose()
            End If

            ' Montar Connection String baseada no tipo
            Dim connString As String = ""

            If OracleConnectionType = "CLOUD" Then
                ' 🌐 Oracle Cloud Autonomous Database com Wallet
                connString = $"User Id={OracleUser};Password={OraclePassword};Data Source={OracleDataSource};TNS_ADMIN={OracleTnsAdmin};Wallet_Location={OracleWalletLocation}"

            ElseIf OracleConnectionType = "TNS" Then
                ' Opção 1: Usar TNS (recomendado para Oracle local)
                connString = $"Data Source={OracleDataSource};User Id={OracleUser};Password={OraclePassword};"

            Else
                ' Opção 2: Conexão direta (sem TNS)
                connString = $"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={OracleHost})(PORT={OraclePort}))(CONNECT_DATA=(SERVICE_NAME={OracleServiceName})));User Id={OracleUser};Password={OraclePassword};"
            End If

            db = New OracleConnection(connString)
            db.Open()

            ' Testar a conexão
            If ConexaoAberta() Then
                MsgBox("Conexão OK - Oracle Cloud (" & OracleDataSource & ")", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "CADASTRO")
            Else
                Throw New Exception("Falha ao estabelecer conexão")
            End If

        Catch ex As Exception
            MsgBox("Erro ao Conectar: " & ex.Message & vbCrLf & vbCrLf &
      "Verifique se:" & vbCrLf &
   "1. O Oracle Cloud está acessível" & vbCrLf &
           "2. As configurações em App.config estão corretas" & vbCrLf &
  "3. O Wallet está no caminho: " & OracleWalletLocation & vbCrLf &
             "4. Usuário: " & OracleUser & vbCrLf &
     "5. Data Source: " & OracleDataSource & vbCrLf &
          "6. ODP.NET está instalado",
    MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERRO DE CONEXÃO")
        End Try
    End Sub

    ' Função para executar consultas SELECT de forma segura
    Public Function ExecutarConsulta(ByVal sqlQuery As String) As OracleDataReader
        Try
            ' Verificar se a conexão está aberta
            If Not ConexaoAberta() Then
                Conecta_banco()
            End If

            ' Criar comando
            Dim cmd As New OracleCommand(sqlQuery, db)
            cmd.CommandTimeout = 30

            ' Executar e retornar DataReader
            Return cmd.ExecuteReader()

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

            Dim cmd As New OracleCommand(sqlCommand, db)
            cmd.CommandTimeout = 30
            cmd.ExecuteNonQuery()

            Return True

        Catch ex As Exception
            MsgBox("Erro ao executar comando: " & ex.Message & vbCrLf & "SQL: " & sqlCommand,
  MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERRO")
            Return False
        End Try
    End Function

    ' Função para executar comandos e retornar resultado (ex: COUNT)
    Public Function ExecutarEscalar(ByVal sqlCommand As String) As Object
        Try
            ' Verificar se a conexão está aberta
            If Not ConexaoAberta() Then
                Conecta_banco()
            End If

            Dim cmd As New OracleCommand(sqlCommand, db)
            cmd.CommandTimeout = 30

            Return cmd.ExecuteScalar()

        Catch ex As Exception
            MsgBox("Erro ao executar comando escalar: " & ex.Message & vbCrLf & "SQL: " & sqlCommand,
MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERRO")
            Return Nothing
        End Try
    End Function

    ' Função para fechar DataReader
    Public Sub LimparDataReader(ByRef reader As OracleDataReader)
        Try
            If Not reader Is Nothing Then
                If Not reader.IsClosed Then
                    reader.Close()
                End If
                reader.Dispose()
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