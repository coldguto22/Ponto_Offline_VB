Module Module1
    Public db As New ADODB.Connection 'Variável do Banco
    Public rs As New ADODB.Recordset 'Variável da Tabela
    Public sql, diretorio, resp As String
    Public cont As Integer

    ' Ajuste aqui o servidor padrão; pode ser sobrescrito ao chamar Conecta_banco
    Public DefaultDataSource As String = "DESKTOP-BNHPJH3\SQLEXPRESS"
    Public DefaultCatalog As String = "PontoOfflineVB"

    ' Carregar campos para o combo (comentado pois o controle pode não existir)
    'Sub carregar_campos()
    '    Try
    '        With Form1.cmb_campo.Items
    '            .Clear()
    '            .Add("CPF")
    '            .Add("NOME")
    '        End With
    '        Form1.cmb_campo.SelectedIndex = 1
    '    Catch ex As Exception
    '        Exit Sub
    '    End Try
    'End Sub


    ' Nova rotina para carregar funcionários (usa o mesmo DataGridView do Form1)
    'Sub Carregar_funcionarios()
    '    Try
    '        ' Adapte para o controle de grid que você utiliza, ex: dgv_funcionarios
    '        ' Aqui está um exemplo para um DataGridView chamado dgv_funcionarios
    '        With Form1.dgv_funcionarios 'Descomente e ajuste se o DataGridView existir
    '            sql = "select * from tb_funcionarios order by nome asc"
    '            rs = db.Execute(sql)
    '            cont = 0
    '            .Rows.Clear()
    '            Do While rs.EOF = False
    '                cont = cont + 1
    '                .Rows.Add(cont, rs.Fields("cpf").Value, rs.Fields("nome").Value, rs.Fields("data_admissao").Value, rs.Fields("data_nasc").Value, rs.Fields("pis").Value, rs.Fields("empresa").Value, rs.Fields("folha").Value, rs.Fields("cargo").Value, rs.Fields("horario").Value, rs.Fields("data_demissao").Value, rs.Fields("foto").Value)
    '                rs.MoveNext()
    '            Loop
    '        End With
    '    Catch ex As Exception
    '        Exit Sub
    '    End Try
    'End Sub

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

    Sub Limpar_cadastro()
        Try
            With cad_funcionario
                .txt_cpf.Clear()
                .txt_nome.Clear()
                .cmb_admissao.Value = Now
                .cmb_nasc.Value = Now
                .txt_pis.Clear()
                .cmb_empresa.Text = ""
                .txt_folha.Clear()
                .txt_cargo.Clear()
                .cmb_horario.Text = ""
                .cmb_demissao.Value = Now
                .img_foto.Load(Application.StartupPath & "\Fotos\nova_foto.png")
                .txt_cpf.Focus()
            End With
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

End Module
