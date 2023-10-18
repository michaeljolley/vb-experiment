VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "Form1"
   ClientHeight    =   4590
   ClientLeft      =   120
   ClientTop       =   465
   ClientWidth     =   8460
   LinkTopic       =   "Form1"
   ScaleHeight     =   4590
   ScaleWidth      =   8460
   StartUpPosition =   3  'Windows Default
   Begin VB.TextBox txtAllegiance 
      Height          =   375
      Left            =   360
      TabIndex        =   5
      Top             =   2760
      Width           =   4215
   End
   Begin VB.CommandButton cmdNext 
      Caption         =   "Next"
      Height          =   615
      Left            =   6480
      TabIndex        =   2
      Top             =   3600
      Width           =   1695
   End
   Begin VB.TextBox txtName 
      Height          =   375
      Left            =   360
      TabIndex        =   1
      Top             =   1920
      Width           =   7695
   End
   Begin VB.CommandButton btnLoadData 
      Caption         =   "Load Data"
      Height          =   615
      Left            =   240
      TabIndex        =   0
      Top             =   240
      Width           =   2055
   End
   Begin VB.Label Label2 
      Caption         =   "Allegiance"
      Height          =   375
      Left            =   360
      TabIndex        =   4
      Top             =   2520
      Width           =   2055
   End
   Begin VB.Label Label1 
      Caption         =   "Name"
      Height          =   375
      Left            =   360
      TabIndex        =   3
      Top             =   1440
      Width           =   1935
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Req As WinHttp.WinHttpRequest

Dim conn As New ADODB.Connection
Dim rs As New ADODB.Recordset

Private Sub Form_Load()
    Dim exePath As String
    exePath = App.Path
        
    Dim connectionString As String
    connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & exePath & "\Database.mdb;"
    conn.Open connectionString
    
            
    ' Execute a SQL query to retrieve records for the current page
    Dim sqlQuery As String
    sqlQuery = "SELECT Id, versionName, allegiance, cardImageUrl FROM Characters"
    
    rs.Open sqlQuery, conn, adOpenStatic, adLockOptimistic
  
    LoadData
        
End Sub

Private Sub Form_Unload(Cancel As Integer)
    ' Close the database connection and release resources
    rs.Close
    conn.Close
    Set rs = Nothing
    Set conn = Nothing
End Sub

Private Sub cmdNext_Click()
    If Not rs.EOF Then
        rs.MoveNext
        LoadData
    End If
End Sub

Private Sub LoadData()
  
        txtAllegiance.Text = rs("allegiance").Value
        txtName.Text = rs("versionName").Value
    
End Sub

Private Sub btnLoadData_Click()
    
    Set Req = New WinHttp.WinHttpRequest
    
    With Req
        .Open "GET", "https://wsoiqltmfzjoqxysfilv.supabase.co/rest/v1/roster_v1", Async:=False
        .SetRequestHeader "Content-Type", "application/json"
        .SetRequestHeader "apikey", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6Indzb2lxbHRtZnpqb3F4eXNmaWx2Iiwicm9sZSI6ImFub24iLCJpYXQiOjE2OTcwNjkzODUsImV4cCI6MjAxMjY0NTM4NX0.WQS3Z_sTYHtvuuAapA12xAVhGo4qrTVFOskRuKWTGfU"
        .SetRequestHeader "Authorization", "Bearer " & "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6Indzb2lxbHRtZnpqb3F4eXNmaWx2Iiwicm9sZSI6ImFub24iLCJpYXQiOjE2OTcwNjkzODUsImV4cCI6MjAxMjY0NTM4NX0.WQS3Z_sTYHtvuuAapA12xAVhGo4qrTVFOskRuKWTGfU"
        .Send
        ParseJSON .ResponseText
    End With
            
End Sub

Private Sub ParseJSON(jsonText As String)

    Dim scriptControl As Object
    Set scriptControl = CreateObject("MSScriptControl.ScriptControl")
    scriptControl.Language = "JScript"
    
    ' Use the Eval method to parse JSON.
    Dim parsedData As Object
    Set parsedData = scriptControl.Eval("(" & jsonText & ")")
    
    ' Iterate through the parsed data.
    Dim intRecs
    intRecs = 0
    For Each obj In parsedData
      intRecs = intRecs + 1
    Next obj
    
    MsgBox "Downloaded " & intRecs & " records"
End Sub

