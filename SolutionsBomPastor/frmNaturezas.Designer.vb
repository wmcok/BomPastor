<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNaturezas
    'Inherits System.Windows.Forms.Form
    Inherits DevComponents.DotNetBar.Metro.MetroForm
    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: O procedimento a seguir é exigido pelo Windows Form Designer
    'Ele pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PanelEx5 = New DevComponents.DotNetBar.PanelEx()
        Me.btnFechar = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancelar = New DevComponents.DotNetBar.ButtonX()
        Me.btnGravar = New DevComponents.DotNetBar.ButtonX()
        Me.btnExcluir = New DevComponents.DotNetBar.ButtonX()
        Me.btnAlterar = New DevComponents.DotNetBar.ButtonX()
        Me.btnInserir = New DevComponents.DotNetBar.ButtonX()
        Me.PanelEx3 = New DevComponents.DotNetBar.PanelEx()
        Me.txtNatureza = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX13 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX14 = New DevComponents.DotNetBar.LabelX()
        Me.cboxEstatus = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.ComboItem3 = New DevComponents.Editors.ComboItem()
        Me.ComboItem4 = New DevComponents.Editors.ComboItem()
        Me.txtDescricao = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX16 = New DevComponents.DotNetBar.LabelX()
        Me.txtCodigo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX17 = New DevComponents.DotNetBar.LabelX()
        Me.dgNaturezas = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.txtID = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX18 = New DevComponents.DotNetBar.LabelX()
        Me.PanelEx5.SuspendLayout()
        Me.PanelEx3.SuspendLayout()
        CType(Me.dgNaturezas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelEx5
        '
        Me.PanelEx5.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx5.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx5.Controls.Add(Me.btnFechar)
        Me.PanelEx5.Controls.Add(Me.btnCancelar)
        Me.PanelEx5.Controls.Add(Me.btnGravar)
        Me.PanelEx5.Controls.Add(Me.btnExcluir)
        Me.PanelEx5.Controls.Add(Me.btnAlterar)
        Me.PanelEx5.Controls.Add(Me.btnInserir)
        Me.PanelEx5.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx5.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelEx5.Location = New System.Drawing.Point(497, 0)
        Me.PanelEx5.Name = "PanelEx5"
        Me.PanelEx5.Size = New System.Drawing.Size(117, 332)
        Me.PanelEx5.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx5.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx5.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx5.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx5.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx5.Style.GradientAngle = 90
        Me.PanelEx5.TabIndex = 22
        '
        'btnFechar
        '
        Me.btnFechar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnFechar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFechar.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnFechar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFechar.Location = New System.Drawing.Point(4, 299)
        Me.btnFechar.Name = "btnFechar"
        Me.btnFechar.Size = New System.Drawing.Size(108, 28)
        Me.btnFechar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnFechar.TabIndex = 6
        Me.btnFechar.Text = "Fechar"
        '
        'btnCancelar
        '
        Me.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnCancelar.Enabled = False
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Location = New System.Drawing.Point(4, 170)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(108, 28)
        Me.btnCancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCancelar.TabIndex = 4
        Me.btnCancelar.Text = "Cancelar"
        '
        'btnGravar
        '
        Me.btnGravar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnGravar.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnGravar.Enabled = False
        Me.btnGravar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGravar.Location = New System.Drawing.Point(4, 204)
        Me.btnGravar.Name = "btnGravar"
        Me.btnGravar.Size = New System.Drawing.Size(108, 55)
        Me.btnGravar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnGravar.TabIndex = 5
        Me.btnGravar.Text = "Gravar"
        '
        'btnExcluir
        '
        Me.btnExcluir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnExcluir.ColorTable = DevComponents.DotNetBar.eButtonColor.MagentaWithBackground
        Me.btnExcluir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcluir.Location = New System.Drawing.Point(4, 125)
        Me.btnExcluir.Name = "btnExcluir"
        Me.btnExcluir.Size = New System.Drawing.Size(108, 24)
        Me.btnExcluir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnExcluir.TabIndex = 3
        Me.btnExcluir.Text = "Excluir"
        '
        'btnAlterar
        '
        Me.btnAlterar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAlterar.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnAlterar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAlterar.Location = New System.Drawing.Point(4, 74)
        Me.btnAlterar.Name = "btnAlterar"
        Me.btnAlterar.Size = New System.Drawing.Size(108, 28)
        Me.btnAlterar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAlterar.TabIndex = 2
        Me.btnAlterar.Text = "Alterar"
        '
        'btnInserir
        '
        Me.btnInserir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnInserir.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnInserir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInserir.Location = New System.Drawing.Point(4, 37)
        Me.btnInserir.Name = "btnInserir"
        Me.btnInserir.Size = New System.Drawing.Size(108, 28)
        Me.btnInserir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnInserir.TabIndex = 1
        Me.btnInserir.Text = "Inserir"
        '
        'PanelEx3
        '
        Me.PanelEx3.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx3.Controls.Add(Me.txtNatureza)
        Me.PanelEx3.Controls.Add(Me.LabelX13)
        Me.PanelEx3.Controls.Add(Me.LabelX14)
        Me.PanelEx3.Controls.Add(Me.cboxEstatus)
        Me.PanelEx3.Controls.Add(Me.txtDescricao)
        Me.PanelEx3.Controls.Add(Me.LabelX16)
        Me.PanelEx3.Controls.Add(Me.txtCodigo)
        Me.PanelEx3.Controls.Add(Me.LabelX17)
        Me.PanelEx3.Controls.Add(Me.dgNaturezas)
        Me.PanelEx3.Controls.Add(Me.txtID)
        Me.PanelEx3.Controls.Add(Me.LabelX18)
        Me.PanelEx3.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelEx3.Location = New System.Drawing.Point(0, 0)
        Me.PanelEx3.Name = "PanelEx3"
        Me.PanelEx3.Size = New System.Drawing.Size(497, 332)
        Me.PanelEx3.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx3.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx3.Style.GradientAngle = 90
        Me.PanelEx3.TabIndex = 26
        '
        'txtNatureza
        '
        Me.txtNatureza.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNatureza.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtNatureza.Border.Class = "TextBoxBorder"
        Me.txtNatureza.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNatureza.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNatureza.DisabledBackColor = System.Drawing.Color.White
        Me.txtNatureza.ForeColor = System.Drawing.Color.Black
        Me.txtNatureza.Location = New System.Drawing.Point(167, 26)
        Me.txtNatureza.MaxLength = 30
        Me.txtNatureza.Name = "txtNatureza"
        Me.txtNatureza.PreventEnterBeep = True
        Me.txtNatureza.Size = New System.Drawing.Size(325, 20)
        Me.txtNatureza.TabIndex = 14
        '
        'LabelX13
        '
        Me.LabelX13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.LabelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX13.ForeColor = System.Drawing.Color.Black
        Me.LabelX13.Location = New System.Drawing.Point(349, 52)
        Me.LabelX13.Name = "LabelX13"
        Me.LabelX13.Size = New System.Drawing.Size(75, 12)
        Me.LabelX13.TabIndex = 13
        Me.LabelX13.Text = "Estatus"
        '
        'LabelX14
        '
        '
        '
        '
        Me.LabelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX14.ForeColor = System.Drawing.Color.Black
        Me.LabelX14.Location = New System.Drawing.Point(168, 7)
        Me.LabelX14.Name = "LabelX14"
        Me.LabelX14.Size = New System.Drawing.Size(58, 17)
        Me.LabelX14.TabIndex = 12
        Me.LabelX14.Text = "Natureza"
        '
        'cboxEstatus
        '
        Me.cboxEstatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboxEstatus.DisplayMember = "Text"
        Me.cboxEstatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboxEstatus.ForeColor = System.Drawing.Color.Black
        Me.cboxEstatus.FormattingEnabled = True
        Me.cboxEstatus.ItemHeight = 14
        Me.cboxEstatus.Items.AddRange(New Object() {Me.ComboItem3, Me.ComboItem4})
        Me.cboxEstatus.Location = New System.Drawing.Point(349, 69)
        Me.cboxEstatus.Name = "cboxEstatus"
        Me.cboxEstatus.Size = New System.Drawing.Size(143, 20)
        Me.cboxEstatus.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cboxEstatus.TabIndex = 4
        '
        'ComboItem3
        '
        Me.ComboItem3.Text = "ATIVO"
        '
        'ComboItem4
        '
        Me.ComboItem4.Text = "DESABILITADO"
        '
        'txtDescricao
        '
        Me.txtDescricao.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescricao.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtDescricao.Border.Class = "TextBoxBorder"
        Me.txtDescricao.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescricao.DisabledBackColor = System.Drawing.Color.White
        Me.txtDescricao.ForeColor = System.Drawing.Color.Black
        Me.txtDescricao.Location = New System.Drawing.Point(7, 69)
        Me.txtDescricao.MaxLength = 450
        Me.txtDescricao.Multiline = True
        Me.txtDescricao.Name = "txtDescricao"
        Me.txtDescricao.PreventEnterBeep = True
        Me.txtDescricao.Size = New System.Drawing.Size(336, 55)
        Me.txtDescricao.TabIndex = 5
        '
        'LabelX16
        '
        '
        '
        '
        Me.LabelX16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX16.ForeColor = System.Drawing.Color.Black
        Me.LabelX16.Location = New System.Drawing.Point(7, 51)
        Me.LabelX16.Name = "LabelX16"
        Me.LabelX16.Size = New System.Drawing.Size(75, 15)
        Me.LabelX16.TabIndex = 6
        Me.LabelX16.Text = "Observação"
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtCodigo.Border.Class = "TextBoxBorder"
        Me.txtCodigo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigo.DisabledBackColor = System.Drawing.Color.White
        Me.txtCodigo.ForeColor = System.Drawing.Color.Black
        Me.txtCodigo.Location = New System.Drawing.Point(71, 26)
        Me.txtCodigo.MaxLength = 30
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.PreventEnterBeep = True
        Me.txtCodigo.Size = New System.Drawing.Size(90, 20)
        Me.txtCodigo.TabIndex = 2
        '
        'LabelX17
        '
        '
        '
        '
        Me.LabelX17.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX17.ForeColor = System.Drawing.Color.Black
        Me.LabelX17.Location = New System.Drawing.Point(71, 10)
        Me.LabelX17.Name = "LabelX17"
        Me.LabelX17.Size = New System.Drawing.Size(49, 12)
        Me.LabelX17.TabIndex = 4
        Me.LabelX17.Text = "Código"
        '
        'dgNaturezas
        '
        Me.dgNaturezas.AllowUserToAddRows = False
        Me.dgNaturezas.AllowUserToDeleteRows = False
        Me.dgNaturezas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgNaturezas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader
        Me.dgNaturezas.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgNaturezas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgNaturezas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgNaturezas.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgNaturezas.EnableHeadersVisualStyles = False
        Me.dgNaturezas.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.dgNaturezas.Location = New System.Drawing.Point(0, 130)
        Me.dgNaturezas.Name = "dgNaturezas"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgNaturezas.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgNaturezas.Size = New System.Drawing.Size(497, 202)
        Me.dgNaturezas.TabIndex = 7
        '
        'txtID
        '
        Me.txtID.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtID.Border.Class = "TextBoxBorder"
        Me.txtID.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtID.DisabledBackColor = System.Drawing.Color.White
        Me.txtID.ForeColor = System.Drawing.Color.Black
        Me.txtID.Location = New System.Drawing.Point(7, 26)
        Me.txtID.Name = "txtID"
        Me.txtID.PreventEnterBeep = True
        Me.txtID.ReadOnly = True
        Me.txtID.Size = New System.Drawing.Size(60, 20)
        Me.txtID.TabIndex = 1
        '
        'LabelX18
        '
        '
        '
        '
        Me.LabelX18.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX18.ForeColor = System.Drawing.Color.Black
        Me.LabelX18.Location = New System.Drawing.Point(7, 7)
        Me.LabelX18.Name = "LabelX18"
        Me.LabelX18.Size = New System.Drawing.Size(25, 12)
        Me.LabelX18.TabIndex = 0
        Me.LabelX18.Text = "ID"
        '
        'frmNaturezas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(614, 332)
        Me.Controls.Add(Me.PanelEx3)
        Me.Controls.Add(Me.PanelEx5)
        Me.DoubleBuffered = True
        Me.MinimumSize = New System.Drawing.Size(630, 370)
        Me.Name = "frmNaturezas"
        Me.Text = "Naturezas"
        Me.PanelEx5.ResumeLayout(False)
        Me.PanelEx3.ResumeLayout(False)
        CType(Me.dgNaturezas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelEx5 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents btnFechar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnGravar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnExcluir As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAlterar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnInserir As DevComponents.DotNetBar.ButtonX
    Friend WithEvents PanelEx3 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents txtNatureza As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX13 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX14 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cboxEstatus As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ComboItem3 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem4 As DevComponents.Editors.ComboItem
    Friend WithEvents txtDescricao As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX16 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtCodigo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX17 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dgNaturezas As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents txtID As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX18 As DevComponents.DotNetBar.LabelX
End Class
