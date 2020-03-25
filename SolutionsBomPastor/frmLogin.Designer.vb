<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
        Me.StyleManager1 = New DevComponents.DotNetBar.StyleManager(Me.components)
        Me.txtUsuario = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.btnEntrar = New DevComponents.DotNetBar.ButtonX()
        Me.txtSenha = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.btnSair = New DevComponents.DotNetBar.ButtonX()
        Me.lblUsuario = New DevComponents.DotNetBar.LabelX()
        Me.lblSenha = New DevComponents.DotNetBar.LabelX()
        Me.lblVersao = New DevComponents.DotNetBar.LabelX()
        Me.ReflectionImage1 = New DevComponents.DotNetBar.Controls.ReflectionImage()
        Me.SuspendLayout()
        '
        'StyleManager1
        '
        Me.StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Metro
        Me.StyleManager1.MetroColorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(154, Byte), Integer)))
        '
        'txtUsuario
        '
        Me.txtUsuario.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtUsuario.Border.Class = "TextBoxBorder"
        Me.txtUsuario.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUsuario.DisabledBackColor = System.Drawing.Color.White
        Me.txtUsuario.FocusHighlightEnabled = True
        Me.txtUsuario.ForeColor = System.Drawing.Color.Black
        Me.txtUsuario.Location = New System.Drawing.Point(340, 34)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.PreventEnterBeep = True
        Me.txtUsuario.Size = New System.Drawing.Size(155, 20)
        Me.txtUsuario.TabIndex = 0
        '
        'btnEntrar
        '
        Me.btnEntrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnEntrar.Font = New System.Drawing.Font("Consolas", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnEntrar.Location = New System.Drawing.Point(420, 86)
        Me.btnEntrar.Name = "btnEntrar"
        Me.btnEntrar.Size = New System.Drawing.Size(75, 29)
        Me.btnEntrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnEntrar.TabIndex = 3
        Me.btnEntrar.Text = "Entrar"
        '
        'txtSenha
        '
        Me.txtSenha.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtSenha.Border.Class = "TextBoxBorder"
        Me.txtSenha.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtSenha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSenha.DisabledBackColor = System.Drawing.Color.White
        Me.txtSenha.FocusHighlightEnabled = True
        Me.txtSenha.ForeColor = System.Drawing.Color.Black
        Me.txtSenha.Location = New System.Drawing.Point(340, 60)
        Me.txtSenha.Name = "txtSenha"
        Me.txtSenha.PasswordChar = Global.Microsoft.VisualBasic.ChrW(35)
        Me.txtSenha.PreventEnterBeep = True
        Me.txtSenha.Size = New System.Drawing.Size(155, 20)
        Me.txtSenha.TabIndex = 2
        '
        'btnSair
        '
        Me.btnSair.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSair.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnSair.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSair.Font = New System.Drawing.Font("Consolas", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnSair.Location = New System.Drawing.Point(340, 86)
        Me.btnSair.Name = "btnSair"
        Me.btnSair.Size = New System.Drawing.Size(75, 29)
        Me.btnSair.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnSair.TabIndex = 4
        Me.btnSair.Text = "Sair"
        '
        'lblUsuario
        '
        Me.lblUsuario.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblUsuario.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblUsuario.Font = New System.Drawing.Font("Consolas", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblUsuario.ForeColor = System.Drawing.Color.Black
        Me.lblUsuario.Location = New System.Drawing.Point(260, 34)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(74, 23)
        Me.lblUsuario.TabIndex = 5
        Me.lblUsuario.Text = "Usuário"
        '
        'lblSenha
        '
        Me.lblSenha.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblSenha.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblSenha.Font = New System.Drawing.Font("Consolas", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblSenha.ForeColor = System.Drawing.Color.Black
        Me.lblSenha.Location = New System.Drawing.Point(260, 60)
        Me.lblSenha.Name = "lblSenha"
        Me.lblSenha.Size = New System.Drawing.Size(74, 23)
        Me.lblSenha.TabIndex = 6
        Me.lblSenha.Text = "Senha"
        '
        'lblVersao
        '
        Me.lblVersao.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblVersao.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblVersao.Font = New System.Drawing.Font("Consolas", 7.75!)
        Me.lblVersao.ForeColor = System.Drawing.Color.Black
        Me.lblVersao.Location = New System.Drawing.Point(0, 138)
        Me.lblVersao.Name = "lblVersao"
        Me.lblVersao.Size = New System.Drawing.Size(500, 16)
        Me.lblVersao.TabIndex = 7
        Me.lblVersao.Text = "Versão"
        '
        'ReflectionImage1
        '
        Me.ReflectionImage1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.ReflectionImage1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionImage1.ForeColor = System.Drawing.Color.Black
        Me.ReflectionImage1.Image = CType(resources.GetObject("ReflectionImage1.Image"), System.Drawing.Image)
        Me.ReflectionImage1.Location = New System.Drawing.Point(0, 3)
        Me.ReflectionImage1.Name = "ReflectionImage1"
        Me.ReflectionImage1.Size = New System.Drawing.Size(251, 128)
        Me.ReflectionImage1.TabIndex = 8
        '
        'frmLogin
        '
        Me.AcceptButton = Me.btnEntrar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BottomLeftCornerSize = 2
        Me.BottomRightCornerSize = 2
        Me.CancelButton = Me.btnSair
        Me.ClientSize = New System.Drawing.Size(504, 152)
        Me.Controls.Add(Me.ReflectionImage1)
        Me.Controls.Add(Me.lblVersao)
        Me.Controls.Add(Me.lblSenha)
        Me.Controls.Add(Me.lblUsuario)
        Me.Controls.Add(Me.btnSair)
        Me.Controls.Add(Me.txtSenha)
        Me.Controls.Add(Me.btnEntrar)
        Me.Controls.Add(Me.txtUsuario)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(520, 190)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(520, 190)
        Me.Name = "frmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Solution's Bom Pastor"
        Me.TopLeftCornerSize = 2
        Me.TopRightCornerSize = 2
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents StyleManager1 As DevComponents.DotNetBar.StyleManager
    Friend WithEvents txtUsuario As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents btnEntrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtSenha As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents btnSair As DevComponents.DotNetBar.ButtonX
    Friend WithEvents lblUsuario As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblVersao As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblSenha As DevComponents.DotNetBar.LabelX
    Friend WithEvents ReflectionImage1 As DevComponents.DotNetBar.Controls.ReflectionImage
End Class
