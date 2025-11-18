Imports System.IO
Imports Oracle.ManagedDataAccess.Client

Public Class Cad_funcionario
    ' Evento para notificar cadastro concluído
    Public Event FuncionarioCadastrado()

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
        ' Preencher cmb_empresa com razões sociais das empresas cadastradas - TABELA: EMPRESA
        Try
            cmb_empresa.Items.Clear()

            ' Usar a nova função segura Oracle - TABELA: EMPRESA, COLUNA: RAZAO_SOCIAL
            sql = "SELECT RAZAO_SOCIAL FROM EMPRESA ORDER BY RAZAO_SOCIAL"
            Dim reader As OracleDataReader = ExecutarConsulta(sql)

            If reader IsNot Nothing Then
                While reader.Read()
                    cmb_empresa.Items.Add(reader("RAZAO_SOCIAL").ToString())
                End While
                LimparDataReader(reader)
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
            Dim nome As String = txt_nome.Text.Replace("'", "''")
            Dim dataAdmissao As String = cmb_admissao.Value.ToString("dd/MM/yyyy")
            Dim dataNasc As String = cmb_nasc.Value.ToString("dd/MM/yyyy")
            Dim pis As String = txt_pis.Text
            ' NOTA: Buscar EMPRESA_ID pela RAZAO_SOCIAL selecionada
            Dim empresaNome As String = cmb_empresa.Text.Replace("'", "''")
            Dim folha As String = txt_folha.Text
            Dim cargo As String = txt_cargo.Text.Replace("'", "''")
            Dim horario As String = cmb_horario.Text.Replace("'", "''")
            Dim dataDemissao As String = If(cmb_demissao.Value = cmb_admissao.Value, "", cmb_demissao.Value.ToString("dd/MM/yyyy"))
            Dim fotoPath As String = If(String.IsNullOrEmpty(diretorio), "", diretorio.Replace("'", "''"))
            Dim adminValue As Integer = If(chk_admin.Checked, 1, 0)

            ' Buscar EMPRESA_ID pela RAZAO_SOCIAL
            Dim empresaId As Object = Nothing
            If Not String.IsNullOrEmpty(empresaNome) Then
                sql = "SELECT ID FROM EMPRESA WHERE RAZAO_SOCIAL='" & empresaNome & "'"
                empresaId = ExecutarEscalar(sql)
            End If

            ' Verificar se já existe - TABELA: FUNCIONARIO
            sql = "SELECT COUNT(*) FROM FUNCIONARIO WHERE CPF='" & cpf & "'"
            Dim total As Object = ExecutarEscalar(sql)

            If total IsNot Nothing Then
                Dim existe As Boolean = CInt(total) > 0

                If Not existe Then
                    ' Inserir novo registro - TABELA: FUNCIONARIO
                    ' COLUNAS: CPF, NOME, DATA_ADMISSAO, DATA_NASCIMENTO, PIS, EMPRESA_ID, FOLHA, CARGO, HORARIO, DATA_DEMISSAO, FOTO, ADMIN
                    sql = "INSERT INTO FUNCIONARIO (CPF, NOME, DATA_ADMISSAO, DATA_NASCIMENTO, PIS, EMPRESA_ID, FOLHA, CARGO, HORARIO"

                    If Not String.IsNullOrEmpty(dataDemissao) Then
                        sql &= ", DATA_DEMISSAO"
                    End If

                    sql &= ", FOTO, ADMIN) VALUES ('" & cpf & "', '" & nome & "', TO_DATE('" & dataAdmissao & "', 'DD/MM/YYYY'), TO_DATE('" & dataNasc & "', 'DD/MM/YYYY'), '" & pis & "', "

                    If empresaId IsNot Nothing Then
                        sql &= empresaId.ToString()
                    Else
                        sql &= "NULL"
                    End If

                    sql &= ", '" & folha & "', '" & cargo & "', '" & horario & "'"

                    If Not String.IsNullOrEmpty(dataDemissao) Then
                        sql &= ", TO_DATE('" & dataDemissao & "', 'DD/MM/YYYY')"
                    End If

                    sql &= ", '" & fotoPath & "', " & adminValue & ")"

                    If ExecutarComando(sql) Then
                        MsgBox("Funcionário cadastrado com sucesso!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "SUCESSO")
                        Limpar_cadastro()
                        RaiseEvent FuncionarioCadastrado()
                    End If
                Else
                    ' Atualizar registro existente
                    sql = "UPDATE FUNCIONARIO SET " &
    "NOME='" & nome & "', " &
           "DATA_ADMISSAO=TO_DATE('" & dataAdmissao & "', 'DD/MM/YYYY'), " &
    "DATA_NASCIMENTO=TO_DATE('" & dataNasc & "', 'DD/MM/YYYY'), " &
 "PIS='" & pis & "', " &
         "EMPRESA_ID=" & If(empresaId IsNot Nothing, empresaId.ToString(), "NULL") & ", " &
    "FOLHA='" & folha & "', " &
         "CARGO='" & cargo & "', " &
      "HORARIO='" & horario & "', " &
      "ADMIN=" & adminValue

                    If Not String.IsNullOrEmpty(dataDemissao) Then
                        sql &= ", DATA_DEMISSAO=TO_DATE('" & dataDemissao & "', 'DD/MM/YYYY')"
                    End If

                    If Not String.IsNullOrEmpty(fotoPath) Then
                        sql &= ", FOTO='" & fotoPath & "'"
                    End If

                    sql &= " WHERE CPF='" & cpf & "'"

                    If ExecutarComando(sql) Then
                        MsgBox("Funcionario atualizado com sucesso!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "SUCESSO")
                        Limpar_cadastro()
                        RaiseEvent FuncionarioCadastrado()
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
            MessageBox.Show(String.Join(Environment.NewLine, erros), "Campos Obrigatórios", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
        ' TABELA: FUNCIONARIO, JOIN com EMPRESA para pegar RAZAO_SOCIAL
            sql = "SELECT F.*, E.RAZAO_SOCIAL FROM FUNCIONARIO F LEFT JOIN EMPRESA E ON F.EMPRESA_ID = E.ID WHERE F.CPF='" & cpfLimpo & "'"
      Dim reader As OracleDataReader = ExecutarConsulta(sql)

            If reader IsNot Nothing AndAlso reader.Read() Then
      PreencherCampos(reader)
          
   ' Bloquear edição do CPF quando em modo de atualização
                txt_cpf.ReadOnly = True
        txt_cpf.BackColor = Color.LightGray

          LimparDataReader(reader)
            Else
                txt_nome.Focus()
                
        ' Permitir edição do CPF para novo cadastro
      txt_cpf.ReadOnly = False
       txt_cpf.BackColor = Color.White
        
    If reader IsNot Nothing Then
              LimparDataReader(reader)
         End If
 End If

        Catch ex As Exception
     MsgBox("Erro ao consultar funcionário! " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "AVISO")
      End Try
    End Sub

    Private Sub PreencherCampos(ByVal reader As OracleDataReader)
      Try
      txt_nome.Text = If(IsDBNull(reader("NOME")), "", reader("NOME").ToString())

     If Not IsDBNull(reader("DATA_ADMISSAO")) Then
            cmb_admissao.Value = Convert.ToDateTime(reader("DATA_ADMISSAO"))
        End If

       If Not IsDBNull(reader("DATA_NASCIMENTO")) Then
          cmb_nasc.Value = Convert.ToDateTime(reader("DATA_NASCIMENTO"))
 End If

       txt_pis.Text = If(IsDBNull(reader("PIS")), "", reader("PIS").ToString())
     ' Usar RAZAO_SOCIAL do JOIN
      cmb_empresa.Text = If(IsDBNull(reader("RAZAO_SOCIAL")), "", reader("RAZAO_SOCIAL").ToString())
            txt_folha.Text = If(IsDBNull(reader("FOLHA")), "", reader("FOLHA").ToString())
       txt_cargo.Text = If(IsDBNull(reader("CARGO")), "", reader("CARGO").ToString())
  cmb_horario.Text = If(IsDBNull(reader("HORARIO")), "", reader("HORARIO").ToString())

            If Not IsDBNull(reader("DATA_DEMISSAO")) Then
         cmb_demissao.Value = Convert.ToDateTime(reader("DATA_DEMISSAO"))
            End If
            
      ' Verificar se existe campo ADMIN no reader
     If Not IsDBNull(reader("ADMIN")) Then
                chk_admin.Checked = (CInt(reader("ADMIN")) = 1)
            End If

            Dim fotoPath As String = If(IsDBNull(reader("FOTO")), "", reader("FOTO").ToString())
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
        
        ' Reabilitar edição do CPF
        txt_cpf.ReadOnly = False
        txt_cpf.BackColor = Color.White
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
     chk_admin.Checked = False
            ' Deixa o campo de demissão vazio
 cmb_demissao.Format = DateTimePickerFormat.Custom
 cmb_demissao.CustomFormat = " "
   ' Carregar foto padrão
            Dim fotoDefault As String = Path.Combine(Application.StartupPath, "Fotos", "nova_foto.png")
     If File.Exists(fotoDefault) Then
      img_foto.Load(fotoDefault)
            End If

   diretorio = ""

     ' Reabilitar edição do CPF
            txt_cpf.ReadOnly = False
   txt_cpf.BackColor = Color.White

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