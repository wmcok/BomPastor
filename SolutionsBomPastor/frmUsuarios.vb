Imports DevComponents.DotNetBar
Public Class frmUsuarios
    'QUERY LISTAR TODOS USUARIOS
    Dim QUERY_USUARIOS As String = "SELECT U.ID,RTRIM(U.USUARIO)USUARIO,RTRIM(U.SENHA)SENHA,RTRIM(U.NOME)NOME,RTRIM(convert(VARCHAR,G.ID))+'-'+RTRIM(G.GRUPO) GRUPO,CASE U.ESTATUS WHEN 'A' THEN 'ATIVO' WHEN 'D' THEN 'DESABILITADO' ELSE 'DESCONHECIDO' END ESTATUS   FROM USUARIOS U  INNER JOIN GRUPOS G ON G.Id=U.ID_GRUPO ORDER BY U.ID"
    Dim QUERY_GRUPOS As String = "SELECT RTRIM(ID)ID,RTRIM(GRUPO)GRUPO,RTRIM(DESCRICAO)DESCRICAO,RTRIM(NIVEL)NIVEL,RTRIM(ESTATUS)ESTATUS FROM GRUPOS"
    'QUERY DE OPERAÇÃO :  INSERIR | ALTERAR | EXCLUIR
    Dim OPERACAO As String = ""
    Private Sub frmUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
        'RetornarResultado("dgUsuariosUsuarios")
        'Dim TEXTO As String = "SELECT U.ID,U.USUARIO,U.SENHA,U.NOME,convert(VARCHAR,U.ID)+'-'+RTRIM(G.GRUPO) GRUPO,CASE U.ESTATUS WHEN 'A' THEN 'ATIVO' WHEN 'D' THEN 'DESABILITADO' ELSE 'DESCONHECIDO' END ESTATUS   FROM USUARIOS U  INNER JOIN GRUPOS G ON G.Id=U.ID_GRUPO ORDER BY U.ID"
        SideNavItem2.Select()
        PREENCHERGRID(Me.dgUsuariosUsuarios, QUERY_USUARIOS)
        PREENCHERCBOX(Me.cboxUsuariosGrupo, "SELECT CONVERT(VARCHAR,ID)+'-'+GRUPO GRUPO FROM GRUPOS", "GRUPO")
        PREENCHERGRID(Me.dgGruposGrupos, QUERY_GRUPOS)
        PREENCHERCBOX(Me.cboxUsuarioForm, "SELECT RTRIM(U.ID)+'-'+RTRIM(U.USUARIO)USUARIO FROM USUARIOS U", "USUARIO")
    End Sub


    Private Function ABAATIVA()
        Dim ABA As String = ""
        If SideNavItem2.Checked = True Then     'ABA USUARIOS
            ABA = "USUARIOS"
        ElseIf SideNavItem3.Checked = True Then 'ABA GRUPOS
            ABA = "GRUPOS"
        ElseIf SideNavItem4.Checked = True Then 'ABA LIBERACOES
            ABA = "LIBERACOES"
        End If
        Return ABA
    End Function
    Private Sub ATIVARBOTOES(TIPO As String, ABA As String)
        ' OPÇÕES: GRAVAR | INSERIR | ALTERAR | BLOQUEADO
        If ABA = "USUARIOS" Then
            If TIPO = "GRAVAR" Then
                btnInserir.Enabled = True
                btnAlterar.Enabled = True
                btnExcluir.Enabled = True
                btnGravar.Enabled = False
                btnCancelar.Enabled = False
                dgUsuariosUsuarios.Enabled = True
                OPERACAO = ""
            ElseIf TIPO = "INSERIR" Or TIPO = "ALTERAR" Then
                btnInserir.Enabled = False
                btnAlterar.Enabled = False
                btnExcluir.Enabled = False
                btnCancelar.Enabled = True
                btnGravar.Enabled = True
                dgUsuariosUsuarios.Enabled = False
            ElseIf TIPO = "BLOQUEADO" Then
                btnInserir.Enabled = False
                btnAlterar.Enabled = False
                btnExcluir.Enabled = False
                btnCancelar.Enabled = False
                btnGravar.Enabled = False
                dgUsuariosUsuarios.Enabled = False
            End If
        ElseIf ABA = "GRUPOS" Then
            If TIPO = "GRAVAR" Then
                btnInserir.Enabled = True
                btnAlterar.Enabled = True
                btnExcluir.Enabled = True
                btnGravar.Enabled = False
                btnCancelar.Enabled = False
                dgGruposGrupos.Enabled = True
                OPERACAO = ""
            ElseIf TIPO = "INSERIR" Or TIPO = "ALTERAR" Then
                btnInserir.Enabled = False
                btnAlterar.Enabled = False
                btnExcluir.Enabled = False
                btnCancelar.Enabled = True
                btnGravar.Enabled = True
                dgGruposGrupos.Enabled = False
            ElseIf TIPO = "BLOQUEADO" Then
                btnInserir.Enabled = False
                btnAlterar.Enabled = False
                btnExcluir.Enabled = False
                btnCancelar.Enabled = False
                btnGravar.Enabled = False
                dgGruposGrupos.Enabled = False
            End If
        ElseIf ABA = "LIBERACOES" Then
            If TIPO = "GRAVAR" Then
                btnInserir.Enabled = True
                btnAlterar.Enabled = True
                btnExcluir.Enabled = True
                btnGravar.Enabled = False
                btnCancelar.Enabled = False
                dgLiberacoes.Enabled = True
                OPERACAO = ""
            ElseIf TIPO = "INSERIR" Or TIPO = "ALTERAR" Then
                btnInserir.Enabled = False
                btnAlterar.Enabled = False
                btnExcluir.Enabled = False
                btnCancelar.Enabled = True
                btnGravar.Enabled = True
                dgLiberacoes.Enabled = False
            ElseIf TIPO = "BLOQUEADO" Then
                btnInserir.Enabled = False
                btnAlterar.Enabled = False
                btnExcluir.Enabled = False
                btnCancelar.Enabled = False
                btnGravar.Enabled = False
                dgLiberacoes.Enabled = False
            End If
        End If

    End Sub

    Private Sub dgUsuariosUsuarios_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgUsuariosUsuarios.CellEnter
        txtUsuariosID.Text = dgUsuariosUsuarios.CurrentRow.Cells(0).Value()
        txtUsuariosUsuario.Text = dgUsuariosUsuarios.CurrentRow.Cells(1).Value()
        txtUsuariosSenha.Text = dgUsuariosUsuarios.CurrentRow.Cells(2).Value()
        txtUsuariosNome.Text = dgUsuariosUsuarios.CurrentRow.Cells(3).Value()
        cboxUsuariosGrupo.Text = dgUsuariosUsuarios.CurrentRow.Cells(4).Value()
        cboxUsuariosEstatus.Text = dgUsuariosUsuarios.CurrentRow.Cells(5).Value()
    End Sub

    Private Sub btnGravar_Click(sender As Object, e As EventArgs) Handles btnGravar.Click
        'MsgBox(OPERACAO)
        Dim ABA As String = ABAATIVA()
        ' Dim APL As String() = Split(cboxUsuariosGrupo.Text, "-")
        Dim COD_GRUPO As String() = Split(cboxUsuariosGrupo.Text, "-")


        If ABA = "USUARIOS" Then
            If OPERACAO = "INSERIR" Then
                EXECUTARQUERY("INSERT INTO USUARIOS VALUES ('" & txtUsuariosUsuario.Text & "','" & txtUsuariosSenha.Text & "','" & txtUsuariosNome.Text & "','" & COD_GRUPO(0) & "','" & cboxUsuariosEstatus.Text.Substring(0, 1) & "')")
            ElseIf OPERACAO = "ALTERAR" Then
                EXECUTARQUERY("UPDATE USUARIOS SET USUARIO='" & txtUsuariosUsuario.Text & "',SENHA='" & txtUsuariosSenha.Text & "',NOME='" & txtUsuariosNome.Text & "',ID_GRUPO='" & COD_GRUPO(0) & "',ESTATUS='" & cboxUsuariosEstatus.Text.Substring(0, 1) & "' WHERE ID='" & txtUsuariosID.Text & "'")
            End If
            PREENCHERGRID(Me.dgUsuariosUsuarios, QUERY_USUARIOS)
        ElseIf ABA = "GRUPOS" Then
            If OPERACAO = "INSERIR" Then
                EXECUTARQUERY("INSERT INTO GRUPOS VALUES ('" & txtGruposGrupo.Text & "','" & txtGruposNome.Text & "','" & cboxGruposNivel.Text & "','" & cboxGruposEstatus.Text.Substring(0, 1) & "')")
            ElseIf OPERACAO = "ALTERAR" Then
                EXECUTARQUERY("UPDATE GRUPOS SET GRUPO='" & txtGruposGrupo.Text & "',DESCRICAO='" & txtGruposNome.Text & "',NIVEL='" & cboxGruposNivel.Text & "',ESTATUS='" & cboxGruposEstatus.Text.Substring(0, 1) & "'  WHERE ID='" & txtGrupoID.Text & "'")
            End If
            PREENCHERGRID(Me.dgGruposGrupos, QUERY_GRUPOS)
        ElseIf ABA = "LIBERACOES" Then
            Dim FORM As String() = Split(cboxForms.Text, "|")
            Dim USER As String() = Split(cboxUsuarioForm.Text, "-")
            If OPERACAO = "INSERIR" Then
                'EXECUTARQUERY("INSERT INTO GRUPOS VALUES ('" & txtGruposGrupo.Text & "','" & txtGruposNome.Text & "','" & cboxGruposNivel.Text & "','" & cboxGruposEstatus.Text.Substring(0, 1) & "')")
                If checkAbrirForm.CheckState = CheckState.Checked Then
                    EXECUTARQUERY("INSERT INTO FORMS VALUES ('" & FORM(0) & "','" & txtDescricaoForm.Text & "','" & USER(1) & "','ABRIR','" & cboxEstatusForm.Text.Substring(0, 1) & "')")
                End If
                If checkVisualizarForm.CheckState = CheckState.Checked Then
                    EXECUTARQUERY("INSERT INTO FORMS VALUES ('" & FORM(0) & "','" & txtDescricaoForm.Text & "','" & USER(1) & "','VISUALIZAR','" & cboxEstatusForm.Text.Substring(0, 1) & "')")
                End If
                If checkInserirForm.CheckState = CheckState.Checked Then
                    EXECUTARQUERY("INSERT INTO FORMS VALUES ('" & FORM(0) & "','" & txtDescricaoForm.Text & "','" & USER(1) & "','INSERIR','" & cboxEstatusForm.Text.Substring(0, 1) & "')")
                End If
                If checkAlterarForm.CheckState = CheckState.Checked Then
                    EXECUTARQUERY("INSERT INTO FORMS VALUES ('" & FORM(0) & "','" & txtDescricaoForm.Text & "','" & USER(1) & "','ALTERAR','" & cboxEstatusForm.Text.Substring(0, 1) & "')")
                End If
                If checkExcluir.CheckState = CheckState.Checked Then
                    EXECUTARQUERY("INSERT INTO FORMS VALUES ('" & FORM(0) & "','" & txtDescricaoForm.Text & "','" & USER(1) & "','EXCLUIR','" & cboxEstatusForm.Text.Substring(0, 1) & "')")
                End If
                'EXECUTARQUERY("INSERT INTO FORMS VALUES ('" & FORM(0) & "','" & txtDescricaoForm.Text & "','" & USER(1) & "','OPERACAO','" & cboxEstatusForm.Text.Substring(0, 1) & "')")
                GRID_LIBERACOES()
            ElseIf OPERACAO = "ALTERAR" Then
                Dim LISTA_OPERACOES As New List(Of String)
                LISTA_OPERACOES = RETORNA_LISTA("SELECT RTRIM(F.OPERACAO)OPERACAO FROM FORMS F WHERE F.FORMULARIO='" & FORM(0) & "' AND F.MODULO='" & USER(1) & "'", "OPERACAO")
                Dim L_ABRIR = LISTA_OPERACOES.Contains("ABRIR")
                Dim L_VISUALIZAR = LISTA_OPERACOES.Contains("VISUALIZAR")
                Dim L_INSERIR = LISTA_OPERACOES.Contains("INSERIR")
                Dim L_ALTERAR = LISTA_OPERACOES.Contains("ALTERAR")
                Dim L_EXCLUIR = LISTA_OPERACOES.Contains("EXCLUIR")
                'MsgBox(L_ABRIR & "-" & L_VISUALIZAR)

                'EXECUTARQUERY("UPDATE GRUPOS SET GRUPO='" & txtGruposGrupo.Text & "',DESCRICAO='" & txtGruposNome.Text & "',NIVEL='" & cboxGruposNivel.Text & "',ESTATUS='" & cboxGruposEstatus.Text.Substring(0, 1) & "'  WHERE ID='" & txtGrupoID.Text & "'")

                If checkAbrirForm.CheckState = CheckState.Checked Then
                    If L_ABRIR = True Then
                        EXECUTARQUERY("UPDATE FORMS SET DESCRICAO='" & txtDescricaoForm.Text & "', ESTATUS='" & cboxEstatusForm.Text.Substring(0, 1) & "' WHERE FORMULARIO='" & FORM(0) & "' AND MODULO='" & USER(1) & "'  AND OPERACAO='ABRIR'")
                    Else
                        EXECUTARQUERY("INSERT INTO FORMS VALUES ('" & FORM(0) & "','" & txtDescricaoForm.Text & "','" & USER(1) & "','ABRIR','" & cboxEstatusForm.Text.Substring(0, 1) & "')")
                    End If
                Else
                    EXECUTARQUERY("DELETE FROM FORMS WHERE FORMULARIO='" & FORM(0) & "' AND USUARIO='" & USER(1) & "'  AND OPERACAO='ABRIR'")
                End If

                If checkVisualizarForm.CheckState = CheckState.Checked Then
                    If L_VISUALIZAR = True Then
                        EXECUTARQUERY("UPDATE FORMS SET DESCRICAO='" & txtDescricaoForm.Text & "', ESTATUS='" & cboxEstatusForm.Text.Substring(0, 1) & "' WHERE FORMULARIO='" & FORM(0) & "' AND MODULO='" & USER(1) & "'  AND OPERACAO='VISUALIZAR'")
                    Else
                        EXECUTARQUERY("INSERT INTO FORMS VALUES ('" & FORM(0) & "','" & txtDescricaoForm.Text & "','" & USER(1) & "','VISUALIZAR','" & cboxEstatusForm.Text.Substring(0, 1) & "')")
                    End If
                Else
                    EXECUTARQUERY("DELETE FROM FORMS WHERE FORMULARIO='" & FORM(0) & "' AND MODULO='" & USER(1) & "'  AND OPERACAO='VISUALIZAR'")
                End If

                If checkInserirForm.CheckState = CheckState.Checked Then
                    If L_INSERIR = True Then
                        EXECUTARQUERY("UPDATE FORMS SET DESCRICAO='" & txtDescricaoForm.Text & "', ESTATUS='" & cboxEstatusForm.Text.Substring(0, 1) & "' WHERE FORMULARIO='" & FORM(0) & "' AND MODULO='" & USER(1) & "'  AND OPERACAO='INSERIR'")
                    Else
                        EXECUTARQUERY("INSERT INTO FORMS VALUES ('" & FORM(0) & "','" & txtDescricaoForm.Text & "','" & USER(1) & "','INSERIR','" & cboxEstatusForm.Text.Substring(0, 1) & "')")
                    End If
                Else
                    EXECUTARQUERY("DELETE FROM FORMS WHERE FORMULARIO='" & FORM(0) & "' AND MODULO='" & USER(1) & "'  AND OPERACAO='INSERIR'")
                End If

                If checkAlterarForm.CheckState = CheckState.Checked Then
                    If L_INSERIR = True Then
                        EXECUTARQUERY("UPDATE FORMS SET DESCRICAO='" & txtDescricaoForm.Text & "', ESTATUS='" & cboxEstatusForm.Text.Substring(0, 1) & "' WHERE FORMULARIO='" & FORM(0) & "' AND MODULO='" & USER(1) & "'  AND OPERACAO='ALTERAR'")
                    Else
                        EXECUTARQUERY("INSERT INTO FORMS VALUES ('" & FORM(0) & "','" & txtDescricaoForm.Text & "','" & USER(1) & "','ALTERAR','" & cboxEstatusForm.Text.Substring(0, 1) & "')")
                    End If
                Else
                    EXECUTARQUERY("DELETE FROM FORMS WHERE FORMULARIO='" & FORM(0) & "' AND MODULO='" & USER(1) & "'  AND OPERACAO='ALTERAR'")
                End If

                If checkExcluir.CheckState = CheckState.Checked Then
                    If L_INSERIR = True Then
                        EXECUTARQUERY("UPDATE FORMS SET DESCRICAO='" & txtDescricaoForm.Text & "', ESTATUS='" & cboxEstatusForm.Text.Substring(0, 1) & "' WHERE FORMULARIO='" & FORM(0) & "' AND MODULO='" & USER(1) & "'  AND OPERACAO='EXCLUIR'")
                    Else
                        EXECUTARQUERY("INSERT INTO FORMS VALUES ('" & FORM(0) & "','" & txtDescricaoForm.Text & "','" & USER(1) & "','EXCLUIR','" & cboxEstatusForm.Text.Substring(0, 1) & "')")
                    End If
                Else
                    EXECUTARQUERY("DELETE FROM FORMS WHERE FORMULARIO='" & FORM(0) & "' AND MODULO='" & USER(1) & "'  AND OPERACAO='EXCLUIR'")
                End If

                GRID_LIBERACOES()
            End If
            'PREENCHERGRID(Me.dgGruposGrupos, QUERY_GRUPOS)
            End If
        ATIVARBOTOES("GRAVAR", ABA)

    End Sub

    Private Sub btnInserir_Click(sender As Object, e As EventArgs) Handles btnInserir.Click
        OPERACAO = "INSERIR"
        Dim ABA As String = ABAATIVA()
        If ABA = "USUARIOS" Then

            txtUsuariosUsuario.Text = ""
            txtUsuariosSenha.Text = ""
            txtUsuariosNome.Text = ""
            cboxUsuariosEstatus.SelectedIndex = 0
            cboxUsuariosGrupo.SelectedIndex = 1
            txtUsuariosUsuario.Focus()
        ElseIf ABA = "GRUPOS" Then

            txtGrupoID.Text = ""
            txtGruposGrupo.Text = ""
            txtGruposNome.Text = ""
            cboxGruposEstatus.SelectedIndex = 0
            cboxGruposNivel.SelectedIndex = 1
            txtGruposGrupo.Focus()
        ElseIf ABA = "LIBERACOES" Then
            txtDescricaoForm.Text = ""
            checkAdmForm.Checked = False
            checkAbrirForm.Checked = False
            checkAlterarForm.Checked = False
            checkInserirForm.Checked = False
            checkVisualizarForm.Checked = False
            checkExcluir.Checked = False
            txtDescricaoForm.Focus()
        End If
        ATIVARBOTOES(OPERACAO, ABA)
    End Sub

    Private Sub btnAlterar_Click(sender As Object, e As EventArgs) Handles btnAlterar.Click
        OPERACAO = "ALTERAR"
        Dim ABA As String = ABAATIVA()
        If ABA = "USUARIOS" Then

            txtUsuariosUsuario.Focus()
        ElseIf ABA = "GRUPOS" Then

            txtGruposGrupo.Focus()
        ElseIf ABA = "LIBERACOES" Then
            txtDescricaoForm.Focus()
        End If
        ATIVARBOTOES(OPERACAO, ABA)
    End Sub

    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click
        If VALIDA_ACESSO(Me, MOD_USUARIO, "EXCLUIR") = True Then
            Dim a As String = MsgBox("Tem Certeza que deseja Excluir este Registro?", MsgBoxStyle.OkCancel)
            If a = MsgBoxResult.Cancel Then
                MsgBox(" A Operação foi Cancelada.")
            Else
                Dim ABA As String = ABAATIVA()
                If ABA = "USUARIOS" Then
                    EXECUTARQUERY("DELETE FROM USUARIOS WHERE ID='" & txtUsuariosID.Text & "'")
                    PREENCHERGRID(Me.dgUsuariosUsuarios, QUERY_USUARIOS)
                ElseIf ABA = "GRUPOS" Then
                    EXECUTARQUERY("DELETE FROM GRUPOS WHERE ID='" & txtGrupoID.Text & "'")
                    PREENCHERGRID(Me.dgGruposGrupos, QUERY_GRUPOS)
                ElseIf ABA = "LIBERACOES" Then
                    Dim FORM As String() = Split(cboxForms.Text, "|")
                    Dim USER As String() = Split(cboxUsuarioForm.Text, "-")
                    EXECUTARQUERY("DELETE FROM FORMS WHERE FORMULARIO='" & FORM(0) & "' AND MODULO='" & USER(1) & "'  ")
                    'PREENCHERGRID(Me.dgGruposGrupos, QUERY_GRUPOS)
                    GRID_LIBERACOES()
                End If
                ATIVARBOTOES("GRAVAR", ABA)
            End If
        Else
            Exit Sub
        End If
    End Sub

    Private Sub frmUsuarios_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        MenuPrincipal()
    End Sub

    Private Sub dgGruposGrupos_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgGruposGrupos.CellEnter
        txtGrupoID.Text = dgGruposGrupos.CurrentRow.Cells(0).Value()
        txtGruposGrupo.Text = dgGruposGrupos.CurrentRow.Cells(1).Value()
        txtGruposNome.Text = dgGruposGrupos.CurrentRow.Cells(2).Value()
        cboxGruposNivel.Text = dgGruposGrupos.CurrentRow.Cells(3).Value()
        cboxGruposEstatus.Text = dgGruposGrupos.CurrentRow.Cells(4).Value()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Dim ABA As String = ABAATIVA()
        ATIVARBOTOES("GRAVAR", ABA)
    End Sub


    Private Sub MostraForms()  'PARA EXIBIR TODOS OS FORMULARIOS DO APLICATIVO
        'Try
        '    If (Me.InvokeRequired = True) Then
        '        Me.BeginInvoke(New MethodInvoker(AddressOf Me.MostraForms))
        '    Else
        Dim frms As Object
        Dim p As System.Reflection.PropertyInfo
        Dim dt As New DataTable
        Dim NovaDr As DataRow
        frms = My.Forms
        dt.Columns.Add("TextoForm", GetType(System.String))
        dt.Columns.Add("Formulario", GetType(System.String))
        For Each p In frms.GetType.GetProperties
            If p.DeclaringType.Name.ToUpper = "MYFORMS" Then
                Dim obj As New Object
                obj = p.GetValue(frms, Nothing)
                NovaDr = dt.NewRow()
                NovaDr("TextoForm") = CType(obj, Form).Text
                NovaDr("Formulario") = CType(obj, Form).Name & " | " & CType(obj, Form).Text
                dt.Rows.Add(NovaDr)

            End If
        Next
        With cboxForms 'ativar cbox na liberaçoes
            .DataSource = dt
            .DisplayMember = "Formulario"
            .ValueMember = "TextoForm"
        End With
        '    End If
        'Catch ex As ThreadAbortException

        'End Try
    End Sub


    Private Sub SideNavItem4_Click(sender As Object, e As EventArgs) Handles SideNavItem4.Click
        MostraForms()
    End Sub

    Public Sub check()
        checkAdmForm.Checked = False
        checkAbrirForm.Checked = False
        checkAlterarForm.Checked = False
        checkInserirForm.Checked = False
        checkVisualizarForm.Checked = False
        CheckExcluir.Checked = False
        Dim A As Integer = 0
        ' A = DataGridViewX1.RowCount.ToString
        ATIVARBOTOES("GRAVAR", ABAATIVA())
        Do While (A <= dgLiberacoes.RowCount.ToString - 1)
            'MsgBox(DataGridViewX1.RowCount.ToString)
            If Me.dgLiberacoes.Rows.Item(A).Cells.Item(5).Value = "ADM" Then
                checkAdmForm.CheckState = CheckState.Checked
                checkAbrirForm.Checked = False
                checkAlterarForm.Checked = False
                checkInserirForm.Checked = False
                checkVisualizarForm.Checked = False
                checkExcluir.Checked = False
                ATIVARBOTOES("BLOQUEADO", ABAATIVA())
                Exit Do
            Else
                checkAdmForm.Checked = False
                'MsgBox(Me.dgLiberacoes.Rows.Item(A).Cells.Item(3).Value)
                If Me.dgLiberacoes.Rows.Item(A).Cells.Item(3).Value = "INSERIR" Then
                    'checkInserirForm.Checked = True
                    checkInserirForm.CheckState = CheckState.Checked
                End If
                If Me.dgLiberacoes.Rows.Item(A).Cells.Item(3).Value = "ABRIR" Then
                    'checkAbrirForm.Checked = True
                    checkAbrirForm.CheckState = CheckState.Checked
                End If
                If Me.dgLiberacoes.Rows.Item(A).Cells.Item(3).Value = "ALTERAR" Then
                    'checkAlterarForm.Checked = True
                    checkAlterarForm.CheckState = CheckState.Checked
                End If
                If Me.dgLiberacoes.Rows.Item(A).Cells.Item(3).Value = "VISUALIZAR" Then
                    'checkVisualizarForm.Checked = True
                    checkVisualizarForm.CheckState = CheckState.Checked
                End If
                If Me.dgLiberacoes.Rows.Item(A).Cells.Item(3).Value = "EXCLUIR" Then
                    'checkExcluir.Checked = True
                    checkExcluir.CheckState = CheckState.Checked
                End If
            End If
            A += 1

        Loop
    End Sub
    Private Sub checkAdmForm_CheckedChanged(sender As Object, e As EventArgs) Handles checkAdmForm.CheckedChanged
        If checkAdmForm.CheckState = CheckState.Checked Then
            checkAbrirForm.CheckState = CheckState.Unchecked
            checkVisualizarForm.CheckState = CheckState.Unchecked
            checkAlterarForm.CheckState = CheckState.Unchecked
            checkExcluir.CheckState = CheckState.Unchecked
            checkInserirForm.CheckState = CheckState.Unchecked
        End If
    End Sub

    Private Sub cboxUsuarioForm_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboxUsuarioForm.SelectedIndexChanged
        GRID_LIBERACOES()
    End Sub

    Public Sub GRID_LIBERACOES()
        Dim FORM As String() = Split(cboxForms.Text, "|")
        Dim USER As String() = Split(cboxUsuarioForm.Text, "-")
        Dim TEXT As String = " SELECT ISNULL(CONVERT(VARCHAR,RTRIM(F.Id)),'')ID,ISNULL(RTRIM(F.FORMULARIO),'')FORMULARIO,ISNULL(RTRIM(F.MODULO),RTRIM(U.USUARIO))USUARIO,ISNULL(rtrim(F.OPERACAO),'')OPERACAO, " &
         "CASE WHEN G.ESTATUS = 'A' AND U.ESTATUS='A' THEN CASE WHEN F.ESTATUS IS NULL THEN 'ATIVO' WHEN F.ESTATUS = 'A' THEN 'ATIVO' ELSE 'DESATIVADO' END ELSE 'DESATIVADO' END ESTATUS, " &
         "CASE WHEN G.NIVEL IN ('1') THEN 'ADM' ELSE 'NOR' END NIVEL ,ISNULL(RTRIM(F.DESCRICAO),'')DESCRICAO FROM USUARIOS U " &
         "LEFT JOIN FORMS F ON F.MODULO=U.USUARIO AND F.FORMULARIO='" & FORM(0).ToString & "' " &
         "LEFT JOIN GRUPOS G ON G.Id=U.ID_GRUPO " &
         "WHERE U.USUARIO='" & USER(1).ToString & "' " &
         "ORDER BY FORMULARIO,USUARIO,OPERACAO"
        'MsgBox(TEXT)
        PREENCHERGRID(Me.dgLiberacoes, TEXT)

        check()
    End Sub

    Private Sub dgLiberacoes_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgLiberacoes.CellEnter
        txtIDForm.Text = dgLiberacoes.CurrentRow.Cells(0).Value()
        cboxEstatusForm.Text = dgLiberacoes.CurrentRow.Cells(4).Value()
        txtDescricaoForm.Text = dgLiberacoes.CurrentRow.Cells(6).Value()
    End Sub

    Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click
        Me.Close()
    End Sub

    Private Sub ReflectionImage1_Click(sender As Object, e As EventArgs) Handles ReflectionImage1.Click
        Me.Close()
    End Sub
End Class