Imports System.IO

Public Class Cad_funcionario
    ' Evento para notificar cadastro concluído
    Public Event FuncionarioCadastrado()

    ' No cad_funcionario.vb
    Private Sub Img_foto_Click(sender As Object, e As EventArgs) Handles img_foto.Click
        Try
            With OpenFileDialog1
                .Title = "Selecione uma Foto"
                .Filter = "Arquivos de Imagem|*.jpg;*.jpeg;*.png;*.bmp;*.gif"
                .InitialDirectory = Path.Combine(Application.StartupPath, "Fotos")

                If .ShowDialog() = DialogResult.OK Then
                    ' Criar pasta se não existir
                    Dim fotoDir As String = Path.Combine(Application.StartupPath, "Fotos")
                    If Not Directory.Exists(fotoDir) Then
                        Directory.CreateDirectory(fotoDir)
                    End If

                    ' Copiar arquivo para pasta local
                    Dim nomeArquivo As String = $"{txt_cpf.Text.Replace(",", "").Replace(".", "").Replace("-", "")}_{Path.GetFileName(.FileName)}"
                    Dim caminhoDestino As String = Path.Combine(fotoDir, nomeArquivo)

                    File.Copy(.FileName, caminhoDestino, True)
                    img_foto.Load(caminhoDestino)
                    diretorio = caminhoDestino
                End If
            End With
        Catch ex As Exception
            MessageBox.Show($"Erro ao carregar foto: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Preencher cmb_empresa com razões sociais das empresas cadastradas
        Try
            cmb_empresa.Items.Clear()

            ' Usar a nova função segura
            sql = "SELECT razao_social FROM tb_empresas ORDER BY razao_social"
            rs = ExecutarConsulta(sql)

            If Not rs Is Nothing Then
                While Not rs.EOF
                    cmb_empresa.Items.Add(rs.Fields("razao_social").Value)
                    rs.MoveNext()
                End While
                LimparRecordset(rs)
            End If

        Catch ex As Exception
            MsgBox("Erro ao carregar empresas! " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "AVISO")
        End Try
    End Sub

    Private Sub Btn_concluir_Click(sender As Object, e As EventArgs) Handles btn_concluir.Click
        Try
            If Not ValidarCampos() Then
                Exit Sub
            End If

            Dim cpf As String = txt_cpf.Text.Replace(".", "").Replace("-", "").Replace(",", "")
            Dim nome As String = txt_nome.Text.Replace("'", "''") ' Escape aspas simples
            Dim dataAdmissao As String = cmb_admissao.Value.ToString("yyyy-MM-dd")
            Dim dataNasc As String = cmb_nasc.Value.ToString("yyyy-MM-dd")
            Dim pis As String = txt_pis.Text
            Dim empresa As String = cmb_empresa.Text.Replace("'", "''")
            Dim folha As String = txt_folha.Text
            Dim cargo As String = txt_cargo.Text.Replace("'", "''")
            Dim horario As String = cmb_horario.Text.Replace("'", "''")
            Dim dataDemissao As String = cmb_demissao.Value.ToString("yyyy-MM-dd")
            Dim fotoPath As String = If(String.IsNullOrEmpty(diretorio), "", diretorio.Replace("'", "''"))

            ' Verificar se já existe
            sql = "SELECT COUNT(*) as total FROM tb_funcionarios WHERE cpf='" & cpf & "'"
            rs = ExecutarConsulta(sql)

            If Not rs Is Nothing Then
                Dim existe As Boolean = rs.Fields("total").Value > 0
                LimparRecordset(rs)

                If Not existe Then
                    ' Inserir novo registro
                    sql = "INSERT INTO tb_funcionarios (cpf, nome, data_admissao, data_nasc, pis, empresa, folha, cargo, horario, data_demissao, foto) " &
                          "VALUES ('" & cpf & "', '" & nome & "', '" & dataAdmissao & "', '" & dataNasc & "', '" & pis & "', '" & empresa & "', '" & folha & "', '" & cargo & "', '" & horario & "', '" & dataDemissao & "', '" & fotoPath & "')"

                    If ExecutarComando(sql) Then
                        MsgBox("Funcionário cadastrado com sucesso!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "SUCESSO")
                        Limpar_cadastro()
                        RaiseEvent FuncionarioCadastrado() ' Notifica cadastro
                    End If
                Else
                    ' Atualizar registro existente
                    sql = "UPDATE tb_funcionarios SET " &
                          "nome='" & nome & "', " &
                          "data_admissao='" & dataAdmissao & "', " &
                          "data_nasc='" & dataNasc & "', " &
                          "pis='" & pis & "', " &
                          "empresa='" & empresa & "', " &
                          "folha='" & folha & "', " &
                          "cargo='" & cargo & "', " &
                          "horario='" & horario & "', " &
                          "data_demissao='" & dataDemissao & "'"

                    If Not String.IsNullOrEmpty(fotoPath) Then
                        sql &= ", foto='" & fotoPath & "'"
                    End If

                    sql &= " WHERE cpf='" & cpf & "'"

                    If ExecutarComando(sql) Then
                        MsgBox("Funcionário atualizado com sucesso!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "SUCESSO")
                        Limpar_cadastro()
                        RaiseEvent FuncionarioCadastrado() ' Notifica atualização
                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox("Erro ao processar funcionário! " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "AVISO")
        End Try
    End Sub

    Private Function ValidarCampos() As Boolean
        Dim erros As New List(Of String)

        If String.IsNullOrWhiteSpace(txt_cpf.Text) OrElse txt_cpf.Text = ",,-" Then
            erros.Add("CPF é obrigatório")
        ElseIf Not ValidarCPF(txt_cpf.Text) Then
            erros.Add("CPF inválido")
        End If

        If String.IsNullOrWhiteSpace(txt_nome.Text) Then
            erros.Add("Nome é obrigatório")
        End If

        If String.IsNullOrWhiteSpace(txt_folha.Text) Then
            erros.Add("Número da folha é obrigatório")
        End If

        If erros.Count > 0 Then
            MessageBox.Show(String.Join(Environment.NewLine, erros), "Campos Obligatórios", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Return True
    End Function

    Private Function ValidarCPF(cpf As String) As Boolean
        cpf = cpf.Replace(".", "").Replace("-", "").Replace(",", "")
        If cpf.Length <> 11 OrElse Not IsNumeric(cpf) Then Return False
        If cpf = New String(cpf(0), 11) Then Return False
        Dim soma As Integer = 0
        For i As Integer = 0 To 8
            soma += Integer.Parse(cpf(i)) * (10 - i)
        Next
        Dim resto As Integer = soma Mod 11
        Dim digito1 As Integer = If(resto < 2, 0, 11 - resto)
        soma = 0
        For i As Integer = 0 To 9
            soma += Integer.Parse(cpf(i)) * (11 - i)
        Next
        resto = soma Mod 11
        Dim digito2 As Integer = If(resto < 2, 0, 11 - resto)
        Return cpf.EndsWith(digito1.ToString() & digito2.ToString())
    End Function

    Private Sub Txt_cpf_LostFocus(sender As Object, e As EventArgs) Handles txt_cpf.LostFocus
        Try
            If String.IsNullOrWhiteSpace(txt_cpf.Text) OrElse txt_cpf.Text = ",,-" Then
                Exit Sub
            End If

            Dim cpfLimpo As String = txt_cpf.Text.Replace(".", "").Replace("-", "").Replace(",", "")
            sql = $"SELECT * FROM tb_funcionarios WHERE cpf='{cpfLimpo}'"
            rs = ExecutarConsulta(sql)

            If Not rs Is Nothing AndAlso Not rs.EOF Then
                PreencherCampos(rs)
                LimparRecordset(rs)
            Else
                txt_nome.Focus()
                If Not rs Is Nothing Then
                    LimparRecordset(rs)
                End If
            End If

        Catch ex As Exception
            MsgBox("Erro ao consultar funcionário! " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "AVISO")
        End Try
    End Sub

    Private Sub PreencherCampos(ByRef recordset As ADODB.Recordset)
        Try
            txt_nome.Text = If(IsDBNull(recordset.Fields("nome").Value), "", recordset.Fields("nome").Value)

            If Not IsDBNull(recordset.Fields("data_admissao").Value) Then
                cmb_admissao.Value = recordset.Fields("data_admissao").Value
            End If

            If Not IsDBNull(recordset.Fields("data_nasc").Value) Then
                cmb_nasc.Value = recordset.Fields("data_nasc").Value
            End If

            txt_pis.Text = If(IsDBNull(recordset.Fields("pis").Value), "", recordset.Fields("pis").Value)
            cmb_empresa.Text = If(IsDBNull(recordset.Fields("empresa").Value), "", recordset.Fields("empresa").Value)
            txt_folha.Text = If(IsDBNull(recordset.Fields("folha").Value), "", recordset.Fields("folha").Value)
            txt_cargo.Text = If(IsDBNull(recordset.Fields("cargo").Value), "", recordset.Fields("cargo").Value)
            cmb_horario.Text = If(IsDBNull(recordset.Fields("horario").Value), "", recordset.Fields("horario").Value)

            If Not IsDBNull(recordset.Fields("data_demissao").Value) Then
                cmb_demissao.Value = recordset.Fields("data_demissao").Value
            End If

            Dim fotoPath As String = If(IsDBNull(recordset.Fields("foto").Value), "", recordset.Fields("foto").Value)
            If Not String.IsNullOrEmpty(fotoPath) AndAlso File.Exists(fotoPath) Then
                img_foto.Load(fotoPath)
                diretorio = fotoPath
            End If

        Catch ex As Exception
            MsgBox("Erro ao preencher campos: " & ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "AVISO")
        End Try
    End Sub

    Private Sub Txt_cpf_DoubleClick(sender As Object, e As EventArgs) Handles txt_cpf.DoubleClick
        Limpar_cadastro()
    End Sub

    Private Sub Cmb_empresa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_empresa.SelectedIndexChanged

    End Sub

    Public Sub PreencherPorCPF(cpf As String)
        Try
            txt_cpf.Text = cpf
            ' Simular o evento LostFocus
            Txt_cpf_LostFocus(txt_cpf, EventArgs.Empty)
        Catch ex As Exception
            MsgBox("Erro ao preencher por CPF! " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "AVISO")
        End Try
    End Sub

    Public Sub Limpar_cadastro()
        Try
            txt_cpf.Clear()
            txt_nome.Clear()
            cmb_admissao.Value = Now
            cmb_nasc.Value = Now
            txt_pis.Clear()
            cmb_empresa.Text = ""
            txt_folha.Clear()
            txt_cargo.Clear()
            cmb_horario.Text = ""
            ' Deixa o campo de demissão vazio
            cmb_demissao.Format = DateTimePickerFormat.Custom
            cmb_demissao.CustomFormat = " "
            ' Carregar foto padrão
            Dim fotoDefault As String = Path.Combine(Application.StartupPath, "Fotos", "nova_foto.png")
            If File.Exists(fotoDefault) Then
                img_foto.Load(fotoDefault)
            End If

            diretorio = ""
            txt_cpf.Focus()
        Catch ex As Exception
            ' Ignorar erros ao limpar
        End Try
    End Sub

    Private Sub cmb_demissao_ValueChanged(sender As Object, e As EventArgs) Handles cmb_demissao.ValueChanged
        cmb_demissao.Format = DateTimePickerFormat.Short
        cmb_demissao.CustomFormat = "dd/MM/yyyy"
    End Sub
End Class