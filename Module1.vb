Module Module1
    Public db As New ADODB.Connection 'Variável do Banco
    Public rs As New ADODB.Recordset 'Variável da Tabela
    Public sql, diretorio, resp As String
    Public cont As Integer
    Public audio As Object

    Sub carregar_voz()
        audio = CreateObject("SAPI.SPVOICE")
        audio.volume = 100
        audio.rate = 2 'Velocidade de reprodução da fala
    End Sub

    Sub carregar_campos()
        Try
            With Form1.cmb_campo.Items
                .Add("CPF")
                .Add("NOME")
            End With
            Form1.cmb_campo.SelectedIndex = 1
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub


    Sub Carregar_dados()
        Try
            With Form1.dgv_dados
                sql = $"select * from tb_clientes order by nome asc"
                rs = db.Execute(sql)
                cont = 0
                .Rows.Clear()
                Do While rs.EOF = False
                    cont = cont + 1
                    .Rows.Add(cont, rs.Fields(1).Value, rs.Fields(2).Value, Nothing, Nothing)
                    rs.MoveNext()
                Loop
            End With
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub


    Sub Conecta_banco()
        Try
            db = CreateObject("ADODB.Connection")
            db.Open("Provider=SQLOLEDB;Data Source=LAB5-PROF;Initial Catalog=cad_clientes_3dsm252s;trusted_connection=yes;")
            MsgBox("Conexão OK", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "CADASTRO DE CLIENTES")
        Catch ex As Exception
            MsgBox("Erro ao Conectar", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "CADASTRO DE CLIENTES")
        End Try
    End Sub

    Sub Limpar_cadastro()
        Try
            With Form1
                .txt_cpf.Clear()
                .txt_nome.Clear()
                .cmb_data.Value = Now
                .txt_fone.Clear()
                .txt_email.Clear()
                .img_foto.Load(Application.StartupPath & "\Fotos\nova_foto.png")
                .txt_cpf.Focus()

            End With
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

End Module
