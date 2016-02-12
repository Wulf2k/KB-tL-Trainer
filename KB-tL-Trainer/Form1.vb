Imports System.Runtime.InteropServices
Imports System.Threading

Public Class frmKBTL
    Private WithEvents refTimer As New System.Windows.Forms.Timer()
    Private WithEvents mouseMoveTimer As New System.Windows.Forms.Timer()
    Public Declare Function GetAsyncKeyState Lib "user32" (ByVal vKey As Integer) As Short

    Private Declare Function OpenProcess Lib "kernel32.dll" (ByVal dwDesiredAcess As UInt32, ByVal bInheritHandle As Boolean, ByVal dwProcessId As Int32) As IntPtr
    Private Declare Function ReadProcessMemory Lib "kernel32" (ByVal hProcess As IntPtr, ByVal lpBaseAddress As IntPtr, ByVal lpBuffer() As Byte, ByVal iSize As Integer, ByRef lpNumberOfBytesRead As Integer) As Boolean
    Private Declare Function WriteProcessMemory Lib "kernel32" (ByVal hProcess As IntPtr, ByVal lpBaseAddress As IntPtr, ByVal lpBuffer() As Byte, ByVal iSize As Integer, ByVal lpNumberOfBytesWritten As Integer) As Boolean
    Private Declare Function CloseHandle Lib "kernel32.dll" (ByVal hObject As IntPtr) As Boolean
    Private Declare Function VirtualAllocEx Lib "kernel32.dll" (ByVal hProcess As IntPtr, ByVal lpAddress As IntPtr, ByVal dwSize As IntPtr, ByVal flAllocationType As Integer, ByVal flProtect As Integer) As IntPtr
    Private Declare Function CreateRemoteThread Lib "kernel32" (ByVal hProcess As Integer, ByVal lpThreadAttributes As Integer, ByVal dwStackSize As Integer, ByVal lpStartAddress As Integer, ByVal lpParameter As Integer, ByVal dwCreationFlags As Integer, ByRef lpThreadId As Integer) As Integer

    Public Const PROCESS_VM_READ = &H10
    Public Const TH32CS_SNAPPROCESS = &H2
    Public Const MEM_COMMIT = 4096
    Public Const PAGE_READWRITE = 4
    Public Const PROCESS_CREATE_THREAD = (&H2)
    Public Const PROCESS_VM_OPERATION = (&H8)
    Public Const PROCESS_VM_WRITE = (&H20)
    Public Const PROCESS_ALL_ACCESS = &H1F0FFF

    Private _targetProcess As Process = Nothing 'to keep track of it. not used yet.
    Private _targetProcessHandle As IntPtr = IntPtr.Zero 'Used for ReadProcessMemory

    Dim playerXpos As Integer
    Dim playerYpos As Integer
    Dim playerZpos As Integer

    Dim charposptr As UInteger
    Dim charposdispptr As UInteger

    Dim ctrlHeld As Boolean
    Dim mouseStartXPos As Integer
    Dim mouseStartYPos As Integer
    Dim charStartXPos As Single
    Dim charStartYPos As Single
    Dim charStartZpos As Single

    Public Function TryAttachToProcess(ByVal windowCaption As String) As Boolean
        Dim _allProcesses() As Process = Process.GetProcesses
        For Each pp As Process In _allProcesses
            If pp.MainWindowTitle.ToLower.Equals(windowCaption.ToLower) Then
                'found it! proceed.
                Return TryAttachToProcess(pp)
            End If
        Next
        MessageBox.Show("Unable to find process '" & windowCaption & ".' Is running?")
        Return False
    End Function
    Public Function TryAttachToProcess(ByVal proc As Process) As Boolean
        If _targetProcessHandle = IntPtr.Zero Then 'not already attached
            _targetProcess = proc
            _targetProcessHandle = OpenProcess(PROCESS_ALL_ACCESS, False, _targetProcess.Id)
            If _targetProcessHandle = 0 Then
                TryAttachToProcess = False
                MessageBox.Show("OpenProcess() FAIL! Are you Administrator??")
            Else
                'if we get here, all connected and ready to use ReadProcessMemory()
                TryAttachToProcess = True
                'MessageBox.Show("OpenProcess() OK")
            End If
        Else
            MessageBox.Show("Already attached! (Please Detach first?)")
            TryAttachToProcess = False
        End If
    End Function
    Public Sub DetachFromProcess()
        If Not (_targetProcessHandle = IntPtr.Zero) Then
            _targetProcess = Nothing
            Try
                CloseHandle(_targetProcessHandle)
                _targetProcessHandle = IntPtr.Zero
                MessageBox.Show("MemReader::Detach() OK")
            Catch ex As Exception
                MessageBox.Show("MemoryManager::DetachFromProcess::CloseHandle error " & Environment.NewLine & ex.Message)
            End Try
        End If
    End Sub

    Public Function ReadInt16(ByVal addr As IntPtr) As Int16
        Dim _rtnBytes(1) As Byte
        ReadProcessMemory(_targetProcessHandle, addr, _rtnBytes, 2, vbNull)
        Return BitConverter.ToInt16(_rtnBytes, 0)
    End Function
    Public Function ReadInt32(ByVal addr As IntPtr) As Int32
        Dim _rtnBytes(3) As Byte
        ReadProcessMemory(_targetProcessHandle, addr, _rtnBytes, 4, vbNull)

        Return BitConverter.ToInt32(_rtnBytes, 0)
    End Function
    Public Function ReadInt64(ByVal addr As IntPtr) As Int64
        Dim _rtnBytes(7) As Byte
        ReadProcessMemory(_targetProcessHandle, addr, _rtnBytes, 8, vbNull)
        Return BitConverter.ToInt64(_rtnBytes, 0)
    End Function
    Public Function ReadUInt16(ByVal addr As IntPtr) As UInt16
        Dim _rtnBytes(1) As Byte
        ReadProcessMemory(_targetProcessHandle, addr, _rtnBytes, 2, vbNull)
        Return BitConverter.ToUInt16(_rtnBytes, 0)
    End Function
    Public Function ReadUInt32(ByVal addr As IntPtr) As UInt32
        Dim _rtnBytes(3) As Byte
        ReadProcessMemory(_targetProcessHandle, addr, _rtnBytes, 4, vbNull)
        Return BitConverter.ToUInt32(_rtnBytes, 0)
    End Function
    Public Function ReadUInt64(ByVal addr As IntPtr) As UInt64
        Dim _rtnBytes(7) As Byte
        ReadProcessMemory(_targetProcessHandle, addr, _rtnBytes, 8, vbNull)
        Return BitConverter.ToUInt64(_rtnBytes, 0)
    End Function
    Public Function ReadFloat(ByVal addr As IntPtr) As Single
        Dim _rtnBytes(3) As Byte
        ReadProcessMemory(_targetProcessHandle, addr, _rtnBytes, 4, vbNull)
        Return BitConverter.ToSingle(_rtnBytes, 0)
    End Function
    Public Function ReadDouble(ByVal addr As IntPtr) As Double
        Dim _rtnBytes(7) As Byte
        ReadProcessMemory(_targetProcessHandle, addr, _rtnBytes, 8, vbNull)
        Return BitConverter.ToDouble(_rtnBytes, 0)
    End Function
    Public Function ReadIntPtr(ByVal addr As IntPtr) As IntPtr
        Dim _rtnBytes(IntPtr.Size - 1) As Byte
        ReadProcessMemory(_targetProcessHandle, addr, _rtnBytes, IntPtr.Size, Nothing)
        If IntPtr.Size = 4 Then
            Return New IntPtr(BitConverter.ToUInt32(_rtnBytes, 0))
        Else
            Return New IntPtr(BitConverter.ToInt64(_rtnBytes, 0))
        End If
    End Function
    Public Function ReadBytes(ByVal addr As IntPtr, ByVal size As Int32) As Byte()
        Dim _rtnBytes(size - 1) As Byte
        ReadProcessMemory(_targetProcessHandle, addr, _rtnBytes, size, vbNull)
        Return _rtnBytes
    End Function

    Public Sub WriteInt32(ByVal addr As IntPtr, val As Int32)
        WriteProcessMemory(_targetProcessHandle, addr, BitConverter.GetBytes(val), 4, Nothing)
    End Sub
    Public Sub WriteUInt32(ByVal addr As IntPtr, val As UInt32)
        WriteProcessMemory(_targetProcessHandle, addr, BitConverter.GetBytes(val), 4, Nothing)
    End Sub
    Public Sub WriteFloat(ByVal addr As IntPtr, val As Single)
        WriteProcessMemory(_targetProcessHandle, addr, BitConverter.GetBytes(val), 4, Nothing)
    End Sub
    Public Sub WriteBytes(ByVal addr As IntPtr, val As Byte())
        WriteProcessMemory(_targetProcessHandle, addr, val, val.Length, Nothing)
    End Sub

    Private Sub chkMouseMove_CheckedChanged(sender As Object, e As EventArgs) Handles chkMouseMove.CheckedChanged
        If chkMouseMove.Checked Then
            mouseMoveTimer.Enabled = True
            mouseMoveTimer.Interval = 10
            mouseMoveTimer.Start()
        Else
            mouseMoveTimer.Stop()
        End If
    End Sub

    Private Sub frmKBTL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TryAttachToProcess("kingsbounty")

        refTimer = New System.Windows.Forms.Timer
        refTimer.Interval = 10
        refTimer.Enabled = True
        refTimer.Start()
    End Sub

    Private Sub refTimer_Tick() Handles refTimer.Tick
        Dim tmpptr As Integer
        charposptr = ReadInt32(ReadInt32(&H1B7BC48) + &H30)

        playerXpos = Math.Round(ReadFloat(charposptr + &H50), 0)
        playerYpos = Math.Round(ReadFloat(charposptr + &H54), 0)
        playerZpos = Math.Round(ReadFloat(charposptr + &H58), 0)

        lblXpos.Text = playerXpos
        lblYPos.Text = playerYpos
        lblZPos.Text = playerZpos

        tmpptr = ReadUInt32(&H1B7BC48)
        tmpptr = ReadUInt32(tmpptr + &H18)
        tmpptr = ReadUInt32(tmpptr + &H40)
        tmpptr = ReadUInt32(tmpptr + &H8)
        If Not txtGold.Focused Then txtGold.Text = FormatNumber(ReadInt32(tmpptr + &H1C), 0)

        tmpptr = ReadUInt32(&H1B80F7C)
        tmpptr = ReadUInt32(tmpptr + &H1C)
        tmpptr = ReadUInt32(tmpptr)
        tmpptr = ReadUInt32(tmpptr + &H50)
        tmpptr = ReadUInt32(tmpptr + &H110)
        If Not txtLeadership.Focused Then txtLeadership.Text = FormatNumber(ReadInt32(tmpptr + &H8), 0)




    End Sub

    Private Shared Sub MouseMoveTimer_Tick() Handles mouseMoveTimer.Tick
        'frmKBTL.charposdispptr = frmKBTL.ReadInt32(frmKBTL.ReadInt32(&H1B81194) + &H14)


        Dim ctrlkey As Boolean
        Dim shiftkey As Boolean
        ctrlkey = GetAsyncKeyState(Keys.ControlKey)
        shiftkey = GetAsyncKeyState(Keys.ShiftKey)

        If ctrlkey And Not frmKBTL.ctrlHeld Then
            frmKBTL.ctrlHeld = True
            frmKBTL.mouseStartXPos = MousePosition.X
            frmKBTL.mouseStartYPos = MousePosition.Y
            frmKBTL.charStartXPos = frmKBTL.playerXpos
            frmKBTL.charstartZpos = frmKBTL.playerZpos
        End If

        If shiftkey And Not frmKBTL.ctrlHeld Then
            frmKBTL.ctrlHeld = True
            frmKBTL.mouseStartYPos = MousePosition.Y
            frmKBTL.charstartYPos = frmKBTL.playerYpos
        End If

        If ctrlkey Then
            frmKBTL.WriteFloat(frmKBTL.charposptr + &H50, frmKBTL.charStartXPos + (MousePosition.X - frmKBTL.mouseStartXPos) * 0.1)
            frmKBTL.WriteFloat(frmKBTL.charposptr + &H58, frmKBTL.charstartZpos + (frmKBTL.mouseStartYPos - MousePosition.Y) * 0.1)

            'frmKBTL.WriteFloat(frmKBTL.charposdispptr + &H30, frmKBTL.charStartXPos + (MousePosition.X - frmKBTL.mouseStartXPos) * 0.1)
            'frmKBTL.WriteFloat(frmKBTL.charposdispptr + &H38, frmKBTL.charStartZpos + (frmKBTL.mouseStartYPos - MousePosition.Y) * 0.1)
        End If

        If shiftkey Then
            frmKBTL.WriteFloat(frmKBTL.charposptr + &H54, frmKBTL.charstartYPos + (frmKBTL.mouseStartYPos - MousePosition.Y) * 0.1)
            'frmKBTL.WriteFloat(frmKBTL.charposdispptr + &H34, frmKBTL.charStartYPos + (frmKBTL.mouseStartYPos - MousePosition.Y) * 0.1)
        End If

        If Not ctrlkey And Not shiftkey Then
            frmKBTL.ctrlHeld = False
        End If
    End Sub

    Private Sub txtGold_TextChanged(sender As Object, e As EventArgs) Handles txtGold.LostFocus
        Dim tmpptr As UInteger

        tmpptr = ReadUInt32(&H1B7BC48)
        tmpptr = ReadUInt32(tmpptr + &H18)
        tmpptr = ReadUInt32(tmpptr + &H40)
        tmpptr = ReadUInt32(tmpptr + &H8)

        WriteInt32(tmpptr + &H1C, txtGold.Text)
    End Sub

    Private Sub txtLeadership_TextChanged(sender As Object, e As EventArgs) Handles txtLeadership.LostFocus
        Dim tmpptr As UInteger

        tmpptr = ReadUInt32(&H1B80F7C)
        tmpptr = ReadUInt32(tmpptr + &H1C)
        tmpptr = ReadUInt32(tmpptr)
        tmpptr = ReadUInt32(tmpptr + &H50)
        tmpptr = ReadUInt32(tmpptr + &H110)

        WriteInt32(tmpptr + &H8, txtLeadership.Text)
    End Sub
End Class
