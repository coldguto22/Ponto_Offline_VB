Module Module1
    Public db As New ADODB.Connection 'Variável do Banco
    Public rs As New ADODB.Recordset 'Variável da Tabela
    Public sql, diretorio, resp As String
    Public cont As Integer

    ' Ajuste aqui o servidor padrão; pode ser sobrescrito ao chamar Conecta_banco
    Public DefaultDataSource As String = "DESKTOP-BNHPJH3\SQLEXPRESS"
    Public DefaultCatalog As String = "PontoOfflineVB"

    ' Conecta ao banco; se catalog não for informado usa DefaultCatalog
    Sub Conecta_banco(Optional ByVal catalog As String = "")
        Try
            Dim targetCatalog As String = If(String.IsNullOrEmpty(catalog), DefaultCatalog, catalog)
            Dim connString As String = $"Provider=SQLOLEDB;Data Source={DefaultDataSource};Initial Catalog={targetCatalog};Trusted_Connection=yes;"
            db = CreateObject("ADODB.Connection")
            db.Open(connString)
            MsgBox("Conexão OK (" & targetCatalog & ")", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "CADASTRO")
        Catch ex As Exception
            MsgBox("Erro ao Conectar: " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "CADASTRO")
        End Try
    End Sub

    ' Sub Main para inicialização automática da conexão
    Sub Main()
        Conecta_banco()
        Application.Run(New frm_menu)
    End Sub

End Module
