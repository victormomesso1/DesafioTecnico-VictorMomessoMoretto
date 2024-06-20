VERSION 5.00
Object = "{67397AA1-7FB1-11D0-B148-00A0C922E820}#6.0#0"; "MSADODC.OCX"
Object = "{CDE57A40-8B86-11D0-B3C6-00A0C90AEA82}#1.0#0"; "MSDATGRD.OCX"
Begin VB.Form RandomAPI 
   Caption         =   "Form1"
   ClientHeight    =   8820
   ClientLeft      =   120
   ClientTop       =   465
   ClientWidth     =   11355
   LinkTopic       =   "Form1"
   ScaleHeight     =   8820
   ScaleWidth      =   11355
   StartUpPosition =   3  'Windows Default
   Begin VB.TextBox txtNome 
      Enabled         =   0   'False
      Height          =   495
      Left            =   1080
      TabIndex        =   6
      Top             =   3600
      Width           =   1215
   End
   Begin VB.TextBox txtSobrenome 
      Enabled         =   0   'False
      Height          =   495
      Left            =   2640
      TabIndex        =   5
      Top             =   3600
      Width           =   1215
   End
   Begin VB.TextBox txtEmail 
      Enabled         =   0   'False
      Height          =   495
      Left            =   4680
      TabIndex        =   4
      Top             =   3720
      Width           =   2775
   End
   Begin VB.TextBox Text2 
      Height          =   375
      Left            =   2040
      TabIndex        =   3
      Text            =   "RandomUserAPI"
      Top             =   480
      Width           =   4935
   End
   Begin VB.TextBox txtGenero 
      Enabled         =   0   'False
      Height          =   495
      Left            =   1920
      TabIndex        =   1
      Top             =   2040
      Width           =   1575
   End
   Begin VB.CommandButton ConsultarAPI 
      Caption         =   "ConsultarAPI"
      Height          =   615
      Left            =   5280
      TabIndex        =   0
      Top             =   1680
      Width           =   1455
   End
   Begin MSAdodcLib.Adodc Adodc1 
      Height          =   735
      Left            =   1080
      Top             =   4920
      Width           =   8055
      _ExtentX        =   14208
      _ExtentY        =   1296
      ConnectMode     =   0
      CursorLocation  =   3
      IsolationLevel  =   -1
      ConnectionTimeout=   15
      CommandTimeout  =   30
      CursorType      =   3
      LockType        =   3
      CommandType     =   8
      CursorOptions   =   0
      CacheSize       =   50
      MaxRecords      =   0
      BOFAction       =   0
      EOFAction       =   0
      ConnectStringType=   3
      Appearance      =   1
      BackColor       =   -2147483643
      ForeColor       =   -2147483640
      Orientation     =   0
      Enabled         =   -1
      Connect         =   "DSN=PostgreSQL30"
      OLEDBString     =   ""
      OLEDBFile       =   ""
      DataSourceName  =   "PostgreSQL30"
      OtherAttributes =   ""
      UserName        =   ""
      Password        =   ""
      RecordSource    =   "Select * from ""users"""
      Caption         =   "ConexaoPostgreSQL"
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      _Version        =   393216
   End
   Begin MSDataGridLib.DataGrid DataGrid1 
      Bindings        =   "RandomAPI.frx":0000
      Height          =   2775
      Left            =   120
      TabIndex        =   10
      Top             =   5880
      Width           =   11175
      _ExtentX        =   19711
      _ExtentY        =   4895
      _Version        =   393216
      HeadLines       =   1
      RowHeight       =   15
      BeginProperty HeadFont {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ColumnCount     =   2
      BeginProperty Column00 
         DataField       =   ""
         Caption         =   ""
         BeginProperty DataFormat {6D835690-900B-11D0-9484-00A0C91110ED} 
            Type            =   0
            Format          =   ""
            HaveTrueFalseNull=   0
            FirstDayOfWeek  =   0
            FirstWeekOfYear =   0
            LCID            =   1046
            SubFormatType   =   0
         EndProperty
      EndProperty
      BeginProperty Column01 
         DataField       =   ""
         Caption         =   ""
         BeginProperty DataFormat {6D835690-900B-11D0-9484-00A0C91110ED} 
            Type            =   0
            Format          =   ""
            HaveTrueFalseNull=   0
            FirstDayOfWeek  =   0
            FirstWeekOfYear =   0
            LCID            =   1046
            SubFormatType   =   0
         EndProperty
      EndProperty
      SplitCount      =   1
      BeginProperty Split0 
         BeginProperty Column00 
         EndProperty
         BeginProperty Column01 
         EndProperty
      EndProperty
   End
   Begin VB.Label Label6 
      Caption         =   "Name"
      Height          =   375
      Left            =   1200
      TabIndex        =   9
      Top             =   3120
      Width           =   975
   End
   Begin VB.Label Label5 
      Caption         =   "LastName"
      Height          =   495
      Left            =   2760
      TabIndex        =   8
      Top             =   3000
      Width           =   1095
   End
   Begin VB.Label Label4 
      Caption         =   "Email"
      Height          =   495
      Left            =   5280
      TabIndex        =   7
      Top             =   3120
      Width           =   1095
   End
   Begin VB.Label Label1 
      Caption         =   "Genero"
      Height          =   375
      Left            =   2160
      TabIndex        =   2
      Top             =   1560
      Width           =   1095
   End
End
Attribute VB_Name = "RandomAPI"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub ConsultarAPI_Click()
 Dim http As New MSXML2.ServerXMLHTTP60
    Dim xml As New MSXML2.DOMDocument60
    Dim dados As MSXML2.IXMLDOMNode
    
    Dim sURL As String
    sURL = "https://randomuser.me/api/?format=xml"
    
    http.open "GET", sURL
    http.send
    
    If http.Status = 200 Then
        xml.loadXML http.responseText
        
        
        If xml.parseError.errorCode <> 0 Then
            MsgBox "Erro ao carregar XML: " & xml.parseError.reason
            Exit Sub
        End If
        
        
        Set dados = xml.selectSingleNode("/user/results")
        
        If Not dados Is Nothing Then
            
            txtGenero.Text = dados.selectSingleNode("gender").Text
            txtNome.Text = dados.selectSingleNode("name/first").Text
            txtSobrenome.Text = dados.selectSingleNode("name/last").Text
            txtEmail.Text = dados.selectSingleNode("email").Text
        Else
            MsgBox "Nó de resultados não encontrado no XML."
        End If
    Else
        MsgBox "Não foi possível realizar a consulta. Código de status: " & http.Status
    End If
End Sub

Private Sub Label2_Click()

End Sub

