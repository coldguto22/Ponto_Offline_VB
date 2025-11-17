Imports System.IO
Imports Oracle.ManagedDataAccess.Client

Public Class cad_empresa
    Dim logoPath As String = ""

    Private Sub Img_logo_Click(sender As Object, e As EventArgs) Handles img_logo.Click
        Try
            Dim ofd As New OpenFileDialog()
            ofd.Title = "Selecione o Logo da Empresa"
            ofd.Filter = "Arquivos de Imagem|*.jpg;*.jpeg;*.png;*.bmp;*.gif"
            ofd.InitialDirectory = Path.Combine(Application.StartupPath, "Logos")

            If ofd.ShowDialog() = DialogResult.OK Then
                Dim logoDir As String = Path.Combine(Application.StartupPath, "Logos")
                If Not Directory.Exists(logoDir) Then
                    Directory.CreateDirectory(logoDir)
                End If
                
                Dim nomeArquivo As String = $"{txt_cnpj.Text.Replace("/", "").Replace(".", "").Replace("-", "")}_{Path.GetFileName(ofd.FileName)}"
                Dim caminhoDestino As String = Path.Combine(logoDir, nomeArquivo)
                File.Copy(ofd.FileName, caminhoDestino, True)
                img_logo.ImageLocation = caminhoDestino
                logoPath = caminhoDestino
            End If
        Catch ex As Exception
            MsgBox($"Erro ao carregar logo: {ex.Message}", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "AVISO")
        End Try
    End Sub

    Private Function ValidarCNPJ(cnpj As String) As Boolean
        cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "")
        ' Apenas verifica se está preenchido e tem 14 dígitos
        Return Not String.IsNullOrWhiteSpace(cnpj) AndAlso cnpj.Length = 14 AndAlso IsNumeric(cnpj)
    End Function

    Private Sub Btn_concluir_Click(sender As Object, e As EventArgs) Handles btn_concluir.Click
        Try
            If String.IsNullOrWhiteSpace(txt_cnpj.Text) OrElse Not ValidarCNPJ(txt_cnpj.Text) Then
                MsgBox("Informe um CNPJ válido.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "AVISO")
                txt_cnpj.Focus()
                Exit Sub
            End If

            Dim cnpj As String = txt_cnpj.Text.Replace(".", "").Replace("-", "").Replace("/", "")
            Dim razao As String = txt_razao.Text.Replace("'", "''")
     Dim fantasia As String = txt_fantasia.Text.Replace("'", "''")
      Dim insc As String = txt_insc.Text
  Dim endereco As String = txt_endereco.Text.Replace("'", "''")
          Dim telefone As String = txt_telefone.Text
       Dim email As String = txt_email.Text
       Dim logo As String = logoPath.Replace("'", "''")

   ' Verificar se já existe
      sql = "SELECT COUNT(*) FROM tb_empresas WHERE cnpj='" & cnpj & "'"
   Dim total As Object = ExecutarEscalar(sql)

            If total IsNot Nothing AndAlso CInt(total) = 0 Then
          ' Inserir nova empresa
       sql = "INSERT INTO tb_empresas (cnpj, razao_social, nome_fantasia, insc_estadual, endereco, telefone, email, logo) " &
  "VALUES ('" & cnpj & "', '" & razao & "', '" & fantasia & "', '" & insc & "', '" & endereco & "', '" & telefone & "', '" & email & "', '" & logo & "')"
    
          If ExecutarComando(sql) Then
      Limpar_cadastro()
      img_logo.Image = Nothing
          logoPath = ""
     MsgBox("Empresa cadastrada com sucesso!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "SUCESSO")
    End If
            Else
           ' Atualizar empresa existente
                sql = "UPDATE tb_empresas SET " &
        "razao_social='" & razao & "', " &
     "nome_fantasia='" & fantasia & "', " &
  "insc_estadual='" & insc & "', " &
        "endereco='" & endereco & "', " &
  "telefone='" & telefone & "', " &
 "email='" & email & "'"
         
  If Not String.IsNullOrEmpty(logo) Then
         sql &= ", logo='" & logo & "'"
    End If
       
             sql &= " WHERE cnpj='" & cnpj & "'"
            
  If ExecutarComando(sql) Then
       Limpar_cadastro()
       img_logo.Image = Nothing
  logoPath = ""
         MsgBox("Empresa atualizada com sucesso!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "SUCESSO")
      End If
   End If

 Catch ex As Exception
    MsgBox("Erro ao Gravar! " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "AVISO")
        End Try
    End Sub

    Public Sub txt_cnpj_LostFocus(sender As Object, e As EventArgs) Handles txt_cnpj.LostFocus
        Try
            If String.IsNullOrWhiteSpace(txt_cnpj.Text) Then
   Exit Sub
     End If

            Dim cnpjLimpo As String = txt_cnpj.Text.Replace(".", "").Replace("-", "").Replace("/", "")
            sql = $"SELECT * FROM tb_empresas WHERE cnpj='{cnpjLimpo}'"
            Dim reader As OracleDataReader = ExecutarConsulta(sql)
  
            If reader IsNot Nothing AndAlso reader.Read() Then
     txt_razao.Text = If(IsDBNull(reader("razao_social")), "", reader("razao_social").ToString())
    txt_fantasia.Text = If(IsDBNull(reader("nome_fantasia")), "", reader("nome_fantasia").ToString())
     txt_insc.Text = If(IsDBNull(reader("insc_estadual")), "", reader("insc_estadual").ToString())
   txt_endereco.Text = If(IsDBNull(reader("endereco")), "", reader("endereco").ToString())
        txt_telefone.Text = If(IsDBNull(reader("telefone")), "", reader("telefone").ToString())
 txt_email.Text = If(IsDBNull(reader("email")), "", reader("email").ToString())
        
                Dim logoDb As String = If(IsDBNull(reader("logo")), "", reader("logo").ToString())
            If Not String.IsNullOrEmpty(logoDb) AndAlso File.Exists(logoDb) Then
            img_logo.ImageLocation = logoDb
       logoPath = logoDb
  Else
         img_logo.Image = Nothing
        logoPath = ""
          End If
  
 LimparDataReader(reader)
            Else
    txt_razao.Focus()
 img_logo.Image = Nothing
                logoPath = ""
                
                If reader IsNot Nothing Then
        LimparDataReader(reader)
                End If
            End If
        
        Catch ex As Exception
            MsgBox("Erro ao Consultar! " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "AVISO")
        End Try
    End Sub

    Private Sub txt_cnpj_DoubleClick(sender As Object, e As EventArgs) Handles txt_cnpj.DoubleClick
        Limpar_cadastro()
        img_logo.Image = Nothing
        logoPath = ""
    End Sub

    Private Sub txt_cnpj_TextChanged(sender As Object, e As EventArgs) Handles txt_cnpj.TextChanged

    End Sub

    Public Sub Limpar_cadastro()
        Try
     txt_cnpj.Clear()
       txt_razao.Clear()
     txt_fantasia.Clear()
txt_insc.Clear()
   txt_endereco.Clear()
            txt_telefone.Clear()
     txt_email.Clear()
            txt_cnpj.Focus()
          img_logo.Image = Nothing
          logoPath = ""
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub
End Class
