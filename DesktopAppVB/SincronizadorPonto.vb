Imports System.Net.Http
Imports System.Text
Imports System.Threading.Tasks
Imports System.Runtime.Serialization.Json

Public Class SincronizadorPonto
    Private Const API_URL As String = "http://localhost:8080/api"
    Private Const INTERVALO_SINCRONIZACAO As Integer = 30000 ' 30 segundos em ms

    Private cliente As HttpClient
    Private tempoUltimaSincronizacao As DateTime
    Private estaProcessando As Boolean = False

    Public Sub New()
        cliente = New HttpClient()
        cliente.DefaultRequestHeaders.Add("Accept", "application/json")
        tempoUltimaSincronizacao = DateTime.Now
    End Sub

    ''' <summary>
    ''' Verifica e sincroniza registros pendentes com a API
    ''' Chamado periodicamente por um Timer (ex: a cada 30 segundos)
    ''' </summary>
    Public Async Function SincronizarAsync() As Task
        If estaProcessando Then Return

        estaProcessando = True
        Try
            ' Verifica se há conexão com a API
            If Not Await TemConexaoComAPI() Then
                ' Sem conexão, aguarda próxima tentativa
                estaProcessando = False
                Exit Function
            End If

            ' Busca registros pendentes (não sincronizados)
            Dim registrosPendentes = BuscarRegistrosPendentes()

            For Each registro In registrosPendentes
                Dim sucesso = Await EnviarRegistroParaAPI(registro)
                
                If sucesso Then
                    MarcarComoSincronizado(registro.id)
                Else
                    MarcarComErro(registro.id, "Erro ao sincronizar com a API")
                End If
            Next

        Catch ex As Exception
            ' Log de erro (opcional)
            ' LogarErro("Erro na sincronização: " & ex.Message)
        Finally
            estaProcessando = False
            tempoUltimaSincronizacao = DateTime.Now
        End Try
    End Function

    ''' <summary>
    ''' Verifica se há conexão com a API (ping simples)
    ''' </summary>
    Private Async Function TemConexaoComAPI() As Task(Of Boolean)
        Try
            Dim response = Await cliente.GetAsync(API_URL & "/funcionarios?limit=1")
            Return response.IsSuccessStatusCode
        Catch
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Busca registros pendentes no banco local
    ''' </summary>
    Private Function BuscarRegistrosPendentes() As List(Of RegistroPontoPending)
        Dim registros As New List(Of RegistroPontoPending)
        Try
            Dim sql = "SELECT id, funcionario_id, data, hora, tipo, latitude, longitude " &
                      "FROM tb_registros_ponto_pending WHERE sincronizado = 0"

            Using rs = ExecutarConsulta(sql)
                While Not rs.EOF
                    Dim registro As New RegistroPontoPending With {
                        .id = rs("id"),
                        .funcionario_id = rs("funcionario_id"),
                        .data = rs("data"),
                        .hora = rs("hora"),
                        .tipo = rs("tipo"),
                        .latitude = If(IsDBNull(rs("latitude")), Nothing, CDbl(rs("latitude"))),
                        .longitude = If(IsDBNull(rs("longitude")), Nothing, CDbl(rs("longitude")))
                    }
                    registros.Add(registro)
                    rs.MoveNext()
                End While
            End Using
        Catch ex As Exception
            ' Log de erro
        End Try
        Return registros
    End Function

    ''' <summary>
    ''' Envia um registro para a API
    ''' </summary>
    Private Async Function EnviarRegistroParaAPI(registro As RegistroPontoPending) As Task(Of Boolean)
        Try
            Dim json = New StringBuilder()
            json.AppendLine("{")
            json.AppendLine("""funcionario"": { ""id"": " & registro.funcionario_id & " },")
            json.AppendLine("""data"": """ & registro.data.ToString("yyyy-MM-dd") & """,")
            json.AppendLine("""hora"": """ & registro.hora.ToString("HH:mm:ss") & """,")
            json.AppendLine("""tipo"": """ & registro.tipo & """")

            If registro.latitude.HasValue Then
                json.AppendLine(", ""latitude"": " & registro.latitude)
            End If

            If registro.longitude.HasValue Then
                json.AppendLine(", ""longitude"": " & registro.longitude)
            End If

            json.AppendLine("}")

            Dim content = New StringContent(json.ToString(), Encoding.UTF8, "application/json")
            Dim response = Await cliente.PostAsync(API_URL & "/registros", content)

            Return response.IsSuccessStatusCode
        Catch
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Marca um registro como sincronizado
    ''' </summary>
    Private Sub MarcarComoSincronizado(id As Long)
        Try
            Dim sql = "UPDATE tb_registros_ponto_pending SET sincronizado = 1 WHERE id = " & id
            ExecutarComando(sql)
        Catch
        End Try
    End Sub

    ''' <summary>
    ''' Marca um registro com erro de sincronização
    ''' </summary>
    Private Sub MarcarComErro(id As Long, erro As String)
        Try
            Dim sql = "UPDATE tb_registros_ponto_pending SET erro_sincronizacao = '" & _
                      erro.Replace("'", "''") & "' WHERE id = " & id
            ExecutarComando(sql)
        Catch
        End Try
    End Sub

    ''' <summary>
    ''' Registra um ponto localmente (offline)
    ''' </summary>
    Public Function RegistrarPontoLocal(funcionarioId As Long, tipo As String, _
                                        latitude As Double?, longitude As Double?) As Boolean
        Try
            Dim sql = "INSERT INTO tb_registros_ponto_pending (funcionario_id, data, hora, tipo, latitude, longitude, sincronizado) " &
                      "VALUES (" & funcionarioId & ", '" & DateTime.Now.ToString("yyyy-MM-dd") & "', '" & _
                      DateTime.Now.ToString("HH:mm:ss") & "', '" & tipo & "'"

            If latitude.HasValue Then
                sql &= ", " & latitude
            Else
                sql &= ", NULL"
            End If

            If longitude.HasValue Then
                sql &= ", " & longitude
            Else
                sql &= ", NULL"
            End If

            sql &= ", 0)"

            ExecutarComando(sql)
            Return True
        Catch ex As Exception
            ' Log de erro
            Return False
        End Try
    End Function
End Class

''' <summary>
''' Classe auxiliar para representar um registro pendente
''' </summary>
Public Class RegistroPontoPending
    Public Property id As Long
    Public Property funcionario_id As Long
    Public Property data As Date
    Public Property hora As TimeSpan
    Public Property tipo As String
    Public Property latitude As Double?
    Public Property longitude As Double?
End Class
