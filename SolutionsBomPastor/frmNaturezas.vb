Imports DevComponents.DotNetBar
Public Class frmNaturezas
    Dim OPERACAO As String = ""
    Dim QUERYNATUREZAS As String = "SELECT ID,CODIGO,NATUREZA,OBSERVACAO,CASE ESTATUS WHEN 'A' THEN 'ATIVO' WHEN 'D' THEN 'DESABILITADO' ELSE '' END ESTATUS FROM NATUREZAS"
    Private Sub frmNaturezas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
        ATIVARBOTOES("GRAVAR")
    End Sub

    Private Sub dgNaturezas_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgNaturezas.CellEnter
        txtID.Text = dgNaturezas.CurrentRow.Cells(0).Value()
        txtCodigo.Text = dgNaturezas.CurrentRow.Cells(1).Value()
        txtNatureza.Text = dgNaturezas.CurrentRow.Cells(2).Value()
        txtDescricao.Text = dgNaturezas.CurrentRow.Cells(3).Value()
        cboxEstatus.Text = dgNaturezas.CurrentRow.Cells(4).Value()
    End Sub

    Private Sub ATIVARBOTOES(TIPO As String)
        ' OPÇÕES: GRAVAR | INSERIR | ALTERAR | BLOQUEADO
        If TIPO = "GRAVAR" Then
            btnInserir.Enabled = True
            btnAlterar.Enabled = True
            btnExcluir.Enabled = True
            btnGravar.Enabled = False
            btnCancelar.Enabled = False
            dgNaturezas.Enabled = True
            OPERACAO = ""
        ElseIf TIPO = "INSERIR" Or TIPO = "ALTERAR" Then
            btnInserir.Enabled = False
            btnAlterar.Enabled = False
            btnExcluir.Enabled = False
            btnCancelar.Enabled = True
            btnGravar.Enabled = True
            dgNaturezas.Enabled = False
        ElseIf TIPO = "BLOQUEADO" Then
            btnInserir.Enabled = False
            btnAlterar.Enabled = False
            btnExcluir.Enabled = False
            btnCancelar.Enabled = False
            btnGravar.Enabled = False
            dgNaturezas.Enabled = False
        End If
    End Sub

    Private Sub frmNaturezas_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        PREENCHERGRID(dgNaturezas, QUERYNATUREZAS)
    End Sub

    Private Sub btnInserir_Click(sender As Object, e As EventArgs) Handles btnInserir.Click
        If VALIDA_ACESSO(Me, MOD_USUARIO, "INSERIR") = True Then
            OPERACAO = "INSERIR"
            ATIVARBOTOES(OPERACAO)
            txtID.ReadOnly = True
            txtCodigo.ReadOnly = False
            txtCodigo.Text = ""
            txtNatureza.ReadOnly = False
            txtNatureza.Text = ""
            txtDescricao.ReadOnly = False
            txtDescricao.Text = ""
            cboxEstatus.Enabled = True
            cboxEstatus.SelectedIndex = 0
            dgNaturezas.ReadOnly = True
            txtCodigo.Focus()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub btnAlterar_Click(sender As Object, e As EventArgs) Handles btnAlterar.Click
        If VALIDA_ACESSO(Me, MOD_USUARIO, "ALTERAR") = True Then
            OPERACAO = "ALTERAR"
            ATIVARBOTOES(OPERACAO)
            txtID.ReadOnly = True
            txtCodigo.ReadOnly = False
            txtNatureza.ReadOnly = False
            txtDescricao.ReadOnly = False
            cboxEstatus.Enabled = True
            dgNaturezas.ReadOnly = True
            txtCodigo.Focus()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click

        OPERACAO = "GRAVAR"
        ATIVARBOTOES(OPERACAO)
        txtID.ReadOnly = True
        txtCodigo.ReadOnly = True
        txtNatureza.ReadOnly = True
        txtDescricao.ReadOnly = True
        cboxEstatus.Enabled = True
        dgNaturezas.ReadOnly = False
        
    End Sub

    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click
        If VALIDA_ACESSO(Me, MOD_USUARIO, "EXCLUIR") = True Then
            Dim a As String = MessageBoxEx.Show("Tem Certeza que deseja Excluir este Registro?", "Solution's Bom Pastor", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
            If a = MsgBoxResult.Cancel Then
                MsgBox(" A Operação foi Cancelada.")
            Else
                EXECUTARQUERY("DELETE FROM NATUREZAS WHERE ID='" & txtID.Text & "'")
                PREENCHERGRID(dgNaturezas, QUERYNATUREZAS)
            End If
            ATIVARBOTOES("GRAVAR")
        Else
            Exit Sub
        End If
    End Sub

    Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click
        Me.Close()
    End Sub

    Private Sub btnGravar_Click(sender As Object, e As EventArgs) Handles btnGravar.Click
        If OPERACAO = "INSERIR" Then
            Dim L As List(Of String) = RETORNA_LISTA("SELECT CODIGO FROM NATUREZAS WHERE CODIGO='" & txtCodigo.Text & "'", "CODIGO")
            If L.Count < 1 Then
                EXECUTARQUERY("INSERT INTO NATUREZAS VALUES ('" & txtCodigo.Text & "','" & txtNatureza.Text & "','" & txtDescricao.Text & "','" & cboxEstatus.Text.Substring(0, 1) & "')")
            Else
                MessageBoxEx.Show("Já existe o Código " & L(0).ToString & " cadastrados no Sistema!" & vbCrLf & "Favor Digitar outro Código para Inserir.", "Solution'Bom Pastor", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                txtCodigo.Focus()
                txtCodigo.SelectAll()
            End If

        ElseIf OPERACAO = "ALTERAR" Then
            EXECUTARQUERY("UPDATE NATUREZAS SET CODIGO='" & txtCodigo.Text & "',NATUREZA='" & txtNatureza.Text & "',OBSERVACAO='" & txtDescricao.Text & "',ESTATUS='" & cboxEstatus.Text.Substring(0, 1) & "' WHERE ID='" & txtID.Text & "'")
        End If
        PREENCHERGRID(dgNaturezas, QUERYNATUREZAS)
        OPERACAO = ""
    End Sub

    Private Sub frmNaturezas_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        MenuPrincipal()
    End Sub
End Class