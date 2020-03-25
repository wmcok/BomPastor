Imports System.Data.SqlClient
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls

Module ModuloGeral
    Public infoReader As System.IO.FileInfo
    Public StringConexaoGERAL As String
    Public MOD_ID_USER As Integer
    Public MOD_USUARIO As String
    Public MOD_NOME_USER As String
    Public MOD_GRUPO As String
    Public MOD_NIVEL As Integer
    Public MOD_ESTATUS_SRVDATA As Boolean = False


    Public Sub MenuPrincipal()
        If frmPrincipal.MetroTilePanel1.Visible = False Then
            frmPrincipal.MetroTilePanel1.Visible = True
        ElseIf frmPrincipal.MetroTilePanel1.Visible = True Then
            frmPrincipal.MetroTilePanel1.Visible = False
        End If
    End Sub


    Public Function PING_DATA()
        Try
            If My.Computer.Network.Ping("192.168.0.225", 100) Then
                MOD_ESTATUS_SRVDATA = True
                frmPrincipal.statusDATA2.BackColor = Color.Green
                frmPrincipal.statusDATA2.Text = "    Data ON    "
                'frmPrincipal.statusDATA2.BackColor = Color.Green
                frmPrincipal.MenuStrip1.Refresh()
                Return True
            Else
                frmPrincipal.statusDATA2.BackColor = Color.Red
                frmPrincipal.statusDATA2.Text = "    Data OFF    "
                MOD_ESTATUS_SRVDATA = False
                frmPrincipal.MenuStrip1.Refresh()
                Return False
            End If
        Catch ex As Exception
            frmPrincipal.statusDATA2.BackColor = Color.Red
            frmPrincipal.statusDATA2.Text = "    Data OFF    "
            frmPrincipal.MenuStrip1.Refresh()
            MOD_ESTATUS_SRVDATA = False
            Return False
        End Try
    End Function



    Public Sub PREENCHERGRID(GRID As Object, QUERY As String)
        If frmLogin.conn.State = System.Data.ConnectionState.Open Then
            Using Comm = New System.Data.SqlClient.SqlCommand()
                Comm.Connection = frmLogin.conn
                Comm.CommandText = QUERY
                Dim dt = New DataTable()
                dt.Load(Comm.ExecuteReader())
                GRID.DATASOURCE = Nothing
                GRID.AutoGenerateColumns = True
                GRID.DataSource = dt
                GRID.Refresh()
            End Using
        End If
    End Sub



    Public Sub PREENCHERCBOX(CBOX As Object, QUERY As String, COLUNA As String)
        If frmLogin.conn.State = System.Data.ConnectionState.Open Then
            Using Comm = New System.Data.SqlClient.SqlCommand()
                Comm.Connection = frmLogin.conn
                Comm.CommandText = QUERY
                Dim reader As SqlDataReader
                reader = Comm.ExecuteReader
                CBOX.Items.Clear()
                While (reader.Read)
                    CBOX.Items.Add(reader(COLUNA))
                End While
                CBOX.Refresh()
                reader.Close()
            End Using
        End If
    End Sub

    Public Sub EXECUTARQUERY(QUERY As String)
        'If frmLogin.conn.State = System.Data.ConnectionState.Open Then
        '    Using Comm1 = New System.Data.SqlClient.SqlCommand()
        '        Comm1.Connection = frmLogin.conn
        '        Comm1.CommandText = QUERY
        '        Dim i As Integer = Comm1.ExecuteNonQuery()

        '    End Using
        'End If
        Using conn1 = New System.Data.SqlClient.SqlConnection()
            conn1.ConnectionString = StringConexaoGERAL
            conn1.Open()
            Dim Sql = New System.Data.SqlClient.SqlCommand(QUERY, conn1)
            Sql.ExecuteNonQuery()
            conn1.Close()
        End Using
    End Sub



    Public Function BUSCAR_ACESSO(FORM As String, USUARIO As String, OPERACAO As String)
        If frmLogin.conn.State = System.Data.ConnectionState.Open Then
            Using Comm = New System.Data.SqlClient.SqlCommand()
                Comm.Connection = frmLogin.conn
                Comm.CommandText = "SELECT F.USUARIO FROM FORMS F WHERE F.USUARIO='" & USUARIO & "' AND F.FORMULARIO='" & FORM & "' AND F.OPERACAO='" & OPERACAO & "' AND F.ESTATUS='A'"
                Dim reader As SqlDataReader
                reader = Comm.ExecuteReader
                Dim LISTA As New List(Of String)
                'MsgBox(Comm.CommandText.ToString)
                While (reader.Read)
                    LISTA.Add(reader("USUARIO"))
                End While
                reader.Close()
                Return LISTA
            End Using
        End If
    End Function


    Public Function RETORNA_LISTA(QUERY As String, COLUNA As String)
        If frmLogin.conn.State = System.Data.ConnectionState.Open Then
            Using Comm = New System.Data.SqlClient.SqlCommand()
                Comm.Connection = frmLogin.conn
                Comm.CommandText = QUERY
                Dim reader As SqlDataReader
                reader = Comm.ExecuteReader
                Dim LISTA As New List(Of String)
                'MsgBox(Comm.CommandText.ToString)
                If reader.HasRows = True Then
                    While (reader.Read)
                        LISTA.Add(reader(COLUNA))
                    End While
                End If
                
                reader.Close()
                Return LISTA
            End Using
        End If
    End Function

    Public Function VALIDA_ACESSO(FORM As Object, USER As String, TIPO As String)
        'FORM = OBJETO FORMULARIO, USER = USUARIO LOGADO, TIPO = ABRIR | VISUALIZAR | INSERIR | ALTERAR | EXCLUIR
        Try
            'VALIDA SE O USUARIO É ADMINISTRADOR
            If USER = MOD_USUARIO And MOD_NIVEL = 1 Then
                If TIPO = "ABRIR" Then
                    FORM.MdiParent = frmPrincipal
                    'FORM.child()
                    FORM.Show()
                    FORM.Location = New System.Drawing.Point(35, 2)
                    FORM.Focus()
                    Return True
                Else
                    Return True
                End If
                'SE NÃO FOR ADM VERIFICA NA BASE SE TEM LIBERAÇÃO DE ACESSO
            Else
                Dim DT As New List(Of String)
                DT = BUSCAR_ACESSO(FORM.NAME.ToString, USER, TIPO)
                'MsgBox(DT.Count & " | ")
                If DT.Count > 0 Then
                    'TESTA SE A FUNCAO É ABRIR FORMULARIO
                    If TIPO = "ABRIR" Then
                        FORM.MdiParent = frmPrincipal
                        FORM.Show()
                        FORM.Location = New System.Drawing.Point(3, 2)
                        FORM.Focus()
                        Return True
                    Else
                        Return True
                    End If
                Else
                    MessageBoxEx.Show("Você não tem Permissão para Acessar este Recurso!" & vbCrLf & "Verifique com o Gestor!", "Solutiosn Bom Pastor", MessageBoxButtons.OK)
                    Return False
                End If
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function TrataCodigos(Texto As String)
        Dim A1 As String = Texto
        A1 = A1.Replace("'", "|")
        A1 = A1.Replace(",", "|")
        A1 = A1.Replace(" ", "|")
        A1 = A1.Replace(";", "|")
        A1 = A1.Replace(":", "|")
        A1 = A1.Replace(vbCrLf, "|")
        A1 = A1.Replace(vbLf, "|")
        A1 = A1.Replace(vbTab, "|")
        A1 = A1.Replace("||||", "|")
        A1 = A1.Replace("|||", "|")
        A1 = A1.Replace("||", "|")
        'A1 = Mid(A1, 1, Len(A1) - 1)
        A1 = A1.Replace("|", "','")
        A1 = "'" & A1 & "'"
        A1 = A1.Replace("',''", "'")
        A1 = A1.Replace("'','", "'")
        'MessageBoxEx.Show(A1)
        Return A1
    End Function

    Public Sub COLORIRGRD(DG As DataGridViewX)
        For x As Integer = 1 To DG.Rows.Count Step 1
            If x Mod 2 = 0 Then
                DG.Rows(x - 1).DefaultCellStyle.BackColor = Color.PowderBlue
            Else
                DG.Rows(x - 1).DefaultCellStyle.BackColor = Color.White
            End If
        Next
        DG.Refresh()
    End Sub



End Module
