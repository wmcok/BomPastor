Imports DevComponents.DotNetBar
Imports Microsoft.SqlServer.Management.Smo

Public Class frmLancamentosMV
    Dim OPERACAO As String = ""
    Dim TB_FINANC As DataTable = New DataTable("Financeiro")
    Dim ID_FIN As String = ""
    Dim INDEX_ROW As Integer = 0
    Dim INDEX_ITEM As Integer = 0
    Dim Dias As String = 10
    Dim DT_INSERT As Date
    Dim TIPO_MV As Integer


    Private Sub frmLancamentosMV_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
        cboxRelatorio.SelectedIndex = 0
        dtInicioExibir.Value = DateValue(Now.Year & "/" & Now.Month & "/01")
        dtCadMVPesqInicio.Value = DateValue(Now.Year & "/" & Now.Month & "/01")
        dtFinalExibir.Value = DateValue(dtInicioExibir.Value.Year & "/" & dtInicioExibir.Value.Month & "/" & Date.DaysInMonth(dtInicioExibir.Value.Year, dtInicioExibir.Value.Month))
        SideNavItem2.Select()
        ATIVARBOTOES("GRAVAR")
        TRATAGRID()
        'cboxCadDias.SelectedIndex = 0
    End Sub

    Public Function MontarQueryExibir(F As Boolean)



        Dim QUERY As String = ""
        Dim TIPO As String = ""
        Dim DATA As String = ""
        Dim ESTATUS As String = ""
        Dim FINANCEIRO As String = ""
        Dim NATUREZA As String = ""
        Dim OBS As String = ""

        'TIPO
        If checkVisualizarEntrada.CheckState = CheckState.Checked Then
            TIPO = " A.TIPO IN ('E') "
        ElseIf checkVisualizarSaida.CheckState = CheckState.Checked Then
            TIPO = " A.TIPO IN ('S') "
        ElseIf checkVisualizarES.CheckState = CheckState.Checked Then
            TIPO = " A.TIPO IN ('E','S') "
        End If

        'DATA
        If checkExibirEmissao.CheckState = CheckState.Checked Then
            DATA = " AND A.EMISSAO BETWEEN '" & dtInicioExibir.Value.ToString("yyyy-MM-dd") & "' AND '" & dtFinalExibir.Value.ToString("yyyy-MM-dd") & "' "
        ElseIf checkExibirVenc.CheckState = CheckState.Checked Then
            DATA = " AND A.VENCIMENTO BETWEEN '" & dtInicioExibir.Value.ToString("yyyy-MM-dd") & "' AND '" & dtFinalExibir.Value.ToString("yyyy-MM-dd") & "' "
        ElseIf checkExibirPag.CheckState = CheckState.Checked Then
            DATA = " AND A.PAGAMENTO BETWEEN '" & dtInicioExibir.Value.ToString("yyyy-MM-dd") & "' AND '" & dtFinalExibir.Value.ToString("yyyy-MM-dd") & "' "
        End If

        'ESTATUS
        If checkExibirEstatusAtivo.CheckState = CheckState.Checked Then
            ESTATUS = " AND A.ESTATUS IN ('A') "
        ElseIf checkExibirEstatusDesativado.CheckState = CheckState.Checked Then
            ESTATUS = " AND A.ESTATUS IN ('D') "
        ElseIf checkExibirEstatusAmbos.CheckState = CheckState.Checked Then
            ESTATUS = " AND A.ESTATUS IN ('A','D') "
        End If

        'NUMERO DO FINANCEIRO
        If txtExibirNumero.Text.Length > 0 Then
            FINANCEIRO = " AND A.FINANCEIRO IN (" & TrataCodigos(txtExibirNumero.Text) & ") "
        End If
        'CODIGO DA NATUREZA
        If txtExibirNatureza.Text.Length > 0 Then
            NATUREZA = " AND A.CODIGO IN (" & TrataCodigos(txtExibirNatureza.Text) & ") "
        End If
        'OBSERVAÇÃO
        If txtCadDescricaoMV.Text.Length > 0 Then
            OBS = " AND A.OBSERVACAO LIKE '%" & txtExibirObs.Text & "' "
        End If

        If cboxRelatorio.SelectedIndex = 0 Then
            QUERY = " SELECT TIPO,FINANCEIRO FINANC,CONVERT(VARCHAR,EMISSAO,103)EMISSAO,COUNT(F_ID)PARCELAS,SUM(VALOR)TOTAL," &
                     "SUM(CASE WHEN PAGAMENTO IS NULL THEN 0 ELSE VALOR END) PAGO,SUM(CASE WHEN PAGAMENTO IS NULL AND VENCIMENTO<GETDATE() THEN VALOR ELSE 0 END) VENCIDO," &
                     "CODIGO+'-'+NATUREZA NATUREZA,CONVERT(VARCHAR,OBSERVACAO)OBSERVACAO,ESTATUS FROM ( " &
                     "SELECT M.TIPO,M.ID FINANCEIRO,M.EMISSAO,N.CODIGO,N.NATUREZA,M.OBSERVACAO,M.ESTATUS,  " &
                     "F.ID F_ID,F.VENCIMENTO,F.PAGAMENTO,F.VALOR " &
                     "FROM MOVIMENTOS M " &
                     "INNER JOIN FINANCEIRO F ON F.ID_MOV=M.ID " &
                     "LEFT JOIN NATUREZAS N ON N.ID=M.ID_NAT " &
                     ")A  " &
                     "WHERE  " &
                     " " & TIPO & " " &
                     " " & DATA & " " &
                     " " & ESTATUS & " " &
                     " " & FINANCEIRO & " " &
                     " " & NATUREZA & " " &
                     " " & OBS & "  " &
                     "  GROUP BY TIPO,FINANCEIRO,EMISSAO,CODIGO,NATUREZA,OBSERVACAO,ESTATUS ORDER BY A.EMISSAO DESC "

        ElseIf cboxRelatorio.SelectedIndex = 1 Then
            QUERY = "  SELECT TIPO, " &
                     " SUM(VALOR)TOTAL," &
                     " SUM(CASE WHEN PAGAMENTO IS NULL THEN 0 ELSE VALOR END) PAGO, " &
                     " SUM(CASE WHEN PAGAMENTO IS NULL AND VENCIMENTO<GETDATE() THEN VALOR ELSE 0 END) VENCIDO, " &
                     " CODIGO+'-'+NATUREZA NATUREZA " &
                     " " &
                     " FROM (  " &
                     " SELECT M.TIPO,M.ID FINANCEIRO,M.EMISSAO,N.CODIGO,N.NATUREZA,M.OBSERVACAO,M.ESTATUS,  F.ID F_ID,F.VENCIMENTO,F.PAGAMENTO,F.VALOR  " &
                     " FROM MOVIMENTOS M  " &
                     " INNER JOIN FINANCEIRO F ON F.ID_MOV=M.ID  " &
                     " LEFT JOIN NATUREZAS N ON N.ID=M.ID_NAT )A   " &
                     "WHERE  " &
                     " " & TIPO & " " &
                     " " & DATA & " " &
                     " " & ESTATUS & " " &
                     " " & FINANCEIRO & " " &
                     " " & NATUREZA & " " &
                     " " & OBS & "  " &
                     " GROUP BY TIPO,CODIGO,NATUREZA ORDER BY A.TIPO DESC "
        ElseIf cboxRelatorio.SelectedIndex = 2 Then
            QUERY = " SELECT B.NATUREZA,SUM(TT_ENTRADA)ENTRADAS,SUM(TT_SAIDA)SAIDAS,SUM(TT_ENTRADA)-SUM(TT_SAIDA) SALDO " &
                     "FROM ( " &
                     "SELECT TIPO,   " &
                     "CASE WHEN TIPO = 'E' THEN SUM(VALOR) ELSE 0 END TT_ENTRADA,  " &
                     "CASE WHEN TIPO = 'S' THEN SUM(VALOR) ELSE 0 END TT_SAIDA,  " &
                     "CASE WHEN TIPO = 'E' THEN SUM(CASE WHEN PAGAMENTO IS NULL THEN 0 ELSE VALOR END)  ELSE 0 END PAGO_ENTRADA,  " &
                     "CASE WHEN TIPO = 'S' THEN SUM(CASE WHEN PAGAMENTO IS NULL THEN 0 ELSE VALOR END)  ELSE 0 END PAGO_SAIDA, " &
                     "CASE WHEN TIPO = 'E' THEN SUM(CASE WHEN PAGAMENTO IS NULL AND VENCIMENTO<GETDATE() THEN VALOR ELSE 0 END)  ELSE 0 END VENCIDO_ENTRADA,   " &
                     "CASE WHEN TIPO = 'S' THEN SUM(CASE WHEN PAGAMENTO IS NULL AND VENCIMENTO<GETDATE() THEN VALOR ELSE 0 END)  ELSE 0 END VENCIDO_SAIDA,   " &
                     "CODIGO+'-'+NATUREZA NATUREZA    " &
                     "FROM (   SELECT M.TIPO,M.ID FINANCEIRO,M.EMISSAO,N.CODIGO,N.NATUREZA,M.OBSERVACAO,M.ESTATUS,  F.ID F_ID,F.VENCIMENTO,F.PAGAMENTO,F.VALOR    " &
                     "FROM MOVIMENTOS M    " &
                     "INNER JOIN FINANCEIRO F ON F.ID_MOV=M.ID    " &
                     "LEFT JOIN NATUREZAS N ON N.ID=M.ID_NAT )A   " &
                     "WHERE  " &
                     " " & TIPO & " " &
                     " " & DATA & " " &
                     " " & ESTATUS & " " &
                     " " & FINANCEIRO & " " &
                     " " & NATUREZA & " " &
                     " " & OBS & "  " &
                     "GROUP BY TIPO,CODIGO,NATUREZA )B GROUP BY B.NATUREZA"
        End If



        'MsgBox(QUERY)

        If F = True Then
            PREENCHERGRID(dgExibirMV, QUERY)
            If dgExibirMV.RowCount < 1 And cboxRelatorio.SelectedIndex = 0 Then
                dgExibirFinanceiroMV.DataSource = Nothing
            End If
        Else
            Return QUERY
        End If

    End Function


    Private Sub btnVisualizar_Click(sender As Object, e As EventArgs) Handles btnVisualizar.Click
        Try
            ' MsgBox(cboxRelatorio.SelectedIndex)
            MontarQueryExibir(True)
            COLORIRGRD(Me.dgExibirMV)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub



    Private Sub dgExibirMV_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgExibirMV.CellEnter
        If dgExibirMV.RowCount < 1 Then
            dgExibirFinanceiroMV.DataSource = Nothing
        ElseIf dgExibirMV.RowCount >= 1 And cboxRelatorio.SelectedIndex = 0 Then
            Dim FINANCEIRO As String = dgExibirMV.CurrentRow.Cells(1).Value()
            PREENCHERGRID(Me.dgExibirFinanceiroMV, "SELECT ROW_NUMBER() OVER (PARTITION BY F.ID_MOV ORDER BY F.ID_MOV)N,CONVERT(VARCHAR,F.VENCIMENTO,103)  VENCIMENTO,ISNULL(CONVERT(VARCHAR,F.PAGAMENTO,103),'')  PAGAMENTO,F.VALOR FROM FINANCEIRO F WHERE F.ID_MOV='" & FINANCEIRO & "' ")
            COLORIRGRD(Me.dgExibirFinanceiroMV)
        Else
            dgExibirFinanceiroMV.DataSource = Nothing
        End If
    End Sub

    Private Sub dtInicioExibir_ValueChanged(sender As Object, e As EventArgs) Handles dtInicioExibir.ValueChanged
        dtFinalExibir.Value = DateValue(dtInicioExibir.Value.Year & "/" & dtInicioExibir.Value.Month & "/" & Date.DaysInMonth(dtInicioExibir.Value.Year, dtInicioExibir.Value.Month))
    End Sub

    Private Sub frmLancamentosMV_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        MenuPrincipal()
    End Sub

    Private Sub SideNavItem3_Click(sender As Object, e As EventArgs) Handles SideNavItem3.Click
        'cboxCadDias.SelectedIndex = 0
        PREENCHERCBOX(cboxCadNaturezas, "SELECT RTRIM(N.CODIGO)+'-'+RTRIM(NATUREZA) NATUREZA FROM NATUREZAS N WHERE N.ESTATUS='A'", "NATUREZA")
        PREENCHERGRIDMV()
    End Sub
    Public Sub PREENCHERGRIDMV()
        If cboxCadDias.Text.Length < 1 Then
            Dias = 30
        Else
            Dias = cboxCadDias.Text
        End If

        'MsgBox(Dias)

        Dim Q As String = " DECLARE @DATE AS DATETIME, @DIAS AS INT SET @DIAS=" & Dias & " SET @DATE=GETDATE() SET @DATE=DATEADD(DAY,-(@DIAS+1),@DATE) " &
                             "SELECT TIPO,FINANCEIRO,CONVERT(VARCHAR,EMISSAO,103)EMISSAO,COUNT(F_ID)PARCELAS,SUM(VALOR)TOTAL, " &
                             "SUM(CASE WHEN PAGAMENTO IS NULL THEN 0 ELSE VALOR END) PAGO, " &
                             "SUM(CASE WHEN PAGAMENTO IS NULL AND VENCIMENTO<GETDATE() THEN VALOR ELSE 0 END) VENCIDO, " &
                             "CODIGO+'-'+NATUREZA NATUREZA,OBSERVACAO,ESTATUS FROM  " &
                             "(  SELECT CASE WHEN M.TIPO='E' THEN 'ENTRADA' WHEN M.TIPO='S' THEN 'SAIDA' END TIPO,RTRIM(M.ID) FINANCEIRO,M.EMISSAO,N.CODIGO,N.NATUREZA,M.OBSERVACAO," &
                             "CASE WHEN M.ESTATUS='A' THEN 'ATIVO' WHEN M.ESTATUS='D' THEN 'DESATIVADO' END ESTATUS,   rTRIM(F.ID) F_ID,F.VENCIMENTO,F.PAGAMENTO,F.VALOR   " &
                             "FROM MOVIMENTOS M   " &
                             "INNER JOIN FINANCEIRO F ON F.ID_MOV=M.ID   " &
                             "LEFT JOIN NATUREZAS N ON N.ID=M.ID_NAT   " &
                             ")A WHERE EMISSAO>=@DATE " &
                             "GROUP BY TIPO,FINANCEIRO,EMISSAO,CODIGO,NATUREZA,OBSERVACAO,ESTATUS ORDER BY A.EMISSAO DESC"
        'MsgBox(Q)
        PREENCHERGRID(dgCadMV, Q)
    End Sub

    Private Sub cboxCadDias_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboxCadDias.SelectedIndexChanged
        PREENCHERGRIDMV()
    End Sub

    Private Sub dgCadMV_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgCadMV.CellEnter
        txtCadIDMV.Text = dgCadMV.CurrentRow.Cells(1).Value()
        cboxCadTipoMV.Text = dgCadMV.CurrentRow.Cells(0).Value()
        dtCadEmissao.Value = dgCadMV.CurrentRow.Cells(2).Value()
        cboxCadNaturezas.Text = dgCadMV.CurrentRow.Cells(7).Value()
        txtCadDescricaoMV.Text = dgCadMV.CurrentRow.Cells(8).Value()
        cboxCadEstatusMV.Text = dgCadMV.CurrentRow.Cells(9).Value()

        PREENCHERGRID(dgCadFinanceiro, "SELECT ID,ID_MOV,CONVERT(VARCHAR,VENCIMENTO,103)DT_VENCTO,CONVERT(VARCHAR,PAGAMENTO,103)DT_PAGTO,VALOR FROM FINANCEIRO WHERE ID_MOV='" & dgCadMV.CurrentRow.Cells(1).Value().ToString & "' ")
    End Sub

    Private Sub dgCadFinanceiro_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgCadFinanceiro.CellEnter
        If dgCadFinanceiro.RowCount > 0 Then
            If OPERACAO = "" Or OPERACAO = "ALTERAR" Then
                INDEX_ROW = dgCadFinanceiro.CurrentCell.RowIndex
                INDEX_ITEM = dgCadFinanceiro.CurrentCell.ColumnIndex
                txtCadIdMVFinanc.Text = dgCadFinanceiro.CurrentRow.Cells(1).Value()
                txtCadIDFinanc.Text = dgCadFinanceiro.CurrentRow.Cells(0).Value()
                dtCadVenc.Value = dgCadFinanceiro.CurrentRow.Cells(2).Value()
                If dgCadFinanceiro.CurrentRow.Cells(3).Value.ToString = "" Then
                    checkCadPago.CheckState = CheckState.Unchecked
                    dtCadPag.Visible = False
                    btnCadPagarFinanc.Enabled = True
                Else
                    checkCadPago.CheckState = CheckState.Checked
                    dtCadPag.Visible = True
                    dtCadPag.Value = dgCadFinanceiro.CurrentRow.Cells(3).Value()
                    btnCadPagarFinanc.Enabled = False
                End If
                txtCadValor.Text = dgCadFinanceiro.CurrentRow.Cells(4).Value()
            ElseIf OPERACAO = "INSERIR" And dgCadFinanceiro.RowCount < 1 Then
                dtCadVenc.Value = dgCadFinanceiro.CurrentRow.Cells(1).Value()
                If dgCadFinanceiro.CurrentRow.Cells(2).Value.ToString = "" Then
                    checkCadPago.CheckState = CheckState.Unchecked
                    dtCadPag.Visible = False
                Else
                    checkCadPago.CheckState = CheckState.Checked
                    dtCadPag.Visible = True
                    dtCadPag.Value = dgCadFinanceiro.CurrentRow.Cells(2).Value()
                End If
                txtCadValor.Text = dgCadFinanceiro.CurrentRow.Cells(3).Value()
            End If
        End If

    End Sub

    Private Sub dgCadFinanceiro_DataSourceChanged(sender As Object, e As EventArgs) Handles dgCadFinanceiro.DataSourceChanged
        Dim Valor As Decimal = 0
        If dgCadFinanceiro.RowCount > 0 And dgCadFinanceiro.ColumnCount > 4 Then
            For i = 0 To dgCadFinanceiro.RowCount - 1 Step 1
                Valor = Valor + CDec(dgCadFinanceiro.Rows(i).Cells(4).Value)
            Next
        ElseIf dgCadFinanceiro.RowCount > 0 And dgCadFinanceiro.ColumnCount = 4 Then
            For i = 0 To dgCadFinanceiro.RowCount - 1 Step 1
                Valor = Valor + CDec(dgCadFinanceiro.Rows(i).Cells(3).Value)
            Next
        End If
        lblCadValor.Text = Valor
    End Sub
    Private Sub ATIVARBOTOES(TIPO As String)
        ' OPÇÕES: GRAVAR | INSERIR | ALTERAR | BLOQUEADO
        If TIPO = "GRAVAR" Then
            btnInserir.Enabled = True
            btnAlterar.Enabled = True
            btnExcluir.Enabled = True
            btnGravar.Enabled = False
            btnCancelar.Enabled = False
            btnCadGravarFinanc.Enabled = False
            btnCadExcluirFinanc.Enabled = False
            btnCadPagarFinanc.Enabled = True
            dgCadMV.Enabled = True
            OPERACAO = ""
        ElseIf TIPO = "INSERIR" Or TIPO = "ALTERAR" Then
            btnInserir.Enabled = False
            btnAlterar.Enabled = False
            btnExcluir.Enabled = False
            btnCancelar.Enabled = True
            btnGravar.Enabled = True
            btnCadGravarFinanc.Enabled = True
            btnCadExcluirFinanc.Enabled = True
            btnCadPagarFinanc.Enabled = False
            dgCadMV.Enabled = False

        ElseIf TIPO = "BLOQUEADO" Then
            btnInserir.Enabled = False
            btnAlterar.Enabled = False
            btnExcluir.Enabled = False
            btnCancelar.Enabled = False
            btnGravar.Enabled = False
            btnCadGravarFinanc.Enabled = False
            btnCadExcluirFinanc.Enabled = False
            dgCadMV.Enabled = False
            btnCadPagarFinanc.Enabled = False
        End If
    End Sub

    Private Sub checkCadPago_CheckedChanged(sender As Object, e As EventArgs) Handles checkCadPago.CheckedChanged
        'If OPERACAO = "INSERIR" Or OPERACAO = "EDITAR" Then
        If checkCadPago.CheckState = CheckState.Checked Then
            dtCadPag.Visible = True
        Else
            dtCadPag.Visible = False
        End If

        'End If
    End Sub
    Public Sub TRATAGRID()

        Dim workCol As DataColumn = TB_FINANC.Columns.Add("ID", GetType(Int32))
        workCol.AutoIncrement = True
        workCol.AutoIncrementSeed = 1
        workCol.AutoIncrementStep = 1
        workCol.AllowDBNull = True
        workCol.Unique = False
        TB_FINANC.Columns.Add("Vencto", GetType(Date))

        TB_FINANC.Columns.Add("Pagto", GetType(Date))
        TB_FINANC.Columns.Add("Valor", GetType(Double))
    End Sub
    Private Sub btnInserir_Click(sender As Object, e As EventArgs) Handles btnInserir.Click
        If VALIDA_ACESSO(Me, MOD_USUARIO, "INSERIR") = True Then
            OPERACAO = "INSERIR"
            ATIVARBOTOES(OPERACAO)
            dgCadFinanceiro.DataSource = Nothing
            txtCadIDMV.ReadOnly = True
            If DT_INSERT = Nothing Then
                TIPO_MV = 1
            End If
            cboxCadTipoMV.SelectedIndex = TIPO_MV
            cboxCadNaturezas.SelectedIndex = 0
            cboxCadEstatusMV.SelectedIndex = 0
            txtCadDescricaoMV.Text = ""
            txtCadIdMVFinanc.ReadOnly = True
            txtCadIDFinanc.ReadOnly = True
            If DT_INSERT = Nothing Then
                DT_INSERT = Now.ToShortDateString
            End If
            dtCadEmissao.Value = DT_INSERT
            'TRATAGRID()

            dtCadVenc.Value = DT_INSERT
            dtCadPag.Value = DT_INSERT
            txtCadValor.Text = "0,00"
            TB_FINANC.Clear()
            PanelPesquisaCadMV.Enabled = False

        End If
    End Sub

    Private Sub btnAlterar_Click(sender As Object, e As EventArgs) Handles btnAlterar.Click
        If VALIDA_ACESSO(Me, MOD_USUARIO, "ALTERAR") = True Then
            OPERACAO = "ALTERAR"
            ATIVARBOTOES(OPERACAO)
            txtCadIDMV.ReadOnly = True
            cboxCadTipoMV.Enabled = False
            cboxCadNaturezas.Enabled = False
            PanelPesquisaCadMV.Enabled = False
        End If
    End Sub

    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click
        If VALIDA_ACESSO(Me, MOD_USUARIO, "EXCLUIR") = True Then
            Dim a As String = MessageBoxEx.Show("Tem Certeza que deseja Excluir este Registro?", "Solution's Bom Pastor", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
            If a = MsgBoxResult.Cancel Then
                MsgBox(" A Operação foi Cancelada.")
            Else
                EXECUTARQUERY("DELETE FROM FINANCEIRO WHERE ID='" & txtCadIDFinanc.Text & "' AND ID_MOV='" & txtCadIdMVFinanc.Text & "'")
                EXECUTARQUERY("DELETE FROM MOVIMENTOS WHERE ID='" & txtCadIDMV.Text & "'")
                PREENCHERGRIDMV()
            End If
            ATIVARBOTOES("GRAVAR")
        Else
            Exit Sub
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        If OPERACAO = "INSERIR" Then
            TB_FINANC.Clear()
        End If
        'txtCadIDMV.ReadOnly = True
        cboxCadTipoMV.Enabled = True
        cboxCadNaturezas.Enabled = True
        dgCadFinanceiro.DataSource = Nothing
        dgCadFinanceiro.Rows.Clear()
        PanelPesquisaCadMV.Enabled = True
        PREENCHERGRIDMV()
        ATIVARBOTOES("GRAVAR")
    End Sub

    Private Sub btnGravar_Click(sender As Object, e As EventArgs) Handles btnGravar.Click


        If OPERACAO = "INSERIR" Then
            Dim NAT() As String = cboxCadNaturezas.Text.Split("-")
            Dim N As List(Of String) = RETORNA_LISTA("SELECT ID FROM NATUREZAS WHERE CODIGO='" & NAT(0) & "'", "ID")
            EXECUTARQUERY("INSERT INTO MOVIMENTOS VALUES('" & cboxCadTipoMV.Text.Substring(0, 1) & "','" & dtCadEmissao.Value.ToString("yyyy-MM-dd") & "','" & N(0) & "','" & txtCadDescricaoMV.Text & "','" & cboxCadEstatusMV.Text.Substring(0, 1) & "')")
            Dim L As List(Of String) = RETORNA_LISTA("SELECT MAX(ID)NUM FROM MOVIMENTOS ", "NUM")
            If L.Count < 1 Then
            Else
                'MsgBox(L(0))
                For I = 0 To dgCadFinanceiro.RowCount - 1 Step 1
                    If IsDBNull(dgCadFinanceiro.Rows(I).Cells(2).Value) Then
                        EXECUTARQUERY("INSERT INTO FINANCEIRO VALUES ('" & L(0) & "','" & Convert.ToDateTime(dgCadFinanceiro.Rows(I).Cells(1).Value).ToString("yyyy-MM-dd") & "',NULL,'" & dgCadFinanceiro.Rows(I).Cells(3).Value.ToString.Replace(",", ".") & "')")
                    Else
                        EXECUTARQUERY("INSERT INTO FINANCEIRO VALUES ('" & L(0) & "','" & Convert.ToDateTime(dgCadFinanceiro.Rows(I).Cells(1).Value).ToString("yyyy-MM-dd") & "','" & Convert.ToDateTime(dgCadFinanceiro.Rows(I).Cells(2).Value).ToString("yyyy-MM-dd") & "','" & dgCadFinanceiro.Rows(I).Cells(3).Value.ToString.Replace(",", ".") & "')")
                        'MsgBox(Convert.ToDateTime(dgCadFinanceiro.Rows(I).Cells(1).Value).ToString("yyyy-MM-dd"))
                    End If
                Next
            End If
            '.Value.ToString("yyyy-MM-dd")
            dgCadFinanceiro.DataSource = Nothing
            dgCadFinanceiro.Rows.Clear()
            TB_FINANC.Clear()
            'PREENCHERGRIDMV()
        ElseIf OPERACAO = "ALTERAR" Then
            EXECUTARQUERY("UPDATE dbo.MOVIMENTOS SET OBSERVACAO='" & txtCadDescricaoMV.Text & "', ESTATUS='" & cboxCadEstatusMV.Text.Substring(0, 1) & "', EMISSAO='" & dtCadEmissao.Value.ToString("yyyy-MM-dd") & "'  WHERE ID='" & txtCadIDMV.Text & "'")

        End If
        PREENCHERGRIDMV()
        PanelPesquisaCadMV.Enabled = True
        ATIVARBOTOES("GRAVAR")
    End Sub

    Private Sub txtCadValor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCadValor.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = "," Or e.KeyChar = "." Or e.KeyChar = Convert.ToChar(Keys.Delete) Or e.KeyChar = Convert.ToChar(Keys.Back))
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then

        End If
    End Sub




    Private Sub txtCadIdMVPesq_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCadIdMVPesq.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = "," Or e.KeyChar = Convert.ToChar(Keys.Delete) Or e.KeyChar = Convert.ToChar(Keys.Back))
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            If txtCadIdMVPesq.TextLength > 0 Then
                Dim COD As String = TrataCodigos(txtCadIdMVPesq.Text)
                Dim Q As String = " DECLARE @DATE AS DATETIME, @DIAS AS INT SET @DIAS=" & cboxCadDias.Text & " SET @DATE=GETDATE() SET @DATE=DATEADD(DAY,-@DIAS,@DATE) " &
    "SELECT TIPO,FINANCEIRO,CONVERT(VARCHAR,EMISSAO,103)EMISSAO,COUNT(F_ID)PARCELAS,SUM(VALOR)TOTAL, " &
    "SUM(CASE WHEN PAGAMENTO IS NULL THEN 0 ELSE VALOR END) PAGO, " &
    "SUM(CASE WHEN PAGAMENTO IS NULL AND VENCIMENTO<GETDATE() THEN VALOR ELSE 0 END) VENCIDO, " &
    "CODIGO+'-'+NATUREZA NATUREZA,OBSERVACAO,ESTATUS FROM  " &
    "(  SELECT CASE WHEN M.TIPO='E' THEN 'ENTRADA' WHEN M.TIPO='S' THEN 'SAIDA' END TIPO,RTRIM(M.ID) FINANCEIRO,M.EMISSAO,N.CODIGO,N.NATUREZA,M.OBSERVACAO," &
    "CASE WHEN M.ESTATUS='A' THEN 'ATIVO' WHEN M.ESTATUS='D' THEN 'DESATIVADO' END ESTATUS,  RTRIM(F.ID) F_ID,F.VENCIMENTO,F.PAGAMENTO,F.VALOR   " &
    "FROM MOVIMENTOS M   " &
    "INNER JOIN FINANCEIRO F ON F.ID_MOV=M.ID   " &
    "LEFT JOIN NATUREZAS N ON N.ID=M.ID_NAT   " &
    ")A WHERE FINANCEIRO IN (" & COD & ") " &
    "GROUP BY TIPO,FINANCEIRO,EMISSAO,CODIGO,NATUREZA,OBSERVACAO,ESTATUS"
                PREENCHERGRID(dgCadMV, Q)
            Else
                PREENCHERGRIDMV()
            End If

        End If

    End Sub

    Private Sub btnCadGravarFinanc_Click(sender As Object, e As EventArgs) Handles btnCadGravarFinanc.Click
        If OPERACAO = "INSERIR" Then

            Try
                If dtCadVenc.Value < dtCadEmissao.Value Then
                    MessageBoxEx.Show("A Data do Vencimento é menor do que a Data de Emissão." & vbCrLf & "Favor Corrigir!")
                    Exit Sub
                End If
                'TB_FINANC.Clear()
                Dim dr As DataRow
                dr = TB_FINANC.NewRow()

                dr.Item(1) = dtCadVenc.Value.ToShortDateString
                If checkCadPago.CheckState = CheckState.Checked Then
                    dr.Item(2) = dtCadPag.Value.ToShortDateString
                Else
                    dr.Item(2) = DBNull.Value
                End If
                dr.Item(3) = txtCadValor.Text
                'dr.Item("Classif") = "Classificação do Produto"
                TB_FINANC.Rows.Add(dr)

                dgCadFinanceiro.DataSource = TB_FINANC
                Dim valor As Double = 0.0
                For i = 0 To dgCadFinanceiro.RowCount - 1 Step 1
                    valor = valor + CDec(dgCadFinanceiro.Rows(i).Cells(3).Value)
                Next
                dgCadFinanceiro.Refresh()
                lblCadValor.Text = valor
            Catch ex As Exception

                MsgBox("A Data de Vencimento Já Exite! " & ex.ToString, MsgBoxStyle.Critical)
            End Try

        ElseIf OPERACAO = "ALTERAR" Then
            If checkCadPago.CheckState = CheckState.Checked Then
                EXECUTARQUERY("UPDATE FINANCEIRO SET VENCIMENTO='" & dtCadVenc.Value.ToString("yyyy-MM-dd") & "',PAGAMENTO='" & dtCadPag.Value.ToString("yyyy-MM-dd") & "',VALOR='" & txtCadValor.Text.ToString.Replace(",", ".") & "' FROM FINANCEIRO WHERE ID='" & txtCadIDFinanc.Text & "' AND ID_MOV='" & txtCadIdMVFinanc.Text & "'")

            Else
                EXECUTARQUERY("UPDATE FINANCEIRO SET VENCIMENTO='" & dtCadVenc.Value.ToString("yyyy-MM-dd") & "',PAGAMENTO=NULL,VALOR='" & txtCadValor.Text.ToString.Replace(",", ".") & "' FROM FINANCEIRO WHERE ID='" & txtCadIDFinanc.Text & "' AND ID_MOV='" & txtCadIdMVFinanc.Text & "'")
                'MsgBox("UPDATE FINANCEIRO SET VENCIMENTO='" & dtCadVenc.Value.ToString("yyyy-MM-dd") & "',PAGAMENTO=NULL,VALOR='" & txtCadValor.Text.ToString.Replace(",", ".") & "' FROM FINANCEIRO WHERE ID='" &  & "' AND ID_MOV='" & txtCadIDFinanc.Text & "'")
            End If
            PREENCHERGRID(dgCadFinanceiro, "SELECT ID,ID_MOV,CONVERT(VARCHAR,VENCIMENTO,103)DT_VENCTO,CONVERT(VARCHAR,PAGAMENTO,103)DT_PAGTO,VALOR FROM FINANCEIRO WHERE ID_MOV='" & txtCadIDMV.Text & "' ")
            'PREENCHERGRIDMV()

        End If

    End Sub

    Private Sub btnExibirRelatorio_Click(sender As Object, e As EventArgs) Handles btnExibirRelatorio.Click
        frmRelatorios2.Close()
        Dim Q As String = MontarQueryExibir(False)
        VALIDA_ACESSO(frmRelatorios2, MOD_USUARIO, "ABRIR")
        'frmRelatorios.ABRE_RELATORIO2(Q, "A", frmRelatorios.RELMOVIMENTOSBindingSource)

        If cboxRelatorio.SelectedIndex = 0 Then
            frmRelatorios2.GeraRelatorio("LOCAL", Q, "Report4.rdlc", "A", "DataSet1", dtInicioExibir.Value.ToString("yyyy-MM-dd"), dtFinalExibir.Value.ToString("yyyy-MM-dd"))
        ElseIf cboxRelatorio.SelectedIndex = 1 Then
            frmRelatorios2.GeraRelatorio("LOCAL", Q, "Report5.rdlc", "A", "DataSet1", dtInicioExibir.Value.ToString("yyyy-MM-dd"), dtFinalExibir.Value.ToString("yyyy-MM-dd"))
        ElseIf cboxRelatorio.SelectedIndex = 2 Then
            frmRelatorios2.GeraRelatorio("LOCAL", Q, "Report6.rdlc", "A", "DataSet1", dtInicioExibir.Value.ToString("yyyy-MM-dd"), dtFinalExibir.Value.ToString("yyyy-MM-dd"))
        End If


    End Sub

    Private Sub btnCadExcluirFinanc_Click(sender As Object, e As EventArgs) Handles btnCadExcluirFinanc.Click
        If VALIDA_ACESSO(Me, MOD_USUARIO, "EXCLUIR") = True And dgCadFinanceiro.Rows.Count > 0 Then
            Dim a As String = MessageBoxEx.Show("Tem Certeza que deseja Excluir este Registro?", "Solution's Bom Pastor", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
            If a = MsgBoxResult.Cancel Then
                MsgBox(" A Operação foi Cancelada.")
            Else
                EXECUTARQUERY("DELETE FROM FINANCEIRO WHERE ID='" & txtCadIDFinanc.Text & "' AND ID_MOV='" & txtCadIdMVFinanc.Text & "'")
            End If
            ATIVARBOTOES("GRAVAR")

        Else
            Exit Sub
        End If
    End Sub

    Private Sub btnCadPagarFinanc_Click(sender As Object, e As EventArgs) Handles btnCadPagarFinanc.Click
        If VALIDA_ACESSO(Me, MOD_USUARIO, "ALTERAR") = True And dgCadFinanceiro.Rows.Count > 0 Then
            EXECUTARQUERY("UPDATE FINANCEIRO SET PAGAMENTO='" & Now.Date.ToString("yyyy-MM-dd") & "' FROM FINANCEIRO WHERE ID='" & txtCadIDFinanc.Text & "' AND ID_MOV='" & txtCadIdMVFinanc.Text & "'")
            'PREENCHERGRID(dgCadFinanceiro, "SELECT ID,ID_MOV,CONVERT(VARCHAR,VENCIMENTO,103)DT_VENCTO,CONVERT(VARCHAR,PAGAMENTO,103)DT_PAGTO,VALOR FROM FINANCEIRO WHERE ID_MOV='" & txtCadIDMV.Text & "' ")
        Else
            Exit Sub
        End If

    End Sub

    Private Sub btnCadPagarFinanc_KeyUp(sender As Object, e As KeyEventArgs) Handles btnCadPagarFinanc.KeyUp
        PREENCHERGRID(dgCadFinanceiro, "SELECT ID,ID_MOV,CONVERT(VARCHAR,VENCIMENTO,103)DT_VENCTO,CONVERT(VARCHAR,PAGAMENTO,103)DT_PAGTO,VALOR FROM FINANCEIRO WHERE ID_MOV='" & txtCadIDMV.Text & "' ")
    End Sub

    Private Sub btnCadExcluirFinanc_KeyUp(sender As Object, e As KeyEventArgs) Handles btnCadExcluirFinanc.KeyUp
        PREENCHERGRID(dgCadFinanceiro, "SELECT ID,ID_MOV,CONVERT(VARCHAR,VENCIMENTO,103)DT_VENCTO,CONVERT(VARCHAR,PAGAMENTO,103)DT_PAGTO,VALOR FROM FINANCEIRO WHERE ID_MOV='" & txtCadIDMV.Text & "' ")
    End Sub

    Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click
        Me.Close()

    End Sub

    Private Sub SideNavItem2_Click(sender As Object, e As EventArgs) Handles SideNavItem2.Click
        If OPERACAO <> "" Then
            ATIVARBOTOES("GRAVAR")
        End If
    End Sub

    Private Sub dtCadEmissao_ValueChanged(sender As Object, e As EventArgs) Handles dtCadEmissao.ValueChanged

        If OPERACAO = "INSERIR" Or OPERACAO = "ALTERAR" Then
            DT_INSERT = dtCadEmissao.Value
            dtCadVenc.Value = DT_INSERT
            dtCadPag.Value = DT_INSERT
        End If

    End Sub

    Private Sub cboxCadTipoMV_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboxCadTipoMV.SelectedIndexChanged
        If OPERACAO = "INSERIR" Then
            TIPO_MV = cboxCadTipoMV.SelectedIndex
        End If
    End Sub

    Private Sub dtCadMVPesqInicio_ValueChanged(sender As Object, e As EventArgs) Handles dtCadMVPesqInicio.ValueChanged
        dtCadMVPesqFinal.Value = DateValue(dtCadMVPesqInicio.Value.Year & "/" & dtCadMVPesqInicio.Value.Month & "/" & Date.DaysInMonth(dtCadMVPesqInicio.Value.Year, dtCadMVPesqInicio.Value.Month))
    End Sub

    Private Sub btnCadMVPesqPeriodo_Click(sender As Object, e As EventArgs) Handles btnCadMVPesqPeriodo.Click
        Dim COD As String = TrataCodigos(txtCadIdMVPesq.Text)
        Dim Q As String = "SELECT TIPO,FINANCEIRO,CONVERT(VARCHAR,EMISSAO,103)EMISSAO,COUNT(F_ID)PARCELAS,SUM(VALOR)TOTAL, " &
            "SUM(CASE WHEN PAGAMENTO IS NULL THEN 0 ELSE VALOR END) PAGO, " &
            "SUM(CASE WHEN PAGAMENTO IS NULL AND VENCIMENTO<GETDATE() THEN VALOR ELSE 0 END) VENCIDO, " &
            "CODIGO+'-'+NATUREZA NATUREZA,OBSERVACAO,ESTATUS FROM  " &
            "(  SELECT CASE WHEN M.TIPO='E' THEN 'ENTRADA' WHEN M.TIPO='S' THEN 'SAIDA' END TIPO,RTRIM(M.ID) FINANCEIRO,M.EMISSAO,N.CODIGO,N.NATUREZA,M.OBSERVACAO," &
            "CASE WHEN M.ESTATUS='A' THEN 'ATIVO' WHEN M.ESTATUS='D' THEN 'DESATIVADO' END ESTATUS,  RTRIM(F.ID) F_ID,F.VENCIMENTO,F.PAGAMENTO,F.VALOR   " &
            "FROM MOVIMENTOS M   " &
            "INNER JOIN FINANCEIRO F ON F.ID_MOV=M.ID   " &
            "LEFT JOIN NATUREZAS N ON N.ID=M.ID_NAT   " &
            ")A WHERE EMISSAO BETWEEN '" & dtCadMVPesqInicio.Value.ToString("yyyy-MM-dd") & "' AND '" & dtCadMVPesqFinal.Value.ToString("yyyy-MM-dd") & "' " &
            "GROUP BY TIPO,FINANCEIRO,EMISSAO,CODIGO,NATUREZA,OBSERVACAO,ESTATUS"
        PREENCHERGRID(dgCadMV, Q)
    End Sub
End Class