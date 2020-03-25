Imports System.Data.SqlClient
Imports DevComponents.DotNetBar
Imports System.Threading

Public Class frmPrincipal

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StyleManager2 = frmLogin.StyleManager1
        Me.Location = Point.Empty
        Dim WA As System.Drawing.Rectangle = Screen.PrimaryScreen.WorkingArea
        Me.Size = New System.Drawing.Size(WA.Width, WA.Height)

        lblUsuario2.Text = MOD_NOME_USER
        lblGrupo2.Text = MOD_GRUPO
        lblVersao2.Text = My.Application.Info.CompanyName & " - " & String.Format("Versão {0}", My.Application.Info.Version.ToString) & " - " & ModuloGeral.infoReader.LastWriteTime
        Timer1.Start()
    End Sub

    Private Sub frmPrincipal_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        frmLogin.Close()
        Application.Exit()
    End Sub


    Private Sub MetroTileItem5_Click(sender As Object, e As EventArgs) Handles MetroTileItem5.Click
        frmLogin.Close()
        Application.Exit()
    End Sub

    Private Sub ToolStripDropDownButton1_Click(sender As Object, e As EventArgs)
        MenuPrincipal()
    End Sub

    Private Sub frmPrincipal_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Dim a As String
            a = MessageBoxEx.Show("Deseja Sair do Sistema?    ", "Solution's Elza", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            If a = MsgBoxResult.Cancel Then
            Else
                frmLogin.Close()
                Application.Exit()
            End If
        ElseIf e.KeyCode = Keys.F4 Then
            MenuPrincipal()
        End If
    End Sub


    Private Sub btnMenuUsuarios_Click(sender As Object, e As EventArgs) Handles btnMenuUsuarios.Click
        VALIDA_ACESSO(frmUsuarios, MOD_USUARIO, "ABRIR")
    End Sub


    Private Sub MetroTilePanel1_ItemClick(sender As Object, e As EventArgs) Handles MetroTilePanel1.ItemClick
        MenuPrincipal()
    End Sub



    Private Sub MetroTileItem1_Click(sender As Object, e As EventArgs) Handles MetroTileItem1.Click
        If MOD_ESTATUS_SRVDATA = False Then
            MessageBoxEx.Show("Não foi possivel Conectar ao Data, Favor verificar Conexão ou Comunicar ao T.I. ", "Solution's Bom Pastor", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            VALIDA_ACESSO(frmMovimentacoes, MOD_USUARIO, "ABRIR")

        End If
    End Sub

    Private Sub MetroTileItem6_Click(sender As Object, e As EventArgs) Handles MetroTileItem6.Click
        If MOD_ESTATUS_SRVDATA = False Then
            MessageBoxEx.Show("Não foi possivel Conectar ao Data, Favor verificar Conexão ou Comunicar ao T.I. ", "Solution's Bom Pastor", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            'VALIDA_ACESSO(frmRelatorios2, MOD_USUARIO, "ABRIR")
            MessageBoxEx.Show("Tela de Relatórios habilitada somente para ser vinculada!" & vbCrLf & "Tente gerar em outra Tela.", "Solution's Bom Pastor", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub MetroTileItem2_Click(sender As Object, e As EventArgs) Handles MetroTileItem2.Click
        VALIDA_ACESSO(frmConfiguracoes, MOD_USUARIO, "ABRIR")
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
         PING_DATA() 
    End Sub

    Private Sub MenuF4ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MenuF4ToolStripMenuItem.Click
        MenuPrincipal()
    End Sub

    Private Sub SairToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SairToolStripMenuItem.Click
        Dim a As String
        a = MessageBoxEx.Show("Deseja Sair do Sistema?    ", "Solution's Elza", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If a = MsgBoxResult.Cancel Then
        Else
            frmLogin.Close()
            Application.Exit()
        End If
    End Sub

    Private Sub MetroTileItem7_Click(sender As Object, e As EventArgs) Handles MetroTileItem7.Click
        'NATUREZAS
        VALIDA_ACESSO(frmNaturezas, MOD_USUARIO, "ABRIR")
    End Sub

    Private Sub MetroTileItem3_Click(sender As Object, e As EventArgs) Handles MetroTileItem3.Click
        'CONTROLE FINANCEIRO
        VALIDA_ACESSO(frmLancamentosMV, MOD_USUARIO, "ABRIR")
    End Sub

    Private Sub JanelasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JanelasToolStripMenuItem.Click
        MenuPrincipal()
    End Sub

    Private Sub MetroTileItem4_Click(sender As Object, e As EventArgs) Handles MetroTileItem4.Click
        VALIDA_ACESSO(frmRelatorios2, MOD_USUARIO, "ABRIR")
    End Sub
End Class
