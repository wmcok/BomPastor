<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrincipal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrincipal))
        Me.StyleManager2 = New DevComponents.DotNetBar.StyleManager(Me.components)
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel()
        Me.ItemContainer4 = New DevComponents.DotNetBar.ItemContainer()
        Me.MetroTileItem1 = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.MetroTileItem6 = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.MetroTileItem3 = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.MetroTileItem7 = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.ItemContainer5 = New DevComponents.DotNetBar.ItemContainer()
        Me.ItemContainer1 = New DevComponents.DotNetBar.ItemContainer()
        Me.btnMenuUsuarios = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.MetroTileItem2 = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.MetroTileItem4 = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.ItemContainer3 = New DevComponents.DotNetBar.ItemContainer()
        Me.ItemContainer2 = New DevComponents.DotNetBar.ItemContainer()
        Me.MetroTileItem5 = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MenuF4ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripStatusLabel6 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.JanelasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripStatusLabel7 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblUsuario2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel8 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblGrupo2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel9 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblVersao2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel11 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.statusDATA2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SairToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StyleManager2
        '
        Me.StyleManager2.ManagerStyle = DevComponents.DotNetBar.eStyle.Metro
        Me.StyleManager2.MetroColorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(154, Byte), Integer)))
        '
        'MetroTilePanel1
        '
        Me.MetroTilePanel1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.MetroTilePanel1.BackgroundStyle.Class = "MetroTilePanel"
        Me.MetroTilePanel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MetroTilePanel1.ContainerControlProcessDialogKey = True
        Me.MetroTilePanel1.DispatchShortcuts = True
        Me.MetroTilePanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MetroTilePanel1.DragDropSupport = True
        Me.MetroTilePanel1.FitButtonsToContainerWidth = True
        Me.MetroTilePanel1.Font = New System.Drawing.Font("Consolas", 10.0!)
        Me.MetroTilePanel1.ForeColor = System.Drawing.Color.Black
        Me.MetroTilePanel1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer4, Me.ItemContainer5, Me.ItemContainer1, Me.ItemContainer3, Me.ItemContainer2})
        Me.MetroTilePanel1.ItemSpacing = 10
        Me.MetroTilePanel1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.MetroTilePanel1.Location = New System.Drawing.Point(0, 0)
        Me.MetroTilePanel1.MultiLine = True
        Me.MetroTilePanel1.Name = "MetroTilePanel1"
        Me.MetroTilePanel1.Size = New System.Drawing.Size(881, 562)
        Me.MetroTilePanel1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.MetroTilePanel1.TabIndex = 6
        Me.MetroTilePanel1.Text = "Menu Principal"
        '
        'ItemContainer4
        '
        '
        '
        '
        Me.ItemContainer4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.ItemContainer4.BackgroundStyle.CornerTypeBottomLeft = DevComponents.DotNetBar.eCornerType.Rounded
        Me.ItemContainer4.BackgroundStyle.CornerTypeBottomRight = DevComponents.DotNetBar.eCornerType.Rounded
        Me.ItemContainer4.BackgroundStyle.CornerTypeTopLeft = DevComponents.DotNetBar.eCornerType.Rounded
        Me.ItemContainer4.BackgroundStyle.CornerTypeTopRight = DevComponents.DotNetBar.eCornerType.Rounded
        Me.ItemContainer4.ItemSpacing = 5
        Me.ItemContainer4.MultiLine = True
        Me.ItemContainer4.Name = "ItemContainer4"
        Me.ItemContainer4.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.MetroTileItem1, Me.MetroTileItem6, Me.MetroTileItem3, Me.MetroTileItem7})
        '
        '
        '
        Me.ItemContainer4.TitleStyle.Class = "MetroTileGroupTitle"
        Me.ItemContainer4.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer4.TitleStyle.Font = New System.Drawing.Font("Consolas", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ItemContainer4.TitleStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.ItemContainer4.TitleStyle.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        Me.ItemContainer4.TitleText = "Controles"
        '
        'MetroTileItem1
        '
        Me.MetroTileItem1.Checked = True
        Me.MetroTileItem1.Image = CType(resources.GetObject("MetroTileItem1.Image"), System.Drawing.Image)
        Me.MetroTileItem1.ImageTextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.MetroTileItem1.Name = "MetroTileItem1"
        Me.MetroTileItem1.SymbolColor = System.Drawing.Color.Empty
        Me.MetroTileItem1.Text = "Vendas Geral"
        Me.MetroTileItem1.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.MetroTileItem1.TileSize = New System.Drawing.Size(150, 45)
        '
        '
        '
        Me.MetroTileItem1.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'MetroTileItem6
        '
        Me.MetroTileItem6.Checked = True
        Me.MetroTileItem6.Image = CType(resources.GetObject("MetroTileItem6.Image"), System.Drawing.Image)
        Me.MetroTileItem6.ImageTextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.MetroTileItem6.Name = "MetroTileItem6"
        Me.MetroTileItem6.SymbolColor = System.Drawing.Color.Empty
        Me.MetroTileItem6.Text = "Relatorios"
        Me.MetroTileItem6.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.MetroTileItem6.TileSize = New System.Drawing.Size(150, 45)
        '
        '
        '
        Me.MetroTileItem6.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'MetroTileItem3
        '
        Me.MetroTileItem3.Checked = True
        Me.MetroTileItem3.Image = CType(resources.GetObject("MetroTileItem3.Image"), System.Drawing.Image)
        Me.MetroTileItem3.ImageTextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.MetroTileItem3.Name = "MetroTileItem3"
        Me.MetroTileItem3.SymbolColor = System.Drawing.Color.Empty
        Me.MetroTileItem3.Text = "Controle Financeiro"
        Me.MetroTileItem3.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.MetroTileItem3.TileSize = New System.Drawing.Size(150, 45)
        '
        '
        '
        Me.MetroTileItem3.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'MetroTileItem7
        '
        Me.MetroTileItem7.Checked = True
        Me.MetroTileItem7.Image = CType(resources.GetObject("MetroTileItem7.Image"), System.Drawing.Image)
        Me.MetroTileItem7.ImageTextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.MetroTileItem7.Name = "MetroTileItem7"
        Me.MetroTileItem7.SymbolColor = System.Drawing.Color.Empty
        Me.MetroTileItem7.Text = "Naturezas"
        Me.MetroTileItem7.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.MetroTileItem7.TileSize = New System.Drawing.Size(150, 45)
        '
        '
        '
        Me.MetroTileItem7.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'ItemContainer5
        '
        '
        '
        '
        Me.ItemContainer5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer5.MultiLine = True
        Me.ItemContainer5.Name = "ItemContainer5"
        '
        '
        '
        Me.ItemContainer5.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'ItemContainer1
        '
        '
        '
        '
        Me.ItemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.ItemContainer1.BackgroundStyle.CornerTypeBottomLeft = DevComponents.DotNetBar.eCornerType.Rounded
        Me.ItemContainer1.BackgroundStyle.CornerTypeBottomRight = DevComponents.DotNetBar.eCornerType.Rounded
        Me.ItemContainer1.BackgroundStyle.CornerTypeTopLeft = DevComponents.DotNetBar.eCornerType.Rounded
        Me.ItemContainer1.BackgroundStyle.CornerTypeTopRight = DevComponents.DotNetBar.eCornerType.Rounded
        Me.ItemContainer1.ItemSpacing = 5
        Me.ItemContainer1.MultiLine = True
        Me.ItemContainer1.Name = "ItemContainer1"
        Me.ItemContainer1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnMenuUsuarios, Me.MetroTileItem2, Me.MetroTileItem4})
        '
        '
        '
        Me.ItemContainer1.TitleStyle.Class = "MetroTileGroupTitle"
        Me.ItemContainer1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer1.TitleStyle.Font = New System.Drawing.Font("Consolas", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ItemContainer1.TitleStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.ItemContainer1.TitleStyle.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        Me.ItemContainer1.TitleText = "Segurança"
        '
        'btnMenuUsuarios
        '
        Me.btnMenuUsuarios.Checked = True
        Me.btnMenuUsuarios.Image = CType(resources.GetObject("btnMenuUsuarios.Image"), System.Drawing.Image)
        Me.btnMenuUsuarios.ImageTextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMenuUsuarios.Name = "btnMenuUsuarios"
        Me.btnMenuUsuarios.SymbolColor = System.Drawing.Color.Empty
        Me.btnMenuUsuarios.Text = "Usuários"
        Me.btnMenuUsuarios.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.btnMenuUsuarios.TileSize = New System.Drawing.Size(150, 45)
        '
        '
        '
        Me.btnMenuUsuarios.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.btnMenuUsuarios.TitleTextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MetroTileItem2
        '
        Me.MetroTileItem2.Checked = True
        Me.MetroTileItem2.Image = CType(resources.GetObject("MetroTileItem2.Image"), System.Drawing.Image)
        Me.MetroTileItem2.ImageTextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.MetroTileItem2.Name = "MetroTileItem2"
        Me.MetroTileItem2.SymbolColor = System.Drawing.Color.Empty
        Me.MetroTileItem2.Text = "Configurações"
        Me.MetroTileItem2.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.MetroTileItem2.TileSize = New System.Drawing.Size(150, 45)
        '
        '
        '
        Me.MetroTileItem2.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'MetroTileItem4
        '
        Me.MetroTileItem4.Checked = True
        Me.MetroTileItem4.Image = CType(resources.GetObject("MetroTileItem4.Image"), System.Drawing.Image)
        Me.MetroTileItem4.ImageTextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.MetroTileItem4.Name = "MetroTileItem4"
        Me.MetroTileItem4.SymbolColor = System.Drawing.Color.Empty
        Me.MetroTileItem4.Text = "teste"
        Me.MetroTileItem4.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.MetroTileItem4.TileSize = New System.Drawing.Size(150, 45)
        '
        '
        '
        Me.MetroTileItem4.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MetroTileItem4.Visible = False
        '
        'ItemContainer3
        '
        '
        '
        '
        Me.ItemContainer3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer3.MultiLine = True
        Me.ItemContainer3.Name = "ItemContainer3"
        '
        '
        '
        Me.ItemContainer3.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'ItemContainer2
        '
        '
        '
        '
        Me.ItemContainer2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer2.MultiLine = True
        Me.ItemContainer2.Name = "ItemContainer2"
        Me.ItemContainer2.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.MetroTileItem5})
        '
        '
        '
        Me.ItemContainer2.TitleStyle.Class = "MetroTileGroupTitle"
        Me.ItemContainer2.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer2.TitleText = "Configurações"
        Me.ItemContainer2.TitleVisible = False
        '
        'MetroTileItem5
        '
        Me.MetroTileItem5.Checked = True
        Me.MetroTileItem5.Image = CType(resources.GetObject("MetroTileItem5.Image"), System.Drawing.Image)
        Me.MetroTileItem5.ImageTextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.MetroTileItem5.Name = "MetroTileItem5"
        Me.MetroTileItem5.SymbolColor = System.Drawing.Color.Empty
        Me.MetroTileItem5.Text = "SAIR"
        Me.MetroTileItem5.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.MetroTileItem5.TileSize = New System.Drawing.Size(150, 45)
        '
        '
        '
        Me.MetroTileItem5.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MetroTileItem5.TitleTextAlignment = System.Drawing.ContentAlignment.MiddleRight
        '
        'Timer1
        '
        Me.Timer1.Interval = 12000
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.White
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.MenuStrip1.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.ForeColor = System.Drawing.Color.Black
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuF4ToolStripMenuItem, Me.ToolStripStatusLabel6, Me.JanelasToolStripMenuItem, Me.ToolStripStatusLabel7, Me.lblUsuario2, Me.ToolStripStatusLabel8, Me.lblGrupo2, Me.ToolStripStatusLabel9, Me.lblVersao2, Me.ToolStripStatusLabel11, Me.statusDATA2, Me.ToolStripStatusLabel1, Me.SairToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 536)
        Me.MenuStrip1.MdiWindowListItem = Me.JanelasToolStripMenuItem
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.MenuStrip1.Size = New System.Drawing.Size(881, 26)
        Me.MenuStrip1.Stretch = False
        Me.MenuStrip1.TabIndex = 8
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MenuF4ToolStripMenuItem
        '
        Me.MenuF4ToolStripMenuItem.Name = "MenuF4ToolStripMenuItem"
        Me.MenuF4ToolStripMenuItem.Size = New System.Drawing.Size(82, 22)
        Me.MenuF4ToolStripMenuItem.Text = "&Menu (F4)"
        '
        'ToolStripStatusLabel6
        '
        Me.ToolStripStatusLabel6.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel6.Name = "ToolStripStatusLabel6"
        Me.ToolStripStatusLabel6.Size = New System.Drawing.Size(24, 17)
        Me.ToolStripStatusLabel6.Text = "   |   "
        '
        'JanelasToolStripMenuItem
        '
        Me.JanelasToolStripMenuItem.Name = "JanelasToolStripMenuItem"
        Me.JanelasToolStripMenuItem.Size = New System.Drawing.Size(75, 22)
        Me.JanelasToolStripMenuItem.Text = "&Janelas "
        '
        'ToolStripStatusLabel7
        '
        Me.ToolStripStatusLabel7.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel7.Name = "ToolStripStatusLabel7"
        Me.ToolStripStatusLabel7.Size = New System.Drawing.Size(24, 17)
        Me.ToolStripStatusLabel7.Text = "   |   "
        '
        'lblUsuario2
        '
        Me.lblUsuario2.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsuario2.Name = "lblUsuario2"
        Me.lblUsuario2.Size = New System.Drawing.Size(110, 17)
        Me.lblUsuario2.Text = "ToolStripStatusLabel1"
        '
        'ToolStripStatusLabel8
        '
        Me.ToolStripStatusLabel8.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel8.Name = "ToolStripStatusLabel8"
        Me.ToolStripStatusLabel8.Size = New System.Drawing.Size(24, 17)
        Me.ToolStripStatusLabel8.Text = "   |   "
        '
        'lblGrupo2
        '
        Me.lblGrupo2.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGrupo2.Name = "lblGrupo2"
        Me.lblGrupo2.Size = New System.Drawing.Size(110, 17)
        Me.lblGrupo2.Text = "ToolStripStatusLabel1"
        '
        'ToolStripStatusLabel9
        '
        Me.ToolStripStatusLabel9.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel9.Name = "ToolStripStatusLabel9"
        Me.ToolStripStatusLabel9.Size = New System.Drawing.Size(24, 17)
        Me.ToolStripStatusLabel9.Text = "   |   "
        '
        'lblVersao2
        '
        Me.lblVersao2.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersao2.Name = "lblVersao2"
        Me.lblVersao2.Size = New System.Drawing.Size(110, 17)
        Me.lblVersao2.Text = "ToolStripStatusLabel1"
        '
        'ToolStripStatusLabel11
        '
        Me.ToolStripStatusLabel11.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel11.Name = "ToolStripStatusLabel11"
        Me.ToolStripStatusLabel11.Size = New System.Drawing.Size(24, 17)
        Me.ToolStripStatusLabel11.Text = "   |   "
        '
        'statusDATA2
        '
        Me.statusDATA2.BackColor = System.Drawing.Color.Transparent
        Me.statusDATA2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.statusDATA2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.statusDATA2.Font = New System.Drawing.Font("Calibri", 10.25!, System.Drawing.FontStyle.Bold)
        Me.statusDATA2.Name = "statusDATA2"
        Me.statusDATA2.Size = New System.Drawing.Size(62, 17)
        Me.statusDATA2.Text = "    DATA    "
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(24, 17)
        Me.ToolStripStatusLabel1.Text = "   |   "
        '
        'SairToolStripMenuItem
        '
        Me.SairToolStripMenuItem.Name = "SairToolStripMenuItem"
        Me.SairToolStripMenuItem.Size = New System.Drawing.Size(89, 22)
        Me.SairToolStripMenuItem.Text = "&Sair (Esc)"
        '
        'frmPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BottomLeftCornerSize = 2
        Me.BottomRightCornerSize = 2
        Me.CaptionFont = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClientSize = New System.Drawing.Size(881, 562)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.MetroTilePanel1)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmPrincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Principal"
        Me.TitleText = "Solution's Bom Pastor - Principal"
        Me.TopLeftCornerSize = 2
        Me.TopRightCornerSize = 2
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StyleManager2 As DevComponents.DotNetBar.StyleManager
    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents ItemContainer1 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents btnMenuUsuarios As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents ItemContainer2 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents MetroTileItem5 As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents MetroTileItem2 As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents ItemContainer3 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents ItemContainer4 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents MetroTileItem1 As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents MetroTileItem6 As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents MetroTileItem7 As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents ItemContainer5 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents JanelasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuF4ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel6 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel7 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblUsuario2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel8 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblGrupo2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel9 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblVersao2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel11 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents statusDATA2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents SairToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MetroTileItem3 As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents MetroTileItem4 As DevComponents.DotNetBar.Metro.MetroTileItem
End Class
