Imports ADODB
Imports System.Data.SqlClient
Imports System.IO
Imports DevComponents.DotNetBar
Imports System.Threading
Public Class frmLogin

    Public cn As New ADODB.Connection
    Public rs As New ADODB.Recordset
    Dim CaminhoBanco = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "bdDados.mdf")
    Dim StringConexao = String.Format("Server=(localdb)\mssqllocaldb; Integrated Security=true; Application Name=#" & Environment.UserName & "; AttachDbFileName={0} ; User ID=sysdba;Password=masterkey", CaminhoBanco)
    Public conn = New System.Data.SqlClient.SqlConnection(StringConexao)
    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'MsgBox(StringConexao)
        ModuloGeral.infoReader = My.Computer.FileSystem.GetFileInfo(My.Application.Info.DirectoryPath & "\SolutionsElza.exe")
        lblVersao.Text = My.Application.Info.CompanyName & " - " & String.Format("Versão {0}", My.Application.Info.Version.ToString) & " - " & ModuloGeral.infoReader.LastWriteTime
        ModuloGeral.StringConexaoGERAL = StringConexao
    End Sub

    Private Sub btnSair_Click(sender As Object, e As EventArgs) Handles btnSair.Click
        Me.Close()
        'CONECTAR()

    End Sub

    Private Sub btnEntrar_Click(sender As Object, e As EventArgs) Handles btnEntrar.Click
        'Using Conn = New System.Data.SqlClient.SqlConnection(StringConexao)
        If conn.State = System.Data.ConnectionState.Closed Then
            conn.Open()
        End If


        If conn.State = System.Data.ConnectionState.Open Then
            Using Comm = New System.Data.SqlClient.SqlCommand()
                Comm.Connection = conn
                Comm.CommandText = "SELECT RTRIM(US.ID)ID,RTRIM(US.USUARIO)USUARIO,RTRIM(US.NOME)NOME,RTRIM(GR.GRUPO)GRUPO,GR.NIVEL FROM USUARIOS US INNER JOIN GRUPOS GR ON GR.Id=US.ID_GRUPO AND GR.ESTATUS='A' WHERE US.USUARIO='" & txtUsuario.Text & "' AND US.SENHA='" & txtSenha.Text & "' AND US.ESTATUS='A'"
                '"SELECT ID,USUARIO,NOME FROM DBO.USUARIOS WHERE USUARIO='" & txtUsuario.Text & "' AND SENHA='" & txtSenha.Text & "' AND ESTATUS='A' "
                Using Reader = Comm.ExecuteReader()
                    If Reader.HasRows = True Then
                        While Reader.Read()
                            MOD_ID_USER = Reader("Id")
                            MOD_USUARIO = Reader("USUARIO")
                            MOD_NOME_USER = Reader("NOME")
                            MOD_GRUPO = Reader("GRUPO")
                            MOD_NIVEL = Reader("NIVEL")
                        End While

                        frmPrincipal.Show()
                        'ABRIR()
                        Me.Visible = False
                        PING_DATA()
                    Else
                        MessageBoxEx.Show("Usuário ou Senha Incorretos, favor verificar os dados Informados. " & vbLf & "Has null: " & Reader.HasRows, "Solution's Bom PAstor", MessageBoxButtons.OK)
                        txtSenha.Focus()
                        txtSenha.SelectAll()
                    End If
                    'EXIBE RESULTADOS POR LINHA
                    'While Reader.Read()
                    '    'Console.WriteLine("ID: {0}, Nome: {1}, Sobrenome: {2}", Reader("Id"), Reader("Nome"), Reader("Sobrenome"))
                    '    MsgBox("ID: " & Reader("Id") & vbLf & "USUARIO: " & Reader("USUARIO") & vbLf & "NOME: " & Reader("NOME"))
                    'End While
                End Using
            End Using


        End If
        'Conn.Close()
        'End Using
    End Sub

    ''==================================================================================================================
    ''===== TESTE PARA APLICAÇÃO MULT-TREADS
    'Public Sub Task_A()
    '    Dim A As DevComponents.DotNetBar.Metro.MetroForm
    '    A = New frmBuild() ' Must be created on this thread!
    '    'A.MdiParent = Me
    '    Application.Run(A)
    '    'Application.
    'End Sub

    'Public Sub FECHAR()
    '    frmBuild.BeginInvoke(New Action(Sub() frmBuild.Close()))
    'End Sub
    ''frmBuild.BeginInvoke(New Action(Sub() frmBuild.Close()))
    'Public Sub ABRIR()
    '    Dim th As System.Threading.Thread = New Threading.Thread(AddressOf Task_A)
    '    th.SetApartmentState(ApartmentState.STA)
    '    th.Start()
    'End Sub
    ''====
    ''===============================================================================================================

    Function Query(text As String)
        If conn.State = System.Data.ConnectionState.Open Then
            MsgBox("Aberto")

        Else
            MsgBox("Fechado")
            conn.Open()
            Using Comm = New System.Data.SqlClient.SqlCommand()
                Comm.Connection = conn
                Comm.CommandText = "SELECT US.ID,US.USUARIO,US.NOME,GR.GRUPO,GR.NIVEL FROM USUARIOS US INNER JOIN GRUPOS GR ON GR.Id=US.ID_GRUPO AND GR.ESTATUS='A' WHERE US.USUARIO='" & txtUsuario.Text & "' AND US.SENHA='" & txtSenha.Text & "' AND US.ESTATUS='A'"
                '"SELECT ID,USUARIO,NOME FROM DBO.USUARIOS WHERE USUARIO='" & txtUsuario.Text & "' AND SENHA='" & txtSenha.Text & "' AND ESTATUS='A' "
                Using Reader = Comm.ExecuteReader()
                    If Reader.HasRows = True Then
                        Return Reader
                    Else
                        MsgBox("Não há resultados para a query informada. " & vbLf & "Has null: " & Reader.HasRows)
                    End If
                    'EXIBE RESULTADOS POR LINHA
                    'While Reader.Read()
                    '    'Console.WriteLine("ID: {0}, Nome: {1}, Sobrenome: {2}", Reader("Id"), Reader("Nome"), Reader("Sobrenome"))
                    '    MsgBox("ID: " & Reader("Id") & vbLf & "USUARIO: " & Reader("USUARIO") & vbLf & "NOME: " & Reader("NOME"))
                    'End While

                End Using

            End Using
        End If
        'Return
    End Function
    Public Sub CONECTAR()

        If conn.State = System.Data.ConnectionState.Open Then
            MsgBox("Aberto")
            conn.Close()

        Else
            MsgBox("Fechado")
            conn.Open()

        End If




        'cn.Open(cndbix)
        'rs.Open("SELECT ID,USUARIO,NOME FROM DBO.USUARIOS WHERE USUARIO='" & txtUsuario.Text & "' AND SENHA='" & txtSenha.Text & "' ", cn)
        'If rs.BOF And rs.EOF Then
        '    MsgBox("NÃO FOI ENCONTRADO REGISTROS PARA OS DADOS INFORMADOS!")
        'Else
        '    MsgBox("ID: " & rs.Fields(0).Value & vbLf & "USUARIO: " & rs.Fields(1).Value)
        'End If
        'rs.Close()
        'cn.Close()
    End Sub




End Class